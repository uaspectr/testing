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
using System.Drawing.Printing;
using System.Collections;

namespace Testing
{
    public partial class TestResults : Form
    {
        public TestResults()
        {
            InitializeComponent();
        }

        public string connection_string = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            DataSet ds_r = new DataSet();

            if (comboBox1.Text == "Today_data(ДД.ММ.ГГГГ)")
            {
                string qry = "SELECT User,ID,Today_data,Graduate,Login FROM Tests_result WHERE Today_data=" + "\"" + textBox1.Text + "\"";

                OleDbDataAdapter dta_r = new OleDbDataAdapter(qry, connection_string);

                ds_r = new DataSet();

                dta_r.Fill(ds_r);
            }
            else if(comboBox1.Text =="Login")
            {
                string qry = "SELECT User,ID,Today_data,Graduate,Login FROM Tests_result WHERE Login=" + "\"" + textBox1.Text + "\"";

                OleDbDataAdapter dta_r = new OleDbDataAdapter(qry, connection_string);

                ds_r = new DataSet();

                dta_r.Fill(ds_r);
            }
            else if (comboBox1.Text == "Фамилия И.О.")
            {
                string qry = "SELECT User,ID,Today_data,Graduate,Login FROM Tests_result WHERE User=" + "\"" + textBox1.Text + "\"";

                OleDbDataAdapter dta_r = new OleDbDataAdapter(qry, connection_string);

                ds_r = new DataSet();

                dta_r.Fill(ds_r);
            }

            

            this.dataGridView1.DataSource = ds_r.Tables[0].DefaultView;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = 500;
            int y = 200;
            int cell_height = 0;
            printDocument1.DefaultPageSettings.Landscape = false;
            int colCount = dataGridView1.ColumnCount;
            int rowCount = dataGridView1.RowCount;

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;


            Font font = new Font("Times new roman", 12, FontStyle.Regular, GraphicsUnit.Point);
            Font fontfortext = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);
            Font fontForString = new Font("Times new roman", 12, FontStyle.Underline, GraphicsUnit.Point);

            int[] widthC = new int[colCount];

            int current_col = 0;
            int current_row = 0;


            int x_coard = 180;
            int y_coard = 100;

            while (current_col < colCount)
            {
                if (g.MeasureString(dataGridView1.Columns[current_col].HeaderText.ToString(), font).Width > widthC[current_col])
                {
                    widthC[current_col] = (int)g.MeasureString(dataGridView1.Columns[current_col].HeaderText.ToString(), font).Width;
                }
                current_col++;
            }

            while (current_row < rowCount)
            {
                while (current_col < colCount)
                {
                    if (g.MeasureString(dataGridView1[current_col, current_row].Value.ToString(), font).Width > widthC[current_col])
                    {
                        widthC[current_col] = (int)g.MeasureString(dataGridView1[current_col, current_row].Value.ToString(), font).Width;
                    }
                    current_col++;
                }
                current_col = 0;
                current_row++;
            }

            current_col = 0;
            current_row = 0;

            string value = "";

            int width = widthC[current_col] + 10;
            int height = dataGridView1[current_col, current_row].Size.Height;

