using System.Data.SqlClient;
using System.IO;
using System;
using System.Collections.Generic;

namespace TCCkpi.Conexoes
{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql()
        {
            string stringConexao = (@"Server=5.161.62.27 ;Database=TCC_TARDE;User Id=sa ;Password=RumoaoSucesso2022#;");
            _conexao = new SqlConnection(stringConexao);
        }

        public void CadastrarKPI(Model.KPIS kpi)
        {
            try
            {
                _conexao.Open();
                string query = @"INSERT INTO KPIS
                                       (Nome
                                       ,UnidadeMedida
                                       ,Status)
                                 VALUES
                                       (@Nome
                                       ,@UnidadeMedida
                                       ,@Status);";


                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", kpi.Nome);
                    cmd.Parameters.AddWithValue("@UnidadeMedida", kpi.UnidadeMedida);
                    cmd.Parameters.AddWithValue("@Status", kpi.Status);

                    cmd.ExecuteNonQuery();
                }


            }
            finally
            {
                _conexao.Close();
            }
        }

        public void CadastrarDadosKPI(Model.DadosKPI dadosKpi)
        {
            try
            {
                _conexao.Open();
                string query = @"INSERT INTO DadosKPI
                                       (ID
                                       ,KPI
                                       ,MesReferencia
                                       ,ValorEsperado
                                       ,ValorObtido)
                                 VALUES
                                       (@ID
                                       ,@KPI
                                       ,@MesReferencia
                                       ,@ValorEsperado
                                       ,@ValorObtido);";


                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", dadosKpi.ID);
                    cmd.Parameters.AddWithValue("@KPI", dadosKpi.KPI);
                    cmd.Parameters.AddWithValue("@MesReferencia", dadosKpi.MesReferencia.Date);
                    cmd.Parameters.AddWithValue("@ValorEsperado", dadosKpi.ValorEsperado);
                    cmd.Parameters.AddWithValue("@ValorObtido", dadosKpi.ValorObtido);

                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Model.KPIS> ListarKPI()
        {
            var kpi = new List<Model.KPIS>();
            try
            {
                _conexao.Open();

                string query = @"Select *
                                FROM KPIS";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var kpis = new Model.KPIS();
                        kpis.Nome = Convert.ToString(rdr["Nome"]);
                        kpis.UnidadeMedida = Convert.ToString(rdr["UnidadeMedida"]);
                        kpis.Status = Convert.ToBoolean(rdr["Status"]);


                        kpi.Add(kpis);
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

            return kpi;
        }

        public List<Model.DadosKPI> ListarDadosKPI()
        {
            var Dadoskpi = new List<Model.DadosKPI>();
            try
            {
                _conexao.Open();

                string query = @"Select *
                                FROM DadosKPI";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var Dadoskpis = new Model.DadosKPI();
                        Dadoskpis.ID = Convert.ToString(rdr["ID"]);
                        Dadoskpis.KPI = Convert.ToString(rdr["KPI"]);
                        Dadoskpis.MesReferencia = Convert.ToDateTime(rdr["MesReferencia"]);
                        Dadoskpis.ValorEsperado = Convert.ToDecimal(rdr["ValorEsperado"]);
                        Dadoskpis.ValorObtido = Convert.ToDecimal(rdr["ValorObtido"]);


                        Dadoskpi.Add(Dadoskpis);
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

            return Dadoskpi;
        }

        public void AtualizarKPI(Model.KPIS kpi)
        {
            try
            {
                _conexao.Open();
                string query = @"UPDATE KPIS
                                       SET UnidadeMedida = @UnidadeMedida
                                       ,Status = @Status
                                 WHERE
                                        Nome = @Nome";
                                       
                                      


                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", kpi.Nome);
                    cmd.Parameters.AddWithValue("@UnidadeMedida", kpi.UnidadeMedida);
                    cmd.Parameters.AddWithValue("@Status", kpi.Status);

                    cmd.ExecuteNonQuery();
                }


            }
            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarDadosKPI(Model.DadosKPI dadoskpi)
        {
            try
            {
                _conexao.Open();
                string query = @"UPDATE DadosKPI
                                       SET KPI = @KPI
                                       ,MesReferencia = @MesReferencia
                                       ,ValorEsperado = @ValorEsperado
                                       ,ValorObtido = @ValorObtido
                                 WHERE
                                        ID = @ID";




                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", dadoskpi.ID);
                    cmd.Parameters.AddWithValue("@KPI", dadoskpi.KPI);
                    cmd.Parameters.AddWithValue("@MesReferencia", dadoskpi.MesReferencia);
                    cmd.Parameters.AddWithValue("@ValorEsperado", dadoskpi.ValorEsperado);
                    cmd.Parameters.AddWithValue("@ValorObtido", dadoskpi.ValorObtido);

                    cmd.ExecuteNonQuery();
                }


            }
            finally
            {
                _conexao.Close();
            }
        }

        public void DeletarKPI(Model.KPIS kpi)
        {
            try
            {
                _conexao.Open();

                string query = @"DELETE FROM KPIS
                                 WHERE Nome = @Nome";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", kpi.Nome);
                    cmd.ExecuteNonQuery();

                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void DeletarDadosKPI(Model.DadosKPI kpi)
        {
            try
            {
                _conexao.Open();

                string query = @"DELETE FROM DadosKPI
                                 WHERE ID = @ID";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", kpi.ID);
                    cmd.ExecuteNonQuery();

                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Model.KPIS SelecionarKPI(string Nome)
        {
            try
            {
                _conexao.Open();

                string query = @"Select * FROM KPIS
                                 WHERE Nome = @Nome";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var KPIS = new Model.KPIS();
                        KPIS.Nome = Nome;
                        KPIS.UnidadeMedida = rdr["UnidadeMedida"].ToString();
                        KPIS.Status = Convert.ToBoolean(rdr["Status"]);

                        return KPIS;
                    }
                    else
                    {
                        throw new InvalidOperationException("O nome " + Nome + " não foi encontrado!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Model.DadosKPI SelecionarDadosKPI(string ID)
        {
            try
            {
                _conexao.Open();

                string query = @"Select * FROM DadosKPI
                                 WHERE ID = @ID";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var DadosKPI = new Model.DadosKPI();
                        DadosKPI.ID = ID;
                        DadosKPI.KPI = rdr["KPI"].ToString();
                        DadosKPI.MesReferencia = Convert.ToDateTime(rdr["MesReferencia"]);
                        DadosKPI.ValorEsperado = Convert.ToDecimal(rdr["ValorEsperado"]);
                        DadosKPI.ValorObtido = Convert.ToDecimal(rdr["ValorObtido"]);

                        return DadosKPI;
                    }
                    else
                    {
                        throw new InvalidOperationException("O  " + ID + " não foi encontrado!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }


    }
}
