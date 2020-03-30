using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Playlist
    {
        private string nombreP;
        private List<Cancion> listPlay;

        public Playlist(string nombreP, List<Cancion> listPlay)
        {
            this.nombreP = nombreP;
            this.listPlay = listPlay;
        }

        public void InformacionPlaylist()
        {
            Console.WriteLine("INFORMACION DE LA PLAYLIST");
            Console.WriteLine("");
            for (int i = 0; i< listPlay.Count; i++)
            {
                Console.WriteLine(listPlay[i].Informacion());
                Console.WriteLine("-------------------------------------------");
            }

        }


    }
}
