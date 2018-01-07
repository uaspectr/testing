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
    public partial class Delete_user : Form
    {


         public string connstring = "";
        public Delete_user()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

            string cmd = "DELETE * FROM Авторизация WHERE Код="+ id.ToString();

            string cmd1 = "SELECT Логин,Пароль,ФИО,Должность FROM [Авторизация]";


            OleDbDataAdapter dta1 = new OleDbDataAdapter(cmd, connstring);

            OleDbDataAdapter dta = new OleDbDataAdapter(cmd1, connstring);

            DataSet ds1 = new DataSet();

            dta1.Fill(ds1);

            DataSet ds = new DataSet();

            dta.Fill(ds);

            Delete_user dltus = new Delete_user();


            dltus.dataGridView1.DataSource = ds.Tables[0].DefaultView;

            this.Close();

            dltus.Show();

        }
    }
}
