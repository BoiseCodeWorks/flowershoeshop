using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using markoz.Models;

namespace markoz.Repositories
{
    public class FlowerRepository
    {
        private readonly IDbConnection _db;
        public FlowerRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Flower> GetALL()
        {
            return _db.Query<Flower>("SELECT * FROM flowers");
        }

        public Flower GetById(int id)
        {
            string query = "SELECT * FROM flowers WHERE id = @id";
            Flower shoe = _db.QueryFirstOrDefault<Flower>(query, new { id });
            if (shoe == null) throw new Exception("Invalid Id");
            return shoe;
        }

        public Flower Create(Flower value)
        {
            string query = @"
            INSERT INTO flowers (name, price)
                    VALUES (@Name, @Price);
                    SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Flower Update(Flower value)
        {
            string query = @"
            UPDATE flowers
            SET
                name = @Name,
                price = @Price
            WHERE id = @Id;            
            SELECT * FROM flowers WHERE id = @Id";
            return _db.QueryFirstOrDefault<Flower>(query, value);
        }

        public string Delete(int id)
        {
            string query = "DELETE FROM flowers WHERE id = @Id";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully deleted Flower";

        }
    }
}