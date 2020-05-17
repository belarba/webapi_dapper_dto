using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Sinaf.Sds.Dominio.DTO;
using App.Sinaf.Sds.RegraNegocio.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Sinaf.Sds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SdsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<NovaSds> Get()
        {
            var sdsNegocio = new SdsNegocio();
            return sdsNegocio.RetornaTodasSds();
        }

        [HttpGet("{id}")]
        public NovaSds Get(int id)
        {
            var sdsNegocio = new SdsNegocio();
            return sdsNegocio.RetornaPorId(id);
        }

        [HttpPost]
        public void Post([FromBody]NovaSds sds)
        {
            var sdsNegocio = new SdsNegocio();
            if (ModelState.IsValid)
                sdsNegocio.Adiciona(sds);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]NovaSds sds)
        {
            sds.id = id; 
            var sdsNegocio = new SdsNegocio();
            if (ModelState.IsValid)
                sdsNegocio.Atualiza(sds);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var sdsNegocio = new SdsNegocio();
            sdsNegocio.Deleta(id);
        }
    }
}