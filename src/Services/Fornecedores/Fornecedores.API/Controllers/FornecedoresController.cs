using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fornecedores.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.API.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedoresController : Controller
    {
        private readonly IFornecedoresDbContext _context;
        public FornecedoresController(IFornecedoresDbContext context)
        {
            _context=context;
        }
        // GET api/values
        [HttpGet("{codigoFornecedor}")]
        public async Task<IActionResult> GetFornecedor(Guid codigoFornecedor)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x=>x.CodigoFornecedor==codigoFornecedor);

            if(fornecedor == null) return StatusCode(404);

            return StatusCode(200,fornecedor);
        }
    }
}
