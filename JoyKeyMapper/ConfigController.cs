using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Linq;

namespace JoyKeyMapper
{
    public static class ConfigController
    {
        private static List<Poller> pollerList;
        private static DataTable ConfigData;
        public static bool Poll { get; set; }
        

        internal static System.Data.DataTable GetConfigData(bool loadFromDatabase)
        {
            if (loadFromDatabase)
            {
                ConfigData = null;
            }

            if (ConfigData == null)
            {
                ConfigData = new System.Data.DataTable();
                ConfigData.Load(LoadConfig());
            }

            return ConfigData;
        }

        internal static void CancelChanges()
        {
            ConfigData.RejectChanges();

        }

        private static IDataReader LoadConfig()
        {
            DataTable configTable = new DataTable();

            if(!File.Exists(@".\config.db"))
            {
                CreateConfigDB();
            }

            using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=.\config.db;Version=3;"))
            {
                using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter("WITH ungrouped as"
                                                                                        + " (SELECT DEVICES.name as DEVICE, BUTTONS.name as BUTTON, keyname as KEY"
                                                                                        + " from DEVICES"
                                                                                        + " left join BUTTONS on DEVICES.id = BUTTONS.device_id"
                                                                                        + " left join KEYBINDINGS on buttons.id = keybindings.button_id"
                                                                                        + " ORDER BY KEYBINDINGS.order_id asc)"
                                                                                    + " SELECT DEVICE, BUTTON, group_concat(KEY, \" + \") as KEYS"
                                                                                    + " from ungrouped "
                                                                                    + " group by DEVICE, BUTTON"
                                                                                    , connection))
                {
                    sQLiteDataAdapter.Fill(configTable);

                    return configTable.CreateDataReader();
                }
            }
            
        }

        private static void CreateConfigDB()
        {
            SQLiteConnection.CreateFile(@".\config.db");
            string sql;
            SQLiteCommand command;

            SQLiteConnection m_dbConnection = new SQLiteConnection(@"Data Source=.\config.db;Version=3;");
            m_dbConnection.Open();

            sql = "create table DEVICES (id integer primary key on conflict abort autoincrement, name varchar(50) unique on conflict abort not null)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table BUTTONS (id integer primary key on conflict abort autoincrement, name varchar(20) not null, device_id int not null references DEVICES(id), UNIQUE(name,device_id))";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table KEYBINDINGS (id integer primary key on conflict abort autoincrement, button_id int not null references BUTTONS(id), order_id int not null, keyname varchar(20) not null, UNIQUE(button_id,order_id), UNIQUE(button_id,keyname))";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        internal static bool SaveChanges()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\config.db;Version=3;");
            conn.Open();
            SQLiteTransaction Transaction = conn.BeginTransaction();
            SQLiteCommand comm = new SQLiteCommand(conn)
            {
                CommandType = CommandType.Text,
                Transaction = Transaction
            };

