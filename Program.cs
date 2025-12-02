using System;

public class Program
{
    public static void Main()
    {
        const string MsgInputHour = "Give me the hours:";
        const string MsgInputMinutes = "Give me the minutes";
        const string MsgOutputPrice = "The total price for your stay is";

        decimal hours, minutes, price;
        string input;

        do
        {
            Console.WriteLine(MsgInputHour);
            input = Console.ReadLine() ?? "";

        } while (!(CheckType(input, out hours) && IsNatural(hours)));

        do
        {
            Console.WriteLine(MsgInputMinutes);
            input = Console.ReadLine() ?? "";

        } while (!(CheckType(input, out minutes) && CheckValidMinutes(minutes) && IsNatural(minutes)));

        price = ParkingPrice(hours, minutes);

        Console.WriteLine($"{MsgOutputPrice} {price:0.00}€");
    }
    public static bool IsNatural(decimal number)
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
    public static bool CheckValidMinutes(decimal minutes)
    {
        return minutes < 60;
    }
    public static bool CheckType(string input, out decimal value)
    {
        value = 0;

        try
        {
            value = decimal.Parse(input);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return false;

    }
    public static decimal ParkingPrice(decimal hours, decimal minutes)
    {
        decimal priceFee;

        minutes /= 60;
        hours += minutes;
               
        if (hours <= 1)
        {
            priceFee = 3.5m;
        }
        else if (hours > 1 && hours <= 5)
        {
            priceFee = 2m;
        }
        else
        {
            priceFee = 1.5m;
        }
                
        return priceFee*hours;
    }
}
