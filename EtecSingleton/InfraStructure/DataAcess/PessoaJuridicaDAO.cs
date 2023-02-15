using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtecSingleton.InfraStructure.DataAcess
{
    public sealed class PessoaJuridicaDAO
    {
        public decimal? GetCodigoPessoaPorCNPJ(string numeroCNPJ,
                                               DbConnection conn,
                                               DbTransaction tran)
        {
            decimal? codigoPessoa = decimal.MinusOne;

            if (string.IsNullOrEmpty(numeroCNPJ))
                throw new Exception("Número de CNPJ é obrigatório.");

            //List<DbParameter> lstParameters = new List<DbParameter>()
            //{
            //    new DbParameter() { ParameterName = "numeroCNPJ", Value =  numeroCNPJ }
            //};

            StringBuilder stb = new StringBuilder();
            stb.Append("SELECT P.CD_PESSOA ");
            stb.Append($"  FROM PESSOA P ");
            stb.Append(" INNER JOIN PESSOAJURIDICA PJ ");
            stb.Append("    ON PJ.CD_PESSOA = P.CD_PESSOA ");
            stb.Append(" WHERE PJ.NR_CNPJ  = :numeroCNPJ ");
            stb.Append("   AND P.CD_COOPERATIVA = :cooperativa ");

            //List<PessoaDTO> dtbPessoa = GetRecordCustom<PessoaDTO>(stb, lstParameters, conn, tran);

            return codigoPessoa;
        }
    }
}
