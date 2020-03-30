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

        public string InformacionPlaylist()
        {
            string info;
            info = nombreP + "\n-----------------------------------------\n";
            
            for (int i = 0; i< listPlay.Count; i++)
            {
                info += listPlay[i].Informacion() + "\n---------------------------------------------------------------------------\n";
            }

            return info;

        }

        public string GetName()
        {
            return nombreP;
        }


    }
}
