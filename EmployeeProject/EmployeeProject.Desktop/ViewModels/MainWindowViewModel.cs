using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EmployeeProject.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ControlPanelViewModel ControlPanelViewModel { get; set; }
        public EmployeeManagementViewModel EmployeeManagementViewModel { get; set; }

        public MainWindowViewModel()
        {
            ControlPanelViewModel = new ControlPanelViewModel();
            EmployeeManagementViewModel = new EmployeeManagementViewModel();
        }
    }
}
