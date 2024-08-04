using System;
using System.IO;
using System.Text;

class Program
{
    static string currentDirectory = "/"; // Root directory initially
    static string containerFile;

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: FileSystemSimulator <container_file> <command> [options]");
            return;
        }

        containerFile = args[0];
        string command = args[1];

        switch (command)
        {
            case "mkdir":
                CreateDirectory(args);
                break;
            case "rmdir":
                RemoveDirectory(args);
                break;
            case "ls":
                ListContents();
                break;
            case "cd":
                ChangeDirectory(args);
                break;
            case "cp":
                CopyFile(args);
                break;
            case "rm":
                RemoveFile(args);
                break;
            case "cat":
                DisplayFileContents(args);
                break;
            case "write":
                WriteToFile(args);
                break;
            default:
                Console.WriteLine("Invalid command.");
                break;
        }
        Console.Read();
    }

    static void CreateDirectory(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: mkdir <directory_name>");
            return;
        }

        string directoryName = Path.Combine(currentDirectory, args[2]);

        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
            Console.WriteLine($"Directory '{directoryName}' created.");
        }
        else
        {
            Console.WriteLine($"Directory '{directoryName}' already exists.");
        }
    }

    static void RemoveDirectory(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: rmdir <directory_name>");
            return;
        }

        string directoryName = Path.Combine(currentDirectory, args[2]);

        if (Directory.Exists(directoryName))
        {
            if (Directory.GetFileSystemEntries(directoryName).Length == 0)
            {
                Directory.Delete(directoryName);
                Console.WriteLine($"Directory '{directoryName}' removed.");
            }
            else
            {
                Console.WriteLine($"Directory '{directoryName}' is not empty. Remove its contents first.");
            }
        }
        else
        {
            Console.WriteLine($"Directory '{directoryName}' does not exist.");
        }
    }

    static void ListContents()
    {
        string[] directories = Directory.GetDirectories(currentDirectory);
        string[] files = Directory.GetFiles(currentDirectory);

        Console.WriteLine($"Contents of {currentDirectory}:");
        Console.WriteLine("Directories:");
        foreach (var dir in directories)
        {
            Console.WriteLine(Path.GetFileName(dir));
        }

        Console.WriteLine("Files:");
        foreach (var file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    static void ChangeDirectory(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: cd <directory_name>");
            return;
        }

        string newDirectory = Path.Combine(currentDirectory, args[2]);

        if (Directory.Exists(newDirectory))
        {
            currentDirectory = newDirectory;
            Console.WriteLine($"Current directory changed to '{currentDirectory}'.");
        }
        else
        {
            Console.WriteLine($"Directory '{newDirectory}' does not exist.");
        }
    }

    static void CopyFile(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: cp <source_file> <destination_file>");
            return;
        }

        string sourceFile = Path.Combine(currentDirectory, args[2]);
        string destinationFile = Path.Combine(currentDirectory, args[3]);

        if (File.Exists(sourceFile))
        {
            File.Copy(sourceFile, destinationFile, true);
            Console.WriteLine($"File '{sourceFile}' copied to '{destinationFile}'.");
        }
        else
        {
            Console.WriteLine($"File '{sourceFile}' does not exist.");
        }
    }

    static void RemoveFile(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: rm <file_name>");
            return;
        }

        string fileName = Path.Combine(currentDirectory, args[2]);

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.WriteLine($"File '{fileName}' removed.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' does not exist.");
        }
    }

    static void DisplayFileContents(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: cat <file_name>");
            return;
        }

        string fileName = Path.Combine(currentDirectory, args[2]);

        if (File.Exists(fileName))
        {
            string content = File.ReadAllText(fileName);
            Console.WriteLine($"Contents of '{fileName}':\n{content}");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' does not exist.");
        }
    }

    static void WriteToFile(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: write <file_name> <content> [+append]");
            return;
        }

        string fileName = Path.Combine(currentDirectory, args[2]);
        string content = args[3];

        bool append = args.Length > 4 && args[4] == "+append";

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, append))
            {
                writer.WriteLine(content);
            }

            Console.WriteLine($"Content written to '{fileName}' {(append ? "appended" : "overwritten")}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file '{fileName}': {ex.Message}");
        }
    }
}
