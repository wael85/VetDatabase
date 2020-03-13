using System.Data.SqlClient;

namespace InsertInDatabas
{
    abstract class Conection
    {
        public static SqlConnection MakeCon()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "VetClinic",
                UserID = "wael",
                Password = "1234",
                DataSource = "localhost"
            };
            SqlConnection con = new SqlConnection(builder.ConnectionString);
            return con;
        }
    }
}
