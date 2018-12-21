using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gldd.AdissParser
{
    //https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        protected Enumeration()
        {
        }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Enumeration otherValue = obj as Enumeration;
            if (otherValue == null)
            {
                return false;
            }
            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(object other)
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !Equals(left, right);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration => GetAll(typeof(T)).Select(obj => (T)obj);

        public static IEnumerable<object> GetAll(Type type) => type
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null));
    }
}
