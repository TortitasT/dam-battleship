using System.Diagnostics;
using dam_battleship.models;

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

        Teams.Clear();
        Teams.Add(new Team("Tortitas"));
        Teams.Add(new Team("John"));

        PopulateBoard(Board, Teams);

        Debug.WriteLine("Game started");
        Debug.WriteLine(Board);
    }

    private static void PopulateBoard(Board board, List<Team> teams)
    {
        var random = new Random();

        teams.ForEach(team =>
        {
            Ship.DefaultShips.ToList().ForEach(defaultShip =>
            {
                var ship = new Ship(defaultShip.Name, defaultShip.Matrix);

                var position = Vector2.Random(board.Width, board.Height);

                while (!board.IsPostionValidForShip(position, ship))
                    position = Vector2.Random(board.Width, board.Height);

                ship.Team = team;

                ship.Position = position;

                board.Ships.Add(ship);
            });
        });
    }

    private static bool PositionOccupied(Board board, Vector2 position)
    {
        return board.Ships.Any(ship => ship.Position == position);
    }
}