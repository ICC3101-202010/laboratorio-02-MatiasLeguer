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
            Espotifai spotify = new Espotifai();  //Se crea la instancia spotify
            bool afirmacion = true;               //Se crea una variable true para tener un loop infinito hasta que el usuario quiera cerrar el programa.
            while (afirmacion)                    //Loop infinito
            {
                Console.WriteLine("Si desea agregar una canción, escriba: 'agregar' ; si desea ver las canciones disponible, escriba: 'ver' ; Si desea buscar a traves de los cuatro criterio, escriba: 'criterio'; Si desea salir del programa escriba: 'close'");
                string caseSwitch = Console.ReadLine(); //Recibimos lo que el usuario quiera hacer.

                switch (caseSwitch)                     //Posibles casos que el usuario puede acceder.
                {
                    case "agregar":                     //Caso utilizado para agregar una cancion a la lista.

                        Console.WriteLine("Porfavor coloque el nombre de la cancion, luego el album, después el artista y finalmente el genero");
                        string name = Console.ReadLine();              //Se agrega el nombre,
                        string album = Console.ReadLine();             //el album,
                        string artist = Console.ReadLine();            //el artista
                        string genre = Console.ReadLine();             // y el genero.
                       
                        Cancion cancion = new Cancion(name, album, artist, genre);  //Se Crea la instancia
                        bool respuesta = spotify.AgregarCancion(cancion);           //Se checkea si la canción se encuentra en la lista.
                        if (respuesta == false)                                     //Condición que nos dice si es que se pudo ingresar la canción
                        {
                            Console.WriteLine("No se pudo ingresar la canción debido a que ya se encuentra dentro del sistema");
                        }
                        break;

                    case "ver":                  // Caso que permite que observes las canciones que se han puesto

                        spotify.VerCanciones();  // Metódo que muestra las canciones
                        break;


                    case "criterio":
                        Cancion mc = new Cancion("m", "", "", "");
                        Cancion nh = new Cancion("n", "", "", "");

                        Console.WriteLine("Porfavor escriba el criterio que quiere utilizar (nombre, album, artista, genero)");
                        string criterio = Console.ReadLine();

                        Console.WriteLine("Ahora escriba el valor");
                        string valor = Console.ReadLine();
                        List<Cancion> answer;

                        Console.WriteLine(" ");
                        Console.WriteLine("LISTA DE CANCIONES POR CRITERIO");
                        Console.WriteLine(" ");
                        answer = spotify.CancionesPorCriterio(criterio, valor);

                        if(answer[0].Informacion() == mc.Informacion())
                        {
                            Console.WriteLine("El criterio no es parte de los cuatro criterios disponibles");
                            answer.Clear();
                        }
                        else if (answer[0].Informacion() == nh.Informacion())
                        {
                            Console.WriteLine("No se encontró ninguna canción que cumpla el valor señalado");
                            answer.Clear();
                        }

                        for (int i = 0; i < answer.Count; i++)
                        {
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine(answer[i].Informacion());
                            Console.WriteLine("-----------------------------------------------");
                        }
                        break;


                    case "close":                // Caso para poder cerrar el loop infinito.
                        afirmacion = false;
                        break;




                }







            }



        }




    }
}



