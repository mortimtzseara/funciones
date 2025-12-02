using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Give me your DNI/NIE:";
        const string MsgOk = "The document is valid";
        const string MsgKo = "The document is not valid";

        string documentNumber;

        Console.WriteLine(MsgInput);
        documentNumber = Console.ReadLine() ?? "";

        if (IsValidDocument(documentNumber))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MsgOk);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(MsgKo);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public static bool IsValidDocument(string documentNumber)
    {
        const string RegexNIE = @"^[XYZ]\d{7}[A-Z]$";
        const string RegexDNI = @"^\d{8}[A-Z]$";

        if (Regex.IsMatch(documentNumber, RegexDNI) || Regex.IsMatch(documentNumber, RegexNIE))
            return true;

        return false;    
    }
}
