using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AIS.Database
{
    public class DataAccessLayer : RepositoryBase
    {
        public void GetDummyData()
        {
            using (var con = LocalDBConnection)
            {
                List<int> data = con.Query<int>("GetDummyData", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
