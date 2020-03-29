using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    public class Espotifai
    {

        public List<Cancion> music = new List<Cancion>(3);

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
                Console.WriteLine("El Criterio no es uno de los cuatro permitidos");
                return answer;
            }

            if (answer.Count != 0)                                   //Cuando cumple con un criterio Se evalua si la lista contiene elementos
            {
                return answer;                                       //La lista Contiene elementos 
            }
            else
            {
                Console.WriteLine("No se encontro ninguna Cancion que cumpla con el valor mencionado.");
                return answer;                                       //La lista no contiene elementos
            }


        }







    }
}
