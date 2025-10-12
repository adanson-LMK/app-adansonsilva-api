
using app_adansonsilva_api.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_adansonsilva_api.Data
{
    public class CRUDCliente : ICliente
    {
        private Configuracion _conexion;
        public CRUDCliente(Configuracion conexion)
        {
            this._conexion = conexion;
        }
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(this._conexion.Conectar);
        }

        public async Task<IEnumerable<Cliente>> ListarCliente()
        {
            var bd = Conectar();
            String sql = @"select * from tb_cliente where estado = 'A' order by nombre asc";

            return await bd.QueryAsync<Cliente>(sql, new { });
        }

        public async Task<bool> BorrarCliente(string codigo)
        {
            var bd = Conectar();
            String sql = @"update tb_cliente set estado = 'I' where cod = @cod";
            int n = await bd.ExecuteAsync(sql, new { cod = codigo });
            return n > 0;
        }

        public async Task<Cliente> BuscarCliente(string codigo)
        {
            var bd = Conectar();
            String sql = @"select * from tb_cliente where cod = @cod";

            return await bd.QueryFirstAsync<Cliente>(sql, new { cod = codigo});
        }

        public async Task<bool> EditarCliente(Cliente cliente)
        {
            var bd = Conectar();
            string sql = @"Update tb_cliente set nombre = @nombre, apellido = @apellido, dni = @dni where cod = @cod";
            int n = await bd.ExecuteAsync(sql, new { nombre = cliente.nombre, apellido = cliente.apellido, dni = cliente.dni, cod = cliente.cod });
            return n > 0;
        }

        public async Task<bool> RegistarCliente(Cliente cliente)
        {
            var bd = Conectar();
            string sql = @"insert into tb_cliente (cod, nombre, apellido, dni) values (@cod, @nombre, @apellido, @dni)";
            int n =  await bd.ExecuteAsync(sql, new { cod = cliente.cod, nombre = cliente.nombre, apellido = cliente.apellido, dni = cliente.dni });
            return n> 0;
        }
    }
}
