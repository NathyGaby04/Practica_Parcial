using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Pagos
    {
        [Key] public int PagosId { get; set; }
        public decimal Saldo { get; set; }
        public int PersonaId { get; set; }

    }
}
