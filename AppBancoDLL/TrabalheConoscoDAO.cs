using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class TrabalheConoscoDAO
    {
        private Banco db;
        public void Insert(TrabalheConosco trabalhe)
        {
            string strQuery = string.Format("Insert into tbl_trabalheConosco(nm_usu, tel_usu, email_usu)" +
                    "values('{0}', '{1}', '{2}');", trabalhe.nm_usu, trabalhe.tel_usu, trabalhe.email_usu); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(TrabalheConosco trabalhe)
        {
            var stratualiza = "";
            stratualiza += "update tbl_trabalheConosco set ";
            stratualiza += string.Format(" nm_usu = '{0}', ", trabalhe.nm_usu);
            stratualiza += string.Format(" tel_usu = '{0}', ", trabalhe.tel_usu);
            stratualiza += string.Format(" email_usu = '{0}', ", trabalhe.email_usu);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Excluir(TrabalheConosco trabalhe)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_trabalheConosco";
            stratualiza += string.Format(" Where cd_usu = {0};", trabalhe.cd_usu);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(TrabalheConosco trabalhe)
        {
            if (trabalhe.cd_usu > 0)
            {
                Atualizar(trabalhe);
            }
            else
            {
                Insert(trabalhe);
            }
        }
        public List<TrabalheConosco> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_trabalheConosco";
            var retorno = db.retornaComando(strQuery);
            return listaTrabalhe(retorno);
        }
        public TrabalheConosco ListarId(int cd)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_trabalheConosco where cd_usu = {0} ", cd);
                var retorno = db.retornaComando(strQuery);
                return listaTrabalhe(retorno).FirstOrDefault();
            }
        }
        public List<TrabalheConosco> listaTrabalhe(MySqlDataReader retorno)
        {
            var trabalhe = new List<TrabalheConosco>();
            while (retorno.Read())
            {
                var TempTrabalhe = new TrabalheConosco()
                {
                    cd_usu = int.Parse(retorno["cd_usu"].ToString()),
                    nm_usu = retorno["nm_usu"].ToString(),
                    tel_usu = retorno["tel_usu"].ToString(),
                    email_usu = retorno["email_usu"].ToString(),
                };
                trabalhe.Add(TempTrabalhe);
            }
            return trabalhe;
        }
    }
}