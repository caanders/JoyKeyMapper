using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace JoyKeyMapper
{
    public class Poller
    {
        public DirectInput DirectInput { get; set; }
        public Guid InstanceGuid { get; set; }
        public int BufferSize { get; set; }
        private bool initialized = false;
        private Joystick joystick;
        public string Button { get; set; }
        public string Bindings { get; set; }

        private volatile bool poll;

        public bool Poll
        {
            get { return this.poll; }
            set { this.poll = value; }
        }

        public Poller(DirectInput directInput, Guid instanceGuid)
        {
            this.DirectInput = directInput;
            this.InstanceGuid = instanceGuid;
            this.BufferSize = 128;
            this.initialized = true;
        }

        public static List<Poller> RegisterOnAllDevices()
        {
            List<Poller> pollerList = new List<Poller>();

            DirectInput directInput = new DirectInput();

            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
            {
                pollerList.Add(new Poller(directInput, deviceInstance.InstanceGuid));
            }
            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.FirstPerson, DeviceEnumerationFlags.AllDevices))
            {
                pollerList.Add(new Poller(directInput, deviceInstance.InstanceGuid));
            }
            return pollerList;
        }

        public void Acquire()
        {
            this.joystick = new Joystick(this.DirectInput, this.InstanceGuid);
            joystick.Properties.BufferSize = this.BufferSize;
            joystick.Acquire();
        }

        public void StartPolling()
        {
            try
            {
                InputSimulator inputTest = new InputSimulator();
                while (this.Poll)
                {
                    Thread.Sleep(10);
                    this.joystick.Poll();
                    JoystickUpdate[] datas = this.joystick.GetBufferedData();

                    if (datas.Length > 0)
                    {
                        foreach (JoystickUpdate data in datas)
                        {
                            string test = data.Offset.ToString().ToUpper();
                            if (data.Offset.ToString().ToUpper() == Button)
                            {
                                string[] singleBindings = Bindings.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < singleBindings.Length; i++)
                                {
                                    VirtualKeyCode enumKey = (VirtualKeyCode)System.Enum.Parse(typeof(VirtualKeyCode), singleBindings[i].Trim());
                                    if (data.Value >= 128)
                                    {
                                        inputTest.Keyboard.KeyDown(enumKey);
                                    }
                                    else
                                    {
                                        inputTest.Keyboard.KeyUp(enumKey);
                                    }
                                }
                            }
                        }
                    }
                }
            }
#pragma warning disable CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
            catch (Exception e)
#pragma warning restore CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
            { }
        }

        public void Unaquire()
        {
            this.joystick.Unacquire();
        }

        public List<string[]> PollOnce()
        {
            List<string[]> buttonList = new List<string[]>();
            if (this.initialized)
            {
                this.joystick.Poll();
                JoystickUpdate[] changes = joystick.GetBufferedData();

                if (changes.Length > 0)
                {
                    foreach (JoystickUpdate change in changes)
                    {
                        if (change.Offset.ToString().ToUpper().Contains("BUTTON"))
                        {
                            if (change.Value >= 128)
                            {
                                //Button pressed
                                string[] temp = new string[2];
                                temp[0] = joystick.Information.InstanceName.ToUpper();
                                temp[1] = change.Offset.ToString().ToUpper();
                                buttonList.Add(temp);
                            }
                        }
                    }
                }
            }
            return buttonList;
        }
    }
}
