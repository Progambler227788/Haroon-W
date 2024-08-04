using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_Assignment
{
    public partial class AddLecturer : Form
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataStoragePersons;Integrated Security=True";
        public AddLecturer()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            Country.SelectedIndex = 0;
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(NameLec.Text) || string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Age.Text) || string.IsNullOrWhiteSpace(Country.Text) ||
                string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Pay.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a program from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               if (Country.SelectedItem == null)
            {
                MessageBox.Show("Please select a program from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate email format and provider
            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("Enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Determine the gender based on radio buttons
            string gender = Male.Checked ? "Male" : "Female";

            // Create an instance of the Lecturer class
            Lecturer lecturer = new Lecturer
            {
                Name = NameLec.Text,
                Address = Address.Text,
                Age = Convert.ToInt32(Age.Text),
                County = Country.SelectedItem.ToString(),
                Phone = Phone.Text,
                Email = Email.Text,
                Pay = Pay.Text,
                Gender = gender,
                Subject = comboBox1.SelectedItem.ToString()

            };

            // Insert the lecturer data into the database
            if (InsertLecturerData(lecturer))
            {
                MessageBox.Show("Lecturer data added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error adding lecturer data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsertLecturerData(Lecturer lecturer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("enterLecturer", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", lecturer.Name);
                        command.Parameters.AddWithValue("@Address", lecturer.Address);
                        command.Parameters.AddWithValue("@County", lecturer.County);
                        command.Parameters.AddWithValue("@Age", lecturer.Age);
                        command.Parameters.AddWithValue("@Phone", lecturer.Phone);
                        command.Parameters.AddWithValue("@Email", lecturer.Email);
                        command.Parameters.AddWithValue("@Pay", lecturer.Pay);
                        command.Parameters.AddWithValue("@Gender", lecturer.Gender);
                        command.Parameters.AddWithValue("@Subject", lecturer.Subject);

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }


        private const int MinAge = 1;
        private const int MaxAge = 120;

        private void Age_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
                MessageBox.Show("Enter only numbers");
            }
        }

        private void Age_TextChanged(object sender, EventArgs e)
        {
            // Check the entered age range
            if (!string.IsNullOrEmpty(Age.Text) && int.TryParse(Age.Text, out int enteredAge))
            {
                if (enteredAge < MinAge)
                {
                    MessageBox.Show($"Please enter an age greater than or equal to {MinAge}");
                    Age.Text = string.Empty;
                }
                else if (enteredAge > MaxAge)
                {
                    MessageBox.Show($"Please enter an age less than or equal to {MaxAge}");
                    Age.Text = string.Empty;
                }
            }
        }

        private const int MinPhoneLength = 5;
        private const int MaxPhoneLength = 15;

        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
                MessageBox.Show("Enter only numbers");
            }
        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {
            // Check the length of the entered phone number
            if (!string.IsNullOrEmpty(Phone.Text))
            {
                if (Phone.Text.Length > MaxPhoneLength)
                {
                    MessageBox.Show($"Please enter a phone number with length between {MinPhoneLength} and {MaxPhoneLength} characters");
                    Phone.Text = string.Empty;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email)
                {
                    // Check for common email providers
                    string[] validProviders = { "gmail.com", "hotmail.com", "yahoo.com" }; // Can add more as needed
                    foreach (var provider in validProviders)
                    {
                        if (email.EndsWith("@" + provider, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
