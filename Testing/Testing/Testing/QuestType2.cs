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
    public partial class QuestType2 : Form
    {
        public QuestType2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox8.Text = "5";
            this.Close();
        }

        private void select_variant1(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
                this.textBox2.BackColor = Color.LightBlue;
            else
                this.textBox2.BackColor = SystemColors.Highlight;
        }

        private void select_variant2(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
                this.textBox3.BackColor = Color.LightBlue;
            else
                this.textBox3.BackColor = SystemColors.Highlight;
        }
        private void select_variant3(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked)
                this.textBox4.BackColor = Color.LightBlue;
            else
                this.textBox4.BackColor = SystemColors.Highlight;
        }
        private void select_variant4(object sender, EventArgs e)
        {
            if (this.checkBox4.Checked)
                this.textBox5.BackColor = Color.LightBlue;
            else
                this.textBox5.BackColor = SystemColors.Highlight;
        }
        private void select_variant5(object sender, EventArgs e)
        {
            if (this.checkBox5.Checked)
                this.textBox6.BackColor = Color.LightBlue;
            else
                this.textBox6.BackColor = SystemColors.Highlight;
        }
        private void select_variant6(object sender, EventArgs e)
        {
            if (this.checkBox6.Checked)
                this.textBox7.BackColor = Color.LightBlue;
            else
                this.textBox7.BackColor = SystemColors.Highlight;
        }
    }
}
