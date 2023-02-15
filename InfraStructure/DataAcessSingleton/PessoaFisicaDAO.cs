using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DataAcessSingleton
{
    internal class PessoaFisicaDAO
    {
        public decimal? GetCodigoPessoaPorCPF(string numeroCPF,
                                             DbConnection conn,
                                             DbTransaction tran)
        {
            decimal? codigoPessoa = decimal.MinusOne;

            if (string.IsNullOrEmpty(numeroCPF))
                throw new Exception("Número de CPF é obrigatório.");

            //List<DbParameter> lstParameters = new List<DbParameter>()
            //{
            //    new DbParameter() { ParameterName = "numeroCPF", Value = numeroCPF }
            //};

            StringBuilder stb = new StringBuilder();
            stb.Append("SELECT P.CD_PESSOA ");
            stb.Append($"  FROM PESSOA P ");
            stb.Append(" INNER JOIN PESSOAFISICA PF ");
            stb.Append("    ON PF.CD_PESSOA = P.CD_PESSOA ");
            stb.Append(" WHERE PF.NR_CPF = :numeroCPF ");

            //List<PessoaModel> dtbPessoa = GetRecordCustom<PessoaModel>(stb, lstParameters, conn, tran);

            return codigoPessoa;
        }
    }
}
