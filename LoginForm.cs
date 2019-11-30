using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Создание_пользоовательского_приложения
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width,50);
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.DarkRed;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        Point lastPoint;//класс координат 
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if(e.Button==MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X,e.Y);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Поля для ввода логина и пароля 
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            //Создаем объект лдя подключения к базе данных
            DBcs db = new DBcs();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //создаем объект для выборки данных из базы данных и делаем заглушки 
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL AND `pass`=@uP",db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;


            //объект позволяющий делать выборку 
            adapter.SelectCommand = command;
            //объект заполнящий объект-таблицу на основе выбранных данных
            adapter.Fill(table);

            //Есть ли такой поьзователь  -> сообщение
            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("No");
            }


        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();//скрывает элемент управления от пользователя   
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();//Открываем окно регистрации 

        }
    }
}

