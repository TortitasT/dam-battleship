using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam_battleship.models.exceptions
{
    internal class OccupiedCoordinateException : CoordinateException
    {
        public OccupiedCoordinateException(Coordinate coordinate) : base(coordinate)
        {
        }

        public string GetMessage()
        {
            return "Coordinate already occupied";
        }
    }
}