            try
            {
                DataTable addedRows = ConfigData.GetChanges(DataRowState.Added);
                DataTable deletedRows = ConfigData.GetChanges(DataRowState.Deleted);
                DataTable changedRows = ConfigData.GetChanges(DataRowState.Modified);

                if (addedRows != null)
                {
                    SaveAddedRows(addedRows, comm);
                }

                if (deletedRows != null)
                {
                    RemoveDeletedRows(deletedRows, comm);
                }

                if (changedRows != null)
                {
                    UpdateChangedRows(changedRows, comm);
                }

                Transaction.Commit();
                conn.Close();

                ConfigData.AcceptChanges();
                return true;
            }
#pragma warning disable CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
            catch (Exception e)
#pragma warning restore CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
            {
                Transaction.Rollback();
                conn.Close();
                ConfigData.RejectChanges();
                return false;
            }
        }

        internal static bool DeleteSelectedRows(List<DataRow> selectedRows)
        {
            foreach (DataRow row in selectedRows)
            {
                row.Delete();
            }
            return true; ;
        }

        private static void UpdateChangedRows(DataTable changedRows, SQLiteCommand comm)
        {
            try
            {
                foreach (DataRow row in changedRows.Rows)
                {
                    object device = row[0];
                    object button = row[1];
                    object bindings_new = row[2];
                    object bindings_old = row[2,DataRowVersion.Original];

                    if (device != null && device != System.DBNull.Value && (string)device != ""
                        && button != null && button != System.DBNull.Value && (string)button != "")
                    {
                        // Bindings
                        if (bindings_new != null && bindings_new != System.DBNull.Value && (string)bindings_new != ""
                            && bindings_old != null && bindings_old != System.DBNull.Value && (string)bindings_old != "")
                        {
                            string bindings_old_str = (string)bindings_old;
                            string[] singleBindings = bindings_old_str.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < singleBindings.Length; i++)
                            {
                                string binding = singleBindings[i].Trim();
                                comm.CommandText = "DELETE FROM keybindings WHERE keyname = '" + binding + "'"
                                                 + " AND button_id="
                                                 + "(select id from buttons where name='" + (string)button + "' "
                                                                           + "and device_id=(select id from devices where name = '" + (string)device + "'"
                                                                                         + ")"
                                                 + ")";
                                comm.ExecuteNonQuery();
                            }

                            string bindings_new_str = (string)bindings_new;
                            singleBindings = bindings_new_str.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < singleBindings.Length; i++)
                            {
                                string binding = singleBindings[i].Trim();
                                comm.CommandText = "INSERT OR IGNORE INTO KEYBINDINGS (keyname,order_id,button_id) VALUES "
                                                 + "("
                                                 + "'" + binding + "'"
                                                 + "," + (i + 1).ToString() + ","
                                                 + "(select id from buttons where name='" + (string)button + "' "
                                                                           + "and device_id=(select id from devices where name = '" + (string)device + "'"
                                                                                         + ")"
                                                 + ")"
                                                 + ")";
                                comm.ExecuteNonQuery();
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void RemoveDeletedRows(DataTable deletedRows, SQLiteCommand comm)
        {

            try
            {
                foreach (DataRow row in deletedRows.Rows)
                {
                    object device = row[0, DataRowVersion.Original];
                    object button = row[1, DataRowVersion.Original];
                    object bindings = row[2, DataRowVersion.Original];

                    if (device != null && device != System.DBNull.Value && (string)device != ""
                        && button != null && button != System.DBNull.Value && (string)button != "")
                    {
                        // Bindings
                        if (bindings != null && bindings != System.DBNull.Value && (string)bindings != "")
                        {
                            string bindings_str = (string)bindings;
                            string[] singleBindings = bindings_str.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < singleBindings.Length; i++)
                            {
                                string binding = singleBindings[i].Trim();
                                comm.CommandText = "DELETE FROM keybindings WHERE keyname = '" + binding + "'"
                                                 + " AND button_id="
                                                 + "(select id from buttons where name='" + (string)button + "' "
                                                                           + "and device_id=(select id from devices where name = '" + (string)device + "'"
                                                                                         + ")"
                                                 + ")";
                                comm.ExecuteNonQuery();
                            }
                        }

                        // Buttons
                        comm.CommandText = "DELETE FROM buttons where name='" + (string)button + "'"
                                         + "AND  device_id="
                                         + "(select id from devices where name = '" + (string)device + "')";
                        comm.ExecuteNonQuery();

                        // Devices
                        comm.CommandText = "DELETE FROM devices WHERE name='" + (string)device + "'"
                                         + " AND (select count(*) from buttons where device_id=devices.id)=0";
                        comm.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void SaveAddedRows(DataTable addedRows, SQLiteCommand comm)
        {
            try
            {
                foreach (DataRow row in addedRows.Rows)
                {
                    object[] columns = row.ItemArray;
                    // Devices
                    if (columns[0] != null && columns[0] != System.DBNull.Value && (string)columns[0] != "")
                    {
                        comm.CommandText = "INSERT OR IGNORE INTO DEVICES (name) VALUES ('" + (string)columns[0] + "')";
                        comm.ExecuteNonQuery();
                    }
                    // Buttons
                    if (columns[1] != null && columns[1] != System.DBNull.Value && (string)columns[1] != "")
                    {
                        comm.CommandText = "INSERT OR IGNORE INTO Buttons (name,device_id) VALUES ('" + (string)columns[1] + "',"
                                         + "(select id from devices where name = '" + (string)columns[0] + "'))";
                        comm.ExecuteNonQuery();
                    }

                    // Bindings
                    if (columns[2] != null && columns[2] != System.DBNull.Value && (string)columns[2] != "")
                    {
                        string bindings = (string)columns[2];
                        string[] singleBindings = bindings.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < singleBindings.Length; i++)
                        {
                            string binding = singleBindings[i].Trim();
                            comm.CommandText = "INSERT OR IGNORE INTO KEYBINDINGS (keyname,order_id,button_id) VALUES "
                                             + "("
                                             + "'" + binding + "'"
                                             + "," + (i + 1).ToString() + ","
                                             + "(select id from buttons where name='" + (string)columns[1] + "' "
                                                                       + "and device_id=(select id from devices where name = '" + (string)columns[0] + "'"
                                                                                     + ")"
                                             + ")"
                                             + ")";
                            comm.ExecuteNonQuery();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal static void ModifyKeysOnRows(List<int> keys, List<DataRow> rowList)
        {
            string keyNames = "";

            for (int i = 0; i < keys.Count; i++)
            {
                //get key names of keys
                object enumKey = System.Enum.Parse(typeof(WindowsInput.Native.VirtualKeyCode), keys[i].ToString());
                string keyName = enumKey.ToString();
                keyNames += keyName + " + ";
            }

            if (keyNames != "")
            {
                keyNames = keyNames.Substring(0, keyNames.Length - 3);
            }

            foreach (DataRow row in rowList)
            {
                //insert names into Cell
                object[] tmp = row.ItemArray;
                tmp[2] = keyNames;
                row.ItemArray = tmp;
            }
        }

        public static List<string[]> GetChanges()
        {
            List<string[]> buttonList = new List<string[]>();
            AquireAll();

            while (Poll)
            {
                Thread.Sleep(10);
                foreach (Poller p in pollerList)
                {
                    List<string[]> buttons = p.PollOnce();
                    buttonList.AddRange(buttons);
                }
            }
            UnaquireAll();

            buttonList = UniqueEntries(buttonList);

            foreach (string[] button in buttonList)
            {
                bool entryExists = false;
                foreach (DataRow row in ConfigData.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string device_old = (string)row[0, DataRowVersion.Original];
                        string button_old = (string)row[1, DataRowVersion.Original];

                        if (device_old.ToUpper() == button[0] && button_old.ToUpper() == button[1])
                        {
                            entryExists = true;
                            row.RejectChanges();
                        }
                    }
                    else
                    {
                        string rowdevice = (string)row[0];
                        string rowbutton = (string)row[1];
                        if (rowdevice.ToUpper() == button[0] && rowbutton.ToUpper() == button[1])
                        {
                            entryExists = true;
                        }
                    }
                }

                if (!entryExists)
                {
                    DataRow tmp = ConfigData.NewRow();
                    tmp[0] = button[0];
                    tmp[1] = button[1];
                    tmp[2] = System.DBNull.Value;
                    ConfigData.Rows.Add(tmp);
                }
            }

            return buttonList;
        }

        private static List<string[]> UniqueEntries(List<string[]> buttonList)
        {
            return buttonList.Distinct<string[]>(new StringArrayComparer<string[]>()).ToList<string[]>();
        }

        private static void UnaquireAll()
        {
            foreach (Poller p in pollerList)
            {
                p.Unaquire();
            }
        }

        private static void AquireAll()
        {
            pollerList = Poller.RegisterOnAllDevices();
            foreach (Poller p in pollerList)
            {
                p.Acquire();
            }
        }

    }
}
