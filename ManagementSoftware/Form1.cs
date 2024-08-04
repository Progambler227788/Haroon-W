using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagementSoftware
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ManagementDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Top = toolStrip1.Bottom;
            // Load data into the DataGrid on form load
            LoadData("GetAllStudents");
        }


        private void LoadData(string storedProcedureName)
        {
            // Clear existing columns and rows in the DataGrid
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Fetch data from the database and populate the DataGrid
            DataTable dataTable = FetchDataFromDatabase(storedProcedureName);

            // Display column names in the first row
            foreach (DataColumn column in dataTable.Columns)
            {
                dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
            }

            // Display data in subsequent rows
            foreach (DataRow row in dataTable.Rows)
            {
                object[] rowData = row.ItemArray;
                dataGridView1.Rows.Add(rowData);
            }
        }




        private DataTable FetchDataFromDatabase(string storedProcedureName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                connection.Close();
            }

            return dataTable;
        }

        private void BindDataToDataGridView(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }
        }

     

        private void menuItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;

            if (menuItem != null)
            {
                LoadData(menuItem.Tag.ToString());
            }
        }

       

       

        private void displayStudents(object sender, EventArgs e)
        {
            LoadData("GetAllStudents");
        }

        private void displayLecturers(object sender, EventArgs e)
        {
            LoadData("GetAllLecturers");
        }

        private void male(object sender, EventArgs e)
        {
            LoadData("GetMaleLecturers");
        }

        private void female(object sender, EventArgs e)
        {
            LoadData("GetFemaleLecturers");
        }

        private void salaryabove25000(object sender, EventArgs e)
        {
            LoadData("GetSalary>25000");
        }

        private void ageAbove25(object sender, EventArgs e)
        {
            LoadData("GetStudentsAbove25");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new StudentDataEntry().Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new LecturerDataEntry().Show();
            this.Hide();
        }
    }
}






//private void displayStudents(object sender, EventArgs e)
//{
//    LoadData("GetAllStudents");
//}

//private void lecturers(object sender, EventArgs e)
//{
//    LoadData("GetAllLecturers");
//}

//private void MaleLecturers(object sender, EventArgs e)
//{
//    LoadData("GetMaleLecturers");
//}

//private void HighPaidLecturers(object sender, EventArgs e)
//{
//    LoadData("GetHighPaidLecturers");
//}

//private void StudentsByCounty(object sender, EventArgs e)
//{
//    LoadData("GetStudentsByCounty");
//}

//private void Above25(object sender, EventArgs e)
//{
//    LoadData("GetStudentsAbove25");
//}

//private void femaleLecturers(object sender, EventArgs e)
//{
//    LoadData("GetFemaleLecturers");
//}

//private void PayGreaterThan25000(object sender, EventArgs e)
//{
//    LoadData("GetSalary>25000");
//}
