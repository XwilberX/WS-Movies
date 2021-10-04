using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_Movies
{
    /// <summary>
    /// Descripción breve de WS_Movies
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Movies : System.Web.Services.WebService
    {

        MoviesEntities1 moviesDB = new MoviesEntities1();

        [WebMethod(Description = "Lista de Peliculas")]
        public List<movies> GetMovies()
        {
            List<movies> query = moviesDB.movies.ToList();

            return query;
        }

        [WebMethod(Description = "Obtener un pelicula por id")]
        public movies GetMovie(int id)
        {
            var query = moviesDB.movies.Find(id);

            return query;
        }

        [WebMethod(Description = "Crear una pelicula")]
        public bool CreateMovie(movies movie)
        {
            try
            {
                moviesDB.movies.Add(movie);
                moviesDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Actualizar una pelicula")]
        public bool UpdateMovie(movies movie)
        {
            try
            {
                movies updated_movie = moviesDB.movies.Find(movie.id);

                if (updated_movie != null)
                {
                    updated_movie.id = movie.id;
                    updated_movie.name = movie.name;
                    updated_movie.genre = movie.genre;
                    updated_movie.description = movie.description;
                    updated_movie.rating = movie.rating;
                    updated_movie.director = movie.director;
                    updated_movie.year = movie.year;
                    moviesDB.SaveChanges();

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
            
        }

        [WebMethod(Description = "Eliminar una pelicula")]
        public bool DeleteMovie(int id)
        {
            try
            {
                movies deleted_movie = moviesDB.movies.Find(id);

                if (deleted_movie != null)
                {
                    moviesDB.movies.Remove(deleted_movie);
                    moviesDB.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
