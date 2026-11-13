using System;

static class Desire
{
    public static int desireNumber = 0;
    public static string[] desires = 
    {
        "Хочу нове корито",
        "Хочу нову хату",
        "Хочу бути володаркою морською"
    };
    public static string[] grandmotherStatus =
    {
        "Бабуся отримала нове корито",
        "Бабуся живе в новій хаті",
        "Бабуся залишилася з розбитим коритом"
    };
}
delegate void MyDelegate();
class Gold
{
    public event MyDelegate MyEvent;
    public void EventHandler()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Це бажання не може бути виконане");
        Console.ResetColor();
    }
    public void ExecuteDesire()
    {
        if (Desire.desireNumber == 2)
        {
            MyEvent?.Invoke();
        }
        else
        {
            Console.WriteLine("Бажання успішно виконано");
        }
    }
}
class Grandfather
{
    public void EventHandler()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Дід боїться. Бажання не виконано");
        Console.ResetColor();
    }
    public void GiveDesire(Gold gold)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Дід передає бажання: " + Desire.desires[Desire.desireNumber]);
        Console.ResetColor();

        gold.ExecuteDesire();
    }
}
class Grandmother
{
    public void EventHandler()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Бабка залишилася з розбитим коритом");
        Console.ResetColor();
    }
    public void ChangeStatus()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Desire.grandmotherStatus[Desire.desireNumber]);
        Console.ResetColor();
    }
}

class Program
{
    static void Main()
    {
        Gold gold = new Gold();
        Grandfather grandfather = new Grandfather();
        Grandmother grandmother = new Grandmother();

        gold.MyEvent += gold.EventHandler;
        gold.MyEvent += grandfather.EventHandler;
        gold.MyEvent += grandmother.EventHandler;

        for (Desire.desireNumber = 0;
             Desire.desireNumber < Desire.desires.Length;
             Desire.desireNumber++)
        {
            Console.WriteLine("\n--- Бажання №" + (Desire.desireNumber + 1) + " ---");

            grandfather.GiveDesire(gold);

            if (Desire.desireNumber != 2)
            {
                grandmother.ChangeStatus();
            }
        }
    }
}