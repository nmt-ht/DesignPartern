using System.ComponentModel;
//using System.Drawing;
using static DesignPartern.SOLID.SingleResponsibilityPrinciple;
using static DesignPartern.SOLID.OpenClosePrinciple;
using static DesignPartern.SOLID.LiskovSubstitutionPrincile;
using static DesignPartern.SOLID.InterfaceSegregationPrinciple;
using static DesignPartern.SOLID.DependencyInversionPrinciple;

#region SRP
//Joural joural = new Joural();
//joural.AddEntry("I cried today");
//joural.AddEntry("I ate a bug");
//Console.WriteLine(joural.ToString());

//var p = new Persistence();
//var fileName = @"c:\temp\joural.txt";
//p.SaveToFile(joural, fileName);
//Process.Start(fileName);
#endregion

#region OCP
//var apple = new Product("Apple", Color.Green, Size.Small);
//var tree = new Product("Tree", Color.Green, Size.Large);
//var hosue = new Product("House", Color.Blue, Size.Large);

//Product[] products = {apple, tree, hosue };
//var pf = new ProductFiler();
//Console.WriteLine("Green products (old):");
//foreach (var product in pf.FillerByColor(products, Color.Green))
//{
//    Console.WriteLine($" - { product.Name} is green");
//}

//var bf = new BetterFilter();
//Console.WriteLine("Green products (new):");
//foreach (var product in bf.Filter(products, new ColorSpecification(Color.Green)))
//{
//    Console.WriteLine($" - {product.Name} is green");
//}

//Console.WriteLine("Large blue items");
//foreach (var product in bf.Filter(products, new AndSpecification<Product>(
//        new ColorSpecification(Color.Blue),
//        new SizeSpecification(Size.Large)
//    )))
//{
//    Console.WriteLine($" - {product.Name} is big and blue");
//}
#endregion

#region Liskov Substitution Principle
//Rectangle rc = new Rectangle(3, 4);
//Console.WriteLine($"{rc} has area {Area(rc)}");
//Rectangle sq = new Square();
//sq.Width = 100;
//Console.WriteLine($"{sq} has area {Area(sq)}");
#endregion

#region Interface Segregation Principle
var parent = new Person { Name = "John" };
var child1 = new Person { Name = "Chris" };
var child2 = new Person { Name = "Matt" };

// low-level module
var relationships = new Relationships();
relationships.AddParentAndChild(parent, child1);
relationships.AddParentAndChild(parent, child2);

new Research(relationships);
#endregion