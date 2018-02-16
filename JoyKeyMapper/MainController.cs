using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace JoyKeyMapper
{
    public static class MainController
    {

        private static RunStatus runningStatus = RunStatus.stopped;

        #region new
        private static List<Poller> myPollerList;
        private static List<Thread> PollerThreadList;
        #endregion new

        public static ActionStatus Start_stop_mapping()
        {
            switch (runningStatus)
            {
                case RunStatus.starting:
                    return ActionStatus.starting;
                case RunStatus.stopping:
                    return ActionStatus.stopping;
                case RunStatus.running:
                    return Stop_mapping();
                case RunStatus.stopped:
                    return Start_mapping();
                default:
                    return ActionStatus.Error;
            }
        }

        private static ActionStatus Start_mapping()
        {
            runningStatus = RunStatus.starting;
            DataTable configTable = ConfigController.GetConfigData(false);

            if (myPollerList == null)
                myPollerList = new List<Poller>();
            if (PollerThreadList == null)
                PollerThreadList = new List<Thread>();
            
            try
            {
                
                foreach (DataRow row in configTable.Rows) 
                {
                    DirectInput directInput = new DirectInput();
                    foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                    {
                        if (((string)deviceInstance.InstanceName).ToUpper() == (string)row[0] 
                            && row[2] != null && row[2] != System.DBNull.Value)
                        {
                            Poller tempPoller = new Poller(directInput, deviceInstance.InstanceGuid)
                            {
                                Button = (string)row[1],
                                Bindings = (string)row[2]
                            };
                            tempPoller.Acquire();
                            myPollerList.Add(tempPoller);
                        }
                    }

                    foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.FirstPerson, DeviceEnumerationFlags.AllDevices))
                    {
                        if (((string)deviceInstance.InstanceName).ToUpper() == (string)row[0]
                            && row[2] != null && row[2] != System.DBNull.Value)
                        {
                            Poller tempPoller = new Poller(directInput, deviceInstance.InstanceGuid)
                            {
                                Button = (string)row[1],
                                Bindings = (string)row[2]
                            };
                            tempPoller.Acquire();
                            myPollerList.Add(tempPoller);
                        }
                    }
                }

                foreach (Poller poller in myPollerList)
                {
                    if (poller.DirectInput != null && poller.InstanceGuid != null)
                    {
                        poller.Poll = true;
                        Thread pollerThread = new Thread(new ThreadStart(poller.StartPolling));
                        PollerThreadList.Add(pollerThread);
                        pollerThread.Start();
                    }
                }
            }
            catch (Exception)
            {
                runningStatus = RunStatus.stopped;
                return ActionStatus.startingError;
            }
            runningStatus = RunStatus.running;
            return ActionStatus.running;
        }

        internal static void StopOnClose()
        {
            Stop_mapping();
        }

        private static ActionStatus Stop_mapping()
        {
            runningStatus = RunStatus.stopping;

            try
            {
                foreach (Poller poller in myPollerList)
                {
                    poller.Poll = false;
                }

                foreach (Thread pollerThread in PollerThreadList)
                {
                    if (pollerThread.IsAlive)
                    {
                        pollerThread.Join();
                    }
                }
                foreach (Poller poller in myPollerList)
                {
                    poller.Unaquire();
                }
                PollerThreadList.Clear();
                myPollerList.Clear();
            }
            catch (Exception)
            {
                runningStatus = RunStatus.running;
                return ActionStatus.stoppingError;
            }
            runningStatus = RunStatus.stopped;
            return ActionStatus.stopped;

        }

        internal static void Start_stop_mapping(bool configChanged)
        {
            if (runningStatus == RunStatus.running)
            {
                //stop
                Start_stop_mapping();
                //start
                Start_stop_mapping();
            }
        }
    }
}
