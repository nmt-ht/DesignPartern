using DesignPartern.Creational.Builder.Buider;
using DesignPartern.Creational.Builder.BuilderInheritance;
using DesignPartern.Creational.Builder.FunctionalBuilder;
using DesignPartern.Creational.Builder.StepwiseBuilder;
using System.Text;

#region BUILDER

#region Builder & Fluent Builder
// if you want to build a simple HTML paragraph using StringBuilder
var hello = "hello";
var sb = new StringBuilder();
sb.Append("<p>");
sb.Append(hello);
sb.Append("</p>");
Console.WriteLine(sb);

// now I want an HTML list with 2 words in it
var words = new[] { "hello", "world" };
sb.Clear();
sb.Append("<ul>");
foreach (var word in words)
{
    sb.AppendFormat("<li>{0}</li>", word);
}
sb.Append("</ul>");
Console.WriteLine(sb);

// ordinary non-fluent builder
var builder = new HtmlBuilder("ul");
builder.AddChild("li", "hello");
builder.AddChild("li", "world");
Console.WriteLine(builder.ToString());

// fluent builder
sb.Clear();
builder.Clear(); // disengage builder from the object it's building, then...
builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
Console.WriteLine(builder);
#endregion

#region Builder Inheritance
var me = DesignPartern.Creational.Builder.BuilderInheritance.Person.New
        .Called("Dmitri")
        .WorksAsA("Quant")
        .Born(DateTime.UtcNow)
        .Build();
Console.WriteLine(me);
#endregion

#region Stepwise Builder
var car = CarBuilder.Create()
                  .OfType(CarType.Crossover)
                  .WithWheels(18)
                  .Build();
#endregion

#region Functional Builder
new DesignPartern.Creational.Builder.FunctionalBuilder.PersonBuilder().Called("Dmitri").WorksAsA("Dev").Build();
#endregion

#region FactetBuilder
var pb = new DesignPartern.Creational.Builder.BuilderFacets.PersonBuilder();
DesignPartern.Creational.Builder.BuilderFacets.Person person = pb
  .Lives
    .At("123 London Road")
    .In("London")
    .WithPostcode("SW12BC")
  .Works
    .At("Fabrikam")
    .AsA("Engineer")
    .Earning(123000);

Console.WriteLine(person);
#endregion

#endregion
