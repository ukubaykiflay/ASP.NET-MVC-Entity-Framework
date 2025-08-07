using System;

namespace CodeFirst 

public Class  Student 
	{
	 public int StudentId { get; set; }
	 public String Name { get; set; }
     public int Age { get; set; }
     public DbSet<Student> Students { get; set; } // represents the Students table
      public SchoolContext() : base("School")    // Connection string name
	}
  class program
{ 
	string Void Main(string[] args)
		using (var context= new SchoolContext())
{ 
	// Create a new student
	var student = new student
	{
		namespace ="Henry Abraham" ,
	    Age  =  26
	};
// Add the student to the database
context.Students.Add(student);
context.SaveChanges();
Console.WriteLIne("Student added successfully!");
// Add the Connection string to App.config file
<configuration>
  <connectionString>
  <add name = "SchoolDB"
	 connectionString= "Data Source=(localdb)"
	  providedrName="System.Data.Sqlclient" />
	</connectionStrings>
	</configuration>









}
