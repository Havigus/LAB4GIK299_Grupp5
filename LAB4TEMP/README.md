
https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console

public static void ClearCurrentConsoleLine()
{
int currentLineCursor = Console.CursorTop;
Console.SetCursorPosition(0, Console.CursorTop);
Console.Write(new string(' ', Console.WindowWidth));
Console.SetCursorPosition(0, currentLineCursor);
}


https://learn.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex.IsMatch?view=net-8.0

Regex^