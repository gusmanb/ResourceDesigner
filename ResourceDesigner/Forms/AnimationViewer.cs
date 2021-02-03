using ResourceDesigner.Classes;
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
    public partial class AnimationViewer : Form
    {
        int currentIndex = -1;

        List<CharSet> animSets = new List<CharSet>();
        List<Bitmap> animImages = new List<Bitmap>();
        public AnimationViewer()
        {
            InitializeComponent();
            ((Control)animPic).AllowDrop = true;
        }

        public void AddCharSet(CharSet NewSet)
        {
            animSets.Add(NewSet.Clone());
            animImages.Add(NewSet.GenerateImage());
        }

        public void UpdateCharSet(CharSet TheCharSet)
        {
            var index = animSets.FindIndex(o => o.Id == TheCharSet.Id);

            if (index > -1)
            {
                animSets.RemoveAt(index);
                animSets.Insert(index, TheCharSet.Clone());

                var img = animImages[index];
                var newImg = TheCharSet.GenerateImage();

                if (currentIndex == index)
                    animPic.Image = newImg;

                img.Dispose();
                animImages.RemoveAt(index);
                animImages.Insert(index, newImg);
            }
        }

        private void animTimer_Tick(object sender, EventArgs e)
        {
            if (animImages.Count == 0)
                return;

            currentIndex++;

            if (currentIndex >= animImages.Count)
                currentIndex = 0;

            animPic.Image = animImages[currentIndex];
        }

        private void animPic_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains("CHARSET_1"))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void animPic_DragDrop(object sender, DragEventArgs e)
        {
            var content = e.Data.GetData("CHARSET_1") as CharSet;
            if (content == null)
                return;

            AddCharSet(content);
        }

        private void AnimationViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            animTimer.Stop();
        }
    }
}
