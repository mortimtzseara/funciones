using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int MinValue = 10;
        int MaxValue = 50;
        int num1 = 6;
        int num2 = 22;

        Console.WriteLine(IsInRange(num1, MinValue, MaxValue) ? "In range" : "Not in range");
        Console.WriteLine(IsInRange(num2, MinValue, MaxValue) ? "In range" : "Not in range");
    }
    public static bool IsInRange(int num, int minValue, int maxValue){
        return (num <= maxValue && num >= minValue);
    }
}
