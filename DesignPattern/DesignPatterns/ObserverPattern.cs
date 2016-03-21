using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banana
{
    /**
     * 观察者模式
     * **/


    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }
    /// <summary>
    /// 主题
    /// </summary>
    public class Subject
    {
        private IList<Observer> observers = new List<Observer>();
        private int state;
        public void SetState(int state)
        {
            this.state = state;
            this.NotifyAllObservers();
        }
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public int GetState()
        {
            return state;
        }
        public void NotifyAllObservers()
        {            
            foreach (var item in observers)
            {
                item.Update();
            }
        }
    }

    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("二进制结果:{0}", Convert.ToString(subject.GetState(), 2));
        }
    }
    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("八进制结果:{0}", Convert.ToString(subject.GetState(), 8));
        }
    }
    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("十六进制结果:{0}", subject.GetState().ToString("X8"));
        }
    }
}
