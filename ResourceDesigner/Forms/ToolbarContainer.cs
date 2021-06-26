using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
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
    public partial class ToolbarContainer : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        CharSetEditor activeEditor;

        ColorComponent currentInk = ColorComponent.InkBlack;
        ColorComponent currentPaper = ColorComponent.PaperWhite;
        ColorComponent currentBright = ColorComponent.None;
        ColorComponent currentFlash = ColorComponent.None;

        public CharSetEditor ActiveEditor 
        {
            get 
            {
                return activeEditor;
            }

            set 
            {
                activeEditor = value;
                if (activeEditor != null)
                {
                    EnableToolbar();

                    if (activeEditor.CurrentTool == CharTool.Line)
                    {
                        multiToolButton.Checked = false;
                        circleToolButton.Checked = false;
                        lineToolButton.Checked = true;
                        
                    }
                    else if (activeEditor.CurrentTool == CharTool.Multiline)
                    {
                        lineToolButton.Checked = false;
                        circleToolButton.Checked = false;
                        multiToolButton.Checked = true;
                    }
                    else if (activeEditor.CurrentTool == CharTool.Circle)
                    {
                        lineToolButton.Checked = false;
                        circleToolButton.Checked = true;
                        multiToolButton.Checked = false;
                    }
                    else
                    {
                        lineToolButton.Checked = false;
                        multiToolButton.Checked = false;
                        circleToolButton.Checked = false;
                    }

                }
                else
                    DisableToolbar();
            } 
        }

        public ToolbarContainer()
        {
            InitializeComponent();
            actionToolbar.Renderer = new DisableGripHighlightRenderer();
            DisableToolbar();
            HookItems();
        }




        private void UpdateDragColorsImage()
        {
            var currentColor = currentInk | currentPaper | currentBright | currentFlash;
            var inkColor = currentColor.ToColor(ColorComponent.Ink);
            var paperColor = currentColor.ToColor(ColorComponent.Paper);

            Bitmap newBitmap = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                using (Brush inkBrush = new SolidBrush(inkColor))
                    g.FillRectangle(inkBrush, new Rectangle(0, 0, 8, 16));
                using (Brush paperBrush = new SolidBrush(paperColor))
                    g.FillRectangle(paperBrush, new Rectangle(8, 0, 8, 16));
                g.DrawRectangle(Pens.Black, 1, 1, 15, 15);
            }

            if (lblDrop.Image != null)
                lblDrop.Image.Dispose();

            lblDrop.Image = newBitmap;
        }
        private void InkMenu_Click(object sender, EventArgs e)
        {
            currentInk = Enum.Parse<ColorComponent>("Ink" + (sender as ToolStripMenuItem).Text);
            UpdateDragColorsImage();
        }
        private void PaperMenu_Click(object sender, EventArgs e)
        {
            currentPaper = Enum.Parse<ColorComponent>("Paper" + (sender as ToolStripMenuItem).Text);
            UpdateDragColorsImage();
        }

        private void brightButton_Click(object sender, EventArgs e)
        {
            if (brightButton.Checked)
                currentBright = ColorComponent.Bright;
            else
                currentBright = ColorComponent.None;

            UpdateDragColorsImage();
        }
        private void flashButton_Click(object sender, EventArgs e)
        {
            if (flashButton.Checked)
                currentFlash = ColorComponent.Flash;
            else
                currentFlash = ColorComponent.None;

            UpdateDragColorsImage();
        }

        private void lblDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataObject dob = new DataObject("ColorComponent", currentInk | currentPaper | currentBright | currentFlash);
                lblDrop.DoDragDrop(dob, DragDropEffects.Copy);
            }
        }

        void HookItems()
        {
            foreach (ToolStripItem item in actionToolbar.Items)
            {
                if (item is ToolStripButton)
                {
                    var btn = item as ToolStripButton;

                    if (btn == brightButton)
                        btn.Click += brightButton_Click;
                    else if (btn == flashButton)
                        btn.Click += flashButton_Click;
                    else
                    {

                        if (btn.CheckOnClick)
                            btn.CheckedChanged += ToolbarContainerItem_CheckedChanged;
                        else
                            btn.Click += ToolbarContainerItem_Click;

                    }
                }
                else if (item is ToolStripDropDownButton)
                {
                    var menu = item as ToolStripDropDownButton;

                    if (menu == inkButton)
                    {
                        foreach (ToolStripItem mItem in menu.DropDownItems)
                            mItem.Click += InkMenu_Click;
                    }
                    else if (menu == paperButton)
                    {
                        foreach (ToolStripItem mItem in menu.DropDownItems)
                            mItem.Click += PaperMenu_Click;
                    }
                    else
                    {
                        foreach (ToolStripItem mItem in menu.DropDownItems)
                            mItem.Click += ToolbarContainerItem_Click;
                    }
                }
            }

            lblDrop.MouseMove += lblDrop_MouseMove;
        }

        private void ToolbarContainerItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveEditor != null)
            {
                var btn = sender as ToolStripButton;

                if (btn.Checked)
                {
                    if (btn == lineToolButton)
                        multiToolButton.Checked = false;
                    else if (btn == multiToolButton)
                        lineToolButton.Checked = false;

                    activeEditor.ExecuteToolbarItem(btn.Name, ToolbarItemAction.Check);
                }
                else
                    activeEditor.ExecuteToolbarItem(btn.Name, ToolbarItemAction.Uncheck);
            }
        }

        private void ToolbarContainerItem_Click(object sender, EventArgs e)
        {
            if (activeEditor != null)
                activeEditor.ExecuteToolbarItem((sender as ToolStripItem).Name, ToolbarItemAction.Click);
        }

        void DisableToolbar()
        {
            foreach (ToolStripItem item in actionToolbar.Items)
            {
                if(item.Name != "toolbarGrip")
                    item.Enabled = false;
            }
        }

        void EnableToolbar()
        {
            foreach (ToolStripItem item in actionToolbar.Items)
            {
                if (item.Name != "toolbarGrip")
                    item.Enabled = true;
            }
        }

        private void toolbarGrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        class DisableGripHighlightRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Name == "toolbarGrip")
                    return;

                base.OnRenderButtonBackground(e);
            }
        }
    }

    public enum ToolbarItemAction
    {
        Click,
        Check,
        Uncheck
    }
}
