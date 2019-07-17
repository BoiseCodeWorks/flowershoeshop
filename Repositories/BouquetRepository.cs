using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using markoz.Models;

namespace markoz.Repositories
{
    public class BouquetRepository
    {
        private readonly IDbConnection _db;
        public BouquetRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Bouquet> GetALL()
        {
            return _db.Query<Bouquet>("SELECT * FROM bouquets");
        }

        public Bouquet GetById(int id)
        {
            string query = "SELECT * FROM bouquets WHERE id = @id";
            Bouquet bouquet = _db.QueryFirstOrDefault<Bouquet>(query, new { id });
            if (bouquet == null) throw new Exception("Invalid Id");
            return bouquet;
        }
        public IEnumerable<Flower> GetFlowersByBouquetId(int id)
        {
            string query = @"
            SELECT * FROM flowerbouquets fb
            INNER JOIN flowers f ON f.id = fb.flowerId
            WHERE bouquetId = @id
            ";
            return _db.Query<Flower>(query, new { id });
        }

        public Bouquet Create(Bouquet value)
        {
            string query = @"
            INSERT INTO bouquets (name, storeId)
                    VALUES (@Name, @StoreId);
                    SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(query, value);
            value.Id = id;
            return value;
        }

        public string AddFlowerToBouquet(FlowerBouquet fb)
        {
            string query = @"INSERT INTO flowerbouquets (bouquetId, flowerId)
                                    VALUES (@BouquetId, @FlowerId);";
            int changedRows = _db.Execute(query, fb);
            if (changedRows < 1) throw new Exception("Invalid Ids");
            return "Successfully added Flower to Bouquet";
        }



        public Bouquet Update(Bouquet value)
        {
            string query = @"
            UPDATE bouquets
            SET
                name = @Name,
                storeId = @StoreId
            WHERE id = @Id;            
            SELECT * FROM bouquets WHERE id = @Id";
            return _db.QueryFirstOrDefault<Bouquet>(query, value);
        }

        public string Delete(int id)
        {
            string query = "DELETE FROM bouquets WHERE id = @Id";
            int changedRows = _db.Execute(query, new { id });
            if (changedRows < 1) throw new Exception("Invalid Id");
            return "Successfully deleted Bouquet";

        }


    }
}