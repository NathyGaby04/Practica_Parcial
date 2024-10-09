using asp_servicios.Nucleo;
using lib_repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;


namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {

        [HttpGet(Name = "GetPagos")]
        public IEnumerable<Pagos> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_Pagos;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();
            conexion.Guardar(new Pagos()

            {
                Saldo = 1200000m,
            });

            conexion.SaveChanges();
            return conexion.Listar<Pagos>();

        }

        [HttpPost]
        public decimal PersonasAtendidas()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_Pagos;Integrated Security=True;TrustServerCertificate=true;";
            var lista = conexion.Listar<Personas>();
            decimal contar = 0;
            foreach (var x in lista)
            {
                if (x.Estado == true)
                {
                    contar++;
                }
            }
            return contar;
        }

        [HttpPost]
        public decimal PromedioPersonasPagos()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_Pagos;Integrated Security=True;TrustServerCertificate=true;";
            var lista = conexion.Listar<Personas>();
            decimal persona = PersonasAtendidas();
            int contar = lista.Count();
            decimal promedio = persona/contar;
            
            return promedio;
        }
    }
}
