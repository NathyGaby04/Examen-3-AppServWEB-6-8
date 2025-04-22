using Matriculas_ITM.Models;
using Matriculas_ITM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matriculas_ITM.Clases
{
    public class ClLogin
    {
        public ClLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        private DBExamen3Entities dBExamen3 = new DBExamen3Entities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarEstudiante()
        {
            try
            {

                //Se consulta el Estudiante, sólo con el nombre, para obtener la información básica del Estudiante: Salt y clave encriptada
                Estudiante Estudiante =  dBExamen3.Estudiantes.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (Estudiante == null)
                {
                    //El Estudiante no existe, se retorna un error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Estudiante no existe";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                //Se consulta el Estudiante con la clave encriptada y el Estudiante para validar si existe
                Estudiante Estudiante = dBExamen3.Estudiantes.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (Estudiante == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                //La clave y el Estudiante son correctos
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarEstudiante() && ValidarClave())
            {
                //Si el Estudiante y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                //Consulta la información del Estudiante y el perfil
                return from U in dBExamen3.Set<Estudiante>()
                       where U.Usuario == login.Usuario &&
                             U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Perfil = "Estudiante",
                           PaginaInicio = "Matricula.html",
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}