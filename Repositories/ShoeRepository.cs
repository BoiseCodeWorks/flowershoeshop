using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using markoz.Models;

namespace markoz.Repositories
{
    public class ShoeRepository
    {
        private readonly IDbConnection _db;
        public ShoeRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Shoe> GetALL()
        {
            return _db.Query<Shoe>("SELECT * FROM shoes");
        }

        public Shoe GetById(int id)
        {
            string query = "SELECT * FROM shoes WHERE id = @id";
            Shoe shoe = _db.QueryFirstOrDefault<Shoe>(query, new { id });
            if (shoe == null) throw new Exception("Invalid Id");
            return shoe;
        }

        public Shoe Create(Shoe value)
        {
            string query = @"
            INSERT INTO shoes (brand, style, price)
                    VALUES (@Brand, @Style, @Price);
                    SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Shoe Update(Shoe value)
        {
            string query = @"
            UPDATE shoes
            SET
                brand = @Brand,
                style = @Style,
                price = @Price
            WHERE id = @Id;            
            SELECT * FROM shoes WHERE id = @Id";
            return _db.QueryFirstOrDefault<Shoe>(query, value);
        }

        public string Delete(int id)
        {
            string query = "DELETE FROM shoes WHERE id = @Id";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully deleted Shoe";

        }
    }
}