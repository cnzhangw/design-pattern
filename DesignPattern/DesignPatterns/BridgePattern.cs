using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banana.BridgePattern
{
    /**
     * 桥接模式
     * **/

    /// <summary>
    /// 桥接接口
    /// </summary>
    public interface IDraw
    {
        void DrawCircle(int radius, int x, int y);
    }

    public class RedCircle : IDraw
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine(string.Format("drawing circle[color:red,radius:{0},x:{1},y:{2}]", radius, x, y));
        }
    }
    public class GreenCircle : IDraw
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine(string.Format("drawing circle[color:green,radius:{0},x:{1},y:{2}]", radius, x, y));
        }
    }

    public abstract class Shape
    {
        protected IDraw drawAPI;
        public Shape(IDraw api)
        {
            this.drawAPI = api;
        }
        public abstract void Draw();
    }


    public class Circle : Shape
    {
        private int radius, x, y;
        public Circle(int radius, int x, int y, IDraw api)
            : base(api)
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
        }
        public override void Draw()
        {
            base.drawAPI.DrawCircle(radius, x, y);
        }
    }

}
