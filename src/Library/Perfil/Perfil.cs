namespace Library
{
    public class Perfil

    {
        //Identificador único de cada conversación, vincula al objeto Perfil con la conversación en la que se originó
        private long id;
        private int edad = -1;
        private TipoGenero genero;
        private TipoAfinidad relacion;
        private string interes;
        private int precioMin = -1;
        private int precioMax = -1;
        private RegistroPreguntas preguntas = new RegistroPreguntas ();
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

        public TipoGenero Genero
        {
            get => genero;
            set => genero = value;
        }
        public TipoAfinidad Relacion
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
        public RegistroPreguntas RegistroPreguntas
        {
            get => preguntas;
            set => preguntas = value;
        }

        public Perfil (long numero)
        {
            this.Id = numero;
        }
        public override string ToString ()
        {
            return $"Edad: {this.edad} / Genero: {this.genero} / Relacion: {this.Relacion} / Interes: {this.Interes} / Precio Mínimo: {this.PrecioMin} / Precio Máximo: {this.PrecioMax}";
        }
    }
}