using SmartHint.Models;

namespace SmartHint.Repository
{
    public interface IClientsRepository
    {
        List<ClientsModel> GetClients();

        ClientsModel AddClient(ClientsModel client);

        ClientsModel GetClient(int id);

        ClientsModel UpdateClient(ClientsModel newClientInfo);

        ClientsModel UpdateClientType(int id, bool is_blocked);

        bool GetClientByEmail(string email);

        bool GetClientByStateReg(string state_reg);

        bool GetClientByCpf(string email);

        bool DeleteClient(int id);

    }
}
