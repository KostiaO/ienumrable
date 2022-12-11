using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace HelloWorld
{
    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }


    public class People : IEnumerable
    {
        public Person[] people;

        public People(Person[] persList)
        {
            this.people = persList;
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnumrable(people);
        }
    }

    public class PeopleEnumrable : IEnumerator
    {
        private readonly Person[] peopleArr;

        private int index = -1;

        public PeopleEnumrable(Person[] people)
        {
            this.peopleArr = people;
        }

        public bool MoveNext()
        {
            if (index < peopleArr.Length - 1)
            {
                index += 2;
                return true;
            }

            return false;
        }

        public object Current
        {
            get
            {
                return peopleArr[index];
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose() {}
       
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persArr = { new Person("John", 45), new Person("Michael", 34), new Person("Kelly", 12), new Person("Molly", 19) };

            var personList = new People(persArr);

            foreach (Person person in personList)
            {
                Console.WriteLine(person.age);
            }
        }
    }
}
