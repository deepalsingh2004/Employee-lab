namespace DeepalSingh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFilePath = "C:\\Users\\hp\\Documents\\oop2\\Employee lab\\DeepalSingh\\Employees.txt";


            List<Employee> employeeList = FillEmployeeList(dataFilePath);


            decimal averageWeeklyPay = CalculateAverageWeeklyPay(employeeList);
            Console.WriteLine($"Average Weekly Pay for All Employees: {averageWeeklyPay:C}");



            var lowestSalaryEmployee = GetLowestSalaryEmployee(employeeList);
            Console.WriteLine($"Lowest Salary for Salaried Employees: {lowestSalaryEmployee.Name} - {lowestSalaryEmployee.WeeklyPay:C}");


            Dictionary<string, double> percentageByCategory = CalculatePercentageByCategory(employeeList);
            foreach (var category in percentageByCategory)
            {
                Console.WriteLine($"{category.Key} Employees: {category.Value:P}");
            }
        }

        static List<Employee> FillEmployeeList(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        Employee employee;

                        switch (values[0][0])
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                                employee = new Salaried
                                {
                                    EmployeeId = int.Parse(values[0]),
                                    Name = values[1],
                                    SIN = values[2],
                                    Salary = decimal.Parse(values[3])
                                };
                                break;

                            case '5':
                            case '6':
                            case '7':
                                employee = new Wages
                                {
                                    EmployeeId = int.Parse(values[0]),
                                    Name = values[1],
                                    SIN = values[2],
                                    HourlyRate = decimal.Parse(values[3]),
                                    WorkHours = decimal.Parse(values[4])
                                };
                               break;

                            case '8':
                            case '9':
                                employee = new PartTime
                                {
                                    EmployeeId = int.Parse(values[0]),
                                    Name = values[1],
                                    SIN = values[2],
                                    HourlyRate = decimal.Parse(values[3]),
                                    WorkHours = decimal.Parse(values[4])
                                };
                                break;

                            default:

                               continue;
                        }

                        employee.CalculateWeeklyPay();
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data file: {ex.Message}");
            }

            return employees;
        }

        static decimal CalculateAverageWeeklyPay(List<Employee> employees)
        {
            return employees.Count > 0 ? employees.Average(e => e.WeeklyPay) : 0;
        }

        static Employee GetHighestWageEmployee(List<Employee> employees)
        {
            return employees.OfType<Wages>().OrderByDescending(e => e.WeeklyPay).FirstOrDefault();
        }

        static Employee GetLowestSalaryEmployee(List<Employee> employees)
        {
            return employees.OfType<Salaried>().OrderBy(e => e.WeeklyPay).FirstOrDefault();
        }

        static Dictionary<string, double> CalculatePercentageByCategory(List<Employee> employees)
        {
            var categoryCounts = employees.GroupBy(e => e.GetType().Name)
                                         .ToDictionary(g => g.Key, g => (double)g.Count() / employees.Count);

            return categoryCounts;
        }
    }

}

