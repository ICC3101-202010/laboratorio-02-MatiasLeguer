using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Espotifai
    {
        
        public List <Cancion> music = new List<Cancion>(3);
        public Espotifai()
        {

        }

        public bool AgregarCancion(Cancion cancion)
        {
            if (music.Count() == 0)
            {
                music.Add(cancion);
                return true;
            }
            else
            {
                
                for (int i = 0; i < music.Count; i++)
                {

                    if (music[i].Informacion() == cancion.Informacion())
                    {
                        return false;
                    }
                }

                music.Add(cancion);
                return true;
            }

            
            
        }

        





    }
}
