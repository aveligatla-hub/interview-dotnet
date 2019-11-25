using GroceryStoreAPI.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public class CosmosDatabase : ICosmosDataBase
    {
        public CosmosData GetData()
        {
            using (StreamReader file = File.OpenText(@"database.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject json = (JObject)JToken.ReadFrom(reader);
                return json.ToObject<CosmosData>();
            }
        }

        public CosmosData SaveData(CosmosData model)
        {
            using (StreamWriter file = File.CreateText(@"database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, model);
            }

            return model;
        }
    }
}
