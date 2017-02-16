using Models;
using Repository;
using System;
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DetermineDisplayDirection("");
        }

        private void CustomersListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var row = CustomersListView.FocusedItem.Index;

            IdLabel.Text = CustomersListView.Items[row].SubItems[0].Text;
            NameLabel.Text = CustomersListView.Items[row].SubItems[1].Text;
            AddressLabel.Text = CustomersListView.Items[row].SubItems[2].Text;
            CityLabel.Text = CustomersListView.Items[row].SubItems[3].Text;
            ZipLabel.Text = CustomersListView.Items[row].SubItems[4].Text;
            StateLabel.Text = CustomersListView.Items[row].SubItems[5].Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_repository.Update(GetSelectedCustomer()))
            {
                MessageBox.Show("Customer updated!");
            }
            else
            {
                MessageBox.Show("Error: Unable to update customer.");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_repository.Delete(GetSelectedCustomer().Id))
            {
                MessageBox.Show("Customer Deleted!");
            }
            else
            {
                MessageBox.Show("Error: Unable to delete customer.");
            }
        }
        private Customer GetSelectedCustomer()
        {
            return new Customer()
            {
                Id = int.Parse(IdLabel.Text),
                Name = NameLabel.Text,
                Address = AddressLabel.Text,
                City = CityLabel.Text,
                Zip = ZipLabel.Text,
                State = StateLabel.Text
            };
        }

    }
}
