using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AppBancoDLL
{
    public class CriaContaDAO
    {
        private Banco db;
        public void Insert(Conta conta)
        {
            string strQuery = string.Format("Insert into tbl_conta(user_login, senha_login)" +
                    "values('{0}', '{1}');", conta.user_login, conta.senha_login); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Conta conta)
        {
            var stratualiza = "";
            stratualiza += "update tbl_conta set ";
            stratualiza += string.Format(" user_login = '{0}', ", conta.user_login);
            stratualiza += string.Format(" senha_login = '{1}', ", conta.senha_login);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }

        public void Excluir(Conta conta)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_conta";
            stratualiza += string.Format(" Where senha_login = {0};", conta.senha_login);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Conta conta)
        {
            if (conta.senha_login != "")
            {
                Atualizar(conta);
            }
            else
            {
                Insert(conta);
            }
        }
        public List<Conta> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_conta";
            var retorno = db.retornaComando(strQuery);
            return listaConta(retorno);
        }
        public Conta ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_login where senha_login = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaConta(retorno).FirstOrDefault();
            }
        }
        private List<Conta> listaConta(MySqlDataReader retorno)
        {
            var contas = new List<Conta>();
            while (retorno.Read())
            {
                var TempConta = new Conta()
                {
                    user_login = retorno["user_login"].ToString(),
                    senha_login = retorno["senha_login"].ToString(),
                };
                contas.Add(TempConta);
            }
            return contas;
        }
    }
}
}
