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
    public partial class Добавление_учетных_записей : Form
    {
        public Добавление_учетных_записей()
        {
            InitializeComponent();
        }

       public  string connstring = "";

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                string qry = "INSERT INTO Autentification (Login,[Password],[User],Administration,Post,Change_structure) Values (" + "\"" + Login.Text + "\"" + "," + "\"" + Password.Text + "\"" + "," + "\"" + FIO.Text + "\"" + "," + checkBox1.Checked + "," + "\"" + Status.Text + "\"" + "," + checkBox2.Checked + ")";
                OleDbDataAdapter dta = new OleDbDataAdapter(qry, connstring);

                DataSet ds = new DataSet();

                dta.Fill(ds);

                MessageBox.Show("Пользователь успешно добавлен");

                this.Close();
            //}
            ////catch
            ////{
            ////    MessageBox.Show("Не удалось добавить пользователя");
            ////}
        }
    }
}
