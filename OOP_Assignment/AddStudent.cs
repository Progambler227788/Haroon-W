using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_Assignment
{
    public partial class AddStudent : Form
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataStoragePersons;Integrated Security=True";
        public AddStudent()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            Country.SelectedIndex = 0;

        }
      

        private void save_Click(object sender, EventArgs e)
        { 

            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(NameStu.Text) || string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Age.Text) || string.IsNullOrWhiteSpace(Country.Text) ||
                string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(StudentNum.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if a program is selected in the comboBox1
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

            // Create an instance of the StudentData class
            Student student = new Student
            {
                Name = NameStu.Text,
                Address = Address.Text,
                Age = Convert.ToInt32(Age.Text),
                County = Country.SelectedItem.ToString(),
                Phone = Phone.Text,
                Email = Email.Text,
                StudentNumber = StudentNum.Text,
                Program = comboBox1.SelectedItem.ToString()
            };

            // Insert the student data into the database
            if (InsertStudentData(student))
            {
                MessageBox.Show("Student data added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error adding student data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InsertStudentData(Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("enterStudent", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", student.Name);
                        command.Parameters.AddWithValue("@Address", student.Address);
                        command.Parameters.AddWithValue("@County", student.County);
                        command.Parameters.AddWithValue("@Age", student.Age);
                        command.Parameters.AddWithValue("@Phone", student.Phone);
                        command.Parameters.AddWithValue("@Email", student.Email);
                        command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                        command.Parameters.AddWithValue("@Program", student.Program);

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

        private void Age_KeyPress(object sender, KeyPressEventArgs e)
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

        private void StudentNum_TextChanged(object sender, EventArgs e)
        {

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
