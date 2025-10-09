using app_adansonsilva_api.Model;

namespace app_adansonsilva_api.Data
{
    public interface IProducto
    {
        Task<IEnumerable<Producto>> ListarProduto();
        Task<Producto> BuscarProducto(String codigo);
        Task<bool> RegistarProducto(Producto Producto);
        Task<bool> EditarProducto(Producto Producto);
        Task<bool> BorrarProducto(String codigo);



    }
}
