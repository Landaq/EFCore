using EFCoreCodeFirstDemo.Entities;

namespace EFCoreCodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var context = new EFCoreDbContext();

                var studentList = context.Students.ToList();

                foreach (var student in studentList)
                {
                    Console.WriteLine($"Firstname: {student?.FirstName}, Lastname: {student?.LastName}");
                }

                var student1 = context.Students.FirstOrDefault(s => s.FirstName == "Pranaya");
                Console.WriteLine($"FirstName: {student1?.FirstName}, LastName: {student1?.LastName}");

                var student2 = context.Students.First(s => s.FirstName == "Pranaya");
                Console.WriteLine($"FirstName: {student2?.FirstName}, LastName: {student2?.LastName}");

                var student3 = (from s in context.Students
                                where s.FirstName == "Pranaya"
                                select s).FirstOrDefault();
                Console.WriteLine($"FirstName: {student3?.FirstName}, LastName: {student3?.LastName}");

                var student4 = (from s in context.Students
                                where s.FirstName == "Pranaya"
                                select s).First();
                Console.WriteLine($"FirstName: {student4?.FirstName}, LastName: {student4?.LastName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }

            Console.ReadKey();
        }
    }
}
