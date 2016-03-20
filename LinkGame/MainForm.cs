using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkGame
{
    public partial class MainForm : Form
    {
        Marker mark;
        int level;
        GameSaver gameSaver = new GameSaver();
        public MainForm()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkGamePanel1.InitIcons();
            myTimer1.TotalTime = 150;
            myTimer1.Start();
            myTimer2.TotalTime = 5;
            myTimer2.Stop();
            mark = new Marker();
            level = 1;
            label1.Text = String.Format("{0:0000000}", mark.Mark);
            label2.Text = String.Format("Level {0}", level);
        }

        private void war3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkGamePanel1.UpdateIcons((sender as ToolStripMenuItem).Tag.ToString());
        }

        private void myTimer1_TimeOutEvent(object sender, EventArgs e)
        {
            linkGamePanel1.TimeOver = true;
            Record r = new Record();
            r.name = "???";
            r.level = level;
            r.score = mark.Mark;
            r.time = DateTime.Now.ToString();
            CheckResult cr = new CheckResult();
            cr.Rank = gameSaver.FindRecord(r);
            Sounder sounder = new Sounder("ding");
            cr.ShowDialog();
            if (cr.Save) {
                r.name = cr.Sname;
                gameSaver.AddRecord(r);
            }
        }

        private void linkGamePanel1_ScoringEvent(object sender, EventArgs e)
        {
            int ltype=(e as LinkGame.LinkGamePanel.ScoringEventArgs).LType;
            mark.Add(myTimer2.Alive, ltype);
            if (ltype == 25)
                myTimer1.LeftTime += 5;
            else if (ltype == 26)
                myTimer1.LeftTime += 10;
            if (myTimer2.Alive)
                myTimer2.LeftTime = myTimer2.TotalTime;
            else {
                myTimer2.Start();
            }
            label1.Text = String.Format("{0:0000000}", mark.Mark);
        }

        private void myTimer2_TimeOutEvent(object sender, EventArgs e)
        {

        }

        private void linkGamePanel1_GameWinEvent(object sender, EventArgs e)
        {
            myTimer1.Stop();
            myTimer2.Stop();
            if (MessageBox.Show("你赢了!进入下一关?", "U Win", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                level++;
                label2.Text = String.Format("Level {0}", level);
                linkGamePanel1.InitIcons();
                myTimer1.TotalTime = Math.Max(myTimer1.LeftTime + 165 - 15 * level, 15);
                myTimer1.Start();
                myTimer2.TotalTime = Math.Max(0.25F * (21 - level), 2F);
                
            }
        }

        private void solidhelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RankForm rf = new RankForm();
            rf.SetScore(gameSaver);
            rf.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}