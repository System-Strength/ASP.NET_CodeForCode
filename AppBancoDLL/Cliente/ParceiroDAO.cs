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
    public class ParceiroDAO
    {
        private Banco db;
        public void Insert(Parceiro parceiros)
        {
            string strQuery = string.Format("Insert into tbl_parceiro(cd_parc, nm_parc, empresa_parc, cnpj_parc, email_parc, site_parc, end_parc, tel_parc, redeSocial_parc, descr_parc)" +
                    "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');", parceiros.cd_parc, parceiros.nm_parc, parceiros.empresa_parc, parceiros.cnpj_parc.Replace(".", string.Empty).Replace("-", string.Empty), parceiros.email_parc, parceiros.site_parc, parceiros.end_parc, parceiros.tel_parc, parceiros.redeSocial_parc, parceiros.descr_parc); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Parceiro parceiros)
        {
            var stratualiza = "";
            stratualiza += "update tbl_parceiro set ";
            stratualiza += string.Format(" nm_parc = '{0}', ", parceiros.nm_parc);
            stratualiza += string.Format(" empresa_parc = '{0}', ", parceiros.empresa_parc);
            stratualiza += string.Format(" cnpj_parc = '{0}', ", parceiros.cnpj_parc.ToString().Replace(".", string.Empty).Replace("-", string.Empty));
            stratualiza += string.Format(" email_parc = '{0}', ", parceiros.email_parc);
            stratualiza += string.Format(" site_parc = '{0}', ", parceiros.site_parc);
            stratualiza += string.Format(" end_parc = '{0}', ", parceiros.end_parc);
            stratualiza += string.Format(" tel_parc = '{0}', ", parceiros.tel_parc);
            stratualiza += string.Format(" redeSocial_parc = '{0}', ", parceiros.redeSocial_parc);
            stratualiza += string.Format(" descr_parc = '{0}', ", parceiros.descr_parc);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Excluir(Parceiro parceiros)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_parceiro";
            stratualiza += string.Format(" Where cd_parceiro = {0};", parceiros.cd_parc);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Parceiro parceiros)
        {
            if (parceiros.cd_parc > 0)
            {
                Atualizar(parceiros);
            }
            else
            {
                Insert(parceiros);
            }
        }
        public List<Parceiro> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_parceiro";
            var retorno = db.retornaComando(strQuery);
            return listaParceiro(retorno);
        }
        public Parceiro ListarId(int cd)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_parceiro where cd_parc = {0} ", cd);
                var retorno = db.retornaComando(strQuery);
                return listaParceiro(retorno).FirstOrDefault();
            }
        }
        public List<Parceiro> listaParceiro(MySqlDataReader retorno)
        {
            var parceiro = new List<Parceiro>();
            while (retorno.Read())
            {
                var TempParceiro = new Parceiro()
                {
                    cd_parc = int.Parse(retorno["cd_parc"].ToString()),
                    nm_parc = retorno["nm_parc"].ToString(),
                    empresa_parc = retorno["nm_parc"].ToString(),
                    cnpj_parc = retorno["cnpj_parc"].ToString().Replace(".", string.Empty).Replace("-", string.Empty),
                    email_parc = retorno["email_parc"].ToString(),
                    site_parc = retorno["site_parc"].ToString(),
                    end_parc = retorno["end_parc"].ToString(),
                    tel_parc = retorno["tel_parc"].ToString(),
                    redeSocial_parc = retorno["redeSocial_parc"].ToString(),
                    descr_parc = retorno["descr_parc"].ToString()
                };
                parceiro.Add(TempParceiro);
            }
            return parceiro;
        }
    }
}