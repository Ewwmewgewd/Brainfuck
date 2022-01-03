namespace Brainfuck;

public class Program
{
    public static void Main(string[] args)
    {
        if ((args.Length < 1) || (args.Length > 2))
        {
            Console.WriteLine(
                "Usage:   Brainfuck.exe FilePath(code)    [FilePath(input)]\n" +
                "Example: Brainfuck.exe source\\code.bf    inputs.txt");
            return;
        }

        // Get code string.
        if (!File.Exists(args[0]))
        {
            Console.WriteLine($"Error: File '{args[0]}' couldn't be found.");
            return;
        }
        
        string code = File.ReadAllText(args[0]);

        // Get input string.
        string input = string.Empty;
        if (args.Length == 2)
        {
            if (!File.Exists(args[1]))
            {
                Console.WriteLine($"Error: File '{args[1]}' couldn't be found.");
                return;
            }

            input = File.ReadAllText(args[1]);
        }

        // Interpret code.
        var bf = new Brainfuck(code, input);
        Console.WriteLine(bf.GetOutput());

        // In case you are dragging & dropping files onto the .exe
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
