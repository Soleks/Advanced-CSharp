using System;

namespace StarGame
{
    class Log
    {
        private event EventHandler<GameLogEventArgs> _message;

        public void WriteLogToConsole(
            string type,
            string mess, 
            EventHandler<GameLogEventArgs> message)
        {
            _message = message;         

            _message?.Invoke(this, new GameLogEventArgs($"{type}" , mess));
        }
    }
}
