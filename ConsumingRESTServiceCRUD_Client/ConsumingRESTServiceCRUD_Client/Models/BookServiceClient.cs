using ConsumingRESTServiceCRUD_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingRESTServiceCRUD_Client.Models
{
    public class BookServiceClient
    {
        Service1Client client = new Service1Client();
        string BASE_URL = "http://localhost:64638/Service1.svc?wsdl";

        public List<Book> getAllBook()
        {
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookId = b.BookId,
                ISDN = b.ISBN,
                Title = b.Title
            }));
            return rt;
            //var syncClient = new WebClient();
            //var content = syncClient.DownloadString(BASE_URL + "Books");
            //var json_serializer = new JavaScriptSerializer();
            //return json_serializer.Deserialize<List<Book>>(content);
        }
        public string AddBook(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISDN,
                Title = newBook.Title
            };
            return client.AddBook(book);
        }
        public string DeleteBook(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }
        public string edit(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISDN,
                Title = newBook.Title
            };
            return client.UpdateBook(book);
        }
    }
}