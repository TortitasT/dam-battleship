using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam_battleship.models.exceptions.io
{
    internal class BattleshipIOException : BattleshipException
    {
        private string Message { get; }

        public BattleshipIOException(string message)
        {
            this.Message = message;
        }
    }
}
