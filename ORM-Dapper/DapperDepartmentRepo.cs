using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperDepartmentRepo: IDepartmentRepo
	{
		private readonly IDbConnection _connection;


		public DapperDepartmentRepo(IDbConnection connection)
		{
			_connection = connection;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
			return _connection.Query<Department>("SELECT * FROM departments;");

        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }
    }
}

