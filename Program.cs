using dam_battleship.models;
using dam_battleship.utils;
using System.Diagnostics;

namespace dam_battleship;

internal static class Program
{
    private static Board? Board { get; set; }
    private static List<Team> Teams { get; } = new();

    [STAThread]
    private static void Main()
    {
        SeededRandom.SetSeed(1234);

        BeginGame();

        StartWinForms();
    }

    private static void StartWinForms()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Main());
    }

    private static void BeginGame()
    {
        Board = new Board(20, 20);

        Teams.Clear();
        Teams.Add(new Team("Tortitas"));
        Teams.Add(new Team("John"));

        Utils.PopulateBoard(Board, Teams);

        Debug.WriteLine("Game started");
        Debug.WriteLine(Board);
    }
}
