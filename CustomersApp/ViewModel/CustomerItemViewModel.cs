using CustomersApp.Model;

namespace CustomersApp.ViewModel
{
    public class CustomerItemViewModel: ViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            this._model = model;
        }
    }
}
