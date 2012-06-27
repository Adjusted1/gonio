using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Com6srvr;
using SimpleLogger;

namespace Goniometer_Controller.Motors
{
    public class MotorSocket : IDisposable
    {
        private INet _socket;

        public MotorSocket(IPAddress ipaddress)
        {
            _socket = new NetClass();
            _socket.Connect(ipaddress.ToString());
            _socket.FSEnabled = true;
        }

        public void Write(string cmd)
        {
            try
            {
                _socket.Write(cmd);
                _socket.Flush();
            }
            finally
            {
                Logging.WriteToLog(cmd);
            }
        }

        public void Flush()
        {
            _socket.Flush();
        }

        public void WriteBlocking(string cmd, short timeout)
        {
            try
            {
                _socket.WriteBlocking(cmd, timeout);
            }
            finally
            {
                Logging.WriteToLog(cmd);
            }
        }

        public string Read()
        {
            string result = _socket.Read();

            Logging.WriteToLog(result);

            return result;
        }

        public void Dispose()
        {
            //attempt to kill motors on termination
            if (_socket != null)
            {
                string cmd = "!k:";
                _socket.Write(cmd);
                _socket = null;

                Logging.WriteToLog(cmd);
            }
        }
    }
}
