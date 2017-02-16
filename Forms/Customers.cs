using Customers;
using Repository;
using System;
using System.Linq;
using System.Windows.Forms;


namespace Forms
{
    public partial class Customers : Form
    {
        private CustomerRepository _repository;
        private int _page = 0;
        private int _limit = 20;

        public Customers()
        {
            _repository = new CustomerRepository();

            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            DisplayCustomers(0, _limit);
        }
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            DetermineDisplayDirection("previous");
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            DetermineDisplayDirection("next");
        }

        private void DisplayCustomers(int startIndex, int limit)
        {
            CustomersListView.Items.Clear();

            var customers = _repository.GetSomeCustomers(startIndex, limit);

            foreach (Customer customer in customers)
            {
                ListViewItem list = new ListViewItem(customer.Id.ToString());
                list.SubItems.Add(customer.Name);
                list.SubItems.Add(customer.Address);
                list.SubItems.Add(customer.City);
                list.SubItems.Add(customer.State);
                list.SubItems.Add(customer.Zip);

                CustomersListView.Items.Add(list);
            }
        }

        private void DetermineDisplayDirection(string direction)
        {
            int lastPage = GetCountCustomers() / _limit;

            if (direction.Equals("next"))
            {
                _page++;
                if (_page == lastPage)
                {
                    NextButton.Enabled = false;
                }
                PreviousButton.Enabled = true;
            }
            else if (direction.Equals("previous"))
            {
                _page--;
                if (_page == 0)
                {
                    PreviousButton.Enabled = false;
                }
                NextButton.Enabled = true;
            }

            int startIndex = _page * _limit;
            DisplayCustomers(startIndex, _limit);
        }

        private int GetCountCustomers()
        {
            return _repository.GetAll().Count;
        }

    }
}
