﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Testing
{
    public partial class ShowQuestType1 : Form
    {
        public ShowQuestType1()
        {
            InitializeComponent();
        }

        public string connString = "";

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE [Quest] SET Question = " + "\"" + this.textBox1.Text + "\"" + " WHERE [Code]=" + ID.Text;

            OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connString);

            DataSet ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Quest] SET Variant1 = " + "\"" + this.textBox2.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);



            dta.Fill(ds);



            cmd = "UPDATE [Quest] SET Variant2 = " + "\"" + this.textBox3.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);



            dta.Fill(ds);



            cmd = "UPDATE [Quest] SET Variant3 = " + "\"" + this.textBox4.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);





            cmd = "UPDATE [Quest] SET Variant4 = " + "\"" + this.textBox5.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);



            cmd = "UPDATE [Quest] SET Variant4 = " + "\"" + this.textBox5.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Quest] SET True_answer = " + "\"" + this.textBox6.Text + "\"" + " WHERE [Code]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


           
            
            
            

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
