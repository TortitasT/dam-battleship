using dam_battleship.models;

namespace dam_battleship.utils
{
    public class Utils
    {
        public static void PopulateBoard(Board board, List<Team> teams)
        {
            var defaultShips = new List<Ship>(){
                    ShipFactory.CreateCarrier(),
                    ShipFactory.CreateBattleship(),
                    ShipFactory.CreateCruiser(),
                    ShipFactory.CreateSubmarine(),
                    ShipFactory.CreateDestroyer(),
                };

            teams.ForEach(team =>
            {
                defaultShips.ToList().ForEach(defaultShip =>
                {
                    var ship = new Ship(defaultShip.Name, defaultShip.Matrix);

                    var position = Vector2.Random(board.Width, board.Height);

                    while (!board.IsPositionValidForShip(position, ship))
                        position = Vector2.Random(board.Width, board.Height);

                    ship.Team = team;

                    ship.Position = position;

                    board.Ships.Add(ship);
                });
            });
        }
    }
}
