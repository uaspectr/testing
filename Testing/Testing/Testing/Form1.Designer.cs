namespace Testing
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора Codeа.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переподключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соединениеСБазойДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdministrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрРезультатовТестовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрИсторииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.структураТестаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьБазуQuestionовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеQuestionовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.полнаяЗагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отдельныйQuestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.AdministrationToolStripMenuItem,
            this.структураТестаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(453, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переподключитьсяToolStripMenuItem,
            this.соединениеСБазойДанныхToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // переподключитьсяToolStripMenuItem
            // 
            this.переподключитьсяToolStripMenuItem.Name = "переподключитьсяToolStripMenuItem";
            this.переподключитьсяToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.переподключитьсяToolStripMenuItem.Text = "Переподключиться";
            this.переподключитьсяToolStripMenuItem.Click += new System.EventHandler(this.переподключитьсяToolStripMenuItem_Click);
            // 
            // соединениеСБазойДанныхToolStripMenuItem
            // 
            this.соединениеСБазойДанныхToolStripMenuItem.Name = "соединениеСБазойДанныхToolStripMenuItem";
            this.соединениеСБазойДанныхToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.соединениеСБазойДанныхToolStripMenuItem.Text = "Соединение с базой данных";
            this.соединениеСБазойДанныхToolStripMenuItem.Click += new System.EventHandler(this.соединениеСБазойДанныхToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // AdministrationToolStripMenuItem
            // 
            this.AdministrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрРезультатовТестовToolStripMenuItem,
            this.просмотрИсторииToolStripMenuItem,
            this.добавитьПользователяToolStripMenuItem,
            this.удалитьПользователяToolStripMenuItem});
            this.AdministrationToolStripMenuItem.Name = "AdministrationToolStripMenuItem";
            this.AdministrationToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.AdministrationToolStripMenuItem.Text = "Administration";
            // 
            // просмотрРезультатовТестовToolStripMenuItem
            // 
            this.просмотрРезультатовТестовToolStripMenuItem.Name = "просмотрРезультатовТестовToolStripMenuItem";
            this.просмотрРезультатовТестовToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.просмотрРезультатовТестовToolStripMenuItem.Text = "Просмотр результатов тестов";
            this.просмотрРезультатовТестовToolStripMenuItem.Click += new System.EventHandler(this.просмотрРезультатовТестовToolStripMenuItem_Click);
            // 
            // просмотрИсторииToolStripMenuItem
            // 
            this.просмотрИсторииToolStripMenuItem.Name = "просмотрИсторииToolStripMenuItem";
            this.просмотрИсторииToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.просмотрИсторииToolStripMenuItem.Text = "Просмотр истории";
            this.просмотрИсторииToolStripMenuItem.Click += new System.EventHandler(this.просмотрИсторииToolStripMenuItem_Click);
            // 
            // добавитьПользователяToolStripMenuItem
            // 
            this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
            this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
            this.добавитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.добавитьПользователяToolStripMenuItem_Click);
            // 
            // удалитьПользователяToolStripMenuItem
            // 
            this.удалитьПользователяToolStripMenuItem.Name = "удалитьПользователяToolStripMenuItem";
            this.удалитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.удалитьПользователяToolStripMenuItem.Text = "Удалить пользователя";
            this.удалитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.удалитьПользователяToolStripMenuItem_Click);
            // 
            // структураТестаToolStripMenuItem
            // 
            this.структураТестаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузитьБазуQuestionовToolStripMenuItem,
            this.добавлениеQuestionовToolStripMenuItem});
            this.структураТестаToolStripMenuItem.Name = "структураТестаToolStripMenuItem";
            this.структураТестаToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.структураТестаToolStripMenuItem.Text = "Структура теста";
            // 
            // выгрузитьБазуQuestionовToolStripMenuItem
            // 
            this.выгрузитьБазуQuestionовToolStripMenuItem.Name = "выгрузитьБазуQuestionовToolStripMenuItem";
            this.выгрузитьБазуQuestionовToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.выгрузитьБазуQuestionовToolStripMenuItem.Text = "Выгрузить базу Questionов";
            this.выгрузитьБазуQuestionовToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьБазуQuestionовToolStripMenuItem_Click);
            // 
            // добавлениеQuestionовToolStripMenuItem
            // 
            this.добавлениеQuestionовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.полнаяЗагрузкаToolStripMenuItem,
            this.отдельныйQuestionToolStripMenuItem});
            this.добавлениеQuestionовToolStripMenuItem.Name = "добавлениеQuestionовToolStripMenuItem";
            this.добавлениеQuestionовToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.добавлениеQuestionовToolStripMenuItem.Text = "Добавление Questionов";
            // 
            // полнаяЗагрузкаToolStripMenuItem
            // 
            this.полнаяЗагрузкаToolStripMenuItem.Name = "полнаяЗагрузкаToolStripMenuItem";
            this.полнаяЗагрузкаToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.полнаяЗагрузкаToolStripMenuItem.Text = "Полная загрузка";
            this.полнаяЗагрузкаToolStripMenuItem.Visible = false;
            this.полнаяЗагрузкаToolStripMenuItem.Click += new System.EventHandler(this.полнаяЗагрузкаToolStripMenuItem_Click);
            // 
            // отдельныйQuestionToolStripMenuItem
            // 
            this.отдельныйQuestionToolStripMenuItem.Name = "отдельныйQuestionToolStripMenuItem";
            this.отдельныйQuestionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.отдельныйQuestionToolStripMenuItem.Text = "Отдельный Question";
            this.отдельныйQuestionToolStripMenuItem.Click += new System.EventHandler(this.отдельныйQuestionToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.Login);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 263);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Соединение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(262, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Закрыть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Вход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(148, 120);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(189, 20);
            this.Password.TabIndex = 1;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(148, 76);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(189, 20);
            this.Login.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(117, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "Начать тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(453, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование сотрудников Rightside";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переподключитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdministrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрИсторииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьПользователяToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.ToolStripMenuItem структураТестаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьБазуQuestionовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеQuestionовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem полнаяЗагрузкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отдельныйQuestionToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem соединениеСБазойДанныхToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem просмотрРезультатовТестовToolStripMenuItem;


    }
}

