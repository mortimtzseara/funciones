using System;

public class Program
{
    public static void Main()
    {
        const string MsgInput = "Give me a date (dd/mm/yyyy):";
        const string MsgOutputDays = "There are {0} days between these dates.";

        int[] date1Int = new int[3];
        int[] date2Int = new int[3];
        string date1, date2;

        do
        {
            Console.WriteLine(MsgInput);
            date1 = Console.ReadLine() ?? "";

        } while (!IsValidDate(date1, out date1Int));

        do
        {
            Console.WriteLine(MsgInput);
            date2 = Console.ReadLine() ?? "";

        } while (!IsValidDate(date2, out date2Int));

        DateSort(ref date1Int, ref date2Int);

        Console.WriteLine(MsgOutputDays, DaysBetweenDates(date1Int, date2Int));
    }
    public static bool IsValidDate(string dateInput, out int[] date)
    {
        const string InputDateError = "The input date is not correct";
        const string InputDateLengthError = "The date is not in a correct format";
        const int DateLength = 3;

        date = new int[DateLength];

        if (dateInput.Split('/').Length != DateLength)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(InputDateLengthError);
            Console.ForegroundColor = ConsoleColor.White;

            return false;
        }

        for (int i = 0; i < DateLength; i++)
        {
            if (!(CheckType(dateInput.Split('/')[i], out date[i]) && IsNatural(date[i])))
            {
                return false;
            }
        }

        if (date[1] > 12)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(InputDateError);
            Console.ForegroundColor = ConsoleColor.White;

            return false;
        }
        else
        {
            if (date[0] > DaysPerMonth(date[1], date[2]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(InputDateError);
                Console.ForegroundColor = ConsoleColor.White;

                return false;
            }
        }
        return true;
    }
    public static bool IsLeap(int year)
    {
        if (year % 4 == 0)
        {
            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    public static int DaysPerMonth(int month, int year)
    {
        int[] month30 = { 4, 6, 9, 11 };
        int[] month31 = { 1, 3, 5, 7, 8, 10, 12 };

        for (int i = 0; i < month30.Length; i++)
        {
            if (month30[i] == month) { return 30; }
        }
        for (int i = 0; i < month31.Length; i++)
        {
            if (month31[i] == month) { return 31; }
        }
        if (IsLeap(year)) { return 29; }

        return 28;
    }
    public static bool IsNatural(int number)
    {
        const string IsNotNatural = "The number must be more than 1";

        if (number < 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsNotNatural);
            Console.ForegroundColor = ConsoleColor.White;

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
    public static int DaysBetweenDates(int[] date1, int[] date2)
    {
        int totalDays = 0, maxMonth = 12, restart = 1;

        do
        {
            if (date1[0] == DaysPerMonth(date1[1], date1[2]))
            {
                if (date1[1] == maxMonth)
                {
                    date1[0] = restart;
                    date1[1] = restart;
                    date1[2]++;
                }
                else
                {
                    date1[0] = restart;
                    date1[1]++;
                }
            }
            else
            {
                date1[0]++;
            }

            totalDays++;

        } while (date1[0] != date2[0] || date1[1] != date2[1] || date1[2] != date2[2]);

        return totalDays;
    }
    public static void DateSort(ref int[] date1Int, ref int[] date2Int)
    {
        bool toSwap = false;
        int[] aux = new int[date1Int.Length];

        if (date1Int[2] > date2Int[2])
        {
            toSwap = true;
        }
        else if (date1Int[2] == date2Int[2])
        {
            if (date1Int[1] > date2Int[1])
            {
                toSwap = true;
            }
            else if (date1Int[1] == date2Int[1])
            {
                if (date1Int[0] > date2Int[0])
                {
                    toSwap = true;
                }
            }
        }

        if (toSwap)
        {
            aux = date1Int;
            date1Int = date2Int;
            date2Int = aux;
        }
    }
}
