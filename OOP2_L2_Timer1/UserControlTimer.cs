using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_L2_Timer1
{
    public partial class UserControlTimer : UserControl
    {
        public interface ITimeObserver
        {
            void UpdateTime(string currentTime);
        }

        private List<ITimeObserver> observers = new();

        public UserControlTimer()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToLongTimeString();
            label1.Text = currentTime;
            NotifyObservers(currentTime);
        }
        private void NotifyObservers(string currentTime)
        {
            foreach (var observer in observers)
            {
                observer.UpdateTime(currentTime);
            }
        }
        public bool TimeEnabled
        {
            get { return timer1.Enabled; }
            set { timer1.Enabled = value; }
        }
        public void RegisterObserver(ITimeObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(ITimeObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
