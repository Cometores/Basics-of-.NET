using CustomersApp.Data;
using CustomersApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApp.ViewModel
{
    public class CustomersViewModel
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer> Customers { get; } = new();

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
    }
}
