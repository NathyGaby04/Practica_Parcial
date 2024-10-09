using asp_servicios.Nucleo;
using lib_repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        [HttpGet(Name ="GetPersonas")]
        public IEnumerable<Personas> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_Pagos;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();
            conexion.Guardar(new Personas()
            {
                Nombre = "Maluma",
                Apellido = "Arias",
                Fecha = DateTime.Parse("2024/10/07"),
                Celular = "3124567645",
                Estado = false,
            });

            conexion.SaveChanges();
            return conexion.Listar<Personas>();
        }

        [HttpPost]
        public int PersonasAtendidasFecha()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_Pagos;Integrated Security=True;TrustServerCertificate=true;";
            var lista = conexion.Listar<Personas>();
            var contar = 0;
            foreach (var x in lista)
            {
                if (x.Fecha.Day == DateTime.Now.Day-1)
                //if (x.Fecha == DateTime.Parse("2024/10/07"))
                {
                    contar++;
                }
            }
            return contar;
        }
    }
}
