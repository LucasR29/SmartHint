using MySql.Data.MySqlClient;
using SmartHint.Data;
using SmartHint.Models;

namespace SmartHint.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly SmartHintContext _databaseContext;

        public ClientsRepository(SmartHintContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public List<ClientsModel> GetClients()
        {
            return _databaseContext.Clients.ToList();
        }

        public ClientsModel GetClient(int id)
        {
            return _databaseContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        public ClientsModel UpdateClient(ClientsModel newClientInfo)
        {
            ClientsModel client = GetClient(newClientInfo.Id) ?? throw new System.Exception("Houve um erro ao atualizar");

            client.Name = newClientInfo.Name;
            client.Email = newClientInfo.Email;
            client.Phone = newClientInfo.Phone;
            client.Password = newClientInfo.Password;
            client.Cpf = newClientInfo.Cpf;
            client.Birth_Date = newClientInfo.Birth_Date;
            client.Exempt = newClientInfo.Exempt;
            client.State_reg = newClientInfo.State_reg;
            client.Sex = newClientInfo.Sex;
            client.Type = newClientInfo.Type;
            client.Is_blocked = newClientInfo.Is_blocked;

            _databaseContext.SaveChanges();

            return client;
        }

        public ClientsModel UpdateClientType(int id, bool is_blocked)
        {
            ClientsModel client = GetClient(id) ?? throw new System.Exception("Houve um erro ao atualizar");

            client.Is_blocked = is_blocked;

            _databaseContext.Clients.Update(client);
            _databaseContext.SaveChanges();

            return client;
        }

        public ClientsModel AddClient(ClientsModel client)
        {
            _databaseContext.Clients.Add(client);
            _databaseContext.SaveChanges();
            return client;
        }

        public bool DeleteClient(int id)
        {
            ClientsModel client = GetClient(id) ?? throw new System.Exception("Houve um erro ao deletar");

            _databaseContext.Clients.Remove(client);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool GetClientByEmail(string email)
        {
            var client = _databaseContext.Clients.FirstOrDefault(x => x.Email == email);

            if(client == null)
            {
                return false;
            }

            return true;
        }

        public bool GetClientByCpf(string cpf)
        {
            var client = _databaseContext.Clients.FirstOrDefault(x => x.Cpf == cpf);

            if (client == null)
            {
                return false;
            }

            return true;
        }

        public bool GetClientByStateReg(string state_reg)
        {
            var client = _databaseContext.Clients.FirstOrDefault(x => x.State_reg == state_reg);

            if (client == null)
            {
                return false;
            }

            return true;
        }
    }
}
