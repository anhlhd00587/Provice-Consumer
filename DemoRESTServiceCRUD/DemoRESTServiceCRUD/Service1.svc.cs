using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DemoRESTServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static IBookRepository repository = new BookReponsitory();
        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id" + newBook.BookId;
            //throw new NotImplementedException();
        }

        public string DeleteBook(string id)
        {
            bool delete = repository.DeleteBook(int.Parse(id));
            if (delete)
                return "Delete succes";
            else
                return "Delete false";
            //throw new NotImplementedException();
        }

        public Book getBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
            //throw new NotImplementedException();
        }

        public List<Book> GetBookList()
        {
            return repository.GetAllBook();
            //throw new NotImplementedException();
        }

        public string UpdateBook(Book book)
        {
            bool deleted = repository.UpdateBook(book);
            if (deleted)
                return "Book with id=" + book.BookId + " Update successfully";
            else
                return "Unable to update book with id =" + book.BookId;
            // throw new NotImplementedException();
        }
    }
}
