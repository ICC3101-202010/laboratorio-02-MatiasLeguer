using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2_MatiasLeguer
{
    class Program
    {
        static void Main(string[] args)
        {
            Espotifai spotify = new Espotifai();
            int i = 0;
            while (i < 3)
            {

                //Se colocan los datos: Nombre, album, artista, genero
                Console.WriteLine("Coloque el nombre de la cancion, luego el album, después el artista y finalmente el genero");
                string name = Console.ReadLine();
                string album = Console.ReadLine();
                string artist = Console.ReadLine();
                string genre = Console.ReadLine();
                //Se Crea la instancia
                Cancion cancion = new Cancion(name, album, artist, genre);

                //Se checkea si la canción se encuentra en la lista.
                bool respuesta = spotify.AgregarCancion(cancion);
                if (respuesta == false) // Si la respuesta es false (que si esta en la lista) entonces se reinicia este ciclo.
                {
                    i--;
                }
                
                
                i++;
            }
           
            
            

        }
    }
}



