using System.Collections.Generic;
using PII_MLApi;

namespace Library
{
    /// <summary>
    /// Pipe que devuelve sugerencias cuando el perfil seleccionado corresponde a un bebé
    /// </summary>
    public class PipeBebe: PipeFinal
    {
        public PipeBebe()
        {
            this.categoria = "1384-bebes";
        }

        public override string Filtrar(Perfil persona)
        {
            return this.categoria;
        }
    }
}