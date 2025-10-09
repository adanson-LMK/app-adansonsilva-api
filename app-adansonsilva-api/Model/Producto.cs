namespace app_adansonsilva_api.Model
{
    public class Producto
    {
        public String codigo_producto {  get; set; }
        public String producto { get; set; }
        public float costo { get; set; }
        public float ganancia { get; set; }
        public  int  stock { get; set; }
        public String producto_codigo_categoria { get; set; }
        public String producto_codigo_marca { get; set; }

    }
}
