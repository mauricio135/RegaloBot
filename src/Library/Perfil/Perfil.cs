namespace Library
{
    public class Perfil
    {
        //Identificador único de cada conversación, vincula al objeto Perfil con la conversación en la que se originó
        private long id;
        private int edad = -1;
        private string genero;
        private string relacion;
        private string interes;
        private int precioMin = -1;
        private int precioMax = -1;
        public long Id
        {
            get => id;
            set => id = value;
        }
        public int Edad
        {
            get => edad;
            set => edad = value;
        }

        public string Genero
        {
            get => genero;
            set => genero = value;
        }
        public string Relacion
        {
            get => relacion;
            set => relacion = value;
        }
         public string Interes
        {
            get => interes;
            set => interes = value;
        }
        public int PrecioMin
        {
            get => precioMin;
            set => precioMin = value;
        }
        public int PrecioMax
        {
            get => precioMax;
            set => precioMax = value;
        }

        public Perfil (long numero)
        {
            this.Id = numero;
        }
        public override string ToString()
        {
            return $"Edad: {this.edad} / Genero: {this.genero} / Relacion: {this.Relacion} / Interes: {this.Interes} / Precio Mínimo: {this.PrecioMin} / Precio Máximo: {this.PrecioMax}";
        }
    }
}