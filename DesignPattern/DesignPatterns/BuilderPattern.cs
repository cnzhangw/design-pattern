using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banana
{
    /**
     * 建造者模式
     * **/

    /// <summary>
    /// 项基类
    /// </summary>
    public interface Item
    {
        string Name();
        float Price();
        Packing Packing();
    }

    /// <summary>
    /// 打包基类
    /// </summary>
    public interface Packing
    {
        string Pack();
    }

    #region 打包形式

    public class Wrapper : Packing
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }
    public class Bottle : Packing
    {
        public string Pack()
        {
            return "Bottle";
        }
    }

    #endregion

    #region 食物形式

    /// <summary>
    /// 汉堡基类
    /// </summary>
    public abstract class Burger : Item
    {
        public abstract string Name();

        public abstract float Price();

        public Packing Packing()
        {
            return new Wrapper();
        }
    }
    /// <summary>
    /// 冷饮基类
    /// </summary>
    public abstract class ColdDrink : Item
    {

        public abstract string Name();

        public abstract float Price();

        public Packing Packing()
        {
            return new Bottle();
        }
    }

    #region 具体食物类的实现

    public class VegBurger : Burger
    {
        public override float Price()
        {
            return 15.00f;
        }

        public override string Name()
        {
            return "veg burger";
        }
    }

    public class ChickenBurger : Burger
    {
        public override float Price()
        {
            return 25.00f;
        }

        public override string Name()
        {
            return "chicken burger";
        }
    }

    public class Coke : ColdDrink
    {

        public override string Name()
        {
            return "coke";
        }

        public override float Price()
        {
            return 8.5f;
        }
    }

    public class Pepsi : ColdDrink
    {
        public override string Name()
        {
            return "pepsi";
        }

        public override float Price()
        {
            return 8.00f;
        }
    }
    
    #endregion

    #endregion

    /// <summary>
    /// 套餐基类
    /// </summary>
    public class Meal
    {
        private IList<Item> items = new List<Item>();
        public Meal AddItem(Item item)
        {
            items.Add(item);
            return this;
        }
        public float GetCost()
        {
            return items.Sum(e => e.Price());
        }
        public void ShowItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine("item:" + item.Name());
                Console.WriteLine("packing:" + item.Packing().Pack());
                Console.WriteLine("price:" + item.Price());
                Console.WriteLine("---------------------------");
            }
        }
    }

    /// <summary>
    /// 套餐建造者
    /// </summary>
    public class MealBuilder
    {
        /// <summary>
        /// 蔬菜汉堡+可口可乐
        /// </summary>
        /// <returns></returns>
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            return meal.AddItem(new VegBurger()).AddItem(new Coke());
        }
        /// <summary>
        /// 肌肉汉堡+百事可乐
        /// </summary>
        /// <returns></returns>
        public Meal PrepareChickenMeal()
        {
            return new Meal().AddItem(new ChickenBurger()).AddItem(new Pepsi());
        }
    }

}
