// Books.h
#pragma once

using namespace System;
using namespace System::Collections::Generic;

namespace $safeprojectname$ {

    public ref class Book {
    public:
        property int BookID;
        property String^ Title;
        property String^ Author;
        property int PublicationYear;
    };

    public ref class Books {
    private:
        List<Book^>^ bookList;

    public:
        Books();
        void AddBook(int bookID, String^ title, String^ author, int publicationYear);
    };

} // namespace $safeprojectname$
