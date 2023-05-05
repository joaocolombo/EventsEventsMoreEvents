namespace VanillaEvents;

public class BatteryEvents
{
    public void CheckLevel(object sender, CarEvent e)
    {
        if (e.BatteryLevel < 15)
        {
            Console.WriteLine("Warning Battery is low");
        }
    }
}

public class OilEvents
{
    public void CheckLevel(object sender, CarEvent e)
    {
        if (e.OilCondition < 25)
        {
            Console.WriteLine("Warning Oil Condition is bad");
        }
    }
}

public class WaterEvents
{
    public void CheckLevel(object sender, CarEvent e)
    {
        if (e.WaterLevel < 30)
        {
            Console.WriteLine("Warning Water Level is low");
        }
    }
}

public class TireEvents
{
    public void CheckLevel(object sender, CarEvent e)
    {
        if (!e.TirePressureIsGood)
        {
            Console.WriteLine("Warning Tire Pressure is low");
        }
    }
}

public class GasEvents
{
    public void CheckLevel(object sender, CarEvent e)
    {
        if (e.GasLevel <10)
        {
            Console.WriteLine("You need refuel!");
        }
        else if (e.GasLevel < 5)
        {
            Console.WriteLine("Warning! You need refuel!");
        }
        else if (e.GasLevel < 2)
        {
            Console.WriteLine("Warning! You have fuel for less than 1 KM, now refuel!");
        }
    }
}