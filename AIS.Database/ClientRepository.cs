using AIS.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace AIS.Database
{
    public class ClientRepository : RepositoryBase
    {
        public List<ClientInfo> GetClientInfo(int id, string lastName)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("v_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("v_lastname", lastName, dbType: DbType.String, direction: ParameterDirection.Input);
                using (var con = LocalDBConnection)
                {
                    return con.Query<ClientInfo>("ais.GetClientInfo", param, null, true, null, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                return new List<ClientInfo>();
            }
        }

        public int SaveClientInfo(ClientInfo client)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("v_status", client.Status, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_course", client.Course, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_lname", client.LName, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_mname", client.MName, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_fname", client.FName, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_city", client.City, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_gender", client.Gender, dbType: DbType.StringFixedLength, direction: ParameterDirection.Input);
                param.Add("v_imageurl", client.ImageUrl, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                using (var con = LocalDBConnection)
                {
                    con.Execute("ais.SaveClientInfo", param, null, null, commandType: CommandType.StoredProcedure);
                }
                return param.Get<int>("v_id");
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
