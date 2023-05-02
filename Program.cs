using dam_battleship.models;
using System.Diagnostics;

namespace dam_battleship;

internal static class Program
{
    private static Board? Board { get; set; }
    private static List<Team> Teams { get; } = new();

    [STAThread]
    private static void Main()
    {
        BeginGame();

        //ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
    }

    private static void BeginGame()
    {
        Board = new Board(20, 20);

        Teams.Add(new Team("Tortitas"));
        Teams.Add(new Team("John"));

        PopulateBoard(Board, Teams);

        Debug.WriteLine("Game started");
        Debug.WriteLine(Board);
    }

    private static void PopulateBoard(Board Board, List<Team> Teams)
    {
        var random = new Random();

        Teams.ForEach(team =>
        {
            Ship.DEFAULT_SHIPS.ToList().ForEach(defaultShip =>
            {
                var ship = new Ship(defaultShip.name, defaultShip.matrix);

                var position = Vector2.random(Board.width, Board.height);

                while (!Board.isPostionValidForShip(position, ship)) 
                    position = Vector2.random(Board.width, Board.height);

                ship.team = team;

                ship.position = position;

                Board.Ships.Add(ship);
            });
        });
    }

    private static bool PositionOccupied(Board board, Vector2 position)
    {
        return board.Ships.Any(ship => ship.position == position);
    }
}