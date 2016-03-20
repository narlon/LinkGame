using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkGame
{
    public partial class CheckResult : Form
    {
        bool save = false;
        int rank = 100;
        String sname = "";

        public String Sname
        {
            get { return sname; }
            set { sname = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public bool Save
        {
            get { return save; }
            set { save = value; }
        }

        public CheckResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save = true;
            sname = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckResult_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("你获得了第{0}名！", rank + 1);
        }
    }
}