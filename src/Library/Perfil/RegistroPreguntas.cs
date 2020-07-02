namespace Library
{
    public class RegistroPreguntas
    {
        private bool edad = false;
        private bool precioMin = false;
        private bool precioMax = false;
        private bool genero = false;
        private bool relacion = false;
        private bool busqueda = false;
        private bool interes = false;

        public bool Edad
        {
            get => edad;
            set => edad = value;
        }
        public bool PrecioMin
        {
            get => precioMin;
            set => precioMin = value;
        }
        public bool PrecioMax
        {
            get => precioMax;
            set => precioMax = value;
        }

         public bool Genero 
        {
            get => genero;
            set => genero = value;
        }
         public bool Relacion 
        {
            get => relacion;
            set => relacion = value;
        }
         public bool Busqueda 
        {
            get => busqueda;
            set => busqueda = value;
        }
         public bool Interes 
        {
            get => interes;
            set => interes = value;
        }
    

    }
}