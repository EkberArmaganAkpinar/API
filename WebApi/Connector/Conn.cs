
using Pomelo.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi.Model;

namespace WebApi.Connector
{
   
    public class Conn
    {
        private string constring;
        public Conn()
        {
            constring = @"server=localhost;userid=root;password=123456;database=deneme";
        }
        public List<Task> Task()
        {
            List<Task> allTasks = new List<Task>();
            

            using (MySqlConnection connMySql= new MySqlConnection(constring))
            {
               
                using (MySqlCommand cmd = connMySql.CreateCommand())
                {
                    cmd.CommandText = "Select * from task";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySql;
                  


                    connMySql.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                      
                        while (reader.Read())
                        {
                            allTasks.Add(new Task { id = reader.GetInt32(reader.GetOrdinal("Id")), task = reader.GetString(reader.GetOrdinal("Task_name"))});
                        }
                    }
                }
                connMySql.Close();
            }


         

            return allTasks;

        }
        public List<Task> AddTask(Task task)
        {
            List<Task> allTasks = new List<Task>();


            using (MySqlConnection connMySql = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = connMySql.CreateCommand())
                {
                    cmd.CommandText = "insert into task(Task_name) values(@Task_name)";
                    string tname;
                    tname = task.task;
                    cmd.Parameters.AddWithValue("@Task_name",tname);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySql;



                    connMySql.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allTasks.Add(new Task { id = reader.GetInt32(reader.GetOrdinal("Id")), task = reader.GetString(reader.GetOrdinal("Task_name")) });
                        }
                    }
                }
                connMySql.Close();
            }




            return allTasks;

        }
        public List<Task> SelectedTask(int id)
        {
            List<Task> allTasks = new List<Task>();


            using (MySqlConnection connMySql = new MySqlConnection(constring))
            {

                using (MySqlCommand cmd = connMySql.CreateCommand())
                {
                    cmd.CommandText = "Select * from task where id="+id+"";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connMySql;



                    connMySql.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allTasks.Add(new Task { id = reader.GetInt32(reader.GetOrdinal("Id")), task = reader.GetString(reader.GetOrdinal("Task_name")) });
                        }
                    }
                }
                connMySql.Close();
            }




            return allTasks;

        }

    }
}
