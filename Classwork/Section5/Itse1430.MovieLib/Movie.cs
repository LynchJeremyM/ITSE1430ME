using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    [Description("A movie.")]
    public class Movie : IValidatableObject
    {
        //Property to back the name field
        [Required(AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 1)]
        public string Name
        {
            //get { return _name ?? ""; }  // string get ()
            get => _name ?? "";

            //set { _name = value; }       // void set ( string value )
            set => _name = value;
        }

        //Backing field for name
        private string _name = "";
               
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }        

        private string _description;

        //Using auto property with field initializer
        [Range(1900,2100,ErrorMessage = "Release Year Must be >= 1900.")]
        //[Required()]
        //[RangeAttribute(1900, 2100), [RequiredAttribute()]
        public int ReleaseYear { get; set; } = 1900;
        
        //Using auto property
        [Range(0,Int32.MaxValue, ErrorMessage = "Run length must be >= 0")]
        public int RunLength { get; set; }
        
        //Using mixed accessibility
        public int Id { get; private set; }

        //Using calculated property with no setter
        public bool IsColor => ReleaseYear > 1940;
        //{
        //    //get { return ReleaseYear > 1940; }
        //    get => ReleaseYear > 1940;
        //}

        public bool IsOwned { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //var results = new List<ValidationResult>();

            //if (String.IsNullOrEmpty(Name))
            //  yield return new ValidationResult("Name is required.",
            //                new[] { nameof(Name) });

            //if (ReleaseYear < 1900)
            //    yield return new ValidationResult("Release year must be >= 1900",
            //                    new[] { nameof(ReleaseYear) });

            //if (RunLength < 0)
            //    yield return new ValidationResult("Run length must be >= 0",
            //                    new[] { nameof(RunLength) });
            yield return null;
        }

        #region Unused Code

        //Don't make fields public
        //public System.String Name;

        //public string GetName ()
        //{
        //    return _name ?? "";
        //}
        //public void SetName ( string value )
        //{
        //    _name = value;
        //}

        //public string GetDescription ()
        //{
        //    return _description ?? "";
        //}

        //public void SetDescription ( Movie this, string value )
        //public void SetDescription ( string value )
        //{
        //    //this._description = value;
        //    //this.
        //    _description = value;
        //}

        //{
        //    get { return _releaseYear; }
        //    set {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}

        //public int GetReleaseYear()
        //{
        //    return _releaseYear;
        //}
        //public void SetReleaseYear ( int value )
        //{
        //    if (value >= 1900)
        //        _releaseYear = value;
        //}
        //private int _releaseYear = 1900;

        //Auto property syntax

        //public int GetRunLength()
        //{
        //    return _runLength;
        //}
        //public void SetRunLength( int value )
        //{
        //    if (value >= 0)
        //        _runLength = value;
        //}
        //private int _runLength;

        //int someValue;
        //private int someValue2;

        //void Foo ()
        //{
        //    var x = RunLength;

        //    var isLong = x > 100;

        //    var y = someValue;

        //}
        #endregion
    }
}
