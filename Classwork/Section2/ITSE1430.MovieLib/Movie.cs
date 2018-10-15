using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie
    {
        public string Name { get; set; }
        //{
        //    get { return _name ?? ""; }       // string get()
        //    set { _name = value; }      // void set( string value )
        //}

        ////public string GetName()
        ////{
        ////    return _name ?? "";
        ////}
        ////public void SetName( string value)
        ////{
        ////    _name = value;
        ////}
        //private string _name = "";

        // public System.String Name;

        public string Description { get; set; }
       /* {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        //public string GetDescription()
        //{
        //    return _description ?? "";
        //}
        //public void SetDescription(string value)
        //{
        //    _description = value;
        //}
        private string _description;
        */
       
        public int ReleaseYear { get; set; } = 1900;
        /*{
            get { return _releaseYear; }
            set
            {
                if (value >= 1900)
                    _releaseYear = value;
            }
        }*/
        //public int GetReleaseYear()
        //{
        //    return _releaseYear;
        //}
        //public void SetReleaseYear(int value)
        //{
        //    if (value >= 1900)
        //        _releaseYear = value;
        //}
        //private int _releaseYear = 1900;

        // Auto property syntax
        public int RunLength{ get; set;}
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set
        //    {
        //        if (value >= 0)
        //            _runLength = value;
        //    }
        //}
        //public int GetRunLength()
        //{
        //    return _runLength;
        //}
        //public void SetRunLength(int value)
        //{
        //    if (value >= 0)
        //        _runLength = value;
        //}
        // private int _runLength;


        //int someValue;
        //private int someValue2;

        //void Foo ()
        //{
        //    var x = RunLength;

        //    var isLong = x > 100;

        //    var y = someValue;
        //}

        public int Id { get; private set; }

        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }

        public bool IsOwned { get; set; }

    }
}
