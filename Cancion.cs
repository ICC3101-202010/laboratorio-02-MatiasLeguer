using System;


namespace Laboratorio2_MatiasLeguer
{
    public class Cancion
    {
        private string nombre;
        private string album;
        private string artista;
        private string genero;

        public Cancion(string nombre, string album, string artista, string genero)
        {
            this.nombre = nombre;
            this.album = album;
            this.artista = artista;
            this.genero = genero;
        }

        public string Informacion()
        {
            string info = "Nombre: " + nombre + ", Album: " + album + ", Artista: " + artista + ", Genero: " + genero;
            return info;
        }

        public string GetName()
        {
            return nombre;
        }

        public string GetAlbum()
        {
            return album;
        }

        public string GetArtist()
        {
            return artista;
        }






    }
}
