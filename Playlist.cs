using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Playlist
    {
        private string nombreP;                 //Nombre de la playlist
        private List<Cancion> listPlay;         //lista de todas las canciones de la playlist

        public Playlist(string nombreP, List<Cancion> listPlay)   //Constructor
        {
            this.nombreP = nombreP;
            this.listPlay = listPlay;
        }

        public string InformacionPlaylist()                                           //Entrega la información de todas las playlists creadas
        {
            string info;
            info = "\n" + nombreP + "\n-----------------------------------------\n";  //Se coloca el nombre de la playlist.
            
            for (int i = 0; i< listPlay.Count; i++)                                   //Se añade cada canción de la playlist
            {
                info += listPlay[i].Informacion() + "\n---------------------------------------------------------------------------\n";
            }

            return info;

        }

        public string GetName()      //Se recibe el nombre de la playlist
        {
            return nombreP;
        }


    }
}
