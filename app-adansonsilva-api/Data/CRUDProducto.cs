using app_adansonsilva_api.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_adansonsilva_api.Data
{
    public class CRUDProducto : IProducto
    {
        private Configuracion _conexion;
        public CRUDProducto(Configuracion conexion)
        {
            this._conexion = conexion;
        }
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(this._conexion.Conectar);
        }
        public async Task<IEnumerable<Producto>> ListarProduto()
        {
            var bd = Conectar();
            String sql = @"select * from tb_producto order by costo desc";

            return await bd.QueryAsync<Producto>(sql, new { });
        }
        public async Task<bool> BorrarProducto(string codigo)
        {
            var bd = Conectar();
            String sql = @"delete from tb_producto where codigo_producto = @cod";
            int n = await bd.ExecuteAsync(sql, new { cod = codigo });
            return n > 0;
        }

        public async Task<Producto> BuscarProducto(string codigo)
        {
            var bd = Conectar();
            String sql = @"select * from tb_producto where codigo_producto = @cod";

            return await bd.QueryFirstAsync<Producto>(sql, new { cod = codigo});
        }

        public async Task<bool> EditarProducto(Producto Producto)
        {
            var bd = Conectar();
            string sql = @"Update tb_producto set producto = @prod, costo = @cst, ganancia = @gnc, stock = @stk, producto_codigo_marca = @cod_mar, producto_codigo_categoria = @cod_cat where codigo_producto = @cod_prod";
            int n = await bd.ExecuteAsync(sql, new { cod_prod = Producto.codigo_producto, prod = Producto.producto, cst = Producto.costo, gnc = Producto.ganancia, stk = Producto.stock, cod_mar = Producto.producto_codigo_marca, cod_cat = Producto.producto_codigo_categoria });
            return n > 0;
        }

        public async Task<bool> RegistarProducto(Producto Producto)
        {
            var bd = Conectar();
            string sql = @"insert into tb_producto values (@cod_prod, @prod, @cst, @gnc, @stk, @cod_mar, @cod_cat)";
            int n =  await bd.ExecuteAsync(sql, new { cod_prod = Producto.codigo_producto, prod = Producto.producto, cst = Producto.costo, gnc = Producto.ganancia, stk = Producto.stock, cod_mar = Producto.producto_codigo_marca, cod_cat = Producto.producto_codigo_categoria});
            return n> 0;
        }
    }
}
