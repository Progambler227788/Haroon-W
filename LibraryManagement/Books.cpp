// Books.cpp
#include "Books.h"

namespace $safeprojectname$ {

    Books::Books() {
        bookList = gcnew List<Book^>();
    }

    void Books::AddBook(int bookID, String^ title, String^ author, int publicationYear) {
        Book^ newBook = gcnew Book();
        newBook->Title = title;
        newBook->BookID= bookID;
        newBook->PublicationYear= publicationYear;
        newBook->Author = author;
        bookList->Add(newBook);
    }

} // namespace $safeprojectname$
