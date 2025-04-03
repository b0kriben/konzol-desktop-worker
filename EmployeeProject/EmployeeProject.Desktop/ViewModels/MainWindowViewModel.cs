using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EmployeeProject.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ControlPanelViewModel ControlPanelVM { get; set; }
        public EmployeeManagementViewModel ManagementVM { get; set; }

        public MainWindowViewModel()
        {
            ControlPanelVM = new ControlPanelViewModel();
            ManagementVM = new EmployeeManagementViewModel();
        }
    }
}
