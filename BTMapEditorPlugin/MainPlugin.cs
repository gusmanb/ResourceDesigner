using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using ResourceDesigner.PluginSystem;
using System;

namespace BTMapEditorPlugin
{
    public class MainPlugin : PluginBase
    {
        MainForm pluginForm;

        public override event EventHandler<PluginNewWindowEventArgs> OpenNewWindow;
        public override event EventHandler<PluginRequestCharSetEventArgs> RequestCharSet;
        public override event EventHandler<PluginCharSetEventArgs> AddUpdateCharSet;
        public override event EventHandler<PluginCharSetEventArgs> DeleteCharSet;

        private PluginMenuItem[] menu = new PluginMenuItem[] 
        {
            new PluginMenuItem
            { 
                Id = Guid.Parse("79a79da6-ab25-11eb-bcbc-1242ac130002"), 
                ItemType = PluginMenuItemType.Button, 
                Image = PluginResources.BatleGrid,
                Tooltip = "BattleGrid Map Editor"
            }
        };
        public override Guid PluginId
        {
            get
            {
                return Guid.Parse("79a79da6-ab25-11eb-bcbc-0242ac130002");
            }
        }
        public override string PluginName
        {
            get
            {
                return "BattleGrid Map Editor";
            }
        }
        public override PluginMenuItem[] MenuItems
        {
            get { return menu; }
        }

        public override void ElementClicked(Guid ElementId)
        {
            if (ElementId == menu[0].Id)
            {
                if (pluginForm != null)
                    pluginForm.BringToFront();
                else
                {
                    pluginForm = new MainForm(this);
                    pluginForm.FormClosed += PluginForm_FormClosed;
                    OpenNewWindow(this, new PluginNewWindowEventArgs { NewWindow = pluginForm });
                }
            }
        }

        private void PluginForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            pluginForm.MdiParent = null;
            pluginForm.Dispose();
            pluginForm = null;
        }

        internal CharSet PluginRequestCharSet(string SetName, CharSetType SetType)
        {
            if (RequestCharSet != null)
            {
                PluginRequestCharSetEventArgs e = new PluginRequestCharSetEventArgs { Name = SetName, SetType = SetType };
                RequestCharSet(this, e);
                return e.FoundCharSet;
            }

            return null;
        }
    }
}
