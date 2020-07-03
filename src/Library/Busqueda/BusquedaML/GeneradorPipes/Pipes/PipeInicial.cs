using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Pipe inicial que toma en cuenta las características personales del perfil para decidir a qué Pipe enviarlo luego
    /// </summary>
    public class PipeInicial: PipeCondicional
    {
        /// <summary>
        ///  Por Creator, PipeInicial crea instancias de los Pipes siguientes, ya que los contiene
        /// </summary>
        public PipeInicial()
        {
            PipeBebe bebe =  new PipeBebe();
            PipeTiempoLibre tiempoLibre = new PipeTiempoLibre();
            PipeCuidadoPersonal cuidadoPersonal = new PipeCuidadoPersonal();
            PipeHogar hogar = new PipeHogar();
            List<IPipe> siguientes = new List<IPipe>();
            siguientes.Add(bebe);
            siguientes.Add(tiempoLibre);
            siguientes.Add(cuidadoPersonal);
            siguientes.Add(hogar);

            this.caminos = siguientes;
        }
        /// <summary>
        /// Tomando en cuenta la edad de la persona, se decanta por uno de los Pipes siguientes
        /// </summary>
        /// <param name="persona">Persona a quien se busca el regalo</param>
        /// <returns></returns>
        public override string Filtrar(Perfil persona)
        {
            if (persona.Edad < 2)
            {
                return this.caminos[0].Filtrar(persona);
            }
            else if (persona.Edad < 20)
            {
                return this.caminos[1].Filtrar(persona);
            }
            else if (persona.Edad < 40)
            {
                return this.caminos[2].Filtrar(persona);
            }
            else
            {
                return this.caminos[3].Filtrar(persona);
            }

        }
        
    }
}