using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepo
	{
		public IEnumerable<Department> GetAllDepartments();

	}


}

