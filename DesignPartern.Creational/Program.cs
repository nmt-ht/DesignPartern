using Autofac;
using DesignPartern.Creational.Builder.Buider;
using DesignPartern.Creational.Builder.BuilderInheritance;
using DesignPartern.Creational.Builder.FunctionalBuilder;
using DesignPartern.Creational.Builder.StepwiseBuilder;
using DesignPartern.Creational.Factories;
using DesignPartern.Creational.Factories.AbstractFactory;
using DesignPartern.Creational.Factories.BulkReplacement;
using DesignPartern.Creational.Prototype;
using DesignPartern.Creational.Prototype.CopyThroughSerialization;
using DesignPartern.Creational.Prototype.ICloneableIsBad;
using DesignPartern.Creational.Prototype.Inheritance;
using DesignPartern.Creational.Singleton;
using DesignPartern.Creational.Singleton.AmbientStack;
using DesignPartern.Creational.Singleton.Monostate;
using DesignPartern.Creational.Singleton.PerThread;
using DesignPartern.Creational.Singleton.SingletonInDI;
using System.Text;
using static System.Console;

#region BUILDER

//#region Builder & Fluent Builder
//// if you want to build a simple HTML paragraph using StringBuilder
//var hello = "hello";
//var sb = new StringBuilder();
//sb.Append("<p>");
//sb.Append(hello);
//sb.Append("</p>");
//Console.WriteLine(sb);

//// now I want an HTML list with 2 words in it
//var words = new[] { "hello", "world" };
//sb.Clear();
//sb.Append("<ul>");
//foreach (var word in words)
//{
//    sb.AppendFormat("<li>{0}</li>", word);
//}
//sb.Append("</ul>");
//Console.WriteLine(sb);

//// ordinary non-fluent builder
//var builder = new HtmlBuilder("ul");
//builder.AddChild("li", "hello");
//builder.AddChild("li", "world");
//Console.WriteLine(builder.ToString());

//// fluent builder
//sb.Clear();
//builder.Clear(); // disengage builder from the object it's building, then...
//builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
//Console.WriteLine(builder);
//#endregion

//#region Builder Inheritance
//var me = DesignPartern.Creational.Builder.BuilderInheritance.Person.New
//        .Called("Dmitri")
//        .WorksAsA("Quant")
//        .Born(DateTime.UtcNow)
//        .Build();
//Console.WriteLine(me);
//#endregion

//#region Stepwise Builder
//var car = CarBuilder.Create()
//                  .OfType(CarType.Crossover)
//                  .WithWheels(18)
//                  .Build();
//#endregion

//#region Functional Builder
//new DesignPartern.Creational.Builder.FunctionalBuilder.PersonBuilder().Called("Dmitri").WorksAsA("Dev").Build();
//#endregion

//#region FactetBuilder
//var pb = new DesignPartern.Creational.Builder.BuilderFacets.PersonBuilder();
//DesignPartern.Creational.Builder.BuilderFacets.Person person = pb
//  .Lives
//    .At("123 London Road")
//    .In("London")
//    .WithPostcode("SW12BC")
//  .Works
//    .At("Fabrikam")
//    .AsA("Engineer")
//    .Earning(123000);

//Console.WriteLine(person);
//#endregion

#endregion


#region FACTORIES

#region Factory
//var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
//var origin = Point.Origin;
//var p2 = Point.Factory.NewCartesianPoint(1, 2);
#endregion

#region AbstractFactory
//var machine = new HotDrinkMachine();
////var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
////drink.Consume();

//IHotDrink drink = machine.MakeDrink();
//drink.Consume();
#endregion

#region BulkReplacement
//var factory = new TrackingThemeFactory();
//var theme = factory.CreateTheme(true);
//var theme2 = factory.CreateTheme(false);
//Console.WriteLine(factory.Info);
//// Dark theme
//// Light theme

//// replacement
//var factory2 = new ReplaceableThemeFactory();
//var magicTheme = factory2.CreateTheme(true);
//Console.WriteLine(magicTheme.Value.BgrColor); // dark gray
//factory2.ReplaceTheme(false);
//Console.WriteLine(magicTheme.Value.BgrColor); // white
#endregion
#endregion

