using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        const string MsgTemperatureInput = "Insert a decimal temperature";
        const string MsgConversionType = "What kind of conversion do you want?";
        const string MsgCelsiusToFahrenheit = "1. Celsius to Fahrenheit";
        const string MsgFahrenheitToCelsius = "2. Fahrenheit to Celsius";
        const string MsgCelsiusToKelvin = "3. Celsius to Kelvin";
        const int MinOp = 1;
        const int MaxOp = 3;
        const int MaxAttempts = 3;

        string input;
        double value, temperature, convertedTemperature;
        int op, attempts = 0;

        do
        {
            Console.WriteLine(MsgTemperatureInput);
            input = Console.ReadLine() ?? "";

        } while (!(CheckType(input, out value) || string.IsNullOrEmpty(input)));

        temperature = value;

        do
        {

            Console.WriteLine(MsgConversionType);
            Console.WriteLine(MsgCelsiusToFahrenheit);
            Console.WriteLine(MsgFahrenheitToCelsius);
            Console.WriteLine(MsgCelsiusToKelvin);
            input = Console.ReadLine() ?? "";

            attempts++;

        } while (!((CheckType(input, out op) && IsValidOption(op, MinOp, MaxOp)) || !Attempts(ref attempts, MaxAttempts)));

        switch (op)
        {
            case 1:

                CelsiusToFahrenheit(temperature, out convertedTemperature);

                break;
            case 2:

                FahrenheitToCelsius(temperature, out convertedTemperature);

                break;
            case 3:

                CelsiusToKelvin(temperature, out convertedTemperature);

                break;
            default:

                convertedTemperature = -1;
                break;
        }

            Console.WriteLine($"{convertedTemperature:0.00}");

    }
    public static bool IsValidOption(int num, int min = 0, int max = 0)
    {
        const string InputError = "Error, not a valid option";

        if (num >= min && num <= max) return true;
        else
        {
            Console.WriteLine(InputError);
            return false;
        }
    }
    public static bool CheckType(string input, out double value)
    {
        value = 0.0;

        try
        {
            value = double.Parse(input);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return false;

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
    public static double CelsiusToFahrenheit(double celsius, out double convertedTemperature)
    {
        convertedTemperature = celsius * 9 / 5 + 32;
        return convertedTemperature;
    }
    public static double FahrenheitToCelsius(double fahrenheit, out double convertedTemperature)
    {
        convertedTemperature = (fahrenheit - 32) * 5 / 9;
        return convertedTemperature;
    }
    public static double CelsiusToKelvin(double celsius, out double convertedTemperature)
    {
        convertedTemperature = celsius + 273.15;
        return convertedTemperature;
    }
    public static bool Attempts(ref int attempts, int max)
    {
        const string ErrorTries = "You used {0} tries";

        if (attempts < max)
        {
            return true;
        }
        else
        {
            Console.WriteLine(ErrorTries, max);
            return false;
        }
    }
}
