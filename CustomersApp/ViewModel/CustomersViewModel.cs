using CustomersApp.Command;
using CustomersApp.Data;
using CustomersApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApp.ViewModel
{

    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
        }

        public ObservableCollection<Customer> Customers { get; } = new();

        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set {
                _selectedCustomer = value; 
                RaisePropertyChanged();
            }
        }

        public NavigationSide NavigationSide { get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
        }

        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left
                ? NavigationSide.Right
                : NavigationSide.Left;
        }
    }

    public enum NavigationSide
    {
        Left,
        Right
    }
}
