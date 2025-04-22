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
        [Route("ConsultarMatricula")]
        public Matricula ConsultarMatricula(int idMatricula)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.Consultar(idMatricula);
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public List<Matricula> ConsultarXDocumento(string dcEstudiante)
        {
            ClMatricula Matricula = new ClMatricula();
            return Matricula.ConsultarDocumento(dcEstudiante);
        }

        [HttpGet]
        [Route("ConsultarXSemestre")]
        public List<Matricula> ConsultarXSemestre(string semestreMatricula)
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