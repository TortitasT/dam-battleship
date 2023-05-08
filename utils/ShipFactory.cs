namespace dam_battleship.utils;

using models;

public class ShipFactory
{
    public static Ship CreateCarrier()
    {
        return new Ship("Aircraft Carrier", new[,]
            {
            { 1, 1, 1, 1 },
            { 0, 0, 0, 1 }
        });
    }

    public static Ship CreateBattleship()
    {
        return new Ship("Battleship", new[,]
            {
            { 1, 1, 1, 1 }
        });
    }

    public static Ship CreateCruiser()
    {
        return new Ship("Cruiser", new[,]
            {
            { 1, 1, 1 }
        });
    }

    public static Ship CreateSubmarine()
    {
        return new Ship("Submarine", new[,]
            {
            { 1, 1, 1 }
        });
    }

    public static Ship CreateDestroyer()
    {
        return new Ship("Destroyer", new[,]
            {
            { 1, 1 }
        });
    }
}
