using System;

namespace Banana
{
    /**
     * 工厂模式
     * **/

    #region 工厂模式-【图形】

    /// <summary>
    /// 图形
    /// </summary>
    public interface IShape
    {
        void Draw();
    }

    /// <summary>
    /// 图形枚举
    /// </summary>
    public enum Shapes
    {
        CIRCLE = 1,
        RECTANGLE = 2,
        SQUARE = 3
    }

    /// <summary>
    /// 矩形
    /// </summary>
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("绘制长方形");
        }
    }
    /// <summary>
    /// 圆形
    /// </summary>
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("绘制圆形");
        }
    }
    /// <summary>
    /// 方形
    /// </summary>
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("绘制正方形");
        }
    }

    /// <summary>
    /// 图形工厂
    /// </summary>
    public class ShapeFactory
    {
        public IShape GetShape(Shapes shapeType)
        {
            IShape instance = null;
            switch (shapeType)
            {
                case Shapes.CIRCLE:
                    instance = new Circle();
                    break;
                case Shapes.RECTANGLE:
                    instance = new Rectangle();
                    break;
                case Shapes.SQUARE:
                    instance = new Square();
                    break;
                default:
                    break;
            }
            return instance;
        }
    }

    #endregion

    #region 工厂模式-【颜色】

    /// <summary>
    /// 颜色
    /// </summary>
    public interface IColor
    {
        void Fill();
    }

    /// <summary>
    /// 颜色枚举
    /// </summary>
    public enum Colors
    {
        RED = 1,
        YELLOW = 2,
        BLUE = 3
    }

    /// <summary>
    /// 红色
    /// </summary>
    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充红色");
        }
    }

    /// <summary>
    /// 黄色
    /// </summary>
    public class Yellow : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充黄色");
        }
    }

    /// <summary>
    /// 蓝色
    /// </summary>
    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("填充蓝色");
        }
    }

    /// <summary>
    /// 颜色工厂
    /// </summary>
    public class ColorFactory
    {
        public IColor GetShape(Colors colorType)
        {
            IColor instance = null;
            switch (colorType)
            {
                case Colors.RED:
                    instance = new Red();
                    break;
                case Colors.YELLOW:
                    instance = new Yellow();
                    break;
                case Colors.BLUE:
                    instance = new Blue();
                    break;
                default:
                    break;
            }
            return instance;
        }
    }

    #endregion

    //********************************************************//

    /**
     * 抽象工厂
     * **/
    //抽象工厂就是对工厂模式进行抽象化，ta其实是工厂的工厂

    #region 抽象工厂

    /// <summary>
    /// 抽象工厂基类
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract IShape GetShape(Shapes shapeType);
        public abstract IColor GetColor(Colors colorType);
    }

    /// <summary>
    /// 实现抽象工厂的图形工厂
    /// </summary>
    public class MyShapeFactory : AbstractFactory
    {
        public override IShape GetShape(Shapes shapeType)
        {
            IShape instance = null;
            switch (shapeType)
            {
                case Shapes.CIRCLE:
                    instance = new Circle();
                    break;
                case Shapes.RECTANGLE:
                    instance = new Rectangle();
                    break;
                case Shapes.SQUARE:
                    instance = new Square();
                    break;
                default:
                    break;
            }
            return instance;
        }

        public override IColor GetColor(Colors colorType)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 实现抽象工厂的颜色工厂
    /// </summary>
    public class MyColorFactory : AbstractFactory
    {
        public override IColor GetColor(Colors colorType)
        {
            IColor instance = null;
            switch (colorType)
            {
                case Colors.RED:
                    instance = new Red();
                    break;
                case Colors.YELLOW:
                    instance = new Yellow();
                    break;
                case Colors.BLUE:
                    instance = new Blue();
                    break;
                default:
                    break;
            }
            return instance;
        }

        public override IShape GetShape(Shapes shapeType)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 工厂枚举
    /// </summary>
    public enum Factorys
    {
        SHAPE = 1,
        COLOR = 2
    }

    /// <summary>
    /// 超级工厂-用来生成其他工厂
    /// </summary>
    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(Factorys factoryType)
        {
            AbstractFactory instance = null;
            switch (factoryType)
            {
                case Factorys.SHAPE:
                    instance = new MyShapeFactory();
                    break;
                case Factorys.COLOR:
                    instance = new MyColorFactory();
                    break;
                default:
                    break;
            }
            return instance;
        }
    }

    #endregion

}