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
    public class ComprasDAO
    {
        private Banco db;
        public void Insert(Compras compra)
        {
            string strQuery = string.Format("Insert into tbl_compra(cpf_usu, end_usu, numCasa_usu, blocoApa_usu, formaPag_usu)" +
                    "values('{0}', '{1}', '{2}', '{3}', '{4}');", compra.cpf_usu.Replace(".", string.Empty).Replace("-", string.Empty), compra.end_usu, compra.numCasa_usu, compra.blocoApa_usu, compra.formaPag_usu); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Compras compra)
        {
            var stratualiza = "";
            stratualiza += "update tbl_compra set ";
            stratualiza += string.Format(" cpf_usu = '{0}', ", compra.cpf_usu.ToString().Replace(".", string.Empty).Replace("-", string.Empty));
            stratualiza += string.Format(" end_usu = '{0}', ", compra.end_usu);
            stratualiza += string.Format(" numCasa_usu = '{0}', ", compra.numCasa_usu);
            stratualiza += string.Format(" blocoApa_usu = '{0}', ", compra.blocoApa_usu);
            stratualiza += string.Format(" formaPag_usu = '{0}', ", compra.formaPag_usu);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Excluir(Compras compra)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_compra";
            stratualiza += string.Format(" Where cd_compra = {0};", compra.cd_compra);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Compras compra)
        {
            if (compra.cd_compra > 0)
            {
                Atualizar(compra);
            }
            else
            {
                Insert(compra);
            }
        }
        public List<Compras> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_compra";
            var retorno = db.retornaComando(strQuery);
            return listaCompra(retorno);
        }
        public Compras ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_compra where cd_compra = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaCompra(retorno).FirstOrDefault();
            }
        }
        public List<Compras> listaCompra(MySqlDataReader retorno)
        {
            var compra = new List<Compras>();
            while (retorno.Read())
            {
                var TempCompra = new Compras()
                {
                    cd_compra = int.Parse(retorno["cd_compra"].ToString()),
                    cpf_usu = retorno["cpf_usu"].ToString().Replace(".", string.Empty).Replace("-", string.Empty),
                    end_usu = retorno["end_usu"].ToString(),
                    numCasa_usu = int.Parse(retorno["cd_compra"].ToString()),
                    blocoApa_usu = retorno["blocoApa_usu"].ToString(),
                    formaPag_usu = retorno["formaPag_usu"].ToString()
                };
                compra.Add(TempCompra);
            }
            return compra;
        }
    }
}