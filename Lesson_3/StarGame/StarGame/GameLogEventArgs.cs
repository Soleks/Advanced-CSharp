using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGame
{
    class GameLogEventArgs : EventArgs
    {
        public string Message
        {
            get;
        }

        public string Type
        {
            get;
        }

        public GameLogEventArgs (string type, string message)
        {
            Message = message;
            Type = type;
        }    }
}
