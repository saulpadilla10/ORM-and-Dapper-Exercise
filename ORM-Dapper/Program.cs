using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var repo = new DapperProductRepo(conn);

            Console.WriteLine("What is the name of your new product?");

            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");

            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID?");

            var prodCatid = int.Parse(Console.ReadLine());


            repo.CreateProduct(prodName, prodPrice, prodCatid);

            var prodList = repo.GetAllProducts();

            foreach (var prod in prodList)
            {

                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
            }

        }
    }
}
