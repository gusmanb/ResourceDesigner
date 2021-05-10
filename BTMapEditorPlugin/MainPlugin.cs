using BTMapEditorPlugin.Classes;
using Newtonsoft.Json;
using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using ResourceDesigner.PluginSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTMapEditorPlugin
{
    public class MainPlugin : PluginBase
    {
        MainForm pluginForm;

        IEnumerable<BTMap> maps;

        public override event EventHandler<PluginNewWindowEventArgs> OpenNewWindow;
        public override event EventHandler<PluginRequestCharSetEventArgs> RequestCharSet;
        public override event EventHandler<PluginCharSetEventArgs> AddUpdateCharSet;
        public override event EventHandler<PluginCharSetEventArgs> DeleteCharSet;
        public override event EventHandler<PluginCharSetIdEventArgs> RequestCharSetIndex;

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
        public override void AddOrUpdateCharser(CharSet Set)
        {
            base.AddOrUpdateCharser(Set);
        }
        public override void DeleteCharset(CharSet Set)
        {
            base.DeleteCharset(Set);
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
                    pluginForm.Maps = maps;
                    pluginForm.FormClosed += PluginForm_FormClosed;
                    OpenNewWindow(this, new PluginNewWindowEventArgs { NewWindow = pluginForm });
                }
            }
        }
        public override void ProjectLoad(PluginData StoredConfig, CharSet[] Sprites, CharSet[] Tiles)
        {
            if (StoredConfig == null)
                return;

            string data = Encoding.UTF8.GetString(StoredConfig.SerializedData);
            maps = JsonConvert.DeserializeObject<IEnumerable<BTMap>>(data);

            if (pluginForm != null)
                pluginForm.Maps = maps;
        }
        public override PluginData GetDataToStore()
        {

            if (pluginForm != null)
                maps = pluginForm.Maps;

            PluginData cfg = new PluginData { OwnerPlugin = PluginId, SerializedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(maps)) };
            return cfg;
        }
        private void PluginForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            pluginForm.Visible = false;
            pluginForm.MdiParent = null;
            pluginForm.Dispose();
            maps = pluginForm.Maps;
            pluginForm = null;
        }
        internal CharSet[] PluginRequestCharSet(Guid? Id, string SetName, CharSetType? SetType)
        {
            if (RequestCharSet != null)
            {
                PluginRequestCharSetEventArgs e = new PluginRequestCharSetEventArgs { Id = Id, Name = SetName, SetType = SetType };
                RequestCharSet(this, e);
                return e.FoundCharSets;
            }

            return null;
        }

        internal int PluginRequestCharSetIndex(Guid CharSetId)
        {
            if (RequestCharSetIndex != null)
            {
                PluginCharSetIdEventArgs args = new PluginCharSetIdEventArgs { Id = CharSetId };
                RequestCharSetIndex(this, args);
                return args.Index;
            }

            return -1;
        }
    }
}
