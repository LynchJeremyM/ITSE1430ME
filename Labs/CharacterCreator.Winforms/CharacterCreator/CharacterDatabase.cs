using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterDatabase
    {
        #region Construction

        public CharacterDatabase ()
        {
        }

        public CharacterDatabase( Character[] characters )
        {
            for (var index = 0; index < characters.Length; ++index)
                _characters[index] = characters[index];
        }

        #endregion

        #region Public Members
        public void Add( Character character )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _characters[index] = character;
        }

        public Character[] GetAll()
        {
            var count = 0;
            foreach (var movie in _characters)
            {
                if (movie != null)
                    ++count;
            };

            var temp = new Character[count];
            var index = 0;
            foreach (var movie in _characters)
            {
                if (movie != null)
                    temp[index++] = movie;
            };

            return temp;
        }

        public void Edit( string name, Character character )
        {
            Remove(name);

            Add(character);
        }

        public void Remove( string name )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (String.Compare(name, _characters[index]?.Name, true) == 0)
                {
                    _characters[index] = null;
                    return;
                };
            };
        }
        #endregion

        #region Private Members

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == null)
                    return index;
            };

            return -1;
        }

        private Character[] _characters = new Character[100];

        #endregion
    }
}
