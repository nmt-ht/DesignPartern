namespace DesignPartern.Creational.Builder.FunctionalBuilder
{
    public class Person
    {
        public string Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSeft>
        where TSeft : FunctionalBuilder<TSubject, TSeft>
        where TSubject : new()
    {
        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
        public TSeft Do(Action<Person> action)
            => AddAction(action);
        private TSeft AddAction(Action<Person> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSeft)this;
        }
        public Person Build()
        {
            return actions.Aggregate(new Person(), (p, f) => f(p));
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
        {
            return Do(p => p.Name = name);
        }
    }

    //public sealed class PersonBuilder
    //{
    //    private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
    //    public PersonBuilder Called(string name)
    //        => Do(p => p.Name = name);
    //    public PersonBuilder Do(Action<Person> action)
    //        => AddAction(action);
    //    private PersonBuilder AddAction(Action<Person> action)
    //    {
    //        actions.Add(p => { action(p); return p; });
    //        return this;
    //    }
    //    public Person Build()
    //    {
    //       return actions.Aggregate(new Person(), (p, f) => f(p));
    //    }
    //}

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA
          (this PersonBuilder builder, string position)
        {
            builder.Do(p =>
            {
                p.Position = position;
            });
            return builder;
        }
    }
}
