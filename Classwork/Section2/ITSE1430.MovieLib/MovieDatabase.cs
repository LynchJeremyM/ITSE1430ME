using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class MovieDatabase
    {
        public MovieDatabase() : this(true)
        {
        }

        private static Movie[] GetSeedMovies( bool seed )
        {
            if (!seed)
                return new Movie[0];

            return new []
            {
                new Movie()
                {
                    Name = "Potato",
                    Description = "Really?",
                    RunLength = 122,
                    ReleaseYear = 2001,
                },

                new Movie()
                {
                    Name = "Not Potato",
                    Description = "Not Really.",
                    RunLength = 124,
                    ReleaseYear = 2002,
                },
            };

            //if (!seed)
            //    return new Movie[0];

            //var movies = new Movie[2];

            //movies[0] = new Movie();
            //movies[0].Name = "Potato";
            //movies[0].Description = "Really?";
            //movies[0].RunLength = 122;
            //movies[0].ReleaseYear = 2001;

            //movies[1] = new Movie();
            //movies[1].Name = "Not Potato";
            //movies[1].Description = "Not Really.";
            //movies[1].RunLength = 124;
            //movies[1].ReleaseYear = 2002;

            //return movies;
        }

        public MovieDatabase( bool seed ) : this(GetSeedMovies(seed))
        {
            //if (seed)
            //{
            //    var movie = new Movie();
            //    movie.Name = "Potato";
            //    movie.Description = "Really?";
            //    movie.RunLength = 122;
            //    movie.ReleaseYear = 2001;
            //    Add(movie);

            //    movie = new Movie();
            //    movie.Name = "Not Potato";
            //    movie.Description = "Not Really.";
            //    movie.RunLength = 124;
            //    movie.ReleaseYear = 2002;
            //    Add(movie);
            //}
        }

        public MovieDatabase ( Movie[] movies)
        {
            _items.AddRange(movies);
            //for (var index = 0; index < movies.Length; ++index)
            //    _movies[index] = movies[index];
        }

        public void Add (Movie movie)
        {
            _items.Add(movie);
            //var index = FindNextFreeIndex();
            //if (index >= 0)
            //    _movies[index] = movie;
        }

        //private int FindNextFreeIndex()
        //{
        //    for (var index = 0; index < _movies.Length; ++index)
        //    {
        //        if (_movies[index] == null)
        //            return index;
        //    };

        //    return -1;
        //}

        public Movie[] GetAll()
        {
            var count = _items.Count;

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _items)
            {
                temp[index++] = movie;
            };

            // How many movies do we have
            //var count = 0;
            //foreach (var movie in _movies)
            //{
            //    if (movie != null)
            //        ++count;
            //};

            //var temp = new Movie[count];
            //var index = 0;
            //foreach (var movie in _movies)
            //{
            //    if (movie != null)
            //        temp[index++] = movie;
            //};

            return temp;
        }

        public void Remove (string name)
        {
            var movie = FindMovie(name);
            if (movie != null)
                _items.Remove(movie);

            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    if (String.Compare(name, _movies[index]?.Name, true) == 0)
            //    {
            //        _items.Remove
            //        //_movies[index] = null;
            //        return;
            //    };
            //}
        }

        public void Edit( string name, Movie movie )
        {
            //Find movie by name
            Remove(name);

            //Replace it
            Add(movie);
        }

        private Movie FindMovie( string name )
        {
            //var pairs = new Dictionary<string, Movie>();

            foreach (var movie in _items)
            {
                if (String.Compare(name, movie.Name, true) == 0)
                {
                    return movie;
                };
            };

            return null;
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _items = new List<Movie>();
    }
}
