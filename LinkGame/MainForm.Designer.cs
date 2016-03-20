namespace LinkGame
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.war3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tearringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youxiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ashdGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSlogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceRangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidhelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myTimer2 = new LinkGame.MyTimer();
            this.myTimer1 = new LinkGame.MyTimer();
            this.linkGamePanel1 = new LinkGame.LinkGamePanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.styleToolStripMenuItem,
            this.othersToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.mainToolStripMenuItem.Text = "主菜单";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "重新开始";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.war3ToolStripMenuItem,
            this.roareaToolStripMenuItem,
            this.tearringToolStripMenuItem,
            this.youxiToolStripMenuItem,
            this.ashdGameToolStripMenuItem,
            this.cSlogoToolStripMenuItem,
            this.spaceRangerToolStripMenuItem});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.styleToolStripMenuItem.Text = "主题";
            // 
            // war3ToolStripMenuItem
            // 
            this.war3ToolStripMenuItem.Name = "war3ToolStripMenuItem";
            this.war3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.war3ToolStripMenuItem.Tag = "War3a";
            this.war3ToolStripMenuItem.Text = "魔兽争霸3";
            this.war3ToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // roareaToolStripMenuItem
            // 
            this.roareaToolStripMenuItem.Name = "roareaToolStripMenuItem";
            this.roareaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.roareaToolStripMenuItem.Tag = "Roarea";
            this.roareaToolStripMenuItem.Text = "仙境传说";
            this.roareaToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // tearringToolStripMenuItem
            // 
            this.tearringToolStripMenuItem.Name = "tearringToolStripMenuItem";
            this.tearringToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tearringToolStripMenuItem.Tag = "TearRing";
            this.tearringToolStripMenuItem.Text = "泪指环传说";
            this.tearringToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // youxiToolStripMenuItem
            // 
            this.youxiToolStripMenuItem.Name = "youxiToolStripMenuItem";
            this.youxiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.youxiToolStripMenuItem.Tag = "Youxi";
            this.youxiToolStripMenuItem.Text = "游戏王";
            this.youxiToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // ashdGameToolStripMenuItem
            // 
            this.ashdGameToolStripMenuItem.Name = "ashdGameToolStripMenuItem";
            this.ashdGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ashdGameToolStripMenuItem.Tag = "AshdGame";
            this.ashdGameToolStripMenuItem.Text = "边锋";
            this.ashdGameToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // cSlogoToolStripMenuItem
            // 
            this.cSlogoToolStripMenuItem.Name = "cSlogoToolStripMenuItem";
            this.cSlogoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSlogoToolStripMenuItem.Tag = "CSlogo";
            this.cSlogoToolStripMenuItem.Text = "CSlogo";
            this.cSlogoToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // spaceRangerToolStripMenuItem
            // 
            this.spaceRangerToolStripMenuItem.Name = "spaceRangerToolStripMenuItem";
            this.spaceRangerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spaceRangerToolStripMenuItem.Tag = "SpaceRanger";
            this.spaceRangerToolStripMenuItem.Text = "太空游侠";
            this.spaceRangerToolStripMenuItem.Click += new System.EventHandler(this.war3ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solidhelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "帮助";
            // 
            // solidhelpToolStripMenuItem
            // 
            this.solidhelpToolStripMenuItem.Name = "solidhelpToolStripMenuItem";
            this.solidhelpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.solidhelpToolStripMenuItem.Text = "真·帮助";
            this.solidhelpToolStripMenuItem.Click += new System.EventHandler(this.solidhelpToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Script MT Bold", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(590, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 96);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label2.Location = new System.Drawing.Point(596, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 58);
            this.label2.TabIndex = 6;
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem});
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.othersToolStripMenuItem.Text = "其他";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recordToolStripMenuItem.Text = "排行";
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // myTimer2
            // 
            this.myTimer2.BackColor = System.Drawing.Color.Black;
            this.myTimer2.LeftTime = 0F;
            this.myTimer2.Location = new System.Drawing.Point(606, 123);
            this.myTimer2.MyText = "COMBO";
            this.myTimer2.Name = "myTimer2";
            this.myTimer2.Size = new System.Drawing.Size(370, 40);
            this.myTimer2.TabIndex = 4;
            this.myTimer2.TotalTime = 5F;
            this.myTimer2.UseBline = false;
            this.myTimer2.Visible = false;
            this.myTimer2.TimeOutEvent += new LinkGame.MyTimer.EventHandler(this.myTimer2_TimeOutEvent);
            // 
            // myTimer1
            // 
            this.myTimer1.BackColor = System.Drawing.Color.Black;
            this.myTimer1.LeftTime = 150F;
            this.myTimer1.Location = new System.Drawing.Point(606, 77);
            this.myTimer1.MyText = "剩余时间";
            this.myTimer1.Name = "myTimer1";
            this.myTimer1.Size = new System.Drawing.Size(370, 40);
            this.myTimer1.TabIndex = 3;
            this.myTimer1.TotalTime = 150F;
            this.myTimer1.UseBline = true;
            this.myTimer1.Visible = false;
            this.myTimer1.TimeOutEvent += new LinkGame.MyTimer.EventHandler(this.myTimer1_TimeOutEvent);
            // 
            // linkGamePanel1
            // 
            this.linkGamePanel1.BackColor = System.Drawing.Color.Black;
            this.linkGamePanel1.Location = new System.Drawing.Point(0, 27);
            this.linkGamePanel1.Name = "linkGamePanel1";
            this.linkGamePanel1.Size = new System.Drawing.Size(600, 600);
            this.linkGamePanel1.TabIndex = 2;
            this.linkGamePanel1.TimeOver = false;
            this.linkGamePanel1.ScoringEvent += new LinkGame.LinkGamePanel.EventHandler(this.linkGamePanel1_ScoringEvent);
            this.linkGamePanel1.GameWinEvent += new LinkGame.LinkGamePanel.EventHandler(this.linkGamePanel1_GameWinEvent);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(983, 626);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTimer2);
            this.Controls.Add(this.myTimer1);
            this.Controls.Add(this.linkGamePanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Hill Again(山再连连看)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private LinkGamePanel linkGamePanel1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem war3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tearringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youxiToolStripMenuItem;
        private MyTimer myTimer1;
        private MyTimer myTimer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidhelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ashdGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSlogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceRangerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

