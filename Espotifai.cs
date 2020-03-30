using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Espotifai
    {

        private List<Cancion> music = new List<Cancion>(3);          //lista que contiene los objetos tipo Cancion
        private Cancion malCriterio = new Cancion("m", "", "", "");  //objeto usado para el método CancionesPorCriterio 
        private Cancion noHay = new Cancion("n", "", "", "");        //objeto usado para el método CancionesPorCriterio
        private List<Playlist> playlist = new List<Playlist>(0);     //objeto usado para el método GenerarPlaylist
        private List<string> nombres = new List<string>(0);          //Lista de tipo string que va a tener todos los nombres de playlists, es usada más adelante en GenerarPlaylist.

        public Espotifai() { }    //Constructor vacío

        public bool AgregarCancion(Cancion cancion)                       //Método utilizado para agregar un objeto del tipo Cancion.
        {
            if (music.Count() == 0)                                       //En caso de que no se hayan agregado canciones, agrega la primera.
            {
                music.Add(cancion);
                return true;
            }
            else                                                          //Caso en donde ya se han colocado canciones.
            {

                for (int i = 0; i < music.Count; i++)
                {

                    if (music[i].Informacion() == cancion.Informacion())  //Evalua si es que la cancion que se quiere registrar ya ha sido ingresada.
                    {
                        return false;                                     //Si se cumple la condición, entonces la cancion no se agrega a la lista.
                    }
                }

                music.Add(cancion);                                       //Si no se cumple la condición la cancion se agrega a la lista.
                return true;
            }

        }

        public void VerCanciones()                          //Método utilizado para mostrar la informacion de todas las canciones.
        {
            for (int i = 0; i < music.Count(); i++)
            {
                Console.WriteLine(music[i].Informacion());  //Saca la informacion de la lista music y la envia a la consola.
                Console.WriteLine("----------------------------------------------");
            }
        }

        public List<Cancion> CancionesPorCriterio(string criterio, string valor)  //Método utilizado para buscar canciones a traves de un criterio y valor específico.
        {
            List<Cancion> answer = new List<Cancion>(0);             //Se crea una lista vacia

            if (criterio == "nombre" || criterio == "Nombre")        //Criterio "cancion"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetName() == valor)                 //Recorre todos los nombres y compara con el valor
                    {
                        answer.Add(music[i]);                        //Si se cumple la condición se agrega a la lista.
                    }
                }
            }
            else if (criterio == "album" || criterio == "Album")     //Criterio "Album"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetAlbum() == valor)                //Recorre todos los albums y compara con el valor
                    {
                        answer.Add(music[i]);                        //Si se cumple la condición se agrega a la lista.
                    }
                }
            }
            else if (criterio == "artista" || criterio == "Artista") //Criterio "Artista"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetArtist() == valor)               //Recorre todos los artistas y compara con el valor
                    {
                        answer.Add(music[i]);                        //si se cumple la condición se agrega a la lista.
                    }
                }
            }
            else if (criterio == "genero" || criterio == "Genero")   //Criterio "genero"
            {
                for (int i = 0; i < music.Count; i++)
                {
                    if (music[i].GetGenre() == valor)                //Recorre todos los generos y compara con el valor
                    {
                        answer.Add(music[i]);                        //Si se cumple la condición, se agrega a la lista.
                    }
                }
            }
            else                                                     //Condición cuando no cumple con ningun criterio.
            {
                answer.Add(malCriterio);                             //Se añade el objeto malCriterio para simbolizar que el criterio no es el correcto.
                return answer;
            }

            if (answer.Count != 0)                                   //Cuando cumple con un criterio Se evalua si la lista contiene elementos
            {
                return answer;                                       //La lista Contiene elementos 
            }
            else                                                     //La lista no contiene elementos
            {
                answer.Add(noHay);                                   //Se añade el objeto noHay para simbolizar que no hay ninguna cancion que coinicde con el valor.
                return answer;                                       
            }


        }

        public bool GenerarPlaylist(string criterio, string valorCriterio, string nombrePlaylist)    //Método utilizado para verificar si la playlist fue creada, y agregar playlist a una lista.
        {
            List<Cancion> listaPlaylist;                                      //lista que va a contener todas las canciones de la playlist
            listaPlaylist = CancionesPorCriterio(criterio, valorCriterio);    //Se llama al método Canciones por criterio y todas las canciones se añaden a la lista listaPlaylist.

            if (listaPlaylist[0].Informacion() == malCriterio.Informacion())  //Se evalua si el criterio fue incorrecto
            {
                Console.WriteLine("\nEl criterio no es el correcto");
                listaPlaylist.Clear();
                return false;
            }
            else if (listaPlaylist[0].Informacion() == noHay.Informacion())   //Se evalua si no hay canciones que cumplan con el valor de la lista.
            {
                Console.WriteLine("\nEl valor seleccionado no cumple con ninguna de las canciones");
                listaPlaylist.Clear();
                return false;
            }

            Playlist play = new Playlist(nombrePlaylist, listaPlaylist);     //Se genera un objeto de tipo Playlist
            if (nombres.Count == 0)                                          //Si no hay ningun nombre en la lista nombres, se agrega la playlist a la listaPlaylist
            {
                playlist.Add(play);
                nombres.Add(nombrePlaylist);
            }
            else                                                             //Condición se cumple cuando si hay nombres en la lista nombres.
            {
                for (int i = 0; i < nombres.Count; i++)
                {
                    if (nombres[i] == nombrePlaylist)                        //Si el nombre de la playlist que se quiere ingresar es igual a uno de los nombres ya creados, no se crea la playlist.
                    {
                        Console.WriteLine("\nEste nombre ya existe");
                        return false;
                    }
                }
                nombres.Add(nombrePlaylist);
                playlist.Add(play);                                          //En caso contrario, se agrega a la lista listaPlaylist
            }
            Console.WriteLine(playlist.Last().InformacionPlaylist());        //Se menciona la información de la playlist recién ingresada
            return true;
        }

        public string VerMisPlaylists()                           //Este método es usado para ver todas las playlists que se han ingresado.
        {
            List<string> infoP = new List<string>(0);             //se genera una lista de tipo string en donde se tendra la información de todas las playlists.
            string infoPlaylist = "\nINFORMACION PLAYLISTS\n";    //Titulo del método cuando es insertado a la consola

            for (int i = 0; i < playlist.Count; i++)
            {
                infoP.Add(playlist[i].InformacionPlaylist());     //Se añade toda la información de cada playlist
            }

            for (int i = 0; i < infoP.Count; i++)
            {
                infoPlaylist += infoP[i];                         //Se agrega a la variable infoPlaylist como un string.
            }
            return infoPlaylist;                                  //Se retorna toda la información en una variable tipo string.
        }
    }
}
