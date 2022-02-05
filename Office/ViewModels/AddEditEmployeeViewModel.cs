using Office.Commands;
using Office.Models;
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
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeViewModel(Employee employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new Employee();

            }            
            else
            {
                Employee = employee;
                IsUpdate = false;
            }

            InitGroups();
            InitContract();
        }


        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
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

        private ObservableCollection<Group> _group;

        public ObservableCollection<Group> Groups
        {
            get { return _group; }
            set
            {
                _group = value;
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


        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>
            {
                new Group {Id = 0, Name = "-- Brak --"},
                new Group {Id = 1, Name = "Produkcja"},
                new Group {Id = 2, Name = "HR"},
                new Group {Id = 3, Name = "Kierownictwo"},
            };

            Employee.Group.Id = 0;
        }

        private void InitContract()
        {
            Contracts = new ObservableCollection<Contract>
            {
                new Contract {Id=0, Name ="-- Brak --"},
                new Contract {Id=0, Name ="Umowa Zlecenie"},
                new Contract {Id=0, Name ="Umowa O Pracę"},
                new Contract {Id=0, Name ="Umowa O Dzieło"},
                new Contract {Id=0, Name ="Umowa B2B"},
            };

            Employee.Contract.Id = 0;
        }


        private void Confirm(object obj)
        {
            if (!IsUpdate)
            {
                AddEmployee();
            }
            else
            {
                UpdateEmployee();
            }
            //
            CloseWindow(obj as Window);

        }

        private void UpdateEmployee()
        {
            // baza danych
        }

        private void AddEmployee()
        {
            // baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
