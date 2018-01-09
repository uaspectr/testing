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
using System.IO;
using System.Threading;
using System.Collections;

namespace Testing
{
    public partial class Form1 : Form
    {

        

        BinaryWriter bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251)); //Поток для записи в бинарный файл логов событий в программме
        BinaryWriter bw2; //Поток для записи в бинарный файл логов тестирования
        StreamWriter strmwrt;
        string connt = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="; // Первая часть строки соединения с базой данных, содержащая версию программы
        string connection_string = ""; //Сюда добавляется путь к базе данных

        
        
 
        // Функция генирирования случайных чисел без повторений
        ArrayList rndarray (int MaxValue,int Count_of_quest)
        {

        ArrayList myArray = new ArrayList();
        Random r = new Random();
        // добавление неповторяющихся элементов
        while(myArray.Count != MaxValue)
        {
            int temp = r.Next(1, Count_of_quest);
            if (!myArray.Contains(temp))
                myArray.Add(temp);
        }

        return myArray;
        }


       


        public Form1()
        {
            
            InitializeComponent();
            bw.Write(DateTime.Now + "\r\n"); // Запись в логи событий даты запуска программы
            bw.Write("Program is started\r\n"); // Запись события
            bw.Close();//закрытие потока записи
           
            //Попытка соединится с базой данных по заданному пути, если файла с путем не существует, открывается диалоговое окно выбора пути к файлу бд
            try
            {
                StreamReader strread = new StreamReader(File.OpenRead("path.txt"), Encoding.GetEncoding(1251));
                connection_string= connt + strread.ReadLine();
                strread.Close();
            }
            catch
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    connection_string = connt + openFileDialog1.FileName;
                }

                StreamWriter strwrite = new StreamWriter(File.OpenWrite("path.txt"), Encoding.GetEncoding(1251));
                strwrite.WriteLine(openFileDialog1.FileName);
                strwrite.Close();
            }

            

        }


        //Функция подсчета Graduateов для Questionов с несколькими Variantами Answerа
        double graduate(ArrayList lst1, ArrayList lst2)
        {
            double grade = 0;
            List<int> array1 = new List<int>();
            List<int> array2 = new List<int>();
            int tmp1 = 0;
            int tmp2 = 0;

            for (int i = 0; i < 6; i++)
            {
                //bw2.Write("Был выбран Variant Answerа: " + lst1[i].ToString() + "\r\n");
                //bw2.Write("True_answer Variant Answerа: " + lst2[i].ToString() + "\r\n");
                //strmwrt.WriteLine("Был выбран Variant Answerа: " + lst1[i].ToString() + "\r\n");
                //strmwrt.WriteLine("True_answer Variant Answerа: " + lst2[i].ToString() + "\r\n");
                if (lst1[i].ToString() == "True")
                {
                    tmp2++;
                    array1.Add(i);
                    
                }
                if (lst2[i].ToString() == "True")
                {
                    tmp1++;
                    array2.Add(i);
                }
            }

            if (array1.SequenceEqual(array2) && tmp1==tmp2)
            {
                grade = 3.0;
                bw2.Write("Все Answerы отмечены верно, Graduate за Question 3!\r\n");
                strmwrt.WriteLine("Все Answerы отмечены верно, Graduate за Question 3!\r\n");
            }
            else if (tmp2 > tmp1)
            {
                grade = 0;
                bw2.Write("Было отмечено слишком много пунктов, полученный Graduate за Question 0\r\n");
                strmwrt.WriteLine("Было отмечено слишком много пунктов, полученный Graduate за Question 0\r\n");
            }

            int tmp3 = 0;
            if ((tmp1 > tmp2) || (!array1.SequenceEqual(array2) && tmp1 == tmp2))
            {
                for (int i = 0; i < array1.Count; i++)
                {
                    for (int j = 0; j < array2.Count; j++)
                    {
                        if(array1[i]==array2[j])
                            tmp3++;
                    }

                }


                grade = Convert.ToDouble(tmp3) * (3.0 / Convert.ToDouble(tmp1));
                bw2.Write("Из "+tmp1.ToString()+" верных Variantов отвечено верно "+tmp3.ToString() +" полученный Graduate: " + grade.ToString() + "\r\n");
                strmwrt.WriteLine("Из " + tmp1.ToString() + " верных Variantов отвечено верно " + tmp3.ToString() + " полученный Graduate: " + grade.ToString() + "\r\n");
            }

            



            


           
            



            return grade;

        }

         //string connection_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\DTBSFORTEST.accdb";
        

        //Функция, навешанная на кнопку вход. Аутентификация и Autentification
        private void button2_Click(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));

            //try
            //{

                

                bw2 = new BinaryWriter(File.Open("logs_for_test.lg", FileMode.Append), Encoding.GetEncoding(1251));

                bw.Write(DateTime.Now.ToString() + "\r\n");
                bw.Write("Login:" + Login.Text + "\r\n");
                bw2.Write(DateTime.Now.ToString() + "\r\n");
                bw2.Write("Login:" + Login.Text + "\r\n");
                bw.Write("Password:" + Password.Text + "\r\n");
                bw2.Close();

                string cmdtxt = "SELECT * FROM [Autentification] WHERE [Login] =" + "\"" + Login.Text + "\"" + " AND [Password] =" + "\"" + Password.Text + "\"";

                OleDbDataAdapter dta3 = new OleDbDataAdapter(cmdtxt, connection_string);


                //создаем Today_data сет, куда запишем данные из запроса
                DataSet dt = new DataSet();

                //записываем данные по запросу
                dta3.Fill(dt);

                if (dt.Tables[0].Rows.Count == 1)
                {
                    //Выводим сообщение добро пожаловать, ИМЯ_ПОЛЬЗОВАТЕЛЯ
                    MessageBox.Show("Добро пожаловать, " + dt.Tables[0].Rows[0][3].ToString() + "!");
                    //Изменяем заголовок программы
                    string str = this.Text = "Тестирование сотрудников RightSide, " + dt.Tables[0].Rows[0][3].ToString() + ", " + dt.Tables[0].Rows[0][5].ToString();
                    //выдаем права в соAnswerствии с записью в базе данных:
                    //Добавление записей
                    this.AdministrationToolStripMenuItem.Visible = Convert.ToBoolean(dt.Tables[0].Rows[0][4].ToString());
                    this.структураТестаToolStripMenuItem.Visible = Convert.ToBoolean(dt.Tables[0].Rows[0][6].ToString());
                    panel1.Visible = false;
                    this.Password.Select();
                    this.Password.ScrollToCaret();
                    bw.Write(DateTime.Now.ToString() + "\r\n");
                    bw.Write(" Succesfull" + "\r\n");
                    bw.Close();


                }
                //Иначе вывести ошибку
                else
                {
                    MessageBox.Show("Ошибка аутентификации!");
                    Password.Clear();
                    bw.Write(DateTime.Now.ToString() + "\r\n");
                    bw.Write(" Access error" + "\r\n");
                    bw.Close();
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Была выбрана не верная база данных!");
            //    bw.Write(DateTime.Now.ToString() + "\r\n");
            //    bw.Write(" Access error, inncorrect data base" + "\r\n");
            //    bw.Close();
            //}
            
        }
        // Выход
        private void button3_Click(object sender, EventArgs e)
        {

            bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));
            bw.Write(DateTime.Now.ToString() + "\r\n");
            bw.Write("Exit From Application" + "\r\n");
            bw.Close();
            Application.Exit();
        }

        //Выход из проги
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));
            bw.Write(DateTime.Now.ToString()+"\r\n");
            bw.Write("Exit From Application"+"\r\n");
            bw.Close();
            Application.Exit();
        }

        //Реконнект
        private void переподключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));
            bw.Write(DateTime.Now.ToString()+"\r\n");
            bw.Write("Exit From Application For Reconnect"+"\r\n");
            bw.Close();
            Password.Text = "";
            this.AcceptButton = button2;
            panel1.Visible = true;
            this.Password.Select();
            this.Password.ScrollToCaret();
        }

        //Выгрузка базы всех Questionов
        public void выгрузитьБазуQuestionовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            try
            {
                string cmd = "SELECT * FROM [Quest]"; //Запрос на выборку всех Questionов перого типа

                OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connection_string);

                DataSet ds = new DataSet();

                dta.Fill(ds);

                QusetBase qstbs = new QusetBase();



                qstbs.dataGridView1.DataSource = ds.Tables[0].DefaultView;



                string cmd1 = "SELECT * FROM [Quest1]";// То же самое для второго типа

                OleDbDataAdapter dta1 = new OleDbDataAdapter(cmd1, connection_string);

                DataSet ds1 = new DataSet();

                dta1.Fill(ds1);





                qstbs.dataGridView2.DataSource = ds1.Tables[0].DefaultView;

                string cmd2 = "SELECT * FROM [Quest2]";// То же для третьего типа

                OleDbDataAdapter dta2 = new OleDbDataAdapter(cmd2, connection_string);

                DataSet ds2 = new DataSet();

                dta2.Fill(ds2);



                qstbs.connstring = connection_string;

                qstbs.dataGridView3.DataSource = ds2.Tables[0].DefaultView;




                qstbs.Show();// Вывести форму на экран
            }
            catch
            {
                MessageBox.Show("Не верно выбрана база данных!");
            }
        }

        private void полнаяЗагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        //Это я удалил за бесполезностью
        
        
        }


        //Добавление Questionов
        private void отдельныйQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddQuest addqst = new AddQuest();

                addqst.textBox1.Enabled = false;
                addqst.textBox2.Enabled = false;
                addqst.textBox2.Enabled = false;
                addqst.textBox3.Enabled = false;
                addqst.textBox4.Enabled = false;
                addqst.textBox5.Enabled = false;
                addqst.textBox6.Enabled = false;



                addqst.connstring = connection_string;
                addqst.Show();
            }
            catch
            {
                MessageBox.Show("Неверно выбрана база данных");
            }


        }


        //Добавление пользователей

        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Добавление_учетных_записей Add_Account = new Добавление_учетных_записей();

                string qry1 = "SELECT COUNT(*) FROM [Autentification]";
                OleDbDataAdapter dta4 = new OleDbDataAdapter(qry1, connection_string);
                DataSet ds1 = new DataSet();



                dta4.Fill(ds1);

                Add_Account.ID.Text = ((Convert.ToInt32(ds1.Tables[0].Rows[0][0])) + 1).ToString();
                Add_Account.connstring = connection_string;
                Add_Account.Show();
            }
            catch
            {
                MessageBox.Show("Неверно выбрана база данных!");
            }
        }

        //Удаление пользователей
        private void удалитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "SELECT Code,Login,Password,User,Post FROM [Autentification]";

                OleDbDataAdapter dta = new OleDbDataAdapter(cmd, connection_string);

                DataSet ds = new DataSet();

                dta.Fill(ds);

                Delete_user dltus = new Delete_user();


                dltus.dataGridView1.DataSource = ds.Tables[0].DefaultView;
                dltus.connstring = connection_string;
                dltus.Show();
            }
            catch
            {
                MessageBox.Show("Не верно выбрана база данных!");
            }
        }


        //Просомтр логов
        private void просмотрИсторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            string path = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }

            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open), Encoding.GetEncoding(1251));

            ShowLogs shlg = new ShowLogs();

           

                while (br.PeekChar() > -1)
                {
                    shlg.textBox1.Text += br.ReadString();
                }

                shlg.Show();
            }
            catch
            {
                MessageBox.Show("Был выбран файл не верного формата!");
            }

        }

        //Начало тестирования
        private void button1_Click(object sender, EventArgs e)
        {

            bool break_flag = false;
            //try
            //{
                string qry_for_id_s = "SELECT * From ID_session";

                OleDbDataAdapter dta_id_s = new OleDbDataAdapter(qry_for_id_s, connection_string);

                DataSet dts_id_s = new DataSet();

                dta_id_s.Fill(dts_id_s);


                int id_s = Convert.ToInt32(dts_id_s.Tables[0].Rows[0][1].ToString());

                id_s = id_s+1;

                string qry_for_upd_id_s = "UPDATE [ID_session] SET ID = " + id_s.ToString();

                dta_id_s = new OleDbDataAdapter(qry_for_upd_id_s, connection_string);

                dts_id_s = new DataSet();

                dta_id_s.Fill(dts_id_s);

                bw2 = new BinaryWriter(File.Open("logs_for_test.lg", FileMode.Append), Encoding.GetEncoding(1251));
               

                if(!Directory.Exists(Login.Text))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Login.Text);
                }

                bw2.Write(DateTime.Now.ToString() + "\r\n");
                bw2.Write("Start testing \r\n");//Это все логи


                string path = Application.StartupPath+"\\"+ Login.Text + "\\" + "testlog_" + DateTime.Now.ToShortDateString()+"_"+DateTime.Now.Hour.ToString()+"_"+ DateTime.Now.Minute.ToString() +"_"+DateTime.Now.Second.ToString()+ ".doc";

               

                strmwrt = new StreamWriter(path);

                strmwrt.WriteLine(DateTime.Now.ToString() + "\r\n");
                strmwrt.WriteLine("Start testing by" +Login.Text +"\r\n");
                

                int i = 0;

                Random rnd = new Random(1);


                ArrayList arrlst = new ArrayList();
                ArrayList arrlst2 = new ArrayList();
                ArrayList arrlst3 = new ArrayList();

                QuestType1 qst1 = new QuestType1();
                QuestType2 qst2 = new QuestType2();
                QuestType3 qst3 = new QuestType3();


                string qry2 = "Select * From Quest";
                string qry3 = "Select * From Quest1";
                string qry4 = "Select * From Quest2";

                OleDbDataAdapter dtaAd = new OleDbDataAdapter(qry2, connection_string);

                DataSet dsforcount = new DataSet();

                dtaAd.Fill(dsforcount);


                OleDbDataAdapter dtaAd1 = new OleDbDataAdapter(qry3, connection_string);

                DataSet dsforcount1 = new DataSet();

                dtaAd1.Fill(dsforcount1);


                OleDbDataAdapter dtaAd2 = new OleDbDataAdapter(qry4, connection_string);

                DataSet dsforcount2 = new DataSet();

                dtaAd2.Fill(dsforcount2);
                // Загрузка Questionов из базы данных


                
            
                int count_of_questions_type1 = dsforcount.Tables[0].Rows.Count; //Подсчет количества Questionов в бд для фуникции рандомной выборки Questionов
                int count_of_questions_type2 = dsforcount1.Tables[0].Rows.Count;
                int count_of_questions_type3 = dsforcount2.Tables[0].Rows.Count;

                arrlst = rndarray(25, count_of_questions_type1); //Формируем рандомно номера Questionов каждого типа
                arrlst2 = rndarray(10, count_of_questions_type2);
                arrlst3 = rndarray(5, count_of_questions_type3);

                int grade = 0;

                 string qry_for_name1 = "SELECT User FROM Autentification WHERE Login=" + "\"" + Login.Text + "\"";

                 OleDbDataAdapter dta_name1 = new OleDbDataAdapter(qry_for_name1, connection_string);

                 DataSet ds_name1 = new DataSet();

                 dta_name1.Fill(ds_name1);

                 string user1 = ds_name1.Tables[0].Rows[0][0].ToString();


                int j = 0;
                //25 Questionов первого типа
                while (j != 25 && break_flag == false)
                {
                    

                    string qry = "Select Question,Variant1,Variant2,Variant3,Variant4,True_answer,Graduate FROM Quest WHERE Code=" + arrlst[j].ToString();
                    

                    OleDbDataAdapter dta = new OleDbDataAdapter(qry, connection_string);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);






                    qst1.Text = "Question №  " + (i + 1).ToString(); // номер Questionа
                    qst1.textBox1.Text = ds.Tables[0].Rows[0][0].ToString();// Текст Questionа
                    qst1.var1.Text = ds.Tables[0].Rows[0][1].ToString();//Первый Variant Answerа
                    qst1.var1.SelectionStart = 0;
                    bw2.Write(DateTime.Now.ToString() + "\r\n");//Today_data в логи
                    bw2.Write(ds.Tables[0].Rows[0][0].ToString() + "\r\n");//Текст Questionа в логи

                    strmwrt.WriteLine(ds.Tables[0].Rows[0][0].ToString()+"\r\n");
                    qst1.var2.Text = ds.Tables[0].Rows[0][2].ToString();//Второй Variant Answerа
                    qst1.var2.SelectionStart = 0;
                    qst1.var3.Text = ds.Tables[0].Rows[0][3].ToString();//Третий
                    qst1.var3.SelectionStart = 0;
                    qst1.var4.Text = ds.Tables[0].Rows[0][4].ToString();//Четвертый
                    qst1.var4.SelectionStart = 0;
                    qst1.ShowDialog();//Вывод диалогового окна


                   

                    
                    bw2.Write("Выбранный Answer:" + qst1.textBox2.Text + "\r\n");//Логи
                    strmwrt.WriteLine("Выбранный Answer:" + qst1.textBox2.Text + "\r\n");
                    bw2.Write("True_answer Answer:" + ds.Tables[0].Rows[0][5].ToString() + "\r\n");
                    strmwrt.WriteLine("True_answer Answer:" + ds.Tables[0].Rows[0][5].ToString() + "\r\n");

                    OleDbDataAdapter dta_for_true_answer_part_1 = new OleDbDataAdapter("Select * from [Quest] where Question ="+"\""+qst1.textBox1.Text.ToString()+"\"",connection_string);

                    DataSet ds_for_true_answer_part_1 = new DataSet();

                    dta_for_true_answer_part_1.Fill(ds_for_true_answer_part_1);

                    string true_answer_part_1 = "";

                    true_answer_part_1 = ds_for_true_answer_part_1.Tables[0].Rows[0][Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString()) + 1].ToString();

                    string current_answer_part_1 = ds_for_true_answer_part_1.Tables[0].Rows[0][Convert.ToInt32(qst1.textBox2.Text.ToString()) + 1].ToString();


                    string current_grade = "0";
                    if (qst1.textBox2.Text == ds.Tables[0].Rows[0][5].ToString())//Если Answer True_answer 2 Graduateа в плюс
                    {
                        grade = grade + 2;

                        current_grade = "2";

                        bw2.Write("Answer is true\r\n");
                        strmwrt.WriteLine("Answer is true\r\n");

                    }
                    else if (qst1.textBox2.Text == "5")
                    {

                        break_flag = true;
                        bw2.Write(DateTime.Now.ToString() + "\r\n");
                        bw2.Write("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                        strmwrt.WriteLine("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                    }
                    else// ничего , если не True_answer, так же запись об этом  в логи
                    {
                        bw2.Write("Answer is false \r\n");
                        strmwrt.WriteLine("Answer is false\r\n");
                    }


                    qst1.textBox2.Clear();


                    string qryansw = "INSERT INTO Answer1 (Login,ID,[User],Question,Answer,True_answer,Graduate,Today_data)  Values (" + "\"" + Login.Text + "\"" + "," + "\"" + id_s.ToString() + "\"" + "," + "\"" + user1.ToString() + "\"" + "," + "\"" + qst1.textBox1.Text.ToString() + "\"" + "," + "\"" + current_answer_part_1 + "\"" + "," + "\"" + true_answer_part_1 + "\"" + "," + "\"" + current_grade + "\"" + "," + "\"" + DateTime.Now.ToShortDateString() + "\"" + ")";

                    OleDbDataAdapter dta_name3 = new OleDbDataAdapter(qryansw, connection_string);

                    DataSet ds_name3 = new DataSet();

                    dta_name3.Fill(ds_name3);



                    j++;
                    i++;
                }



                int k = 0;

                double grade2 = 0;

                //10 Questionов 2 типа
                while (k != 10 && break_flag == false)
                {




                    qst2.Text = "Question №  " + (i + 1).ToString(); // Порядковый номер


                    string qry = "Select Question,Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,True_answer1,True_answer2,True_answer3,True_answer4,True_answer5,True_answer6,Graduate FROM Quest1 WHERE Code=" + arrlst2[k].ToString();// Выборка вопрсов

                    OleDbDataAdapter dta = new OleDbDataAdapter(qry, connection_string);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);

                    qst2.textBox1.Text = ds.Tables[0].Rows[0][0].ToString();//Question
                    strmwrt.WriteLine("Question: " + ds.Tables[0].Rows[0][0].ToString() + "\r\n");
                    qst2.textBox2.Text = ds.Tables[0].Rows[0][1].ToString();//Variant 1
                    qst2.textBox3.Text = ds.Tables[0].Rows[0][2].ToString();//2
                    qst2.textBox4.Text = ds.Tables[0].Rows[0][3].ToString();//3
                    qst2.textBox5.Text = ds.Tables[0].Rows[0][4].ToString();//4
                    qst2.textBox6.Text = ds.Tables[0].Rows[0][5].ToString();//5
                    qst2.textBox7.Text = ds.Tables[0].Rows[0][6].ToString();//6


                    ArrayList lst1 = new ArrayList();
                    ArrayList lst2 = new ArrayList();




                    qst2.ShowDialog();






                    lst1.Add(qst2.checkBox1.Checked.ToString());//Тут в массивы записываются выбранные Variantы Answerов
                    lst1.Add(qst2.checkBox2.Checked.ToString());
                    lst1.Add(qst2.checkBox3.Checked.ToString());
                    lst1.Add(qst2.checkBox4.Checked.ToString());
                    lst1.Add(qst2.checkBox5.Checked.ToString());
                    lst1.Add(qst2.checkBox6.Checked.ToString());


                    lst2.Add(ds.Tables[0].Rows[0][7].ToString());// Тут верные записываются
                    lst2.Add(ds.Tables[0].Rows[0][8].ToString());
                    lst2.Add(ds.Tables[0].Rows[0][9].ToString());
                    lst2.Add(ds.Tables[0].Rows[0][10].ToString());
                    lst2.Add(ds.Tables[0].Rows[0][11].ToString());
                    lst2.Add(ds.Tables[0].Rows[0][12].ToString());

                    ArrayList current_answers_for_2_part = new ArrayList(6);
                    ArrayList true_ansers_for_2_part = new ArrayList(6);

                    for (int v = 0; v < 6; v++)
                    {
                        current_answers_for_2_part.Add("");
                        true_ansers_for_2_part.Add("");
                    }

                    int counter = 0;

                    strmwrt.WriteLine("\nВыбраны Variantы Answerов:");

                    while (counter != 6)
                    {

                        switch (counter)
                        {
                            case 0:
                                {
                                    if (qst2.checkBox1.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox2.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox2.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }

                            case 1:
                                {
                                    if (qst2.checkBox2.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox3.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox3.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 2:
                                {
                                    if (qst2.checkBox3.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox4.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox4.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 3:
                                {
                                    if (qst2.checkBox4.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox5.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox5.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 4:
                                {
                                    if (qst2.checkBox5.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox6.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox6.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 5:
                                {
                                    if (qst2.checkBox6.Checked)
                                    {

                                        strmwrt.WriteLine(qst2.textBox7.Text.ToString());
                                        current_answers_for_2_part.Insert(counter, qst2.textBox7.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }






                        }
                    }

                    counter = 0;

                    strmwrt.WriteLine("\nВерные Variantы Answerов:");


                    while (counter != 6)
                    {

                        switch (counter)
                        {
                            case 0:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox2.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox2.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }

                            case 1:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox3.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox3.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 2:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox4.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox4.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 3:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox5.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox5.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 4:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox6.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox6.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            case 5:
                                {
                                    if (lst2[counter].ToString() == "True")
                                    {

                                        strmwrt.WriteLine(qst2.textBox7.Text.ToString());
                                        true_ansers_for_2_part.Insert(counter, qst2.textBox7.Text.ToString());
                                    }
                                    counter++;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }






                        }

                    }

                    string qry_for_2_parts_answer = "INSERT INTO Answer2 (ID,Login, [User], Question, Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,True_answer1,True_answer2,True_answer3,True_answer4,True_answer5,True_answer6,Graduate,Today_data) Values (" +"\""+ id_s.ToString() + "\"" + ","+"\""+ Login.Text.ToString()+"\""+"," + "\"" + user1.ToString() + "\"" + "," + "\"" + qst2.textBox1.Text.ToString() + "\"" + "," + "\"" + current_answers_for_2_part[0].ToString() + "\"" + "," + "\"" + current_answers_for_2_part[1].ToString() + "\"" + "," + "\"" + current_answers_for_2_part[2].ToString() + "\"" + "," + "\"" + current_answers_for_2_part[3].ToString() + "\"" + ","+"\"" + current_answers_for_2_part[4].ToString() + "\"" + "," + "\"" + current_answers_for_2_part[5].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[0].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[1].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[2].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[3].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[4].ToString() + "\"" + "," + "\"" + true_ansers_for_2_part[5].ToString() + "\"" + "," + "\"" + graduate(lst1, lst2).ToString() + "\"" + "," + "\"" + DateTime.Now.ToShortDateString()+"\" )";
                    OleDbDataAdapter dta_for_answers_part_2 = new OleDbDataAdapter(qry_for_2_parts_answer,connection_string);

                    DataSet ds_for_answer_part_2 = new DataSet();

                    dta_for_answers_part_2.Fill(ds_for_answer_part_2);



                    counter = 0;



                    bw2.Write(DateTime.Now.ToString() + "\r\n");//Время в логи
                    grade2 = grade2 + graduate(lst1, lst2);//Вызов фунции подсчета Graduateов


                    qst2.checkBox1.Checked = false;//Сброс чекбоксов на false для нового Questionа
                    qst2.checkBox2.Checked = false;
                    qst2.checkBox3.Checked = false;
                    qst2.checkBox4.Checked = false;
                    qst2.checkBox5.Checked = false;
                    qst2.checkBox6.Checked = false;

                    if (qst2.textBox8.Text == "5")
                    {
                        break_flag = true;
                        bw2.Write(DateTime.Now.ToString() + "\r\n");
                        bw2.Write("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                        strmwrt.WriteLine("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                    }

                    k++;
                    i++;
                }

                int l = 0;
            

                int grade3 = 0;
                while (l != 5 && break_flag == false)
                {
                    qst3.Text = "Question №  " + (i + 1).ToString();// Тут Аналогично первому типу Questionов




                    string qry = "Select Question,Answer,Graduate FROM Quest2 WHERE Code=" + arrlst3[l].ToString();

                    OleDbDataAdapter dta = new OleDbDataAdapter(qry, connection_string);

                    DataSet ds = new DataSet();

                    dta.Fill(ds);



                    bw2.Write(DateTime.Now.ToString() + "\r\n");



                    qst3.textBox1.Text = ds.Tables[0].Rows[0][0].ToString();

                    bw2.Write("\r\nQuestion: " + qst3.textBox1.Text + "\r\n");
                    strmwrt.WriteLine("\r\nQuestion: " + qst3.textBox1.Text + "\r\n");
                    bw2.Write("\r\nTrue_answer Answer: " + ds.Tables[0].Rows[0][1].ToString() + "\r\n");
                    strmwrt.Write("\r\nTrue_answer Answer: " + ds.Tables[0].Rows[0][1].ToString() + "\r\n");

                    qst3.ShowDialog();

                    bw2.Write("\r\nВыбранный варинт: " + qst3.textBox2.Text + "\r\n");
                    strmwrt.Write("\r\nВыбранный варинт: " + qst3.textBox2.Text + "\r\n");

                    string current_grade = "0";

                    if (qst3.textBox2.Text == ds.Tables[0].Rows[0][1].ToString())
                    {
                        bw2.Write("Answer True_answer\r\n");
                        strmwrt.Write("Answer True_answer\r\n");
                        grade3 = grade3 + 4;
                        current_grade = "4";
                    }
                    else
                    {
                        bw2.Write("Answer не True_answer\r\n");
                        strmwrt.Write("Answer не True_answer\r\n");
                    }

                    l++;
                    i++;

                    if (qst3.textBox3.Text == "5")
                    {
                        break_flag = true;
                        bw2.Write(DateTime.Now.ToString() + "\r\n");
                        bw2.Write("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                        strmwrt.Write("Тест был завершен пользователем на " + i.ToString() + " Questionе\r\n");
                    }

                    string qryansw = "INSERT INTO Answer3 (Login,ID,[User],Question,Answer,True_answer,Graduate,Today_data) Values (" + "\"" + Login.Text + "\"" + "," + "\"" + id_s.ToString() + "\"" + "," + "\"" + user1.ToString() + "\"" + "," + "\"" + qst3.textBox1.Text.ToString() + "\"" + "," + "\"" + qst3.textBox2.Text.ToString() + "\"" + "," + "\"" + ds.Tables[0].Rows[0][1].ToString() + "\"" + "," + "\"" + current_grade + "\"" + "," + "\"" + DateTime.Now.ToShortDateString() + "\"" + ")";

                    OleDbDataAdapter dta_name3 = new OleDbDataAdapter(qryansw, connection_string);

                    DataSet ds_name3 = new DataSet();

                    dta_name3.Fill(ds_name3);



                    qst3.textBox2.Clear();
                }



                
                    grade2 = Math.Round(grade2, 2); // Округляем оценку до 2х знаков после запятой

                    MessageBox.Show("Итоговый Graduate: " + (Convert.ToDouble(grade) + grade2 + Convert.ToDouble(grade3)).ToString() + " / 100");//Вывод итогового Graduateа
                    bw2.Write(DateTime.Now.ToString() + "\r\n");
                    bw2.Write("Итоговый Graduate: " + (Convert.ToDouble(grade) + grade2 + Convert.ToDouble(grade3)).ToString() + " / 100 \r\n");//Запись в логи
                    strmwrt.Write("Итоговый Graduate: " + (Convert.ToDouble(grade) + grade2 + Convert.ToDouble(grade3)).ToString() + " / 100 \r\n");
                    bw2.Close();
                    strmwrt.Close();
                    string grd = (Convert.ToDouble(grade) + grade2 + Convert.ToDouble(grade3)).ToString();

                    string user = "";

                    string qry_for_name = "SELECT User FROM Autentification WHERE Login=" + "\"" + Login.Text + "\"";

                    OleDbDataAdapter dta_name = new OleDbDataAdapter(qry_for_name, connection_string);

                    DataSet ds_name = new DataSet();

                    dta_name.Fill(ds_name);

                    user = ds_name.Tables[0].Rows[0][0].ToString();


                    string qry_r = "INSERT INTO Tests_result ([User],ID,Today_data,Graduate,Login) Values (" + "\"" + user + "\"" + ","+"\""+ id_s.ToString() + "\"" +","+ "\"" + DateTime.Now.ToShortDateString() + "\"" + "," + "\"" + grd + "\""+"," +"\""+Login.Text+"\""+ ")";
                    OleDbDataAdapter dta_r = new OleDbDataAdapter(qry_r, connection_string);

                    DataSet ds_r = new DataSet();

                    dta_r.Fill(ds_r);
                
            //}
            //catch
            //{
            //    bw2.Close();
            //    MessageBox.Show("Не верно выбрана база данных!");
            //}

        }


        //Переподключение к базе данных из программы
        private void соединениеСБазойДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); 

            BinaryWriter bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));
            bw.Write(DateTime.Now.ToString() + "\r\n");

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   connection_string = connt + openFileDialog1.FileName;
                }

            StreamWriter strwrite = new StreamWriter(File.OpenWrite("path.txt"), Encoding.GetEncoding(1251));
            strwrite.WriteLine(openFileDialog1.FileName);

            bw.Write("Смена пути к базе данных на " + connection_string + "\r\n");
            bw.Close();
            
            strwrite.Close();
        }


        // То же самое из окна аутентификации
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            BinaryWriter bw = new BinaryWriter(File.Open("logs.lg", FileMode.Append), Encoding.GetEncoding(1251));
            bw.Write(DateTime.Now.ToString() + "\r\n");
            

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                connection_string = connt + openFileDialog1.FileName;
            }

            StreamWriter strwrite = new StreamWriter(File.OpenWrite("path.txt"), Encoding.GetEncoding(1251));
            strwrite.WriteLine(openFileDialog1.FileName);
            bw.Write("Смена пути к базе данных на " + connection_string+"\r\n");
            bw.Close();
            strwrite.Close();
        }

        private void просмотрРезультатовТестовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestResults tstr = new TestResults();


            tstr.connection_string = connection_string;
            tstr.Show();

        }
    }
}
