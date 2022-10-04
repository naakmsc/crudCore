//using System.Data.SqlClient;

namespace crudCore.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        //Constructor
        public Conexion() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            
            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL() 
        {
            return cadenaSql;
        }
    }
}
