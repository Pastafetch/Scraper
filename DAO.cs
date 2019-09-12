﻿using MySql.Data.MySqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbotTest
{
   
    public class DaoArticle
    {
        
        public static bool InsertUrl(string url)
        {


            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string sql = string.Format($"INSERT INTO article (title) VALUE ('{url}')");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return false;
            }


        }

        public List<Article> GetAllArticles()
        {
            List<Article> articles = new List<Article>();
            //string sql = "select * from article";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //MySqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    articles.Add(new Article(){
            //        ArticleId = int.Parse(reader[0]),
            //        );
            //}
            //reader.Close();
            return articles;
        }



    }

    public class DaoUrl
    {

        public static bool InsertFreshUrls(List<string> freshUrls)
        {
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                foreach (string url in freshUrls)
                {
                    string sql = string.Format($"INSERT INTO url (url) VALUE ('{url}')");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return false;
            }


        }

        public static List<string> GetAllKnownUrls(ref List<string> urlList)
        {


            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string sql = string.Format("SELECT url FROM url");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    urlList.Add(reader[0].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());

            }

            return urlList;

        }
    }


    public class DaoCategory
    {
        public static bool InitCategoryDB(List<Category> categories)
        {
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                foreach (Category category in categories)
                {
                    string sql = string.Format($"INSERT INTO category (category_name, relative_path) VALUES ('{category.Name}', '{category.Relative_Path}')");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return false;

            }
        }

        public static List<Category> GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {

                conn.Open();
                string sql = string.Format($"SELECT * FROM category");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        CategoryId = int.Parse(reader.GetString(1)),
                        Name = reader.GetString(0),
                        Relative_Path = reader.GetString(2)
                    };
                    categories.Add(category);
                }
                conn.Close();
                return categories;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return categories;

            }
        }

    }

    public class DaoBlog
    {
        public static bool InitBlogDB(List<Blog> blogs)
        {
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                foreach (Blog blog in blogs)
                {
                    Debug.WriteLine("inserting to blog database");
                    string sql = string.Format($"INSERT INTO blog (name, relative_path) VALUES ('{blog.BlogName}', '{blog.Relative_Path}')");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return false;

            }
        }

        public static List<Blog> GetAllBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {

                conn.Open();
                string sql = string.Format($"SELECT * FROM blog");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Blog blog = new Blog();
                    blog.BlogId = int.Parse(reader.GetString(2));
                    blog.BlogName = reader.GetString(0);
                    blog.Relative_Path = reader.GetString(1);

                    blogs.Add(blog);
                }

                conn.Close();
                return blogs;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return blogs;
                
            }
        }

    }

    public class DaoAuthor
    {
        public static bool InsertAuthor(Author author)
        {
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                
                    string sql = string.Format($"INSERT INTO author (name, description) VALUES ('{author.AuthorName}', '{author.AuthorDescription}')");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return false;

            }
        }

        public static List<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();
            string connStr = "server=localhost;user=root;database=news_data_pool;port=3306;password=3056jjjjj";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {

                conn.Open();
                string sql = string.Format($"SELECT * FROM author");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author()
                    {
                        AuthorId = int.Parse(reader.GetString(1)),
                        AuthorName = reader.GetString(0),
                        AuthorDescription = reader.GetString(2)
                    };
                    authors.Add(author);
                }
                conn.Close();
                return authors;
            }
            catch (Exception e)
            {
                conn.Close();
                Log.Logger.Information(e.ToString());
                return authors;

            }
        }

    }
}
