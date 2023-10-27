using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application
{
    public class ClientAppService :  AppServiceBase<Client>, IClientAppService
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientAppService(IClientService clientService, IMapper mapper)
            : base(clientService)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public IEnumerable<ClientViewModel> getClient()
        {
            var getClient = _clientService.GetAll();
            return _mapper.Map<IEnumerable<ClientViewModel>>(getClient);
        }

        public ClientViewModel getClientId(int id)
        {
            var client = _clientService.GetById(id);

           return _mapper.Map<ClientViewModel>(client);
        }
    }
}
