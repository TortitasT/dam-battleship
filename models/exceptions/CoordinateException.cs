using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam_battleship.models.exceptions
{
    internal abstract class CoordinateException : BattleshipException
    {
        public CoordinateException(Coordinate coordinate)
        {
        }

        public string GetMessage()
        {
            return "Invalid coordinate";
        }
    }
}
