using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DataAcess
{
    public sealed class PessoaDAO : IDisposable
    {
        static int _qtdeInstancias=0;
        public PessoaDAO()
        {
            _qtdeInstancias++;
        }

        public int QtdeInstancias
        {
            get { return _qtdeInstancias; }
        }

        public void Dispose()
        {   
            // Suppress finalization.
            GC.SuppressFinalize(this);
            _qtdeInstancias--;
        }

        public decimal? GetCodigoPessoaPorCPFCNPJ(string cpfCnpj,
                                                  DbConnection conn,
                                                  DbTransaction tran)
        {
            decimal? decCodigoPessoa = null;
            PessoaFisicaDAO pfDAO = new PessoaFisicaDAO();
            PessoaJuridicaDAO pjDAO = new PessoaJuridicaDAO();


            if (cpfCnpj.Length == 11)
            {
                // Pesquisa pessoa por CPF...
                decCodigoPessoa = pfDAO.GetCodigoPessoaPorCPF(cpfCnpj, conn, tran);
            }
            else
            {
                // Pesquisa pessoa por CNPJ...
                decCodigoPessoa = pjDAO.GetCodigoPessoaPorCNPJ(cpfCnpj, conn, tran);
            }

            return (decCodigoPessoa);
        }
    }
}
