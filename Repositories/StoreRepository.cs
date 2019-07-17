using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using markoz.Models;

namespace markoz.Repositories
{
    public class StoreRepository
    {
        private readonly IDbConnection _db;
        public StoreRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Store> GetALL()
        {
            return _db.Query<Store>("SELECT * FROM stores");
        }

        public Store GetById(int id)
        {
            string query = "SELECT * FROM stores WHERE id = @id";
            Store store = _db.QueryFirstOrDefault<Store>(query, new { id });
            if (store == null) throw new Exception("Invalid Id");
            return store;
        }

        public IEnumerable<Bouquet> GetBouquetsByStoreId(int id)
        {
            string query = "SELECT * FROM bouquets WHERE storeId = @id";
            return _db.Query<Bouquet>(query, new { id });
        }


        public Store Create(Store value)
        {
            string query = @"
            INSERT INTO stores (location)
                    VALUES (@Location);
                    SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public Store Update(Store value)
        {
            string query = @"
            UPDATE stores
            SET
                location = @Location
            WHERE id = @Id;            
            SELECT * FROM stores WHERE id = @Id";
            return _db.QueryFirstOrDefault<Store>(query, value);
        }


        public string Delete(int id)
        {
            string query = "DELETE FROM stores WHERE id = @Id";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully deleted Store";

        }
    }
}