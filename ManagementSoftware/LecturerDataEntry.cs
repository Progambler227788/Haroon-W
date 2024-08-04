using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagementSoftware
{
    public partial class LecturerDataEntry : Form
    {
        // private const string connectionString = "Your_Connection_String_Here";
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ManagementDB;Integrated Security=True";


        public LecturerDataEntry()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty text boxes
                if (AreTextBoxesEmpty())
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert data into the database
                InsertLecturerData();
                MessageBox.Show("Data saved successfully for Lecturer.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertLecturerData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertLecturer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set parameters
                    command.Parameters.AddWithValue("@Name", NameTB.Text);
                    command.Parameters.AddWithValue("@Address", AddressTB.Text);
                    command.Parameters.AddWithValue("@County", CountryTB.Text);
                    command.Parameters.AddWithValue("@Age", Convert.ToInt32(AgeTB.Text));
                    command.Parameters.AddWithValue("@Phone", PhoneTB.Text);
                    command.Parameters.AddWithValue("@Email", EmailTB.Text);
                    command.Parameters.AddWithValue("@Pay", PayTB.Text);
                    command.Parameters.AddWithValue("@Gender", GenderTB.Text);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private bool AreTextBoxesEmpty()
        {
            // Check if any of the text boxes are empty
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && textBox.Name.EndsWith("TB") && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }
            }

            return false;
        }

        private void home_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void AgeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }

        private void PhoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }
    }
}
