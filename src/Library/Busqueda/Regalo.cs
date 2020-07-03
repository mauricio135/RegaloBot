namespace Library
{
    public class Regalo
    {
        private string nombre;
        private string precio;
        private string moneda;
        private string url;
        private string urlImagen;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Precio
        {
            get => precio;
            set => precio = value.Replace(".","");
        }
        public string Moneda
        {
            get => moneda;
            set => moneda = value;
        }
        public string Url
        {
            get => url;
            set
            {
                string[] link = value.Split ('#');
                url = link[0];
            }
        }

        public string UrlImagen
        {
            get => urlImagen;
            set => urlImagen = value;
        }

        public Regalo (string nomb, string prec, string moned, string link, string linkImagen)
        {
            this.nombre = nomb;
            this.precio = prec;
            this.moneda = moned;
            this.url = link;
            this.urlImagen = linkImagen;
        }
        public Regalo ()
        {

        }
        
        public override string ToString ()
        {
            return $"{nombre} -> {moneda} {precio} \n {url}";
        }
    }
}