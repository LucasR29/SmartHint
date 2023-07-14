using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using SmartHint.Models;
using SmartHint.Repository;

namespace SmartHint.Controllers
{
    public class Clients : Controller
    {
        private readonly IClientsRepository _clientsRepository;

        public Clients(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        public IActionResult List()
        {
            List<ClientsModel> clients = _clientsRepository.GetClients();
            return View(clients);
        }

        [HttpGet]
        public IActionResult ListClients()
        {
            List<ClientsModel> clients = _clientsRepository.GetClients();
            return new JsonResult(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ClientsModel client = _clientsRepository.GetClient(id);
            return View(client);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            var client = _clientsRepository.GetClient(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Create(ClientsModel client)
        {
            if(ModelState.IsValid)
            {
                _clientsRepository.AddClient(client);
                return RedirectToAction("List");
            }

            return View(client);
        }

        [HttpPatch]
        public IActionResult EditType(bool is_blocked, int id)
        {
            _clientsRepository.UpdateClientType(id, is_blocked);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult GetUserByEmail(string email)
        {
            var clientExists = _clientsRepository.GetClientByEmail(email);

            return new JsonResult(clientExists);
        }

        [HttpGet]
        public IActionResult GetUserByStateReg(string state_reg)
        {
            var clientExists = _clientsRepository.GetClientByStateReg(state_reg);

            return new JsonResult(clientExists);
        }

        [HttpGet]
        public IActionResult GetUserByCpf(string cpf)
        {
            var clientExists = _clientsRepository.GetClientByCpf(cpf);

            return new JsonResult(clientExists);
        }

        [HttpPost]
        public IActionResult Edit(ClientsModel newClientInfo)
        {
            if (ModelState.IsValid)
            {
                var client = _clientsRepository.UpdateClient(newClientInfo);
                return RedirectToAction("List");
            }
            return View(newClientInfo);
        }

        public IActionResult Delete(int id)
        {
            _clientsRepository.DeleteClient(id);
            return RedirectToAction("List");
        }
    }
}
