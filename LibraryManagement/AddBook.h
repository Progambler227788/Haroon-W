#pragma once
#include <windows.h>
#include <sqltypes.h>

#include "AddBook.h"


namespace LibraryManagement {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Data::SqlClient;
	ref class AddBook; // Forward declaration

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class HomePage : public System::Windows::Forms::Form
	{
	public:
		HomePage(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~HomePage()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ ShowBooks;
	private: System::Windows::Forms::DataGridView^ BooksData;
	private: System::Windows::Forms::Button^ AddBook;


	protected:

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->ShowBooks = (gcnew System::Windows::Forms::Button());
			this->BooksData = (gcnew System::Windows::Forms::DataGridView());
			this->AddBook = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->BooksData))->BeginInit();
			this->SuspendLayout();
			// 
			// ShowBooks
			// 
			this->ShowBooks->Location = System::Drawing::Point(555, 44);
			this->ShowBooks->Name = L"ShowBooks";
			this->ShowBooks->Size = System::Drawing::Size(120, 61);
			this->ShowBooks->TabIndex = 0;
			this->ShowBooks->Text = L"Show";
			this->ShowBooks->UseVisualStyleBackColor = true;
			this->ShowBooks->Click += gcnew System::EventHandler(this, &HomePage::show);
			// 
			// BooksData
			// 
			this->BooksData->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->BooksData->Location = System::Drawing::Point(1, 44);
			this->BooksData->Name = L"BooksData";
			this->BooksData->RowHeadersWidth = 62;
			this->BooksData->RowTemplate->Height = 28;
			this->BooksData->Size = System::Drawing::Size(502, 212);
			this->BooksData->TabIndex = 1;
			// 
			// AddBook
			// 
			this->AddBook->Location = System::Drawing::Point(555, 134);
			this->AddBook->Name = L"AddBook";
			this->AddBook->Size = System::Drawing::Size(120, 61);
			this->AddBook->TabIndex = 2;
			this->AddBook->Text = L"Add Book";
			this->AddBook->UseVisualStyleBackColor = true;
			this->AddBook->Click += gcnew System::EventHandler(this, &HomePage::AddBook_Click);
			// 
			// HomePage
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(766, 376);
			this->Controls->Add(this->AddBook);
			this->Controls->Add(this->BooksData);
			this->Controls->Add(this->ShowBooks);
			this->Name = L"HomePage";
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &HomePage::MyForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->BooksData))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
	}

	private: System::Void show(System::Object^ sender, System::EventArgs^ e) {

		try {
			String^ connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True";


			// Create a SqlConnection
			SqlConnection^ connection = gcnew SqlConnection(connectionString);

			// Open the connection
			connection->Open();

			// Create a SqlCommand for the stored procedure
			SqlCommand^ command = gcnew SqlCommand("usp_GetBooks", connection);
			command->CommandType = CommandType::StoredProcedure;

			// Create a DataTable to store the result
			DataTable^ dataTable = gcnew DataTable();

			// Use a DataAdapter to fill the DataTable
			SqlDataAdapter^ adapter = gcnew SqlDataAdapter(command);
			adapter->Fill(dataTable);

			// Set the DataTable as the DataSource for the DataGridView
			BooksData->DataSource = dataTable;
		}
		catch (Exception^ ex) {
			// Handle any exceptions
			MessageBox::Show("Error: " + ex->Message, "Error", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
	}

private: System::Void AddBook_Click(System::Object^ sender, System::EventArgs^ e) {

	LibraryManagement::AddBook^ addBookForm = gcnew LibraryManagement::AddBook();

	// Show the AddBook form
	addBookForm->Show();

	this->Hide();
}
};
}
