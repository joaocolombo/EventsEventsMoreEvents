namespace VanillaEvents;

public class Car
{
    public Car(IEnumerable<EventHandler<CarEvent>> startEngine, int oilCondition, int waterLevel, int batteryLevel, bool tirePressureIsGood, int gasLevel)
    {
        OilCondition = oilCondition;
        WaterLevel = waterLevel;
        BatteryLevel = batteryLevel;
        TirePressureIsGood = tirePressureIsGood;
        GasLevel = gasLevel;
        foreach (var eventHandler in startEngine)
        {
            CheckEvents += eventHandler;
        }
    }
    private EventHandler<CarEvent> CheckEvents { get; }


    public int OilCondition { get; private set; }
    public int WaterLevel { get; private set; }
    public int BatteryLevel { get; private set; }
    public bool TirePressureIsGood { get; private set; }
    public int GasLevel { get; private set; }

    public void Start()
    {
        CheckCar();
    }

    public void Move()
    {
        OilCondition -= 2;
        WaterLevel -= 1;
        BatteryLevel -= 1;
        GasLevel -= 5;
        CheckCar();
    }

    private void CheckCar()
    {
        var carEvent = new CarEvent(OilCondition, WaterLevel, BatteryLevel, TirePressureIsGood, GasLevel);
        CheckEvents.Invoke(null, carEvent);
    }
}

public static class CarFactory
{
    public static Car CreateCar(int oilCondition, int waterLevel, int batteryLevel, bool tirePressureIsGood, int gasLevel)
    {

        List<EventHandler<CarEvent>> events = new()
        {
            new TireEvents().CheckLevel!,
            new BatteryEvents().CheckLevel!,
            new WaterEvents().CheckLevel!,
            new OilEvents().CheckLevel!,
            new GasEvents().CheckLevel!,
        };

        return new Car(events, oilCondition,waterLevel,batteryLevel,tirePressureIsGood,gasLevel);
    }
}

