using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Matriculas_ITM.Models;

namespace Matriculas_ITM.Clases
{
    public class clsEstudiante
    {

        private DBExamen3Entities dBExamen3 = new DBExamen3Entities();
        public Estudiante estudiante { get; set; }

        public Estudiante Consultar(string Documento)
        {
            Estudiante estudiante = dBExamen3.Estudiantes.Where(e => e.Documento == Documento).First();
            return estudiante;
        }

    }
}