using ResourceDesigner.Classes;
using ResourceDesigner.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Forms
{
    public partial class CharSetListManager : Form
    {
        CharSetList spriteSetList;
        CharSetList tileSetList;

        CharSet setToDelete;
        CharSetList listToDelete;

        public event EventHandler<CharSetEventArgs> CharSetSelected;
        public event EventHandler<CharSetEventArgs> CharSetDeleted;

        public CharSetListCharSets CharSets
        {
            get 
            {
                return new CharSetListCharSets 
                { 
                    Sprites = spriteSetList?.CharSets,
                    Tiles = tileSetList?.CharSets 
                };
            }

            set
            {
                if(spriteSetList != null)
                    spriteSetList.CharSets = value.Sprites;

                if (tileSetList != null)
                    tileSetList.CharSets = value.Tiles;
            }
        }

        public CharSetListManager(bool IncludeSpriteSet, bool IncludeTileSet)
        {
            InitializeComponent();
            int width = 0;

            if (IncludeSpriteSet)
            {
                spriteSetList = new CharSetList();
                spriteSetList.Top = 0;
                spriteSetList.Left = 0;
                spriteSetList.Width = CharSetList.ItemSize + 32;
                spriteSetList.Height = this.ClientSize.Height;
                spriteSetList.Title = "Sprites";
                spriteSetList.CharSetSelected += CharSetList_CharSetSelected;
                spriteSetList.CharSetMenuRequested += SpriteSetList_CharSetMenuRequested;
                Controls.Add(spriteSetList);
                spriteSetList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
                width = spriteSetList.Width;

            }

            if (IncludeTileSet)
            {
                tileSetList = new CharSetList();
                tileSetList.Top = 0;
                tileSetList.Left = width;
                tileSetList.Width = CharSetList.ItemSize + 32;
                tileSetList.Height = this.ClientSize.Height;
                tileSetList.Title = "Tiles";
                tileSetList.CharSetSelected += CharSetList_CharSetSelected;
                tileSetList.CharSetMenuRequested += TileSetList_CharSetMenuRequested;
                Controls.Add(tileSetList);
                tileSetList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
                width += tileSetList.Width;
            }

            var clw = this.ClientSize;
            clw.Width = width;
            this.ClientSize = clw;
            this.MinimumSize = new Size(this.Width, CharSetList.ItemSize);
            this.MaximumSize = new Size(this.Width, 10000);
        }

        private void TileSetList_CharSetMenuRequested(object sender, CharSetMenuEventArgs e)
        {
            setToDelete = e.CharSet;
            listToDelete = sender as CharSetList;
            var point = e.Source.PointToScreen(e.Position);
            ctmCharSets.Show(point);
        }

        private void SpriteSetList_CharSetMenuRequested(object sender, CharSetMenuEventArgs e)
        {
            setToDelete = e.CharSet;
            listToDelete = sender as CharSetList;
            var point = e.Source.PointToScreen(e.Position);
            ctmCharSets.Show(point);
        }

        private void CharSetList_CharSetSelected(object sender, CharSetEventArgs e)
        {
            CharSetSelected(this, e);
        }

        public void AddUpdateCharSet(CharSet Set)
        {
            if (Set.SetType == Enums.CharSetType.Sprite)
                spriteSetList.AddOrUpdateCharSet(Set);
            else
                tileSetList.AddOrUpdateCharSet(Set);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (listToDelete != null && setToDelete != null)
            {
                listToDelete.RemoveCharSet(setToDelete);
                CharSetDeleted(this, new CharSetEventArgs { CharSet = setToDelete });
            }
        }
    }

    public class CharSetListCharSets
    {
        public CharSet[] Sprites { get; set; }
        public CharSet[] Tiles { get; set; }
    }
}
