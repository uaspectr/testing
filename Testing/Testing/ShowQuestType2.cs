using System;
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
    public partial class ShowQuestType2 : Form
    {
        public string connString = "";

        public ShowQuestType2()
        {
            InitializeComponent();
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

        private void textBox4_Validated(object sender, EventArgs e)
        {

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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE [Вопрос1] SET Вопрос = " + "\"" + this.textBox1.Text + "\"" + " WHERE [Код]=" + ID.Text;

            OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connString);

            DataSet ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопрос1] SET Ответ1 = " + "\"" + this.textBox2.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);



            dta.Fill(ds);



            cmd = "UPDATE [Вопрос1] SET Ответ2 = " + "\"" + this.textBox3.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);



            dta.Fill(ds);



            cmd = "UPDATE [Вопрос1] SET Ответ3 = " + "\"" + this.textBox4.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);





            cmd = "UPDATE [Вопрос1] SET Ответ4 = " + "\"" + this.textBox5.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);



            cmd = "UPDATE [Вопрос1] SET Ответ5 = " + "\"" + this.textBox6.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопрос1] SET Ответ6 = " + "\"" + this.textBox7.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопрос1] SET Верный1 = " + this.checkBox4.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);

            cmd = "UPDATE [Вопрос1] SET Верный2 = " + this.checkBox5.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);

            cmd = "UPDATE [Вопрос1] SET Верный3 = " + this.checkBox6.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);

            cmd = "UPDATE [Вопрос1] SET Верный4 = " + this.checkBox8.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопрос1] SET Верный5 = " + this.checkBox9.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопрос1] SET Верный6 = " + this.checkBox7.Checked + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);

            ds = new DataSet();

            dta.Fill(ds);


            this.Close();



        }
    }
}
