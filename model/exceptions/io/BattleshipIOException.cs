using BattleShip.model.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.model.exceptions.io
{
    internal class BattleshipIOException : BattleshipException
    {
        private string Message { get; }

        public BattleshipIOException(string message)
        {
            Message = message;
        }
    }
}
