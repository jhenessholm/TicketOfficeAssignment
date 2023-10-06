


using System;
using System.Collections.Generic;
using System.Globalization;

class TicketOffice
{
    static Random random = new Random();
    static HashSet<int> usedTicketNumbers = new HashSet<int>();
    static int TicketNumberGenerator()
    {
        int ticketNumber;
        do
        {
            ticketNumber = random.Next(1, 8001);
        } while (usedTicketNumbers.Contains(ticketNumber));
        usedTicketNumbers.Add(ticketNumber);
        return ticketNumber;
    }
    static int PriceSetter(int age, string place)
    {
        int price = 0;
        if (age <= 11)
        {
            price = (place.ToLower() == "seated") ? 50 : 25;
        }
        else if (age >= 12 && age <= 64)
        {
            price = (place.ToLower() == "seated") ? 170 : 110;
        }
        else if (age >= 65)
        {
            price = (place.ToLower() == "seated") ? 100 : 60;
        }
        return price;
    }
    static decimal TaxCalculator(int price)
    {
        decimal tax = Math.Round(price * 0.06m, 2);
        return tax;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ticket Office - Calculate Ticket Price");
        Console.WriteLine("--------------------------------------");
        Console.Write("Enter your age: ");
        int age;
        if (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Invalid age input.");
            return;
        }
        Console.Write("Enter ticket type (Seated or Standing): ");
        string place = Console.ReadLine().ToLower();
        if (place != "seated" && place != "standing")
        {
            Console.WriteLine("Invalid seat type.");
            return;
        }
        int ticketPrice = PriceSetter(age, place);
        decimal tax = TaxCalculator(ticketPrice);
        int ticketNumber = TicketNumberGenerator();
        CultureInfo currency = new CultureInfo("sv-SE");
        Console.WriteLine("\nReceipt:");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Ticket Type: {place}");
        Console.WriteLine($"Ticket Price: {ticketPrice.ToString("C", currency)}");
        Console.WriteLine($"Tax (6%): {tax.ToString("C", currency)}");
        Console.WriteLine($"Total Price: {(ticketPrice + tax).ToString("C", currency)}");
        Console.WriteLine($"Ticket Number: {ticketNumber}");
    }
}

