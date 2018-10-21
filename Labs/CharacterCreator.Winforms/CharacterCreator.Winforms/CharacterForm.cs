using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        #region Construction

        public CharacterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        public Character Character { get; set; }

        #endregion

        #region Event Handlers

        private void CharacterForm_Load( object sender, EventArgs e )
        {
            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _txtProfession.Text = Character.Profession;
                _txtRace.Text = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntelligence.Text = Character.Intelligence.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
                _txtDescription.Text = Character.Description;
            };

            ValidateChildren();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = new Character();

            character.Name = _txtName.Text;
            character.Profession = _txtProfession.Text;
            character.Race = _txtRace.Text;
            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);
            character.Description = _txtDescription.Text;

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Private Members

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            StringValidation(sender, e, "Name");
        }

        private void OnValidateProfession( object sender, CancelEventArgs e )
        {
            ComboBoxValidation(sender, e, "Profession");
        }

        private void OnRaceValidating( object sender, CancelEventArgs e )
        {
            ComboBoxValidation(sender, e, "Race");
        }

        private void OnValidatingStrength( object sender, CancelEventArgs e )
        {
            IntValidation(sender, e);
        }

        private void OnValidatingIntelligence( object sender, CancelEventArgs e )
        {
            IntValidation(sender, e);
        }

        private void OnValidatingAgility( object sender, CancelEventArgs e )
        {
            IntValidation(sender, e);
        }

        private void OnValidatingConstitution( object sender, CancelEventArgs e )
        {
            IntValidation(sender, e);
        }

        private void OnValidatingCharisma( object sender, CancelEventArgs e )
        {
            IntValidation(sender, e);
        }

        private void StringValidation( object sender, CancelEventArgs e, string message )
        {
            var control = sender as TextBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, $"{message} is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void ComboBoxValidation(object sender, CancelEventArgs e, string message)
        {
            var control = sender as ComboBox;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, $"{message} is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void IntValidation(object sender, CancelEventArgs e)
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1 || result > 100)
            {
                _errors.SetError(control, "Must be an int from 1 - 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private int GetInt32( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        #endregion
    }
}
