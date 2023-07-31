using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VideoShop.Models;

namespace VideoShop.DataAccess
{
    public class MovieRepository
    {

        public Movie GetById(int id)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VideoClubDb;Integrated Security=True";

            // Create a new SqlConnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();
                string query = $"SELECT * FROM Movies WHERE Id = {id}";

                // Create a SqlCommand object to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader object to read the data from the SQL query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Load the data into the DataTable
                        dataTable.Load(reader);
                    }
                }

                // Close the database connection
                connection.Close();
            }

            //Mapeamos un DataTable a una lista de Movies
            var movie = BindDataList<Movie>(dataTable);

            return movie.FirstOrDefault();
        }

        public List<Movie> GetAll()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VideoClubDb;Integrated Security=True";

            // Create a new SqlConnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();
                string query = "SELECT * FROM Movies";

                // Create a SqlCommand object to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader object to read the data from the SQL query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Load the data into the DataTable
                        dataTable.Load(reader);
                    }
                }

                // Close the database connection
                connection.Close();
            }

            //Mapeamos un DataTable a una lista de Movies
            var movies = BindDataList<Movie>(dataTable);

            return movies;
        }

        public void Create(Movie item)
        {
            
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VideoClubDb;Integrated Security=True";

            // Create a new SqlConnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();
                
                string query = $"INSERT INTO Movies (Title, Duration, ReleaseDate, Genre)  VALUES ('{item.Title}', {item.Duration}, '{item.ReleaseDate.ToString("yyyy-MM-dd")}', '{item.Genre}')";

                // Create a SqlCommand object to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader object to read the data from the SQL query
                    command.ExecuteNonQuery();
                    
                }

                // Close the database connection
                connection.Close();
            }

            
        }

        public void Update(Movie item)
        {

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VideoClubDb;Integrated Security=True";

            // Create a new SqlConnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                string query = $"UPDATE Movies SET Title = '{item.Title}' , Duration = {item.Duration} , ReleaseDate = '{item.ReleaseDate.ToString("yyyy-MM-dd")}' , Genre = '{item.Genre}' WHERE Id = {item.Id}";

                // Create a SqlCommand object to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader object to read the data from the SQL query
                    command.ExecuteNonQuery();

                }

                // Close the database connection
                connection.Close();
            }


        }

        public void Delete(int id)
        {

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VideoClubDb;Integrated Security=True";

            // Create a new SqlConnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                string query = $"DELETE FROM Movies WHERE Id = {id}";

                // Create a SqlCommand object to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader object to read the data from the SQL query
                    command.ExecuteNonQuery();

                }

                // Close the database connection
                connection.Close();
            }


        }

        public List<T> BindDataList<T>(DataTable dt)
        {
            List<string> columns = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                columns.Add(dc.ColumnName);
            }

            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    if (columns.Contains(fieldInfo.Name))
                    {
                        fieldInfo.SetValue(ob, dr[fieldInfo.Name]);
                    }
                }

                foreach (var propertyInfo in properties)
                {
                    if (columns.Contains(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(ob, dr[propertyInfo.Name]);
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }

    }
}