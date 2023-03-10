//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : report
	/// Data Source    : 127.0.0.1
	/// Server Version : 5.5.5-10.3.38-MariaDB
	/// </summary>
	public partial class ReportDB : LinqToDB.Data.DataConnection
	{
		public ITable<Calendar>   Calendars   { get { return this.GetTable<Calendar>(); } }
		public ITable<DayCode>    DayCodes    { get { return this.GetTable<DayCode>(); } }
		public ITable<Department> Departments { get { return this.GetTable<Department>(); } }
		public ITable<Employee>   Employees   { get { return this.GetTable<Employee>(); } }
		public ITable<Report>     Reports     { get { return this.GetTable<Report>(); } }

		public ReportDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public ReportDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public ReportDB(LinqToDBConnectionOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public ReportDB(LinqToDBConnectionOptions<ReportDB> options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table("calendar")]
	public partial class Calendar
	{
		[Column(),           PrimaryKey, NotNull] public DateTime HDay    { get; set; } // date
		[Column("Day_type"),             NotNull] public sbyte    DayType { get; set; } // tinyint(4)
	}

	[Table("day_code")]
	public partial class DayCode
	{
		[PrimaryKey, NotNull] public string CodeId { get; set; } // varchar(2)
		[Column,     NotNull] public string Name   { get; set; } // varchar(300)

		#region Associations

		/// <summary>
		/// fk_r_dc_BackReference (report)
		/// </summary>
		[Association(ThisKey="CodeId", OtherKey="CodeId", CanBeNull=true)]
		public IEnumerable<Report> Fkrdcs { get; set; }

		#endregion
	}

	[Table("departments")]
	public partial class Department
	{
		[PrimaryKey, Identity] public int    DepId { get; set; } // int(11)
		[Column,     NotNull ] public string Name  { get; set; } // varchar(100)

		#region Associations

		/// <summary>
		/// fk_emp_dep_BackReference (employees)
		/// </summary>
		[Association(ThisKey="DepId", OtherKey="DepId", CanBeNull=true)]
		public IEnumerable<Employee> Fkempdeps { get; set; }

		#endregion
	}

	[Table("employees")]
	public partial class Employee
	{
		[PrimaryKey, Identity   ] public int      EmpID      { get; set; } // int(11)
		[Column,     NotNull    ] public string   LastName   { get; set; } // varchar(45)
		[Column,     NotNull    ] public string   FirstName  { get; set; } // varchar(45)
		[Column,        Nullable] public string   MiddleName { get; set; } // varchar(45)
		[Column,     NotNull    ] public DateTime BirthDay   { get; set; } // date
		[Column,     NotNull    ] public string   Post       { get; set; } // varchar(100)
		[Column,     NotNull    ] public string   Address    { get; set; } // varchar(255)
		[Column,     NotNull    ] public sbyte    RemoteWork { get; set; } // tinyint(4)
		[Column,        Nullable] public int?     DepId      { get; set; } // int(11)

		#region Associations

		/// <summary>
		/// fk_emp_dep (departments)
		/// </summary>
		[Association(ThisKey="DepId", OtherKey="DepId", CanBeNull=true)]
		public Department Dep { get; set; }

		/// <summary>
		/// fk_r_emp_BackReference (report)
		/// </summary>
		[Association(ThisKey="EmpID", OtherKey="EmpID", CanBeNull=true)]
		public IEnumerable<Report> Fkremps { get; set; }

		#endregion
	}

	[Table("report")]
	public partial class Report
	{
		[PrimaryKey(1), NotNull] public int      EmpID    { get; set; } // int(11)
		[PrimaryKey(2), NotNull] public DateTime WorkDate { get; set; } // date
		[Column,        NotNull] public string   CodeId   { get; set; } // varchar(2)

		#region Associations

		/// <summary>
		/// fk_r_dc (day_code)
		/// </summary>
		[Association(ThisKey="CodeId", OtherKey="CodeId", CanBeNull=false)]
		public DayCode Code { get; set; }

		/// <summary>
		/// fk_r_emp (employees)
		/// </summary>
		[Association(ThisKey="EmpID", OtherKey="EmpID", CanBeNull=false)]
		public Employee Emp { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Calendar Find(this ITable<Calendar> table, DateTime HDay)
		{
			return table.FirstOrDefault(t =>
				t.HDay == HDay);
		}

		public static DayCode Find(this ITable<DayCode> table, string CodeId)
		{
			return table.FirstOrDefault(t =>
				t.CodeId == CodeId);
		}

		public static Department Find(this ITable<Department> table, int DepId)
		{
			return table.FirstOrDefault(t =>
				t.DepId == DepId);
		}

		public static Employee Find(this ITable<Employee> table, int EmpID)
		{
			return table.FirstOrDefault(t =>
				t.EmpID == EmpID);
		}

		public static Report Find(this ITable<Report> table, int EmpID, DateTime WorkDate)
		{
			return table.FirstOrDefault(t =>
				t.EmpID    == EmpID &&
				t.WorkDate == WorkDate);
		}
	}
}