#region PROTOTYPE
#region ICloneableIsBad
//var john = new DesignPartern.Creational.Prototype.ICloneableIsBad.Person(new[] { "John", "Smith" }, new Address("London Road", 123));
//var jane = (DesignPartern.Creational.Prototype.ICloneableIsBad.Person)john.Clone();
//jane.Address.HouseNumber = 321; // oops, John is now at 321

//// this doesn't work
////var jane = john;

//// but clone is typically shallow copy
//jane.Names[0] = "Jane";

//WriteLine(john);
//WriteLine(jane);
#endregion
#region Copy Contructor
//var john = new DesignPartern.Creational.Prototype.CopyContructor.Employee("John", new DesignPartern.Creational.Prototype.CopyContructor.Address("123 London Road", "London", "UK"));
////var chris = john;
//var chris = new DesignPartern.Creational.Prototype.CopyContructor.Employee(john);

//chris.Name = "Chris";
//WriteLine(john); // oops, john is called chris
//WriteLine(chris);
#endregion
#region Inheritance
//var john = new DesignPartern.Creational.Prototype.Inheritance.Employee();
//john.Names = new[] { "John", "Doe" };
//john.Address = new DesignPartern.Creational.Prototype.Inheritance.Address { HouseNumber = 123, StreetName = "London Road" };
//john.Salary = 321000;
//var copy = john.DeepCopy();

//copy.Names[1] = "Smith";
//copy.Address.HouseNumber++;
//copy.Salary = 123000;

//Console.WriteLine(john);
//Console.WriteLine(copy);
#endregion
#region Copy Through Serialization
//Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

////Foo foo2 = foo.DeepCopy(); // crashes without [Serializable]
//Foo foo2 = foo.DeepCopyXml();

//foo2.Whatever = "xyz";
//WriteLine(foo);
//WriteLine(foo2);
#endregion
#endregion

#region SINGLETON
#region Singleton Impletation
var db = SingletonDatabase.Instance;

// works just fine while you're working with a real database.
var city = "Tokyo";
WriteLine($"{city} has population {db.GetPopulation(city)}");

// now some tests
#endregion
#region Singleton in DI
var builder = new ContainerBuilder();
builder.RegisterType<EventBroker>().SingleInstance();
builder.RegisterType<DesignPartern.Creational.Singleton.SingletonInDI.Foo>();

using (var c = builder.Build())
{
    var foo1 = c.Resolve<DesignPartern.Creational.Singleton.SingletonInDI.Foo>();
    var foo2 = c.Resolve<DesignPartern.Creational.Singleton.SingletonInDI.Foo>();

    WriteLine(ReferenceEquals(foo1, foo2));
    WriteLine(ReferenceEquals(foo1.Broker, foo2.Broker));
}
#endregion
#region Monostate
var ceo = new ChiefExecutiveOfficer();
ceo.Name = "Adam Smith";
ceo.Age = 55;

var ceo2 = new ChiefExecutiveOfficer();
WriteLine(ceo2);
#endregion
#region AmbientContext
var house = new Building();

// ground floor
//var e = 0;
house.Walls.Add(new Wall(new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 0), new DesignPartern.Creational.Singleton.AmbientStack.Point(5000, 0)/*, e*/));
house.Walls.Add(new Wall(new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 0), new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 4000)/*, e*/));

// first floor
//e = 3500;
using (new BuildingContext(3500))
{
    house.Walls.Add(new Wall(new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 0), new DesignPartern.Creational.Singleton.AmbientStack.Point(5000, 0) /*, e*/));
    house.Walls.Add(new Wall(new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 0), new DesignPartern.Creational.Singleton.AmbientStack.Point(0, 4000) /*, e*/));
}

// back to ground again
// e = 0;
house.Walls.Add(new Wall(new DesignPartern.Creational.Singleton.AmbientStack.Point(5000, 0), new DesignPartern.Creational.Singleton.AmbientStack.Point(5000, 4000)/*, e*/));

Console.WriteLine(house);
#endregion
#region Per Thread
var t1 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"t1: " + PerThreadSingleton.Instance.Id);
});
var t2 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"t2: " + PerThreadSingleton.Instance.Id);
    Console.WriteLine($"t2 again: " + PerThreadSingleton.Instance.Id);
});
Task.WaitAll(t1, t2);
#endregion
#endregion