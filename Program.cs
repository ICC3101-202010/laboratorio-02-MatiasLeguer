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
            bool afirmacion = true;
            while (afirmacion)
            {
                Console.WriteLine("Si desea agregar una canción, escriba: 'agregar' ; si desea ver las canciones disponible, escriba: 'ver' ; Si desea salir del programa escriba: 'close'' ");
                string caseSwitch = Console.ReadLine();

                switch (caseSwitch)
                {
                    case "agregar":

                        Console.WriteLine("Porfavor coloque el nombre de la cancion, luego el album, después el artista y finalmente el genero");
                        string name = Console.ReadLine();
                        string album = Console.ReadLine();
                        string artist = Console.ReadLine();
                        string genre = Console.ReadLine();
                        //Se Crea la instancia
                        Cancion cancion = new Cancion(name, album, artist, genre);

                        //Se checkea si la canción se encuentra en la lista.
                        bool respuesta = spotify.AgregarCancion(cancion);
                        if (respuesta == false)
                        {
                            Console.WriteLine("No se pudo ingresar la canción debido a que ya se encuentra dentro del sistema");
                        }
                        break;

                    case "ver":

                        spotify.VerCanciones();
                        break;

                    case "close":

                        afirmacion = false;
                        break;

                }

            }
        }
    }
}



