using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    public interface IMovieDatabase
    {
        void Add( Movie movie );
        void Edit( string name, Movie movie );
        IEnumerable<Movie> GetAll();
        void Remove( string name );
    }
}