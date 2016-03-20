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
    public partial class LinkGamePanel : UserControl
    {
        const int imageWidthL = 60;
        const int imageWidthS = 56;
        const int offside = 2;
        Image[] icons = new Bitmap[30];
        int[,] iconArray = new int[10, 10];
        int cur = -1;
        bool timeOver = false;
        public delegate void EventHandler(Object sender, EventArgs e);
        public event EventHandler ScoringEvent;
        public event EventHandler GameWinEvent;

        public bool TimeOver
        {
            get { return timeOver; }
            set { timeOver = value; }
        }

        public LinkGamePanel()
        {
            InitializeComponent();
            for (int i = 0; i < 16; i++) {
                icons[i] = PicLoader.Read("War3a", String.Format("{0}.JPG", i + 1));
            }
            for (int i = 0; i < 8; i++)
            {
                icons[20+i] = PicLoader.Read("Symbol", String.Format("{0}.JPG", i + 1));
            }
            this.DoubleBuffered = true;
        }

        public void InitIcons() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    iconArray[i, j] = 0;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    iconArray[i + 1, j + 1] = j / 4 + i * 2 + 1;
                }
            }
            Random r = new Random(DateTime.Now.Millisecond);
            int sel = (r.Next() % 16);
            int symid = (r.Next() % 8) + 1;
            iconArray[(sel % 8) + 1, sel / 8 * 4 + 1] = 20 + symid;
            iconArray[(sel % 8) + 1, sel / 8 * 4 + 2] = 20 + symid;
            symid = (r.Next() % 8) + 1;
            iconArray[(sel % 8) + 1, sel / 8 * 4 + 3] = 20 + symid;
            iconArray[(sel % 8) + 1, sel / 8 * 4 + 4] = 20 + symid;

            for (int i = 0; i < 1000; i++)
            {
                Swap(r.Next() % 8, r.Next() % 8, r.Next() % 8, r.Next() % 8);
            }
            timeOver = false;
            Invalidate();
        }

        private void Swap(int i1, int j1, int i2, int j2)
        {
            int temp = iconArray[i1+1, j1+1];
            iconArray[i1+1, j1+1] = iconArray[i2+1, j2+1];
            iconArray[i2+1, j2+1] = temp;
        }

        private void LinkGamePanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (iconArray[i + 1, j + 1]!=0)
                        e.Graphics.DrawImage(icons[iconArray[i + 1, j + 1] - 1], new Rectangle(new Point((i + 1) * imageWidthL + offside, (j + 1) * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
                }
            }
            if (cur != -1) {
                Pen p =new Pen(Brushes.Red,4);
                e.Graphics.DrawRectangle(p, new Rectangle(new Point((cur % 10) * imageWidthL + offside, (cur / 10)  * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
            }
        }

        private void LinkGamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !timeOver)
            {
                int click;
                if (e.X < imageWidthL * 10 && e.Y < imageWidthL * 10 && iconArray[e.X / imageWidthL, e.Y / imageWidthL] != 0)
                {
                    click = e.X / imageWidthL + e.Y / imageWidthL * 10;
                }
                else
                    return;
                if (click == cur)
                {
                    return;
                }
                //      Invalidate(new Rectangle(new Point((cur % 10) * imageWidthL + offside, (cur / 10) * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
                if (cur == -1)
                {
                    cur = click;
                }
                else
                {
                    if (FindPath(click, cur, CheckMethod.Try))
                    {
                        ScoringEventArgs sea = new ScoringEventArgs();
                        sea.LType = iconArray[click % 10, click / 10];
                        ScoringEvent(this, sea);
                        iconArray[click % 10, click / 10] = 0;
                        iconArray[cur % 10, cur / 10] = 0;
                        //               Invalidate(new Rectangle(new Point((cur % 10) * imageWidthL + offside, (cur / 10) * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
                        //               Invalidate(new Rectangle(new Point((click % 10) * imageWidthL + offside, (click / 10) * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
                        Sounder s = new Sounder("ok");
                        Thread.Sleep(200);
                    }
                    else
                    {
                        Sounder s = new Sounder("err");
                    }
                    cur = -1;
                }
                if (IsGameEnd()) {
                    GameWinEvent(this, e);
                    return;
                }
                while (!GameAvail())
                    Resort();
                //        Invalidate(new Rectangle(new Point((cur % 10) * imageWidthL + offside, (cur / 10) * imageWidthL + offside), new Size(imageWidthS, imageWidthS)));
                Invalidate();
            }
        }

        private int GetIconArray(int v) {
            return iconArray[v % 10, v / 10];
        }

        private bool ContainV(List<LinkUnit> list,int v) {
            for (int i = 0; i < list.Count; i++)
                if (list[i].value == v)
                    return true;
            return false;
        }

        #region 寻找匹配
        private bool FindPath(int click, int cur,CheckMethod method)
        {
            bool f = false;
            int mindis = 999999;
            int lastnode = -1;
            if (GetIconArray(click) != GetIconArray(cur)) {
                return false;
            }
            List<LinkUnit> list =new List<LinkUnit>();
            list.Add(new LinkUnit(click,0,0,-1));
            for (int i = 0; i < 3 && !f; i++) { 
                for (int j = 0;j< list.Count;j++) {
                    if (list[j].depth == i) {
                        for (int k = list[j].value-1,dis = 0; k >= list[j].value - (list[j].value % 10); k--,dis++) {
                            if (k == cur && list[j].distance + dis < mindis)
                            {
                                mindis = list[j].distance + dis;
                                lastnode = j;
                                f = true;
                            }
                            if (GetIconArray(k) > 0)
                                break;
                            else {
                                if (!ContainV(list, k))
                                    list.Add(new LinkUnit(k, list[j].depth + 1, list[j].distance + dis,j));
                            }
                        }
                        for (int k = list[j].value+1, dis = 0; k <= list[j].value - (list[j].value % 10)+9; k++, dis++)
                        {
                            if (k == cur && list[j].distance + dis < mindis)
                            {
                                mindis = list[j].distance + dis;
                                lastnode = j;
                                f = true;
                            }
                            if (GetIconArray(k) > 0)
                                break;
                            else
                            {
                                if (!ContainV(list, k))
                                    list.Add(new LinkUnit(k, list[j].depth + 1, list[j].distance + dis,j));
                            }
                        }
                        for (int k = list[j].value-10, dis = 0; k >= 0; k-=10, dis++)
                        {
                            if (k == cur && list[j].distance + dis < mindis)
                            {
                                mindis = list[j].distance + dis;
                                lastnode = j;
                                f = true;
                            }
                            if (GetIconArray(k) > 0)
                                break;
                            else
                            {
                                if (!ContainV(list, k))
                                    list.Add(new LinkUnit(k, list[j].depth + 1, list[j].distance + dis,j));
                            }
                        }
                        for(int k = list[j].value+10, dis = 0; k <=99; k+=10, dis++)
                        {
                            if (k == cur && list[j].distance + dis < mindis)
                            {
                                mindis = list[j].distance + dis;
                                lastnode = j;
                                f = true;
                            }
                            if (GetIconArray(k) > 0)
                                break;
                            else
                            {
                                if (!ContainV(list, k))
                                    list.Add(new LinkUnit(k, list[j].depth + 1, list[j].distance + dis,j));
                            }
                        }
                    }
                }
            }

            if (!f)
                return false;

            if (method == CheckMethod.Try)
            {
                Graphics g = this.CreateGraphics();

                if (lastnode <= 0)
                {
                    DrawLine(g, cur, click);
                }
                else
                {
                    int target = cur;
                    int source = list[lastnode].value;
                    lastnode = list[lastnode].father;
                    do
                    {
                        DrawLine(g, source, target);
                        target = source;
                        source = list[lastnode].value;
                        lastnode = list[lastnode].father;
                    } while (lastnode != -1);
                    DrawLine(g, source, target);
                }
            }

            return true;
        }
        #endregion

        private void DrawLine(Graphics g,int source, int target)
        {
            Pen p =new Pen(Brushes.Blue,7);
            g.DrawLine(p, (source % 10) * 60+27, (source / 10) * 60+27, (target % 10) * 60+27, (target / 10) * 60+27);
        }

        public void UpdateIcons(String dir) {
            for (int i = 0; i < 16; i++)
            {
                icons[i] = PicLoader.Read(dir, String.Format("{0}.JPG", i + 1));
            }
            Invalidate();
        }

        /// <summary>
        /// 判断游戏是否结束
        /// </summary>
        /// <returns></returns>
        private bool IsGameEnd()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (iconArray[i, j] != 0)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 重排连连子
        /// </summary>
        private void Resort() {
            List<int> li = new List<int>();
            for (int i = 1; i < 9; i++) {
                for (int j = 1; j < 9; j++)
                {
                    if (iconArray[i, j] != 0)
                        li.Add(iconArray[i, j]);
                }
            }
            Random r = new Random();
            for (int i = 0; i < 10; i++) {
                int p = r.Next() % li.Count;
                int v = li[p];
                li.RemoveAt(p);
                li.Add(v);
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (iconArray[i, j] != 0)
                    {
                        iconArray[i, j] = li[0];
                        li.RemoveAt(0);
                    }
                }
            }
   //         Invalidate();
        }

        /// <summary>
        /// 检测是否死锁
        /// </summary>
        /// <returns></returns>
        private bool GameAvail()
        {
            for (int i1 = 1, j1 = 1; i1 < 9 || j1 < 9; i1++) {
                if (i1 == 9) {
                    i1 = 0;
                    j1++;
                }
                for (int i2 = 1, j2 = 1; i2 < 9 || j2 < 9; i2++)
                {
                    if (i2 == 9)
                    {
                        i2 = 0;
                        j2++;
                    }
                    if (i1 + j1 * 10 == i2 + j2 * 10 || iconArray[i1, j1] == 0 || (iconArray[i1, j1] != iconArray[i2, j2]) )
                    {
                        continue;
                    }
                    if (FindPath(i1 + j1 * 10, i2 + j2 * 10, CheckMethod.Test))
                    {
                        //iconArray[i1, j1] = 0;
                        //iconArray[i2, j2] = 0;
                        //Invalidate();
                        return true;
                    }
                }
            }
            return false;
        }

        public enum CheckMethod { 
            Try,Test,Hint
        }

        public class ScoringEventArgs : EventArgs {
            private int lType;

            public int LType
            {
                get { return lType; }
                set { lType = value; }
            }

        }
    }
}
