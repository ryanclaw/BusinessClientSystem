using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace BusinessClientSystem.Models
{
    public class BusinessClient
    {
        
        public MySqlConnection CreateConnection()
        {
            string connection = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            return con;
            
        }

        public List<Clients> clients = new List<Clients>();

        public void addClientToDB(Clients c)
       {
           //This portion is show that you have create a private function so that you will not copy the sql connection
           //over and over again 
            var con = this.CreateConnection();

            //string cmdText = "insert into products values("+p.Id+", "+p.Name+", "+p.Brand+""+ p.Price +");";
            //Code below is the new way of inserting value to DB via variable cmdText
           string cmdText = $"insert into clients values({c.id}, '{c.salutation}', '{c.firstname}', '{c.lastname}', '{c.gender}', '{c.contacttype}', '{c.dateofbirth}','{c.address1}','{c.address2}', {c.phone1}, {c.phone2}, '{c.email}','{c.product}')";
            MySqlCommand cmd = new MySqlCommand (cmdText, con);
            cmd.ExecuteNonQuery();
            
        }

        public List<Clients> client = new List<Clients>();

        public void updateClientToDB(Clients c)
       {
           //This portion is show that you have create a private function so that you will not copy the sql connection
           //over and over again 
            var con = this.CreateConnection();

            //string cmdText = "insert into products values("+p.Id+", "+p.Name+", "+p.Brand+""+ p.Price +");";
            //Code below is the new way of inserting value to DB via variable cmdText
           string cmdText = $"update clients set id={c.id}, salutation='{c.salutation}', firstname='{c.firstname}', lastname='{c.lastname}', gender='{c.gender}', contacttype='{c.contacttype}', dateofbirth='{c.dateofbirth}', address1='{c.address1}', address2='{c.address2}', phone1={c.phone1}, phone2={c.phone2}, email='{c.email}', product='{c.product}' where id={c.id}";
            MySqlCommand cmd = new MySqlCommand (cmdText, con);
            cmd.ExecuteNonQuery();
            
        }
        

        public List<Clients> getClientsFromDb()

        {
            List<Clients> clients = new List<Clients>();

            //creating and opening the mysql conenction
            string connection = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();

            //creating the mysql command /query that I want to run
            MySqlCommand cmd = new MySqlCommand ("select * from clients", con);

            //Execute the command
            var result = cmd.ExecuteReader();

            //prepare our results
            while (result.Read())
            {
                Clients c = new Clients();
                c.id = Convert.ToInt32(result["id"]);
                c.salutation = result["salutation"].ToString();
                c.firstname = result["firstName"].ToString();
                c.lastname = result["lastName"].ToString();
                c.gender = result["gender"].ToString();
                 c.contacttype = result["contacttype"].ToString();
                c.dateofbirth = result["dateofbirth"].ToString();
                c.address1 = result["address1"].ToString();
                c.address2 = result["address2"].ToString();
                c.phone1 = Convert.ToInt32(result["phone1"]);
                c.phone2 = Convert.ToInt32(result["phone2"]);
                c.email = result["email"].ToString();
                c.product = result["product"].ToString();
                clients.Add(c);
            }

            con.Close();

            return clients;
         }

         public Clients getClients(int id)
         {
          var con = this.CreateConnection();
          string cmdText = $"select * from clients where id = {id}";
          MySqlCommand cmd = new MySqlCommand(cmdText, con);
          var result = cmd.ExecuteReader();
          Clients c = new Clients();
          while(result.Read())
          {
                c.id = Convert.ToInt32(result["id"]);
                c.salutation = result["salutation"].ToString();
                c.firstname = result["firstName"].ToString();
                c.lastname = result["lastName"].ToString();
                c.gender = result["gender"].ToString();
                c.contacttype = result["contacttype"].ToString();
                c.dateofbirth = result["dateofbirth"].ToString();
                c.address1 = result["address1"].ToString();
                c.address2 = result["address2"].ToString();
                c.phone1 = Convert.ToInt32(result["phone1"]);
                c.phone2 = Convert.ToInt32(result["phone2"]);
                c.email = result["email"].ToString();
                c.product = result["product"].ToString();
            }

                con.Close();
                return c;
         }

            public void deleteClient(int id)
            {
            var con = this.CreateConnection();
            string cmdText = $"delete from clients where id = {id}";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            cmd.ExecuteNonQuery();
            con.Close();
            }

              
           
            
    }
}
