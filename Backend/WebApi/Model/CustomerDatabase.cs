using MySql.Data.MySqlClient;


namespace WebApi.Model
{


    public class CustomerDatabase
    {
        public MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_PROPERTIES"));
            }
        }


        public IEnumerable<Customer> GetAll()
        {
            var conn = Connection;
            conn.Open();

            string query = @"SELECT * FROM Customer";
            var command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();

            List<Customer> response = new List<Customer>();

            while (reader.Read())
            {
                Customer row = new Customer();

                row.id = reader.GetInt32(0);
                row.name = reader.GetString(1);
                row.address = reader.GetString(2);
                row.policyType = reader.GetString(3);
                row.insurerName = reader.GetString(4);
                row.premium = reader.GetDouble(5);

                response.Add(row);

            }

            conn.Close();


            return response;
        }

        public void Add(Customer customer)
        {
            var conn = Connection;
            conn.Open();

            string query = "INSERT INTO Customer (Name, Address, PolicyType, InsurerName, Premium) VALUES (@name, @address, @policyType, @insurerName, @premium)";

            var command = new MySqlCommand(query, conn);

            //Parameterized queries - Defensive Layer against SQL injections 
            command.Parameters.AddWithValue("@name", customer.name);
            command.Parameters.AddWithValue("@address", customer.address);
            command.Parameters.AddWithValue("@policyType", customer.policyType);
            command.Parameters.AddWithValue("@insurerName", customer.insurerName);
            command.Parameters.AddWithValue("@premium", customer.premium);

            command.ExecuteNonQuery();

            conn.Close();
        }


        public Customer GetById(int id)
        {
            var conn = Connection;
            conn.Open();

            string query = "SELECT * FROM Customer WHERE id = @id;";
            var command = new MySqlCommand(query, conn);

            //Parameterized queries - Defensive Layer against SQL injections 
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();

            //Returns id of -1 if no match has been found
            if (reader.Read())
            {
                Customer match = new Customer();

                match.id = reader.GetInt32(0);
                match.name = reader.GetString(1);
                match.address = reader.GetString(2);
                match.policyType = reader.GetString(3);
                match.insurerName = reader.GetString(4);
                match.premium = reader.GetDouble(5);

                conn.Close();

                return match;
            }

            return new Customer(-1, null, null, null, null, null);

        }

        public void Update(Customer customer)
        {
            var conn = Connection;
            conn.Open();

            string query = "UPDATE Customer SET name = @name, address = @address, policyType = @policyType, insurerName = @insurerName, premium = @premium WHERE id = @id";
            var command = new MySqlCommand(query, conn);

            //Parameterized queries - Defensive Layer against SQL injections 
            command.Parameters.AddWithValue("@id", customer.id);
            command.Parameters.AddWithValue("@name", customer.name);
            command.Parameters.AddWithValue("@address", customer.address);
            command.Parameters.AddWithValue("@policyType", customer.policyType);
            command.Parameters.AddWithValue("@insurerName", customer.insurerName);
            command.Parameters.AddWithValue("@premium", customer.premium);

            command.ExecuteNonQuery();

            conn.Close();
        }

        public void Delete(int id)
        {
            var conn = Connection;
            conn.Open();

            string query = "DELETE FROM Customer WHERE id = @id;";
            var command = new MySqlCommand(query, conn);

            //Parameterized queries - Defensive Layer against SQL injections 
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();

            conn.Close();
        }

    }
}