using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> _logger;
        private readonly ProEventosContext _context;
        
        public EventoController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _context.Eventos.Where(x => x.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "value";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "value";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "value";
        }
    }
}
