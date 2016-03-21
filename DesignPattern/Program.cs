using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{

    using Banana;
    class Program
    {

        static void BuilderPattern()
        {
            Console.WriteLine("建造者模式");
            Meal vegMeal = new MealBuilder().PrepareVegMeal();
            vegMeal.AddItem(new Pepsi());
            vegMeal.ShowItems();
            Console.WriteLine("总计:" + vegMeal.GetCost());
        }

        static void AdapterPattern()
        {
            Console.WriteLine("适配器模式");
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play(MediaType.MP3, "http://www.6188.hk/a.mp3");
            audioPlayer.Play(MediaType.MP4, "http://www.6188.hk/b.mp4");
            audioPlayer.Play(MediaType.WMV, "http://www.6188.hk/c.wmv");
        }

        static void ObserverPattern()
        {
            Console.WriteLine("观察者模式");
            Subject subject = new Subject();
            new BinaryObserver(subject);
            new HexaObserver(subject);
            new OctalObserver(subject);
            subject.SetState(10);
            subject.SetState(92);
        }

        static void FactoryPattern()
        {
            Console.WriteLine("工厂模式");
            IShape myShape = new ShapeFactory().GetShape(Shapes.SQUARE);
            myShape.Draw();

            Console.WriteLine("抽象工厂模式");
            var shapeFactory = FactoryProducer.GetFactory(Factorys.SHAPE);
            shapeFactory.GetShape(Shapes.CIRCLE).Draw();
            shapeFactory.GetColor(Colors.YELLOW).Fill();//图形工厂是不可以调用颜色工厂的方法的
        }

        static void PrototypePattern()
        {
            Console.WriteLine("原型模式");
            PersonCache.LoadCache();
            Person p = PersonCache.GetPerson("1");
            p.SayHi();
            p = PersonCache.GetPerson("3");
            p.SayHi();
        }

        static void BridgePattern()
        {
            Console.WriteLine("桥接模式");
            Banana.BridgePattern.Shape shape = new Banana.BridgePattern.Circle(10, 15, 20, new Banana.BridgePattern.GreenCircle());
            shape.Draw();
        }

        static void Main(string[] args)
        {
            //Console.ReadKey();

            //FactoryPattern();
            ObserverPattern();
            //BuilderPattern();
            //AdapterPattern();
            //PrototypePattern();
            //BridgePattern();

            while (ConsoleKey.Enter != Console.ReadKey(true).Key) { }
        }
    }
}
