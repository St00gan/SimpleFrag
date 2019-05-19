namespace ZBase
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DiscordBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BunnyhopCheck = new System.Windows.Forms.CheckBox();
            this.GithubBTN = new System.Windows.Forms.Button();
            this.ESPCheck = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DiscordBTN
            // 
            this.DiscordBTN.Location = new System.Drawing.Point(12, 64);
            this.DiscordBTN.Name = "DiscordBTN";
            this.DiscordBTN.Size = new System.Drawing.Size(166, 23);
            this.DiscordBTN.TabIndex = 0;
            this.DiscordBTN.Text = "Join Discord";
            this.DiscordBTN.UseVisualStyleBackColor = true;
            this.DiscordBTN.Click += new System.EventHandler(this.DiscordBTN_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "SimpleFragV2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BunnyhopCheck
            // 
            this.BunnyhopCheck.AutoSize = true;
            this.BunnyhopCheck.Location = new System.Drawing.Point(12, 93);
            this.BunnyhopCheck.Name = "BunnyhopCheck";
            this.BunnyhopCheck.Size = new System.Drawing.Size(79, 17);
            this.BunnyhopCheck.TabIndex = 2;
            this.BunnyhopCheck.Text = "Bunny Hop";
            this.BunnyhopCheck.UseVisualStyleBackColor = true;
            // 
            // GithubBTN
            // 
            this.GithubBTN.Location = new System.Drawing.Point(12, 35);
            this.GithubBTN.Name = "GithubBTN";
            this.GithubBTN.Size = new System.Drawing.Size(166, 23);
            this.GithubBTN.TabIndex = 4;
            this.GithubBTN.Text = "Github Page";
            this.GithubBTN.UseVisualStyleBackColor = true;
            this.GithubBTN.Click += new System.EventHandler(this.GithubBTN_Click);
            // 
            // ESPCheck
            // 
            this.ESPCheck.AutoSize = true;
            this.ESPCheck.Location = new System.Drawing.Point(12, 116);
            this.ESPCheck.Name = "ESPCheck";
            this.ESPCheck.Size = new System.Drawing.Size(86, 17);
            this.ESPCheck.TabIndex = 7;
            this.ESPCheck.Text = "Overlay ESP";
            this.ESPCheck.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Glow ESP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 185);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(75, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "TriggerBot";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 139);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(79, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Radar ESP";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(142, 182);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(43, 20);
            this.domainUpDown1.TabIndex = 11;
            this.domainUpDown1.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "  Delay";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Enemy Only",
            "Visible Only"});
            this.comboBox1.Location = new System.Drawing.Point(99, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 255);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ESPCheck);
            this.Controls.Add(this.GithubBTN);
            this.Controls.Add(this.BunnyhopCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiscordBTN);
            this.Name = "Menu";
            this.Text = "SimpleFrag";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiscordBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox BunnyhopCheck;
        private System.Windows.Forms.Button GithubBTN;
        private System.Windows.Forms.CheckBox ESPCheck;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

