using System;
using System.Collections.Generic;
namespace Library
{
    public class PipeInicial: PipeCondicional
    {
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