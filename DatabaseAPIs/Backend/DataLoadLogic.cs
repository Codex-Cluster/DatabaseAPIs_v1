using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

using DatabaseAPIs.Models; 

namespace DatabaseAPIs.Backend
{
    public class DataLoadLogic
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BookDB"].ConnectionString;

        protected List<Book> LoadBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Books";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return ConvertToBookList(dr);
            }
        }
        protected List<Category> LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Category";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return ConvertToCategoryList(dr);
            }
        }
        protected List<SubCategory> LoadSubcategories()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM SubCategory";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return ConvertToSubCategoryList(dr);
            }
        }
        protected List<Book> ConvertToBookList(SqlDataReader reader)
        {
            var rows = new List<Book>();
            while (reader.Read())
            {
                // rows.Add(columns.ToDictionary(column => column, column => reader[column]));
                rows.Add(new Book()
                {
                    Author = reader["Author"].ToString(),
                    Title = reader["Title"].ToString(),
                    CatID = reader["CatID"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    Image = reader["Image"].ToString(),
                    Rating = double.Parse(reader["Rating"].ToString()),
                    Format = reader["Format"].ToString(),
                    Price = double.Parse(reader["Price"].ToString()),
                    OldPrice = double.Parse(reader["OldPrice"].ToString()),
                    SubID = reader["SubID"].ToString(),
                });
            }
            return rows;
        }
        protected List<Category> ConvertToCategoryList(SqlDataReader reader)
        {
            var rows = new List<Category>();
            while (reader.Read())
            {
                // rows.Add(columns.ToDictionary(column => column, column => reader[column]));
                rows.Add(new Category()
                {
                    CatID = reader["CatID"].ToString(),
                    CatName = reader["CatName"].ToString(),
                    CatDescription = reader["CatDescription"].ToString(),
                    Position = Int32.Parse(reader["Position"].ToString()),
                    Status = reader["Status"].ToString(),
                    Image = reader["Image"].ToString()
                });
            }
            return rows;
        }
        protected List<SubCategory> ConvertToSubCategoryList(SqlDataReader reader)
        {
            var rows = new List<SubCategory>();
            while (reader.Read())
            {
                // rows.Add(columns.ToDictionary(column => column, column => reader[column]));
                rows.Add(new SubCategory()
                {
                    SubID = reader["SubID"].ToString(),
                    SubName = reader["SubName"].ToString(),
                    SubDescription = reader["SubDescription"].ToString(),
                    Position = Int32.Parse(reader["Position"].ToString()),
                    Status = reader["Status"].ToString(),
                    Image = reader["Image"].ToString(),
                    CatID = reader["CatID"].ToString()
                });
            }
            return rows;
        }
    }
}