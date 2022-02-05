using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Office.Commands;
using Office.Models;
using Office.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Office.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEditEmployee);
            EditEmployeeCommand = new RelayCommand(AddEditEmployee, CanEditDeleteEmployee);
            DeleteEmployeeCommand = new AsyncRelayCommand(DeleteEmployee, CanEditDeleteEmployee);
            RefreshEmployeeCommand = new RelayCommand(RefreshEmployee);

            RefreshOffice();

            InitGroups();
            InitContracts();
        }

       

        public ICommand AddEmployeeCommand { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public ICommand RefreshEmployeeCommand { get; set; }




        private Employee _selectedEmployee;

        public Employee SelectedEmployee 
        {
            get { return _selectedEmployee; }
            set {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        private int _selectedContractId;

        public int SelectedContractId
        {
            get { return _selectedContractId; }
            set
            {
                _selectedContractId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Contract> _contracts;

        public ObservableCollection<Contract> Contracts
        {
            get { return _contracts; }
            set
            {
                _contracts = value;
                OnPropertyChanged();
            }
        }


        private bool CanEditDeleteEmployee(object obj)
        {
            return SelectedEmployee != null;
        }

        private async Task DeleteEmployee(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;

           var dialog = await metroWindow.ShowMessageAsync
           ("Usuwanie Pracownika", $"Czy na pewno chcesz usunąć pracownika { SelectedEmployee.FirstName} { SelectedEmployee.LastName}?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog == MessageDialogResult.Affirmative)
            {
                return;
            }
        }

        private void AddEditEmployee(object obj)
        {
            var addEditEmployeeWindow = new AddEditEmployeeView(obj as Employee);

            addEditEmployeeWindow.Closed += AddEditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void AddEditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            RefreshOffice();
        }

        private void RefreshEmployee(object obj)
        {
            RefreshOffice();
        }

        private void InitContracts()
        {
            Contracts = new ObservableCollection<Contract>
            {
                new Contract {Id=0, Name ="Wszystkie Umowy"},
                new Contract {Id=0, Name ="Umowa Zlecenie"},
                new Contract {Id=0, Name ="Umowa O Pracę"},
                new Contract {Id=0, Name ="Umowa O Dzieło"},
                new Contract {Id=0, Name ="Umowa B2B"},
            };

            SelectedContractId = 0;
        }

        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>
            {
                new Group {Id = 0, Name = "Wszystkie"},
                new Group {Id = 1, Name = "Produkcja"},
                new Group {Id = 2, Name = "HR"},
                new Group {Id = 3, Name = "Kierownictwo"},
            };

            SelectedGroupId = 0;
        }

        private void RefreshOffice()
        {
            Employees = new ObservableCollection<Employee>
            {

                new Employee
                {
                    FirstName = "Jan",
                    LastName = "As",
                    Group = new Group {Id = 1},
                    Contract = new Contract {Id = 1},

                },

                 new Employee
                {
                    FirstName = "Marian",
                    LastName = "Now",
                    Group = new Group {Id = 2},
                    Contract = new Contract {Id = 2},

                },

                  new Employee
                {
                    FirstName = "Olgier",
                    LastName = "Gwóźdź",
                    Group = new Group {Id = 3},
                    Contract = new Contract {Id = 3},

                },
            };
        }


    }

}
