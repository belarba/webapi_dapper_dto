using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using App.Sds.Repositorio.RepositorioDapper;
using App.Sinaf.Sds.Dominio.DTO;

namespace App.Sinaf.Sds.RegraNegocio.Negocio
{
    public class SdsNegocio
    {
        private readonly RepositorioDapperSds repositorioDapperSds;

        public SdsNegocio()
        {
            repositorioDapperSds = new RepositorioDapperSds();
        }

        public IEnumerable<NovaSds> RetornaTodasSds()
        {
            return repositorioDapperSds.GetAll();
        }

        public NovaSds RetornaPorId(int id)
        {
            return repositorioDapperSds.GetById(id);
        }

        public void Adiciona(NovaSds sds)
        {
            repositorioDapperSds.Add(sds);
        }

        public void Atualiza(NovaSds sds)
        {
            repositorioDapperSds.Update(sds);
        }

        public void Deleta(int id)
        {
            repositorioDapperSds.Delete(id);
        }

    }
}
