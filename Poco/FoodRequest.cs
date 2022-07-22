namespace Poco
{
    public class FoodRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public Precio Precio { get; set; }

        public Food ToFoodModel()
        {
            return new Food() { 
                Categoria = Categoria, 
                Descripcion = Descripcion,
                Imagen = Imagen,
                Nombre = Nombre,
                Precio = Precio
            };
        }
    }
}
