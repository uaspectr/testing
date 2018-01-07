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
    public partial class AddQuest : Form
    {
        public AddQuest()
        {
            InitializeComponent();
        }


        TextBox textBox8 = new TextBox();
        Label label10 = new Label();
        public string connstring = "";

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (checkBox1.Checked == true)
                {

                    string cmd = "INSERT INTO [Вопросы] (Вопрос,Вариант1,Вариант2,Вариант3,Вариант4,Верный,Балл) Values (" + "\"" + textBox1.Text + "\"" + "," + "\"" + textBox2.Text + "\"" + "," + "\"" + textBox3.Text + "\"" + "," + "\"" + textBox4.Text + "\"" + "," + "\"" + textBox5.Text + "\"" + "," + "\"" + textBox6.Text + "\"" + "," + "\"" + textBox7.Text + "\"" + ")";

                    OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connstring);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);

                    MessageBox.Show("Вопрос успешно добавлен");
                }
           
                else if (checkBox2.Checked == true)
                {


                    string cmd = "INSERT INTO [Вопрос1] (Вопрос,Ответ1,Ответ2,Ответ3,Ответ4,Ответ5,Ответ6,Верный1,Верный2,Верный3,Верный4,Верный5,Верный6,Балл) Values (" + "\"" + textBox1.Text + "\"" + "," + "\"" + textBox2.Text + "\"" + "," + "\"" + textBox3.Text + "\"" + "," + "\"" + textBox4.Text + "\"" + "," + "\"" + textBox5.Text + "\"" + "," + "\"" + textBox6.Text + "\"" + "," +"\""+textBox8.Text+"\""+","+ checkBox4.Checked.ToString()+","+checkBox5.Checked.ToString()+","+checkBox6.Checked.ToString()+","+checkBox8.Checked.ToString()+","+checkBox9.Checked.ToString()+","+ checkBox7.Checked.ToString()+ "," + "\"" + textBox7.Text + "\"" + ")";

                    OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connstring);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);

                    MessageBox.Show("Вопрос успешно добавлен");


                }
                else if(checkBox3.Checked == true)
                {
                    string cmd = "INSERT INTO [Вопросы2] (Вопрос,Ответ,Балл) Values (" + "\"" + textBox1.Text + "\"" + "," +"\""+ textBox6.Text +"\""+","+textBox7.Text+ ")";

                    OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connstring);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);

                    MessageBox.Show("Вопрос успешно добавлен");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления!");
            }
            




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                textBox7.Text = "2";
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;

            }
            else
            {
                textBox7.Text = "";
                this.checkBox2.Enabled = true;
                this.checkBox3.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

           
            textBox8.Location = new System.Drawing.Point(143, 230);
            textBox8.Visible = true;
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new System.Drawing.Size(219, 20);
            textBox8.TabIndex = 6;

         

            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 230);
            label10.Name = "label7";
            label10.Size = new System.Drawing.Size(91, 13);
            label10.TabIndex = 11;
            label10.Text = "Ответ 6";


            if (this.checkBox2.Checked)
            {
                textBox7.Text = "3";
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;

                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                label6.Text = "Ответ 5";

                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                label9.Visible = true;

                Controls.Add(textBox8);
                Controls.Add(label10);


                

            }
            else
            {
                textBox7.Text = "";
                this.checkBox3.Enabled = true;
                this.checkBox1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Visible = false;
                label6.Text = "Верный ответ №";

                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                label9.Visible = false;
                Controls[Controls.Count - 1].Visible = false;
                Controls[Controls.Count - 2].Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked)
            {
                textBox7.Text = "4";
                this.checkBox2.Enabled = false;
                this.checkBox1.Enabled = false;
                
                textBox6.Enabled = true;
                textBox1.Enabled = true;
                label6.Text = "Верный вариант ответа";
                
                
            }
            else
            {
                textBox7.Text = "";
                this.checkBox2.Enabled = true;
                this.checkBox1.Enabled = true;

                textBox1.Enabled = false;
                textBox6.Enabled = false;   
            }
        }


    }
}
