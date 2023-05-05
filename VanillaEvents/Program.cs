using VanillaEvents;

var car = CarFactory.CreateCar(oilCondition: 83,
    waterLevel: 40,
    batteryLevel: 70,
    tirePressureIsGood: true,
    gasLevel: 100);


car.Start();

for (int i = 0; i < 20; i++)
{
    Console.WriteLine($"Move{i}");
    car.Move();
    Console.WriteLine($"=========");
}


public class CarEvent : EventArgs
{
    public CarEvent(int oilCondition, int waterLevel, int batteryLevel, bool tirePressureIsGood, int gasLevel)
    {
        OilCondition = oilCondition;
        WaterLevel = waterLevel;
        BatteryLevel = batteryLevel;
        TirePressureIsGood = tirePressureIsGood;
        GasLevel = gasLevel;
    }

    public int OilCondition { get; }
    public int WaterLevel { get;  }
    public int BatteryLevel { get; }
    public bool  TirePressureIsGood { get;}
    public int  GasLevel { get; }
}

public class CarSender
{
    public string Who { get; set; }
    public DateTime When { get; set; }
    public (int,int) Where { get; set; }
}

