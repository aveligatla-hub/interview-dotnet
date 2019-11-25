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
    public interface ICosmosDataBase
    {
        CosmosData GetData();

        CosmosData SaveData(CosmosData model);
    }
}
