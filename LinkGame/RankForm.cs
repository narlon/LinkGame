using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkGame
{
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
        }
        internal void SetScore(GameSaver gs)
        {
            for (int i = 0; i < 100; i++) {
                ListViewItem lvm = new ListViewItem((i + 1).ToString());
                lvm.SubItems.Add(gs.Record[i].name);
                lvm.SubItems.Add(gs.Record[i].time);
                lvm.SubItems.Add(gs.Record[i].level.ToString());
                lvm.SubItems.Add(gs.Record[i].score.ToString());
                listView1.Items.Add(lvm);
            }
        }
    }
}