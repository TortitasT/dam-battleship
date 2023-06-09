using BattleShip.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.model.exceptions
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
