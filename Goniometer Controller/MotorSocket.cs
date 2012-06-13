using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

using Com6srvr;

namespace Goniometer_Controller
{
    class MotorSocket : IDisposable
    {
        INet socket;
        
        public MotorSocket(IPAddress ipaddress)
        {
            socket = new NetClass();
            socket.Connect(ipaddress.ToString());
            socket.FSEnabled = true;

            this.Connect();
        }

        private void Connect()
        {
            string cmd = "";

            cmd += "eres8192,8192:";
            cmd += "lh0,0:";
            cmd += "scla9102,100:";
            cmd += "sclv9102,100:";
            cmd += "scld9102.2,2000:";
            cmd += "smper4,15:";
            cmd += "sgp20,1:";           //Proportional [microvolts/step]
            cmd += "sgv3,15:";           //Velocity or Derivative [microvolts/step/sec]
            cmd += "sgi,0.1:";           //Integral [microvolts/sec*sec]
            cmd += "sgilim,2:";          //Limit?

            Write(cmd);
        }

        public void Write(string cmd)
        {
            socket.Write(cmd);
            socket.Flush();
        }

        public void WriteBlocking(string cmd, short timeout)
        {
            socket.WriteBlocking(cmd, timeout);
        }

        public string Read()
        {
            return socket.Read();
        }

        public void Dispose()
        {
            //attempt to kill motors on termination
            if (socket != null)
            {
                socket.Write("!k:");
                socket = null;
            }
        }
    }
}
