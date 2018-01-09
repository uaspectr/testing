using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class QuestType1 : Form
    {

        List<int> lst = new List<int>();

       
       

        public QuestType1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void var1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "1";
            this.Close();
           
        }

        private void var2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "2";
            this.Close();
        }

        private void var3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "3";
            this.Close();
        }

        private void var4_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "4";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "5";
            this.Close();
        }

        private void select_variant(object sender, EventArgs e)
        {
            this.var1.BackColor = Color.LightBlue;
        }

        private void select_variant1(object sender, EventArgs e)
        {
            this.var2.BackColor = Color.LightBlue;
        }

        private void select_variant3(object sender, EventArgs e)
        {
            this.var3.BackColor = Color.LightBlue;
        }

        private void select_variant4(object sender, EventArgs e)
        {
            this.var4.BackColor = Color.LightBlue;
        }

        private void left_variant(object sender, EventArgs e)
        {
            this.var1.BackColor = SystemColors.Highlight;
        }

        private void left_variant1(object sender, EventArgs e)
        {
            this.var2.BackColor = SystemColors.Highlight;
        }

        private void left_variant2(object sender, EventArgs e)
        {
            this.var3.BackColor = SystemColors.Highlight;
        }

        private void left_variant3(object sender, EventArgs e)
        {
            this.var4.BackColor = SystemColors.Highlight;
        }
     

       
    }
}
