using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Assignment
{
    public partial class Form1 : Form
    {
        //  a connection string
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataStoragePersons;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();

            Lecturers.SelectedIndex = 0;
            Students.SelectedIndex = 0;
            // Populate the ComboBox with items
            PopulateComboBox();
           
        }

        private void PopulateComboBox()
        {
            // Add items to the ComboBox
            comboBox1.Items.Add("All Students");
            comboBox1.Items.Add("All Lecturers");
            comboBox1.Items.Add("Male Lecturers");
            comboBox1.Items.Add("Students Age Above 25");
            comboBox1.Items.Add("Students by Name starting with A or a");
            comboBox1.Items.Add("Highest Salary Lecturer");
            comboBox1.SelectedIndex = 0; 
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the relevant method based on the selected item
            switch (comboBox1.SelectedItem.ToString())
            {
                case "All Students":
                    DisplayData(GetStudents());
                    break;
                case "All Lecturers":
                    DisplayData(GetLecturers());
                    break;
                case "Male Lecturers":
                    DisplayData(GetMaleLecturers());
                    break;
                case "Students Age Above 25":
                    DisplayData(GetStudentsAbove25());
                    break;
                case "Students by Name starting with A or a":
                    DisplayData(GetStudentsByNamePattern());
                    break; 
                case "Highest Salary Lecturer":
                    DisplayData(GetHighestSalary());
                    break;


                default:
                    break;
            }
        }

        private List<Student> GetStudents()
        {
            // Implement logic to call stored procedure for all students
            DataTable dataTable = FetchDataFromDatabase("getStudents");
            return ConvertToStudentList(dataTable);
        }

        private List<Lecturer> GetLecturers()
        {
            // Implement logic to call stored procedure for all lecturers
            DataTable dataTable = FetchDataFromDatabase("getLecturers");
            return ConvertToLecturerList(dataTable);
        }
        private List<Lecturer> GetHighestSalary()
        {
            // Implement logic to call stored procedure for all lecturers
            DataTable dataTable = FetchDataFromDatabase("GetHighestPaidLecturer");
            return ConvertToLecturerList(dataTable);
        }


        private List<Lecturer> GetMaleLecturers()
        {
            // Implement logic to call stored procedure for male lecturers
            DataTable dataTable = FetchDataFromDatabase("getMaleLecturers");
            return ConvertToLecturerList(dataTable);
        }

        private List<Student> GetStudentsAbove25()
        {
            // Implement logic to call stored procedure for students above 25
            DataTable dataTable = FetchDataFromDatabase("getStudentsAbove25");
            return ConvertToStudentList(dataTable);
        }

        private List<Student> GetStudentsByNamePattern()
        {
            // Implement logic to call stored procedure for students by name pattern
            DataTable dataTable = FetchDataFromDatabase("getStudentsByNamePattern");
            return ConvertToStudentList(dataTable);
        }

        // Generic method to fetch data from the database without parameters
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

        private DataTable FetchDataFromDatabaseWithParameters(string storedProcedureName, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command 
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                connection.Close();
            }

            return dataTable;
        }
        private List<Lecturer> GetLecturersBySubject(string subject)
        {
            // Implement logic to call stored procedure for lecturers by subject
            SqlParameter parameter = new SqlParameter("@Subject", subject);
            DataTable dataTable = FetchDataFromDatabaseWithParameters("GetLecturersBySubject", parameter);
            return ConvertToLecturerList(dataTable);
        }

        private List<Student> GetStudentsByProgram(string program)
        {
            // Implement logic to call stored procedure for students by program
            SqlParameter parameter = new SqlParameter("@Program", program);
            DataTable dataTable = FetchDataFromDatabaseWithParameters("GetStudentsByProgram", parameter);
            return ConvertToStudentList(dataTable);
        }



        // Display data in your DataGridView or other UI elements
        private void DisplayData<T>(List<T> dataList)
        {
           
            dataShow.DataSource = dataList;
        }

        // Convert DataTable to List<Student>
        private List<Student> ConvertToStudentList(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow row in dataTable.Rows)
            {
                Student student = new Student
                {
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    County = row["County"].ToString(),
                    Age = Convert.ToInt32(row["Age"]),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    StudentNumber = row["StudentNumber"].ToString(),
                    Program = row["Program"].ToString()
                };
            

                students.Add(student);
            }

            return students;
        }

        // Convert DataTable to List<Lecturer>
        private List<Lecturer> ConvertToLecturerList(DataTable dataTable)
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            foreach (DataRow row in dataTable.Rows)
            {
                Lecturer lecturer = new Lecturer
                {
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    County = row["County"].ToString(),
                    Age = Convert.ToInt32(row["Age"]),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    Pay = row["Pay"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Subject = row["Subject"].ToString()
                };

                lecturers.Add(lecturer);
            }

            return lecturers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           new AddLecturer().Show();
           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddStudent().Show();
            Hide();
        }
        private string CheckProgram(string inputString)
        {
            string[] validPrograms = { "Bsc in Computing", "Msc in Business", "Bsc in Psychology", "Diploma in mathematics" };

            foreach (string program in validPrograms)
            {
                if (inputString.Contains(program))
                {
                    return program;
                }
            }

            return null; // Return null if none of the valid programs is found
        }
        private string CheckSubject(string inputString)
        {
            string[] validSubjects = { "Programming", "Business", "Psychology", "Mathematics" };

            foreach (string subject in validSubjects)
            {
                if (inputString.Contains(subject))
                {
                    return subject;
                }
            }

            return null; // Return null if none of the valid subjects is found
        }

        private void Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            String program = CheckProgram(Students.SelectedItem.ToString());
            DisplayData(GetStudentsByProgram(program));
        }

        private void Lecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            String subject = CheckSubject(Lecturers.SelectedItem.ToString());
            DisplayData(GetLecturersBySubject(subject));
        }
    }
}
