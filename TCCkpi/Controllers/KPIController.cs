using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;

namespace TCCkpi.Controllers
{
    
    [ApiController]
    public class KPIController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;
        public KPIController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/CadastrarKPI")]
        public void CadastrarKPI(Model.KPIS kpi)
        {
            _sql.CadastrarKPI(kpi);
        }

        [HttpPost("v1/CadastrarDadosKPI")]
        public void CadastrarDadosKPI(Model.DadosKPI DadosKpi)
        {
            _sql.CadastrarDadosKPI(DadosKpi);
        }

        [HttpGet("v1/ListarKPI")]
        public List<Model.KPIS> ListarKPI()
        {
            return _sql.ListarKPI();
        }

        [HttpGet("v1/ListarDadosKPI")]
        public List<Model.DadosKPI> ListarDadosKPI()
        {
            return _sql.ListarDadosKPI();
        }

        [HttpPut("v1/AtualizarKPI")]
        public void AtualizarKPI(Model.KPIS kpi)
        {
            _sql.AtualizarKPI(kpi);
        }

        [HttpPut("v1/AtualizarDadosKPI")]
        public void AtualizarDadosKPI(Model.DadosKPI kpi)
        {
            _sql.AtualizarDadosKPI(kpi);
        }

        [HttpDelete("v1/DeletarKPI")]
        public void DeletarKPI(Model.KPIS kpi)
        {
            _sql.DeletarKPI(kpi);
        }

        [HttpDelete("v1/DeletarDadosKPI")]
        public void DeletarDadosKPI(Model.DadosKPI kpi)
        {
            _sql.DeletarDadosKPI(kpi);
        }

        [HttpGet("v1/SelecionarKPI")]
        public Model.KPIS SelecionarKPI(string Nome)
        {
            return _sql.SelecionarKPI(Nome);
        }

        [HttpGet("v1/SelecionarDadosKPI")]
        public Model.DadosKPI SelecionarDadosKPI(string ID)
        {
            return _sql.SelecionarDadosKPI(ID);
        }
    }
}
