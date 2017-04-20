using AIS.Entity;
using Dapper;
using System;
using System.Data;

namespace AIS.Database
{
    public class UserRepository : RepositoryBase
    {
        public bool ValidateUser(string username, string password)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("v_username", username, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_password", password, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_isuservalid", dbType: DbType.UInt16, direction: ParameterDirection.Output);

                using (var con = LocalDBConnection)
                {
                    con.Execute("ais.AuthenticateUser", param, commandType: CommandType.StoredProcedure);
                }
                return (param.Get<UInt16>("v_isuservalid") == 1);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("v_username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("v_status", user.Status, dbType: DbType.Int16, direction: ParameterDirection.Input);
                param.Add("v_isusercreated", dbType: DbType.UInt16, direction: ParameterDirection.Output);

                using (var con = LocalDBConnection)
                {
                    con.Execute("ais.CreateUser", param, commandType: CommandType.StoredProcedure);
                }
                return (param.Get<UInt16>("v_isusercreated") == 1);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
