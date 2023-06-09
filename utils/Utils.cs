using BattleShip.model;

namespace BattleShip.utils;

public class Utils
{
    public static void PopulateBoard(Board board, List<Team> teams)
    {
        /*        var defaultShips = new List<Ship>
                {
                    ShipFactory.CreateCarrier(),
                    ShipFactory.CreateBattleship(),
                    ShipFactory.CreateCruiser(),
                    ShipFactory.CreateSubmarine(),
                    ShipFactory.CreateDestroyer()
                };*/

        /*        teams.ForEach(
                    team =>
                    {
                        defaultShips.ToList().ForEach(
                            defaultShip =>
                            {
                                Ship ship = new Ship(defaultShip.Name, defaultShip.Matrix);

                                Coordinate position = Coordinate.Random(board.Width, board.Height);

                                while (!board.IsPositionValidForShip(position, ship))
                                    position = Coordinate.Random(board.Width, board.Height);

                                ship.Team = team;

                                ship.Position = position;

                                board.Ships.Add(ship);
                            }
                        );
                    }
                );*/
    }
}