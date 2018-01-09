namespace Testing
{
    partial class QuestType1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.var1 = new System.Windows.Forms.TextBox();
            this.var2 = new System.Windows.Forms.TextBox();
            this.var3 = new System.Windows.Forms.TextBox();
            this.var4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(62, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(655, 105);
            this.textBox1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Answer №";
            this.label5.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 635);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(555, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Завершить тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // var1
            // 
            this.var1.BackColor = System.Drawing.SystemColors.Highlight;
            this.var1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.var1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.var1.Location = new System.Drawing.Point(62, 136);
            this.var1.Multiline = true;
            this.var1.Name = "var1";
            this.var1.ReadOnly = true;
            this.var1.Size = new System.Drawing.Size(655, 105);
            this.var1.TabIndex = 12;
            this.var1.Click += new System.EventHandler(this.var1_Click);
            this.var1.MouseEnter += new System.EventHandler(this.select_variant);
            this.var1.MouseLeave += new System.EventHandler(this.left_variant);
            // 
            // var2
            // 
            this.var2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.var2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.var2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.var2.Location = new System.Drawing.Point(62, 247);
            this.var2.Multiline = true;
            this.var2.Name = "var2";
            this.var2.ReadOnly = true;
            this.var2.Size = new System.Drawing.Size(655, 105);
            this.var2.TabIndex = 13;
            this.var2.Click += new System.EventHandler(this.var2_Click);
            this.var2.MouseEnter += new System.EventHandler(this.select_variant1);
            this.var2.MouseLeave += new System.EventHandler(this.left_variant1);
            // 
            // var3
            // 
            this.var3.BackColor = System.Drawing.SystemColors.Highlight;
            this.var3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.var3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.var3.Location = new System.Drawing.Point(62, 358);
            this.var3.Multiline = true;
            this.var3.Name = "var3";
            this.var3.ReadOnly = true;
            this.var3.Size = new System.Drawing.Size(655, 105);
            this.var3.TabIndex = 14;
            this.var3.Click += new System.EventHandler(this.var3_Click);
            this.var3.MouseEnter += new System.EventHandler(this.select_variant3);
            this.var3.MouseLeave += new System.EventHandler(this.left_variant2);
            // 
            // var4
            // 
            this.var4.BackColor = System.Drawing.SystemColors.Highlight;
            this.var4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.var4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.var4.Location = new System.Drawing.Point(62, 469);
            this.var4.Multiline = true;
            this.var4.Name = "var4";
            this.var4.ReadOnly = true;
            this.var4.Size = new System.Drawing.Size(655, 105);
            this.var4.TabIndex = 15;
            this.var4.Click += new System.EventHandler(this.var4_Click);
            this.var4.MouseEnter += new System.EventHandler(this.select_variant4);
            this.var4.MouseLeave += new System.EventHandler(this.left_variant3);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(62, 600);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Принять Answer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // QuestType1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 654);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.var4);
            this.Controls.Add(this.var3);
            this.Controls.Add(this.var2);
            this.Controls.Add(this.var1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Name = "QuestType1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuestType1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox var1;
        public System.Windows.Forms.TextBox var2;
        public System.Windows.Forms.TextBox var3;
        public System.Windows.Forms.TextBox var4;
        private System.Windows.Forms.Button button2;
    }
}