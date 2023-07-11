using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepo
	{
		public IEnumerable<Department> GetAllDepartments();
		public void InsertDepartment(string newDepartmentName);
	}


}

