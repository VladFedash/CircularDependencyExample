using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Example
{
	public class Person
	{
		public string Name { get; set; }
		public Department Department { get; set; }
	}

	public class Department
	{
		public string DepartmentName { get; set; }
		public List<Person> Employees { get; set; } = new List<Person>();
	}

	class Program
	{
		static void Main(string[] args)
		{
			var department = new Department { DepartmentName = "Engineering" };
			var person1 = new Person { Name = "John Doe", Department = department };
			var person2 = new Person { Name = "Vlad Fedash", Department = department };

			var persons = new List<Person>() { person1, person2 };

			department.Employees.Add(person1);
			department.Employees.Add(person2);

			// Serialize with Newtonsoft.Json
			var newtonsoftJsonSettings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			};

			var newtonsoftJson = JsonConvert.SerializeObject(department, newtonsoftJsonSettings);
			Console.WriteLine($"Newtonsoft.Json serialization:\n{newtonsoftJson}");

			// Serialize with System.Text.Json
			var systemTextJsonOptions = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				// WriteIndented = true
			};
			
			var systemTextJson = System.Text.Json.JsonSerializer.Serialize(department, systemTextJsonOptions);
			Console.WriteLine($"\nSystem.Text.Json serialization:\n{systemTextJson}");

			// Serialize with Newtonsoft.Json - Person
			var newtonsoftJsonPerson = Newtonsoft.Json.JsonConvert.SerializeObject(persons, newtonsoftJsonSettings);
			Console.WriteLine($"\nNewtonsoft.Json serialization (Person):\n{newtonsoftJsonPerson}");

			// Serialize with System.Text.Json - Person
			var systemTextJsonPerson = JsonSerializer.Serialize(persons, systemTextJsonOptions);
			Console.WriteLine($"\nSystem.Text.Json serialization (Person):\n{systemTextJsonPerson}");
		}
	}
}
