using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Shop
{
    class ManagementShopSQL : IManagementShop
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringShopDB"].ConnectionString;

        public List<Product> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Product> list = new List<Product>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
                reader.Close();
                return list;
            }
        }

        public List<Sale> GetAllSales()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Sales", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Sale> list = new List<Sale>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Sale()
                        {
                            SaleId = reader.GetInt32(0),
                            BuyerName = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            Sum = reader.GetDecimal(3),
                            ProductId = reader.GetInt32(4)
                        });
                    }
                }
                reader.Close();
                return list;
            }
        }
        public bool AddProduct(string name, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("INSERT INTO Products (Name, Price) VALUES ('{0}', {1})", name, price);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public bool AddSale(string buyer, int productId, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                string sqlExpression = String.Format("SELECT Price FROM Products Where ProductId = {0}", productId);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object result = command.ExecuteScalar();
                if (result == null)
                {
                    return false;
                }
                decimal price = (decimal)result;
                command.CommandText = String.Format("INSERT INTO Sales (BuyerName, Quantity, Sum, ProductId) VALUES ('{0}', {1}, {2}, {3})", buyer, quantity, price*quantity, productId);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public List<Product> GetProductsByNameAndPrice(string nameArg, decimal priceArg)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT * FROM Products WHERE Name LIKE '%{0}%' AND Price <= {1}", nameArg, priceArg);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Product> list = new List<Product>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
                reader.Close();
                return list;
            }
        }
        public Product GetProductById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT * FROM Products WHERE ProductId = {0}", Id);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                Product product = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2)
                    };
                }
                reader.Close();
                return product;
            }
        }
        public Sale GetSaleById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("SELECT * FROM Sales WHERE SaleId = {0}", Id);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                Sale sale = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    sale = new Sale()
                    {
                        SaleId = reader.GetInt32(0),
                        BuyerName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                        Sum = reader.GetDecimal(3),
                        ProductId = reader.GetInt32(4)
                    };
                }
                reader.Close();
                return sale;
            }
        }
        public bool ChangeProduct(int Id, string name, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("UPDATE Products SET Name='{1}', Price={2} WHERE ProductId = {0}", Id, name, price);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public bool DeleteProductById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("DELETE FROM Products WHERE ProductId = {0}", Id);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public bool DeleteSaleById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                string sqlExpression = String.Format("DELETE FROM Sales WHERE SaleId = {0}", Id);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public bool DeleteAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("TRUNCATE TABLE Products", connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
        public bool DeleteAllSales()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("TRUNCATE TABLE Sales", connection);
                return Convert.ToBoolean(command.ExecuteNonQuery());
            }
        }
    }
}