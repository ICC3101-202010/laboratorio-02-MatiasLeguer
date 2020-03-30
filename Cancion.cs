using System;


namespace Laboratorio2_MatiasLeguer
{
    public class Cancion
    {
        private string nombre;
        private string album;
        private string artista;
        private string genero;

        public Cancion(string nombre, string album, string artista, string genero)  // Constructor que recibe los nuevos nombres del objeto
        {
            this.nombre = nombre;
            this.album = album;
            this.artista = artista;
            this.genero = genero;
        }

        public string Informacion() //Método que te entrega la información de la canción.
        {
            string info = "genero: " + genero + ", artista: " + artista + ", album: " + album + ", nombre: " + nombre;
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
        public string GetGenre()
        {
            return genero;
        }






    }
}
