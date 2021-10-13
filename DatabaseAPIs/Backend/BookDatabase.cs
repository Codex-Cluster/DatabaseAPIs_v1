using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

using DatabaseAPIs.Models;
using DatabaseAPIs.Interfaces;

namespace DatabaseAPIs.Backend
{
    public class BookDatabase: DataLoadLogic, IBookDatabase
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BookDB"].ConnectionString;
        public List<Book> Books = new List<Book>();
        private static BookDatabase Instance = null;
        public static BookDatabase instantiateDB()
        {
            if (Instance == null)
            {
                Instance = new BookDatabase();
            }
            return Instance;
        }
        private BookDatabase()
        {
            Books = LoadBooks();
        }


        public List<Book> GetData()
        {
            return Books;
        }

        public Book GetData(string isbn)
        {
            return Books.FirstOrDefault(book => book.ISBN == isbn);
        }

        public string PostData(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = String.Format(
                    "insert into BooksCollection (Author, Title, CatID, ISBN, Image, Rating, Format, Price, OldPrice, SubID) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    book.Author, book.Title, book.CatID, book.ISBN, book.Image, book.Rating, book.Format, book.Price, book.OldPrice, book.SubID
                    );
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Books.Add(book);
            return String.Format(
                "Successfully added book! Author: {0} Title: {1} CatID: {2} ISBN: {3} Date: {4}", 
                book.Author, book.Title, book.CatID, book.ISBN, book.Image, book.Rating, book.Format, book.Price, book.OldPrice 
                );
        }

        public string PutData(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = String.Format(
                    "update BooksCollection set Author='{0}', Title='{1}', CatID='{2}', ISBN='{3}', Image='{4}', Rating='{5}', Format='{6}', Price='{7}', OldPrice='{8}' SubID='{9}' where ISBN='{3}'",
                    book.Author, book.Title, book.CatID, book.ISBN, book.Image, book.Rating, book.Format, book.Price, book.OldPrice, book.SubID
                    );
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Books = LoadBooks();
            return String.Format(
                "Successfully updated book! Author: {0} Title: {1} CatID: {2} ISBN: {3} Price: {8}",
                book.Author, book.Title, book.CatID, book.ISBN, book.Image, book.Rating, book.Format, book.Price, book.OldPrice
                );
        }

        public string DeleteData(string isbn)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = String.Format("DELETE FROM BooksCollection WHERE ISBN='{0}'", isbn);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Books.Remove(Books.FirstOrDefault(book => book.ISBN == isbn));
            return String.Format("Deleted book where ISBN == {0}", isbn);
        }
    }
}