using System;

public class Program
{
    public static void Main()
    {
        const string MsgInputNumber = "Give me a number:";
        const string MsgOutput = """
            Sum of the even numbers: {0}
            Product of the odd numbers: {1}
            Biggest number: {2}
            Smallest number: {3}
            """;

        string input;
        int number;

        do
        {
            Console.WriteLine(MsgInputNumber);
            input = Console.ReadLine() ?? "";

        } while (!(CheckType(input, out number) && IsNatural(number)));

        Console.WriteLine(MsgOutput, SumEvenPosition(number), ProductOddPosition(number), BiggestNumber(number), SmallestNumber(number));
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
    public static int SumEvenPosition(int number)
    {
        int result = 0;

        for (int i = 0; i < number.ToString().Length; i++)
        {
            if (IsEven(i+1))
            {
                result += (number.ToString()[i] - '0');
            }
        }

        return result;
    }
    public static int ProductOddPosition(int number)
    {
        int result = 1;

        for (int i = 0; i < number.ToString().Length; i++)
        {
            if (!IsEven(i+1))
            {
                result *= (number.ToString()[i] - '0');
            }
        }

        return result;
    }
    public static int BiggestNumber(int number)
    {
        int biggest = 0;
        char[] biggestNumber = number.ToString().ToCharArray();

        foreach (char num in biggestNumber)
        {
            if (num > biggest)
            {
                biggest = num;
            }
        }

        return biggest - '0';
    }
    public static int SmallestNumber(int number)
    {
        char[] smallestNumber = number.ToString().ToCharArray();
        int smallest = smallestNumber[0];

        foreach (char num in smallestNumber)
        {
            if (num < smallest)
            {
                smallest = num;
            }
        }

        return smallest - '0';
    }
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
