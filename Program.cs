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
            Console.WriteLine("MENÚ");            //Comienzo del menú
            
            while (afirmacion)                    //Loop infinito
            {   //Contenido del menú
                Console.WriteLine("\nSi desea agregar una canción, escriba: agregar\nSi desea ver las canciones disponible, escriba: ver\nSi desea buscar a traves de los cuatro criterios, escriba: criterio\nSi desea crear una playlist, escriba: Crear playlist\nSi desea ver las playlists creadas, escriba: Ver mis playlists\nSi desea salir del programa escriba: close");
                string caseSwitch = Console.ReadLine(); //Recibimos lo que el usuario quiera hacer.

                switch (caseSwitch)                     //Posibles casos que el usuario puede acceder.
                {
                    case "agregar":                     //Caso utilizado para agregar una cancion a la lista.

                        Console.Write("Coloque el nombre de la cancion: "); string name = Console.ReadLine();    //Recibe el nombre,
                        Console.Write("Coloque el album: ");                string album = Console.ReadLine();   //el album,
                        Console.Write("Coloque el artista: ");              string artist = Console.ReadLine();  //el artista
                        Console.Write("Coloque el genero: ");               string genre = Console.ReadLine();   // y el genero.
                       
                        Cancion cancion = new Cancion(name, album, artist, genre);  //Se Crea la instancia
                        bool respuesta = spotify.AgregarCancion(cancion);           //Se checkea si la canción se encuentra en la lista.
                        
                        if (respuesta == false)                                     //Condición que nos dice si es que se pudo ingresar la canción
                        {
                            Console.WriteLine("\nNo se pudo ingresar la canción debido a que ya se encuentra dentro del sistema");
                        }
                        break;

                    case "ver":                  // Caso que permite que observes las canciones que se han puesto

                        spotify.VerCanciones();  // Metódo que muestra las canciones
                        break;


                    case "criterio":
                        Cancion mc = new Cancion("m", "", "", "");  //objeto utilizado para identificar que el criterio escrito no es correcto.
                        Cancion nh = new Cancion("n", "", "", "");  //objeto utilizado para identificar que no hay cancion que cumpla con el valor escrito.

                        Console.Write("Porfavor escriba el criterio que quiere utilizar (nombre, album, artista, genero): ");
                        string criterio = Console.ReadLine();       //Se recibe el criterio del usuario.

                        Console.Write("Escriba el valor: ");
                        string valor = Console.ReadLine();          //Se recibe el valor del usuario.

                        List<Cancion> answer;                       //utilizamos una lista answer para recibir todas las canciones que fueron aceptadas por el criterio y valor.

                        Console.WriteLine(" ");
                        Console.WriteLine("LISTA DE CANCIONES POR CRITERIO");
                        Console.WriteLine(" ");
                        answer = spotify.CancionesPorCriterio(criterio, valor);

                        if(answer[0].Informacion() == mc.Informacion())       //Si la condición se cumple, entonces el criterio no fue escrito correctamente.
                        {
                            Console.WriteLine("\nEl criterio no es parte de los cuatro criterios disponibles");
                            answer.Clear();
                        }
                        else if (answer[0].Informacion() == nh.Informacion()) //Si la condicion se cumple, entonces no hay canciones que coincidan con el valor escrito por el usuario.
                        {
                            Console.WriteLine("\nNo se encontró ninguna canción que cumpla el valor señalado");
                            answer.Clear();
                        }

                        for (int i = 0; i < answer.Count; i++)                //En el caso de que no se cumplan ninguna de las condiciones se escribe la informacion de todas las canciones en la consola
                        {
                            Console.WriteLine("-----------------------------------------------");
                            Console.WriteLine(answer[i].Informacion());
                            Console.WriteLine("-----------------------------------------------");
                        }
                        break;

                    case "Crear playlist": //Caso utilizado para crear una playlist.

                        Console.Write("Porfavor ingrese el criterio con el cual quiere crear la playlist: ");  string criterioPlaylist = Console.ReadLine();      //Se recibe el criterio
                        Console.Write("Coloque el valor del criterio: ");                                      string valorCriterioPlaylist = Console.ReadLine(); //Se recibe el valor
                        Console.Write("Porfavor coloque un nombre a su playlist: ");                           string nombreP = Console.ReadLine();               //Se recibe el nombre de la playlist
                        
                        bool creacion = spotify.GenerarPlaylist(criterioPlaylist, valorCriterioPlaylist, nombreP);  //Se checkea si es que se ingresa la playlist al sistema o se rechaza.
                        if (creacion == false)   //si el resultado es falso, entonces la playlist no fue ingresada.
                        {
                            break;
                        }
                        break;                   //En el caso de que el resultado sea true, la playlist fue agregada en el método GenerarPlaylist, por lo que simplemente se coloca un break

                    case "Ver mis playlists":    //Caso para ver las playlists que se han creado
                        Console.WriteLine(spotify.VerMisPlaylists());
                        break;

                    
                    case "close":                // Caso para poder cerrar el loop infinito.
                        afirmacion = false;
                        break;
                }
            }
        }
    }
}



