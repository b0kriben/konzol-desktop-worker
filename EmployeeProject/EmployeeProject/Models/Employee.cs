namespace EmployeeProject.Models
{
    public class Employee
    {
        private string _email;
        private int _salary;

        public Employee(string email, string name)
        {
            if (!IsEmailValid(email))
                throw new ArgumentException("Az e-mail cím formátuma nem megfelelő!");
            if (IsEmpty(name))
                throw new ArgumentException("A név nem lehet üres!");

            _email = email;
            Name = name;
            _salary = 0;
        }

        public string Name { get; set; }
        public string Email { get => _email; set => _email = value; }
        public int Salary { get => _salary; set => _salary = value; }

        private static bool IsEmailValid(string email) =>
            !IsEmpty(email) && email.Contains('@');

        private static bool IsEmpty(string text) =>
            text is null || text == string.Empty || text == "" || text.Length == 0;

        public void AddSalary(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Nem megfelelő összeg!");
            _salary += amount;
        }

        public override string ToString() =>
            $"{Name} - {Salary} Ft";
    }
}
