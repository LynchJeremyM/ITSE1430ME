/* Jeremy Lynch
 * 11/27/2018
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile;
using Nile.Stores;

namespace Niles.Stores.Sql
{
    public class SqlNilesDatabase : ProductDatabase
    {
        #region Construction

        public SqlNilesDatabase( string connectionString )
        {
            //Validate
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty."
                            , nameof(connectionString));

            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        #endregion

        #region Protected Members

        protected override Product AddCore( Product product )
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                conn.Open();
                cmd.ExecuteReader();
            };

            return product;
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = CreateConnection())
            {
                var da = new SqlDataAdapter();
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);
            }

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
                return Enumerable.Empty<Product>();

            var products = new List<Product>();
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                var product = new Product()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row.Field<string>("Name"),
                    Description = row.Field<string>("Description"),
                    Price = row.Field<decimal>("Price"),
                    IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                };
                products.Add(product);
            };

            return products;
        }

        protected override Product GetCore( int id )
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        var productId = reader.GetInt32(0);
                        if (productId.CompareTo(id) == 0)
                            continue;

                        return new Product()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            //Name = reader.GetFieldValue<string>(1),
                            //Description = reader.GetFieldValue<string>(2),
                            //Price = reader.GetFieldValue<decimal>(4),
                            IsDiscontinued = reader.GetBoolean(4),
                        };
                    };
                };
            };

            return null;
        }

        protected override void RemoveCore( int id )
        {
            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            var id = Get(existing.Id);
            Remove(id.Id);

            return Add(newItem);
        }

        #endregion

        #region Private Members

        private SqlConnection CreateConnection()
            => new SqlConnection(_connectionString);

        #endregion
    }
}
