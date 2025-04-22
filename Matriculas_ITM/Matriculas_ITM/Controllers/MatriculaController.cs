using Microsoft.Ajax.Utilities;
using Matriculas_ITM.Clases;
using Matriculas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Matriculas_ITM.Controllers
{
    [RoutePrefix("api/Matricula")]
    [Authorize]
    public class MatriculaController : ApiController
    {
        [HttpGet]
        [Route("Consultar")]
        public Matricula ConsultarImagenes(int idMatricula)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.Consultar(idMatricula);
        }

        [HttpGet]
        [Route("ConsultarDocumento")]
        public List<Matricula> ConsultarDocumento(int dcEstudiante)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.ConsultarDocumento(dcEstudiante);
        }

        [HttpGet]
        [Route("ConsultarSemestre")]
        public List<Matricula> Consultar(string semestreMatricula)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.ConsultarSemestre(semestreMatricula);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Matricula matricula)
        {
            ClMatricula Matricula = new ClMatricula();
            Matricula.matricula = matricula;
            return Matricula.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Matricula matricula)
        {
            ClMatricula Matricula = new ClMatricula();
            Matricula.matricula = matricula;
            return Matricula.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int CodigoMatricula)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.Eliminar(CodigoMatricula);
        }
    }
}