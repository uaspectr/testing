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
    public partial class QusetBase : Form
    {
        public QusetBase()
        {
            InitializeComponent();
        }

        public string connstring = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                ShowQuestType1 sqt1 = new ShowQuestType1();

                string ID = "";

                ID = dataGridView1[0, e.RowIndex].Value.ToString();

                string CmdText = "SELECT * FROM " + "[Quest]"
                                   + " WHERE [Code] = " + e.RowIndex + 1;


                OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(CmdText, connstring);
                // создаем объект DataSet
                DataSet datas = new DataSet();
                // заполняем таблицу Order  
                // данными с базы данных
                dataAdapter3.Fill(datas);


                DataTable dt2 = new DataTable();

                dt2 = datas.Tables[0];

                sqt1.ID.Text = ID;
                sqt1.textBox1.Text = dataGridView1[1,e.RowIndex].Value.ToString();

                sqt1.textBox2.Text = dataGridView1[2,e.RowIndex].Value.ToString();
                sqt1.textBox3.Text = dataGridView1[3,e.RowIndex].Value.ToString();
                sqt1.textBox4.Text = dataGridView1[4,e.RowIndex].Value.ToString();
                sqt1.textBox5.Text = dataGridView1[5,e.RowIndex].Value.ToString();
                sqt1.textBox6.Text = dataGridView1[6,e.RowIndex].Value.ToString();

                sqt1.button1.Enabled = false;
                sqt1.connString = connstring;
                sqt1.Show();


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowQuestType2 sqt2 = new ShowQuestType2();

                string ID = "";

                ID = dataGridView1[0, e.RowIndex].Value.ToString();

                string CmdText = "SELECT * FROM " + "[Quest1]"
                                   + " WHERE [Code] = " + e.RowIndex + 1;


                OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(CmdText, connstring);
                // создаем объект DataSet
                DataSet datas = new DataSet();
                // заполняем таблицу Order  
                // данными с базы данных
                dataAdapter3.Fill(datas);


                DataTable dt2 = new DataTable();

                dt2 = datas.Tables[0];

                sqt2.ID.Text = ID;


                sqt2.textBox1.Text = dataGridView2[1,e.RowIndex].Value.ToString();
                sqt2.textBox2.Text = dataGridView2[2,e.RowIndex].Value.ToString();
                sqt2.textBox3.Text = dataGridView2[3,e.RowIndex].Value.ToString();
                sqt2.textBox4.Text = dataGridView2[4,e.RowIndex].Value.ToString();
                sqt2.textBox5.Text = dataGridView2[5,e.RowIndex].Value.ToString();
                sqt2.textBox6.Text = dataGridView2[6,e.RowIndex].Value.ToString();
                sqt2.textBox7.Text = dataGridView2[7, e.RowIndex].Value.ToString();

                sqt2.checkBox4.Checked = Convert.ToBoolean(dataGridView2[8, e.RowIndex].Value.ToString());
                sqt2.checkBox5.Checked = Convert.ToBoolean(dataGridView2[9, e.RowIndex].Value.ToString());
                sqt2.checkBox6.Checked = Convert.ToBoolean(dataGridView2[10, e.RowIndex].Value.ToString());
                sqt2.checkBox8.Checked = Convert.ToBoolean(dataGridView2[11, e.RowIndex].Value.ToString());
                sqt2.checkBox9.Checked = Convert.ToBoolean(dataGridView2[12, e.RowIndex].Value.ToString());
                sqt2.checkBox7.Checked = Convert.ToBoolean(dataGridView2[13, e.RowIndex].Value.ToString());


                sqt2.button1.Enabled = false;
                sqt2.connString = connstring;
                sqt2.Show();


            }
        
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowQuestType3 sqt3 = new ShowQuestType3();

                string ID = "";

                ID = dataGridView1[0, e.RowIndex].Value.ToString();

                string CmdText = "SELECT * FROM " + "[Quest2]"
                                   + " WHERE [Code] = " + e.RowIndex + 1;


                OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(CmdText, connstring);
                // создаем объект DataSet
                DataSet datas = new DataSet();
                // заполняем таблицу Order  
                // данными с базы данных
                dataAdapter3.Fill(datas);


                DataTable dt2 = new DataTable();

                dt2 = datas.Tables[0];

                sqt3.ID.Text = ID;


                sqt3.textBox1.Text = dataGridView3[1, e.RowIndex].Value.ToString();
                sqt3.textBox2.Text = dataGridView3[2, e.RowIndex].Value.ToString();              

                sqt3.button1.Enabled = false;
                sqt3.connString = connstring;
                sqt3.Show();


            }
        }
        
    }
}
