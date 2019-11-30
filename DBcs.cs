using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Создание_пользоовательского_приложения
{
    class DBcs
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=rootC#2019;database=developer");
        public void openConnectoin()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnectoin()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
