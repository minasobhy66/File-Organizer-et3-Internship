
using System.Text.Json;
using System.Collections.Concurrent;
using FileOrganizer.models;
using FileOrganizer.services;
using FileOrganizer.services.FileMover;

class Program
{
    static void Main(string[] args)
    {
        RunCommandLine();



    }

    private static void RunCommandLine()
    {
        Console.WriteLine("Welcome to FileOrganizer CLI");
        Console.WriteLine("Commands:");
        Console.WriteLine("  organize <folderPath>   - Organize files in a folder");
        Console.WriteLine(" [--simulate]        - if you went to simulate add this to command");
        Console.WriteLine("  exit       - Exit the application");
        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = parts[0].ToLower();

            if (command == "organize")
            {
                if (parts.Length < 2)
                {
                    Console.WriteLine("Usage: organize <folderPath> [--simulate]");
                    continue;
                }

                string folderPath = parts[1];
                bool simulate = parts.Length > 2 && parts[2].Equals("--simulate", StringComparison.OrdinalIgnoreCase);

                RunOrganize(folderPath, simulate);
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }

    }

    private static void RunOrganize(string folderPath, bool simulate)
    {
        try
        {
            CategoryConfig? config = LoadConfig();
            var logger = new Logger();
            var scanner = new FileScanner();
            var categorizer = new FileCategorizer(config);
            var mover = FileMoverFactory.Create(simulate, logger);

            var summary = new ConcurrentDictionary<string, int>();
            var files = scanner.GetFiles(folderPath).ToList();

            Parallel.ForEach(files, file =>
            {
                string category = categorizer.GetCategory(file);
                string targetFolder = Path.Combine(folderPath, category);

                mover.MoveFile(file, targetFolder);
                summary.AddOrUpdate(category, 1, (_, count) => count + 1);
            });

            PrintSummary(summary);
            if (mover is RealFileMover realMover)
            {
                UndoCommand(realMover);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    private static CategoryConfig? LoadConfig()
    {
        string configPath = Path.Combine(AppContext.BaseDirectory, "Config", "config.json");
        var loadConfig = File.ReadAllText(configPath);
        var config = JsonSerializer.Deserialize<CategoryConfig>(loadConfig);
        return config;
    }

    private static void UndoCommand(RealFileMover realMover)
    {
        Console.WriteLine("\nPress 'U' to undo all moves or any other key to exit...");
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.U)
        {
            Console.WriteLine("\nUndoing all moves...");
            realMover.UndoAll();
            Console.WriteLine("Undo complete.");
        }
    }

    private static void PrintSummary(ConcurrentDictionary<string, int> summary)
    {
        Console.WriteLine("\nSummary:");
        foreach (var kv in summary.OrderBy(s => s.Key))
        {
            Console.WriteLine($"{kv.Key}: {kv.Value} files");
        }
    }
}
