using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace Banana
{
    /**
     * 原型模式
     * **/

    public abstract class Person:ICloneable
    {
        public string Id { get; set; }
        public string PersonType { get; protected set; }

        public abstract void SayHi();

        public object Clone()
        {
            object clone = null;
            try
            {
                clone = base.MemberwiseClone();
            }
            catch (Exception)
            {
                throw;
            }
            return clone;
        }
    }

    public class Chinese : Person
    {
        public Chinese()
        {
            this.PersonType = "中国人";
        }
        public override void SayHi()
        {
            Console.WriteLine("大家好，我是"+this.PersonType);
        }
    }
    public class American : Person
    {
        public American()
        {
            this.PersonType = "美国人";
        }
        public override void SayHi()
        {
            Console.WriteLine("大家好，我是"+this.PersonType);
        }
    }
    public class Korean : Person
    {
        public Korean()
        {
            this.PersonType = "韩国人";
        }
        public override void SayHi()
        {
            Console.WriteLine("大家好，我是" + this.PersonType);
        }
    }

    public class PersonCache
    {
        //private static Hashtable<string, Person> personMap = new Hashtable<string, Person>();
        private static Dictionary<string, Person> personMap = new Dictionary<string, Person>();
        public static Person GetPerson(string id)
        {
            Person cachedPerson = personMap[id];
            return cachedPerson.Clone() as Person;
        }
        public static void LoadCache()
        {
            var p1=new Chinese() { Id = "1" };
            personMap.Add(p1.Id, p1);
            var p2 = new American() { Id = "2" };
            personMap.Add(p2.Id, p2);
            var p3 = new Korean() { Id = "3" };
            personMap.Add(p3.Id, p3);
        }
    }


}
