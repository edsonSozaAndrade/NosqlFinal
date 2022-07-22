using MongoDB.Entities;

namespace Poco
{
    public class Food : Entity
    {
        public FuzzyString Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public Precio Precio { get; set; }
    }

    public class Precio
    {
        public double Base { get; set; }
        public string Moneda { get; set; }
    }
}
