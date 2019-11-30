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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            UserNameField.Text = "Введите имя";
            UserNameField.ForeColor = Color.Gray;

            UserSernameField.Text = "Введите фамилию";
            UserSernameField.ForeColor = Color.Gray;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        Point lastPoint;//класс координат 
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //Ввод текста,черный текст,при выходе из формы серый
        private void UserNameField_Enter(object sender, EventArgs e)
        {
            if (UserNameField.Text == "Введите имя")
            {
                UserNameField.Text = "";
                UserNameField.ForeColor = Color.Black;
            }



        }

        //Прии выходе из формы
        private void UserNameField_Leave(object sender, EventArgs e)
        {
            if (UserNameField.Text == "")
            {
                UserNameField.Text = "Введите имя";
                UserNameField.ForeColor = Color.Gray;
            }
        }

        private void UserSernameField_Enter(object sender, EventArgs e)
        {
            if (UserSernameField.Text == "Введите фамилию")
            {
                UserSernameField.Text = "";
                UserSernameField.ForeColor = Color.Black;
            }

        }

        private void UserSernameField_Leave(object sender, EventArgs e)
        {
            if (UserSernameField.Text == "")
            {
                UserSernameField.Text = "Введите фамилию";
                UserSernameField.ForeColor = Color.Gray;
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {   //в случае если не введено имя,фамилия,пароль,логин
            if (UserSernameField.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }

            if (UserSernameField.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (loginField.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (passField.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            //пРОТОТИП ФУНКЦИИ 
            if (IsUserExist())
                return;//выход в случае повтора


            //Создаем объект лдя подключения к базе данных
            DBcs db = new DBcs();


            //сформировали запрос
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `login`, `pass`, `name`, `sername`) VALUES ('@login', '@pass', '@name', '@sername')", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserNameField;
            command.Parameters.Add("@sername", MySqlDbType.VarChar).Value = UserSernameField;

            //выполнение самого запроса
            db.openConnectoin();
            //в случае создания
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }
            db.closeConnectoin();
        }

        //если пользователь зарегистрирован
        public Boolean IsUserExist()
        {
            //Поля для ввода логина и пароля 
            String loginUser = loginField.Text;


            //Создаем объект лдя подключения к базе данных
            DBcs db = new DBcs();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //создаем объект для выборки данных из базы данных и делаем заглушки 
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField;



            //объект позволяющий делать выборку 
            adapter.SelectCommand = command;
            //объект заполнящий объект-таблицу на основе выбранных данных
            adapter.Fill(table);

            //Есть ли такой поьзователь  -> сообщение
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть");
                return true;
            }
            else
            {
                
                return false;
            }
        }

        private void AutoresLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


