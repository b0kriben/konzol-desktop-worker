using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeProject.Models;
using EmployeeProject.Repos;
using System.Collections.ObjectModel;
using System.Windows;

namespace EmployeeProject.Desktop.ViewModels
{
    public partial class EmployeeManagementViewModel : ObservableObject
    {
        private readonly EmployeeRepo _repo;

        [ObservableProperty]
        private ObservableCollection<Employee> _employees;
        [ObservableProperty]
        private Employee _selectedEmployee;
        [ObservableProperty]
        private int _amount;

        public EmployeeManagementViewModel()
        {
            _repo = new EmployeeRepo();
            UpdateView();
        }

        [RelayCommand]
        private void AddSalary()
        {
            Employee? employee = _repo.GetEmployeeByEmail(SelectedEmployee.Email);

            if (employee is null)
                MessageBox.Show("Nem található dolgozó!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                _repo.AddSalary(SelectedEmployee.Email, Amount);
            UpdateView();
        }

        [RelayCommand]
        private void DeleteEmployee(string email)
        {
            Employee? employee = _repo.GetEmployeeByEmail(email);

            if (employee is null)
                MessageBox.Show("Nem található dolgozó ilyen e-mail címmel.", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if(employee.Salary != 0)
                MessageBox.Show("Csak fizetés nélküli dolgozókat törölhet!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                _repo.DeleteEmployee(email);
            UpdateView();
        }

        private void UpdateView()
        {
            Employees = new ObservableCollection<Employee>(_repo.GetEmployees());
            SelectedEmployee = Employees[0];
            Amount = 0;
        }
    }
}
