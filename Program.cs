using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Give me a natural number:";

        int number;
        string input;

        do
        {
            Console.WriteLine(MsgInput);
            input = Console.ReadLine() ?? "";

        } while (!(CheckType(input, out number) && IsNatural(number)));

        Console.Write($"{number}=");

        PrimeFactor(number);
    }
    public static bool IsNatural(int number)
    {
        const string IsNotNatural = "The number must be more than 0";

        if (number < 0)
        {
            Console.WriteLine(IsNotNatural);
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool CheckType(string input, out int value)
    {
        value = 0;

        try
        {
            value = int.Parse(input);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return false;

    }
    public static bool IsPrime(int number)
    {
        for (int i = 2; i < number - 1; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    public static void PrimeFactor(int number)
    {
        int exponent;
        bool first = true;

        if (number == 1)
        {
            Console.WriteLine(number);
        }
        else
        {
            for (int i = 2; i < number+1; i++)
            {
                if (IsPrime(i))
                {
                    if (number % i == 0)
                    {
                        exponent = 0;

                        if (!first)
                        {
                            Console.Write("×");
                        }
                        else
                        {
                            first = false;
                        }
                        Console.Write($"{i}^");

                        do
                        {
                            number /= i;
                            exponent++;

                        } while (number % i == 0);

                        Console.Write($"{exponent}");
                    }
                }
            }
        }
    }
}
