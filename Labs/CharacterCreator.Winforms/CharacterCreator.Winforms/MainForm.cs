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
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _listCharacters.DisplayMember = "Name";
            RefreshCharacters();
        }
        
        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?",
            "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Jeremy Lynch\nITSE-140-20630\nCharacter Creator", "About", MessageBoxButtons.OK);
        }

        private void OnListKeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteCharacter();
            }
        }

        private void OnMovieDoubleClick( object sender, EventArgs e )
        {
            EditCharacter();
        }

        private void OnCharacterEdit( object sender, EventArgs e )
        {
            EditCharacter();
        }

        private void OnCharacterAdd( object sender, EventArgs e )
        {
            var form = new CharacterForm();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Add(form.Character);
            RefreshCharacters();
        }

        #endregion

        #region Private Members

        private void DeleteCharacter()
        {
            var item = GetSelectedCharacter();
            if (item == null)
                return;

            //Remove from database and refresh
            if (MessageBox.Show("Do you want to delete this character?",
                "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _database.Remove(item.Name);
            RefreshCharacters();
        }

        private void EditCharacter()
        {           
            var item = GetSelectedCharacter();
            if (item == null)
                return;
           
            var form = new CharacterForm();
            form.Character = item;
            form.Text = "Edit Character";
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Edit(item.Name, form.Character);
            RefreshCharacters();
        }

        private Character GetSelectedCharacter()
        {
            return _listCharacters.SelectedItem as Character;
        }

        private void RefreshCharacters()
        {
            var characters = _database.GetAll();

            _listCharacters.Items.Clear();
            _listCharacters.Items.AddRange(characters);
        }

        private CharacterDatabase _database = new CharacterDatabase();

        #endregion
    }
}
