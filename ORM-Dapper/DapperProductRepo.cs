using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperProductRepo : IProductRepo
	{
        private readonly IDbConnection _connection;

		public DapperProductRepo(IDbConnection connection)
		{
            _connection = connection;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID)" +
               "VALUES (@name, @price, @categoryID);",
               new { name = name, price = price, categoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }
    }
}

