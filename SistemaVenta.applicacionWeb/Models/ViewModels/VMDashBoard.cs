namespace SistemaVenta.applicacionWeb.Models.ViewModels
{
    public class VMDashBoard
    {
        public int TotalVentas { get; set; }    
        public string? TotalIngresos { get; set;}

        public int TotalProductos{ get; set; }
        public int TotalCategorias{ get; set; }


        public List<VMVentaSemana> VentaUltimasSemanas { get; set; }   
        public List<VMProductoSemana> ProductosTopUltimaSemanas { get; set; }   


    }
}
