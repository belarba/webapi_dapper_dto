using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using App.Sinaf.Sds.Dominio.DTO;
using System.Data.SQLite;

namespace App.Sds.Repositorio.RepositorioDapper
{
    public class RepositorioDapperSds
    {
        private string connectionString;

//SQLITE EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\Sds.sqlite"; }
        }

        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
//SQLITE EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE

        public RepositorioDapperSds()
        {
            connectionString = "";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(NovaSds sds)
        {
            //using (IDbConnection dbConnection = Connection)
            using (var dbConnection = SimpleDbConnection()) //SQLite
            {
                string sQuery = @"INSERT INTO Sds_teste
                    (Name, Description) VALUES
                    (@Name, @Description)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, sds);
            }
        }

        public IEnumerable<NovaSds> GetAll()
        {
            //using (IDbConnection dbConnection = Connection)
            using (var dbConnection = SimpleDbConnection()) //SQLite
            {
                string sQuery = "SELECT * FROM Sds_teste";
                dbConnection.Open();
                return dbConnection.Query<NovaSds>(sQuery);
            }
        }

        public NovaSds GetById(int id)
        {
            //using (IDbConnection dbConnection = Connection)
            using (var dbConnection = SimpleDbConnection()) //SQLite
            {
                string sQuery = @"SELECT * FROM Sds_teste WHERE id=@Id"; 
                dbConnection.Open();
                return dbConnection.Query<NovaSds>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            //using (IDbConnection dbConnection = Connection)
            using (var dbConnection = SimpleDbConnection()) //SQLite
            {
                string sQuery = @"DELETE FROM Sds_teste WHERE id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(NovaSds sds)
        {
            //using (IDbConnection dbConnection = Connection)
            using (var dbConnection = SimpleDbConnection()) //SQLite
            {
                string sQuery = @"UPDATE Sds_teste SET Name=@Name, Description=@Description WHERE id=@Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, sds);
            }
        }

    }
}
