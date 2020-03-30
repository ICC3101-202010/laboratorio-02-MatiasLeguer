using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Espotifai
    {

        private List<Cancion> music = new List<Cancion>(3);
        private Cancion malCriterio = new Cancion("m", "", "", "");
        private Cancion noHay = new Cancion("n", "", "", "");
        private List<Playlist> playlist = new List<Playlist>(0);

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

        public void VerCanciones()
        {
            for (int i = 0; i < music.Count(); i++)
            {
                Console.WriteLine(music[i].Informacion());
                Console.WriteLine("----------------------------------------------");
            }
        }

        public List<Cancion> CancionesPorCriterio(string criterio, string valor)
        {
            List<Cancion> answer = new List<Cancion>(0);             //Se crea una lista vacia

            if (criterio == "nombre" || criterio == "Nombre")        //Criterio "cancion"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetName() == valor)                 //Recorre todos los nombres y compara con el valor
                    {
                        answer.Add(music[i]);
                    }
                }
            }
            else if (criterio == "album" || criterio == "Album")     //Criterio "Album"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetAlbum() == valor)                //Recorre todos los albums y compara con el valor
                    {
                        answer.Add(music[i]);
                    }
                }
            }
            else if (criterio == "artista" || criterio == "Artista") //Criterio "Artista"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetArtist() == valor)               //Recorre todos los artistas y compara con el valor
                    {
                        answer.Add(music[i]);
                    }
                }
            }
            else if (criterio == "genero" || criterio == "Genero")   //Criterio "genero"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetGenre() == valor)                //Recorre todos los generos y compara con el valor
                    {
                        answer.Add(music[i]);
                    }
                }
            }
            else                                                     //Condición cuando no cumple con ningun criterio.
            {
                answer.Add(malCriterio);
                return answer;
            }

            if (answer.Count != 0)                                   //Cuando cumple con un criterio Se evalua si la lista contiene elementos
            {
                return answer;                                       //La lista Contiene elementos 
            }
            else
            {
                answer.Add(noHay);
                return answer;                                       //La lista no contiene elementos
            }


        }

        public bool GenerarPlaylist(string criterio, string valorCriterio, string nombrePlaylist)
        {
            Espotifai spot = new Espotifai();
            List<Cancion> listaPlaylist;
            List<string> nombres = new List<string>(0);
            listaPlaylist = spot.CancionesPorCriterio(criterio, valorCriterio);

            if (listaPlaylist[0].Informacion() == malCriterio.Informacion())
            {
                Console.WriteLine("El criterio no es el correcto");
                listaPlaylist.Clear();
                return false;
            }
            else if (listaPlaylist[0].Informacion() == noHay.Informacion())
            {
                Console.WriteLine("No hay canciones solicitadas con su valor para agregar a la playlist");
                listaPlaylist.Clear();
                return false;
            }

            if (nombres.Count == 0)
            {
                Playlist play = new Playlist(nombrePlaylist, listaPlaylist);
                playlist.Add(play);
            }
            else
            {
                for (int i = 0; i < nombres.Count; i++)
                {
                    if (nombres[i] == nombrePlaylist)
                    {
                        Console.WriteLine("Este nombre ya existe");
                        return false;
                    }
                }
            }
            return true;
        }

        public string VerMisPlaylists()
        {
            List<string> infoP = new List<string>(0);
            string infoPlaylist = "INFORMACION PLAYLISTS\n";

            for (int i = 0; i < playlist.Count; i++)
            {
                infoP.Add(playlist[i].InformacionPlaylist());
            }

            for (int i = 0; i < infoP.Count; i++)
            {
                infoPlaylist += infoP[i];
            }
            return infoPlaylist;
        }







    }
}
