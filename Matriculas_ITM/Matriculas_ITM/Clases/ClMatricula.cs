using Matriculas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Matriculas_ITM.Clases
{
    public class ClMatricula
    {
        private DBExamen3Entities dBExamen3 = new DBExamen3Entities();
        public Matricula matricula { get; set; }
        public string Insertar()
        {
            try
            {
                dBExamen3.Matriculas.Add(matricula);
                dBExamen3.SaveChanges();
                return "Matricula insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la matricula: " + ex.Message;

            }
        }

        public string Actualizar()
        {
            try
            {
                Matricula mtc = Consultar(matricula.idMatricula);
                if(mtc == null)
                {
                    return "La matricula con el id ingresado no existe, por lo tanto no se puede actualizar";
                }
                dBExamen3.Matriculas.AddOrUpdate(matricula);
                dBExamen3.SaveChanges();
                return "Se actualizó la matricula correctamente";
                
            }
            catch(Exception ex)
            {
                return "No se pudo actualizar la matricula: " + ex.Message;
            }
        }


        public Matricula Consultar (int idMatricula)
        {
            return dBExamen3.Matriculas.FirstOrDefault(e => e.idMatricula == idMatricula);
        }
        public List<Matricula> ConsultarDocumento(int idEstudiante)
        {
            return dBExamen3.Matriculas
                .Where(e => e.idEstudiante == idEstudiante)
                .OrderBy(e => e.SemestreMatricula)
                .ToList();
        }

        public List<Matricula> ConsultarSemestre (string semestreMatricula)
        {
            return dBExamen3.Matriculas
                .Where(e => e.SemestreMatricula.Equals(semestreMatricula))
                .OrderBy(e => e.FechaMatricula)
                .ToList();
        }

        public string Eliminar (int idMatricula)
        {
            try
            {
                Matricula mtc = Consultar(matricula.idMatricula);
                if (mtc == null)
                {
                    return "La matricula con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                dBExamen3.Matriculas.Remove(mtc);
                dBExamen3.SaveChanges();
                return "Se eliminó la matricula correctamente";

            }
            catch (Exception ex)
            {
                return "No se pudo eliminar la matricula: " + ex.Message;
            }
        }
    }
}