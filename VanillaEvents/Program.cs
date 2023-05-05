
var car = Car.CarFactory.CreateCar(new EventHandler[]
{
    (sender, e) => Console.WriteLine($"Car started by {sender}"),
    (sender, e) => Console.WriteLine("Start oil pump"),
    (sender, e) => Console.WriteLine("Start gas pump"),
    (sender, e) => Console.WriteLine("Start water pump"),
});

car.StartEngine(null, EventArgs.Empty);


public class Car
{
    private Car()
    {
    }

    public EventHandler StartEngine { get; set; }

    public static class CarFactory
    {
        public static Car CreateCar(IEnumerable<EventHandler> whenCarStart)
        {
            var car = new Car();
            car.StartEngine += (sender, e) => Console.WriteLine("Engine started");
            
            foreach (var eventHandler in whenCarStart)
                car.StartEngine += eventHandler;
            
            return car;
        }
    }
}