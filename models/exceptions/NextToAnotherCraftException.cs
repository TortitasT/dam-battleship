using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam_battleship.models.exceptions
{
    internal class NextToAnotherCraftException : CoordinateException
    {
        public NextToAnotherCraftException(Coordinate coordinate) : base(coordinate)
        {
        }

        public string GetMessage()
        {
            return "Next to another craft";
        }
    }
}
