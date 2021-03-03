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
    public class CategoriaDAO
    {
        private Banco db;
        public void Insert(Categoria categoria)
        {
            string strQuery = string.Format("Insert into tbl_categoria(nm_cat)" +
                    "values('{0}');", categoria.nm_cat);
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Categoria categoria)
        {
            var stratualiza = "";
            stratualiza += "update tbl_categoria set ";
            stratualiza += string.Format(" nm_cat = '{0}', ", categoria.nm_cat);
            
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }

        public void Excluir(Categoria categoria)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_categoria";
            stratualiza += string.Format(" Where cd_cat = {0};", categoria.cd_cat);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Categoria categoria)
        {
            if (categoria.cd_cat > 0)
            {
                Atualizar(categoria);
            }
            else
            {
                Insert(categoria);
            }
        }
        public List<Categoria> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_categoria";
            var retorno = db.retornaComando(strQuery);
            return listaCategoria(retorno);
        }
        public Categoria ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_categoria where cd_cat = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaCategoria(retorno).FirstOrDefault();
            }
        }
        private List<Categoria> listaCategoria(MySqlDataReader retorno)
        {
            var categorias = new List<Categoria>();
            while (retorno.Read())
            {
                var TempCategoria = new Categoria()
                {
                    nm_cat = retorno["nm_cat"].ToString()
                };
                categorias.Add(TempCategoria);
            }
            return categorias;
        }
    }
}
