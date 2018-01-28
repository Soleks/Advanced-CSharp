using System;

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
