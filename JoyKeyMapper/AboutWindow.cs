using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoyKeyMapper
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            this.TitleLable.Text = ((AssemblyTitleAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false))[0]).Title;
            this.VersionLabel_dynamic.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.CopyrightLabel.Text = ((AssemblyCopyrightAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false))[0]).Copyright;
            this.LicenseBox.Text = "This application uses the following libraries:\r\n" 
                + "System.Data.SQLite, MS-PL License, https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki" + "\r\n"
                + "InputSimulatorPlus, MS-PL License, https://www.nuget.org/packages/InputSimulatorPlus/" + "\r\n"
                + "AutoClosingMessageBox, https://www.nuget.org/packages/AutoClosingMessageBox/" + "\r\n"
                + "DeepCompare, https://www.nuget.org/packages/DeepCompare/" + "\r\n"
                + "fasterflect, Apache-2.0 License, https://www.nuget.org/packages/fasterflect/" + "\r\n" + "http://www.apache.org/licenses/LICENSE-2.0" + "\r\n"
                + "SharpDX, MIT License, https://www.nuget.org/packages/SharpDX" + "\r\n\r\n"
                + "This application is published as free software under the MIT License:\r\n"
                + "MIT License\r\n\r\n"
                + "Copyright(c) 2018 Carsten Anders, https://github.com/caanders/JoyKeyMapper"+ "\r\n\r\n"
                + "Permission is hereby granted, free of charge, to any person obtaining a copy of this "
                + "software and associated documentation files(the \"Software\"), to deal in the Software "
                + "without restriction, including without limitation the rights to use, copy, modify, merge, "
                + "publish, distribute, sublicense, and/ or sell copies of the Software, and to permit persons to whom the Software is"
                + " furnished to do so, subject to the following conditions:" + "\r\n\r\n"
                + "The above copyright notice and this permission notice shall be included in all"
                + "copies or substantial portions of the Software." + "\r\n\r\n"
                + "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR"
                + "IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,"
                + "FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE"
                + "AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER"
                + "LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,"
                + "OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THESOFTWARE.";
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
