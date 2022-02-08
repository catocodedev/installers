using Pastel;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
static bool IsAdministrator()
{
    var identity = WindowsIdentity.GetCurrent();
    var principal = new WindowsPrincipal(identity);
    return principal.IsInRole(WindowsBuiltInRole.Administrator);
}
Console.WriteLine("Welcome to CatoScript Dev0.1.4 Installer and modifier! Press any key to start");
Console.ReadKey();
if (File.Exists("cato.exe") == false)
{
    Console.Clear();
    Console.WriteLine("Download Options");
    string op1 = "(X)".Pastel("#ff0000");
    string op2 = "(O)".Pastel("#00ff00");
    Console.WriteLine("[1]" + op1 + "- Create default project");
    Console.WriteLine("[2]" + op2 + "- Set PATH env var");
    Console.WriteLine("Press enter to accept the options");
    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
    {
        if (Console.ReadKey(true).Key == ConsoleKey.D1)
        {
            if (op1 == "(X)".Pastel("#ff0000"))
            {
                op1 = "(O)".Pastel("#00ff00");
            }
            else
            {
                op1 = "(X)".Pastel("#ff0000");
            }
        }
        if (Console.ReadKey(true).Key == ConsoleKey.D2)
        {
            if (op2 == "(X)".Pastel("#ff0000"))
            {
                op2 = "(O)".Pastel("#00ff00");
            }
            else
            {
                op2 = "(X)".Pastel("#ff0000");
            }
        }
        Console.Clear();
        Console.WriteLine("Download Options");
        Console.WriteLine("[1]" + op1 + "- Create default project");
        Console.WriteLine("[2]" + op2 + "- Set PATH env var");
        Console.WriteLine("Press enter to accept the options");
    }
    // convert from visual to simple
    if (op1 == "(X)".Pastel("#ff0000"))
    {
        op1 = "no";
    }
    else
    {
        op1 = "yes";
    }
    if (op2 == "(X)".Pastel("#ff0000"))
    {
        op2 = "no";
    }
    else
    {
        op2 = "yes";
    }
    Console.Clear();
    Console.WriteLine("Installing CatoScript executeable . . .");
    try
    {
        WebClient myWebClient = new WebClient();
        myWebClient.DownloadFile("https://github.com/catocodedev/catoscript/releases/download/Dev0.1.4Pre2/cato.exe", "cato.exe");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    while (File.Exists("cato.exe") == false)
    {

    }
    Console.WriteLine("Installed!");
    Console.WriteLine("Preforming optional tasks . . .");
    if (op1 == "yes")
    {
        try
        {
            string runner = "cmd";
            // the /c will quit
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo(runner, "/c " + "cato.exe pur init");
            procStartInfo.RedirectStandardOutput = false;
            procStartInfo.UseShellExecute = true;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    if (op2 == "yes")
    {
        if (IsAdministrator())
        {
            Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path") + ";" + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), EnvironmentVariableTarget.User);
        }
        else
        {
            Console.WriteLine("You must be a Admin to set env vars");
        }
    }

    Console.WriteLine("CatoScript sucsessfully installed with all tasks. Press any key to close installer!");
    Console.ReadKey();
}
else
{
    Console.WriteLine("[1] - Uninstall CatoScript!");
    Console.WriteLine("[2] - Update cato script to Dev0.1.4");
    Console.ReadKey();
    Console.Clear();
    if (Console.ReadKey(true).Key == ConsoleKey.D1)
    {
        Console.WriteLine("ARE YOU SURE YOU WANT TO REMOVE CATOSCRIPT! *This will not remove the env var. Press any key to continue or exit to stop");
        Thread.Sleep(1000);
        Console.ReadKey();
        Console.WriteLine("Uninstalling CatoScript . . .");
        try
        {
            File.Delete("cato.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to uninstall catoscript!!");
        }
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine("CatoScript unstalled Sucessfully! Press any key to exit catoscript installer.");
        Console.SetCursorPosition(0, Console.CursorTop + 1);
    }
    else if (Console.ReadKey(true).Key == ConsoleKey.D2)
    {
        Console.WriteLine("Uninstalling old CatoScript . . .");
        try
        {
            File.Delete("cato.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to uninstall catoscript!!");
        }
        Console.WriteLine("Installing new version Dev0.1.4 . . .");
        try
        {
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile("https://github.com/catocodedev/catoscript/releases/download/Dev0.1.4Pre2/cato.exe", "cato.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        while (File.Exists("cato.exe") == false)
        {

        }
        Console.WriteLine("Running Cato Ver command");
        try
        {
            string runner = "cmd";
            // the /c will quit
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo(runner, "/c " + "cato.exe ver");
            procStartInfo.RedirectStandardOutput = false;
            procStartInfo.UseShellExecute = true;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.WriteLine("Catoscript Updated!");
    }
    else
    {
        Console.WriteLine("Invaild Option");
    } 
}
Console.ReadKey();