            Rectangle cell_border;
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.Gray);


            UTF8Encoding utf8;
            utf8 = new UTF8Encoding();

            g.DrawString("ИТОГИ ТЕСТИРОВАНИЯ СОТРУДНИКОВ КОМПАНИИ RIGHTSIDE", font, brush, x_coard, y_coard);


            x = 200;



            while (current_col < colCount)
            {
                width = widthC[current_col] + 50;
                cell_height = dataGridView1[current_col, current_row].Size.Height;
                cell_border = new Rectangle(x, y, width, height);


                g.FillRectangle(Brushes.Gray, cell_border);

                g.DrawRectangle(new Pen(Color.Black), cell_border);
                value = dataGridView1.Columns[current_col].HeaderText.ToString();

                g.DrawString(value, font, brush, x, y);


                x += widthC[current_col] + 50;
                current_col++;
            }




            current_row = -1;
            while (current_row < rowCount)
            {
                while (current_col < colCount)
                {
                    width = widthC[current_col] + 50;
                    cell_height = dataGridView1[current_col, current_row].Size.Height;
                    cell_border = new Rectangle(x, y, width, height);

                    value = dataGridView1[current_col, current_row].Value.ToString();
                    g.DrawRectangle(new Pen(Color.Black), cell_border);
                    g.DrawString(value, fontfortext, brush, x, y);
                    x += widthC[current_col] + 50;
                    current_col++;
                }
                current_col = 0;
                current_row++;
                x = 200;
                y += cell_height;
            }


            y = y + 40;
            x = x + 55;
            g.DrawString("Today_data: ___________ ", font, brush, x, y);
            x = x + 250;
            g.DrawString("Подпись: ___________ ", font, brush, x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Margins marg = new Margins(10000, 10000, 10000, 10000);
            //printDocument1.DefaultPageSettings.Landscape = true;


            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;

            ppd.ShowDialog();

            printDocument1.Print();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Вывод_резльтатов_теста_из_базы view_results = new Вывод_резльтатов_теста_из_базы();

                view_results.connection_string = connection_string;



                string ID = dataGridView1[1, e.RowIndex].Value.ToString();

                view_results.ID = ID;

                string qry_for_show_results = "select * from [Answer1] where ID=" + "\"" + ID + "\"";
                string qry_for_show_results_part_2 = "select * from [Answer2] where ID=" + "\"" + ID + "\"";
                string qry_for_show_results_part_3 = "select * from [Answer3] where ID=" + "\"" + ID + "\"";
                string qry_for_count_1 = "SELECT COUNT(*) FROM [Answer1] where ID=" + "\"" + ID + "\"";
                string qry_for_count_2 = "SELECT COUNT(*) FROM [Answer2] where ID=" + "\"" + ID + "\"";
                string qry_for_count_3 = "SELECT COUNT(*) FROM [Answer3] where ID=" + "\"" + ID + "\"";


                //Запрос к бд на Answerы 1 части Questionов
                OleDbDataAdapter dta_for_show_results = new OleDbDataAdapter(qry_for_show_results, connection_string);

                DataSet ds_for_show_results = new DataSet();

                dta_for_show_results.Fill(ds_for_show_results);
                //Запрос к бд на Answerы 2 части Questionов
                OleDbDataAdapter dta_for_show_results_part_2 = new OleDbDataAdapter(qry_for_show_results_part_2, connection_string);

                DataSet ds_for_show_results_part_2 = new DataSet();

                dta_for_show_results_part_2.Fill(ds_for_show_results_part_2);

                //Запрос к бд на овтеты 3 части Questionов
                OleDbDataAdapter dta_for_show_results_part_3 = new OleDbDataAdapter(qry_for_show_results_part_3, connection_string);

                DataSet ds_for_show_results_part_3 = new DataSet();

                dta_for_show_results_part_3.Fill(ds_for_show_results_part_3);


                OleDbDataAdapter count_1 = new OleDbDataAdapter(qry_for_count_1, connection_string);

                DataSet ds_for_count1 = new DataSet();

                count_1.Fill(ds_for_count1);

                OleDbDataAdapter count_2 = new OleDbDataAdapter(qry_for_count_2, connection_string);

                DataSet ds_for_count2 = new DataSet();

                count_2.Fill(ds_for_count2);

                OleDbDataAdapter count_3 = new OleDbDataAdapter(qry_for_count_3, connection_string);

                DataSet ds_for_count3 = new DataSet();

                count_3.Fill(ds_for_count3);


                int k = 0;
                int textbox_size_x = 655;
                int textbox_size_y = 105;
                int textbox_location_x = 65;
                int textbox1_location_y = 25;
                int textbox2_location_y = textbox1_location_y + 111;
                int textbox3_location_y = textbox2_location_y + 111;
                int textbox4_location_y = textbox3_location_y + 111;
                int textbox5_location_y = textbox4_location_y + 111;
                Size size = new Size(textbox_size_x, textbox_size_y);
                while (k != Convert.ToInt32(ds_for_count1.Tables[0].Rows[0][0].ToString()))
                {
              

                    view_results.tabPage1.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox1_location_y), Size = size, Text = ds_for_show_results.Tables[0].Rows[k][4].ToString(), Multiline = true, Enabled = true, ReadOnly = true, SelectionStart = 0});
                    if (ds_for_show_results.Tables[0].Rows[k][5].ToString() == ds_for_show_results.Tables[0].Rows[k][6].ToString())
                    {
                        view_results.tabPage1.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = ds_for_show_results.Tables[0].Rows[k][5].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });
                        view_results.tabPage1.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox3_location_y), Size = size, Text = ds_for_show_results.Tables[0].Rows[k][6].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });
                    }
                    else
                    {
                        view_results.tabPage1.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = ds_for_show_results.Tables[0].Rows[k][5].ToString(), Multiline = true, Enabled = true, BackColor = Color.Red });
                        view_results.tabPage1.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox3_location_y), Size = size, Text = ds_for_show_results.Tables[0].Rows[k][6].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });

                    }
                   
                    textbox1_location_y = textbox3_location_y + 111;
                    textbox2_location_y = textbox1_location_y + 111;
                    textbox3_location_y = textbox2_location_y + 111;
                    k = k + 1;
                }

                k = 0;

                ArrayList lst_current_answer = new ArrayList();
                ArrayList lst_true_answer = new ArrayList();
                

                while (k != Convert.ToInt32(ds_for_count2.Tables[0].Rows[0][0].ToString()))
                {
                    for (int i = 5; i < 11; i++)
                    {
                        lst_current_answer.Add(ds_for_show_results_part_2.Tables[0].Rows[k][i].ToString());
                    }
                    for (int i = 11; i < 17; i++)
                    {
                        lst_true_answer.Add(ds_for_show_results_part_2.Tables[0].Rows[k][i].ToString());
                    }
                    k++;

                }

                k = 0;

                textbox_size_x = 655;
                textbox_size_y = 105;
                textbox_location_x = 65;
                textbox1_location_y = 25;
                textbox2_location_y = textbox1_location_y + 111;
                Color color;
                int itterator = 0;

                while (k != Convert.ToInt32(ds_for_count2.Tables[0].Rows[0][0].ToString()))
                {
                    view_results.tabPage2.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox1_location_y), Size = size, Text = ds_for_show_results_part_2.Tables[0].Rows[k][3].ToString(), Multiline = true, Enabled = true, ReadOnly = true, SelectionStart = 0 });
                    for (int i = 0+itterator; i < 6+itterator; i++)
                    {

                        if(lst_true_answer.Contains(lst_current_answer[i]))
                        {
                            color = Color.LightGreen;
                        }
                        else
                        {
                            color = Color.Red;
                        }

                        if (lst_current_answer[i].ToString() != "")
                        {
                        
                                view_results.tabPage2.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = lst_current_answer[i].ToString(), Multiline = true, Enabled = true, BackColor = color });

                                textbox2_location_y = textbox2_location_y + 111;
                        }

                    }

                    for (int i = 0 + itterator; i < 6 + itterator; i++)
                    {

                        if(!lst_current_answer.Contains(lst_true_answer[i]))
                        {
                            color = Color.YellowGreen;

                        if (lst_true_answer[i].ToString() != "")
                        

                            view_results.tabPage2.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = lst_true_answer[i].ToString(), Multiline = true, Enabled = true, BackColor = color });

                            textbox2_location_y = textbox2_location_y + 111;
                        }
            
                    }

                    textbox1_location_y = textbox2_location_y + 111;
                    textbox2_location_y = textbox1_location_y + 111;
                   
                    k = k + 1;
                    itterator = itterator + 6;
                }

                textbox_size_x = 655;
                textbox_size_y = 105;
                textbox_location_x = 65;
                textbox1_location_y = 25;
                textbox2_location_y = textbox1_location_y + 111;
                textbox3_location_y = textbox2_location_y + 111;
                textbox4_location_y = textbox3_location_y + 111;
                textbox5_location_y = textbox4_location_y + 111;
                
                size = new Size(textbox_size_x, textbox_size_y);
                k = 0;
                while (k != Convert.ToInt32(ds_for_count3.Tables[0].Rows[0][0].ToString()))
                {


                    view_results.tabPage3.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox1_location_y), Size = size, Text = ds_for_show_results_part_3.Tables[0].Rows[k][4].ToString(), Multiline = true, Enabled = true, ReadOnly = true, SelectionStart = 0 });
                    if (ds_for_show_results_part_3.Tables[0].Rows[k][5].ToString() == ds_for_show_results_part_3.Tables[0].Rows[k][6].ToString())
                    {
                        view_results.tabPage3.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = ds_for_show_results_part_3.Tables[0].Rows[k][5].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });
                        view_results.tabPage3.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox3_location_y), Size = size, Text = ds_for_show_results_part_3.Tables[0].Rows[k][6].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });
                    }
                    else
                    {
                        view_results.tabPage3.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox2_location_y), Size = size, Text = ds_for_show_results_part_3.Tables[0].Rows[k][5].ToString(), Multiline = true, Enabled = true, BackColor = Color.Red });
                        view_results.tabPage3.Controls.Add(new TextBox() { Location = new Point(textbox_location_x, textbox3_location_y), Size = size, Text = ds_for_show_results_part_3.Tables[0].Rows[k][6].ToString(), Multiline = true, Enabled = true, BackColor = Color.LightGreen });

                    }

                    textbox1_location_y = textbox3_location_y + 111;
                    textbox2_location_y = textbox1_location_y + 111;
                    textbox3_location_y = textbox2_location_y + 111;
                    k = k + 1;
                }

                view_results.Show();
            }
        }
    }
}
