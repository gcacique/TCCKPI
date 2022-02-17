using System;

namespace TCCkpi.Model
{
    public class DadosKPI
    {
        public string ID { get; set; }
        public string KPI { get; set; }
        public DateTime MesReferencia { get; set; }
        public decimal ValorEsperado { get; set; }
        public decimal ValorObtido { get; set; }


    }
}
