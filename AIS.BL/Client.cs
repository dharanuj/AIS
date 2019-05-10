using AIS.Database;
using AIS.Entity;
using System;
using System.Collections.Generic;

namespace AIS.BL
{
    public class Client
    {
        private readonly ClientRepository _client = new ClientRepository();
        
        private string str = "";

        public List<ClientInfo> GetClientInfo(int? id, string lastName)
        {
            try
            {
                return _client.GetClientInfo(id ?? -1, lastName);
            }
            catch (Exception e)
            {
                return new List<ClientInfo>();
            }
        }

        public int SaveClientInfo(ClientInfo client)
        {
            client.MName = client.MName ?? string.Empty;
            return _client.SaveClientInfo(client);
        }
    }
}
