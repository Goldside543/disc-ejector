using System;
using System.Management;

class Program
{
    static void Main()
    {
        Console.WriteLine("PC Information:");
        Console.WriteLine("-------------------------");

        // Get and display the machine name
        string machineName = Environment.MachineName;
        Console.WriteLine($"Machine Name: {machineName}");

        // Get and display the OS version
        string osVersion = Environment.OSVersion.ToString();
        Console.WriteLine($"Operating System: {osVersion}");

        // Get and display the system architecture
        string osArchitecture = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
        Console.WriteLine($"OS Architecture: {osArchitecture}");

        // Get and display the system manufacturer and model
        string manufacturer = GetSystemInfo("Win32_ComputerSystem", "Manufacturer");
        string model = GetSystemInfo("Win32_ComputerSystem", "Model");
        Console.WriteLine($"Manufacturer: {manufacturer}");
        Console.WriteLine($"Model: {model}");

        // Get and display the processor information
        string processor = GetSystemInfo("Win32_Processor", "Name");
        Console.WriteLine($"Processor: {processor}");

        // Get and display the total physical memory
        string totalPhysicalMemory = GetSystemInfo("Win32_ComputerSystem", "TotalPhysicalMemory");
        Console.WriteLine($"Total Physical Memory: {FormatBytes(Convert.ToInt64(totalPhysicalMemory))}");

        Console.WriteLine("-------------------------");
    }

    static string GetSystemInfo(string wmiClass, string wmiProperty)
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {wmiProperty} FROM {wmiClass}");
        foreach (ManagementObject obj in searcher.Get())
        {
            return obj[wmiProperty]?.ToString() ?? "N/A";
        }
        return "N/A";
    }

    static string FormatBytes(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}
