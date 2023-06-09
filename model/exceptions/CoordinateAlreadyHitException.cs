using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.model.exceptions
{
    internal class CoordinateAlreadyHitException : CoordinateException
    {
        public CoordinateAlreadyHitException(Coordinate coordinate) : base(coordinate)
        {
        }

        public string GetMessage()
        {
            return "Coordinate already hit";
        }
    }
}
