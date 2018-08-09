using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private ClienteDbContext _context;
        public ClienteController(ClienteDbContext context)
        {
            _context = context;
        }
        [HttpGet("{contaUID}")]
        public IActionResult GetEnderecosDoCliente(string contaUID)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.ContaUID.ToString() == contaUID);
            if(cliente == null) return StatusCode(404);

            return StatusCode(200,cliente.Enderecos);
        }
    }
}
