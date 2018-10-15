using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSE1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            //Trigger validate event on each child
            if (!ValidateChildren())
                return;

            var movie = new Movie() {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                ReleaseYear = GetInt32(_txtReleaseYear),
                RunLength = GetInt32(_txtRunLength)
            };

            //var movie = new Movie();
        //var movie2 = new Movie();
        //var name = movie2.GetName();

        //Name is required
            //movie.Name = _txtName.Text;
        //movie.SetName(_txtName.Text);
        //if (String.IsNullOrEmpty(movie.Name))
        //    return;

            //movie.Description = _txtDescription.Text;
        //if (String.IsNullOrEmpty(movie.Description))
        //    return;

        //Release year is numeric, if set
            //movie.ReleaseYear = GetInt32(_txtReleaseYear);
        //movie.SetReleaseYear(GetInt32(_txtReleaseYear));
        //if (movie.ReleaseYear < 0)
        //    return;

            //movie.RunLength = GetInt32(_txtRunLength);
        //movie.SetRunLength(GetInt32(_txtRunLength));
        //if (movie.RunLength < 0)
        //    return;

            //movie.IsOwned = _chkOwned.Checked;

        Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        private void MovieForm_Load( object sender, EventArgs e )
        {
            //_btnSave.Click += _btnSave_Click;
            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };
            ValidateChildren();
        }

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //control.Error
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidatingReleaseYear( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1900)
            {
                _errors.SetError(control, "Must be > 1900");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }
        private void OnValidatingRunLength( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0)
            {
                _errors.SetError(control, "Must be > 0");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
