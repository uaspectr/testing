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
    public partial class ShowQuestType3 : Form
    {

       public string connString = "";

        public ShowQuestType3()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE [Вопросы2] SET Вопрос = " + "\"" + this.textBox1.Text + "\"" + " WHERE [Код]=" + ID.Text;

            OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connString);

            DataSet ds = new DataSet();

            dta.Fill(ds);


            cmd = "UPDATE [Вопросы2] SET Ответ = " + "\"" + this.textBox2.Text + "\"" + " WHERE [Код]=" + ID.Text;

            dta = new OleDbDataAdapter(cmd, connString);



            dta.Fill(ds);


            this.Close();
        }
    }
}
