using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LinkGame
{
    public partial class MyTimer : UserControl
    {
        private System.Threading.Timer t;
        private float totalTime = 100;
        private float leftTime = 100;
        private Image RedLine;
        private Image BlueLine;
        private bool useBline = true;
        private bool alive = false;
        public delegate void EventHandler(Object sender, EventArgs e);
        public event EventHandler TimeOutEvent;

        public bool UseBline
        {
            get { return useBline; }
            set { useBline = value; }
        }

        public float LeftTime
        {
            get { return leftTime; }
            set { leftTime = value;}
        }

        public String MyText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public bool Alive
        {
            get { return alive; }
        }

        public float TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }
        public MyTimer()
        {
            InitializeComponent();
            DoubleBuffered = true;
            RedLine = PicLoader.Read("System", "Rline.JPG");
            BlueLine = PicLoader.Read("System", "Bline.JPG");
        }

        public void Start(){
            leftTime = totalTime;
            t = new System.Threading.Timer(new TimerCallback(TimerProc),null,250,250);
            Visible = true;
            alive = true;
        }

        public void Stop() {
            Visible = false;
            alive = false;
        }

        private void TimerProc(object state)
        {
            leftTime-=0.25F;
            Invalidate();
            if (leftTime <= 0 && alive)
            {
                alive = false;
                TimeOutEvent(this, null);
                t.Dispose();
            }
        }

        private void MyTimer_Paint(object sender, PaintEventArgs e)
        {
            if (alive)
            {
                if (useBline)
                    e.Graphics.DrawImage(BlueLine, 80.0F, 13.0F, 280F, 15.0F);
                else
                    e.Graphics.DrawImage(RedLine, 80.0F, 13.0F, 280F, 15.0F);
                e.Graphics.FillRectangle(Brushes.Black, 80.0F + (float)(leftTime * 280 / totalTime), 13.0F, (float)(280 - leftTime * 280 / totalTime), 15.0F);
                float t = totalTime;
                int a = 1;
                while (t > 15)
                {
                    e.Graphics.DrawString((a*15).ToString(), new System.Drawing.Font("Arial", 7, FontStyle.Bold), new System.Drawing.SolidBrush(System.Drawing.Color.DarkGray), 80.0F + (a * 15) / totalTime * 280, 30F);
                    a++;
                    t -= 15;
                }
            }
          //  label1.Text = leftTime.ToString();
        }

    }
}
