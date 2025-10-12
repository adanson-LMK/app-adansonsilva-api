using app_adansonsilva_api.Model;

namespace app_adansonsilva_api.Data
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> ListarCliente();
        Task<Cliente> BuscarCliente(String codigo);
        Task<bool> RegistarCliente(Cliente cliente);
        Task<bool> EditarCliente(Cliente cliente);
        Task<bool> BorrarCliente(String codigo);
    }
}
