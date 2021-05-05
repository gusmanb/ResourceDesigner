using System;
using System.Text;
using System.Windows.Forms;
using ResourceDesigner.Classes;
using ResourceDesigner.PluginSystem;

namespace PluginTest
{
    public class DemoPlugin : PluginBase
    {
        public override event EventHandler<PluginNewWindowEventArgs> OpenNewWindow;
        public override event EventHandler<PluginRequestCharSetEventArgs> RequestCharSet;
        public override event EventHandler<PluginCharSetEventArgs> AddUpdateCharSet;
        public override event EventHandler<PluginCharSetEventArgs> DeleteCharSet;

        Form openFrm;

        public override Guid PluginId
        {
            get
            {
                return Guid.Parse("cdddcdf9-9680-45b6-ada2-b2a47d96956f");
            }
        }
        public override string PluginName
        {
            get
            {
                return "Demo plugin";
            }
        }
        public override PluginMenuItem[] MenuItems
        {
            get
            {
                return new PluginMenuItem[]
                {
                    new PluginMenuItem
                    {
                        Id = Guid.Parse("cdddcdf9-9681-45b6-ada2-b2a47d96956f"),
                        ItemType = PluginMenuItemType.Button,
                        Tooltip = "Plugin button",
                        Image = PluginResources.AbsVMirror
                    },
                    new PluginMenuItem
                    {
                        Id = Guid.Parse("cdddcdf9-9682-45b6-ada2-b2a47d96956f"),
                        ItemType = PluginMenuItemType.Dropdown,
                        Tooltip = "Plugin dropdown",
                        Image = PluginResources.AbsHMirror,
                        DropdownItems = new PluginDropdownItem[]
                        {
                            new PluginDropdownItem
                            {
                                Id = Guid.Parse("cdddcdf9-9683-45b6-ada2-b2a47d96956f"),
                                Image = PluginResources.FuchsiaColor,
                                Text = "Plugin menu item with mage"
                            },
                            new PluginDropdownItem
                            {
                                Id = Guid.Parse("cdddcdf9-9684-45b6-ada2-b2a47d96956f"),
                                Text = "Plugin menu item without image"
                            }
                        }
                    }
                };
            }
        }

        public override void Initialize() 
        {
            MessageBox.Show("Init plugin");
        }
        public override void Terminate() 
        {
            MessageBox.Show("Terminate plugin plugin");
        }
        public override void NewProject() 
        {
            MessageBox.Show("Plugin informed of new project");
        }
        public override void ProjectLoad(PluginData StoredConfig, CharSet[] Sprites, CharSet[] Tiles) 
        {
            MessageBox.Show("Plugin informed of project load");

            if (StoredConfig != null)
            {
                var cfg = StoredConfig as PluginData;
                MessageBox.Show($"Received config: {Encoding.ASCII.GetString(cfg.SerializedData)}");
            }
        }
        public override void ProjectUnload() 
        {
            MessageBox.Show("Plugin informed of project unload");
        }
        public override PluginData GetDataToStore() 
        {
            MessageBox.Show("Requested plugin data");
            return new PluginData { OwnerPlugin = PluginId, SerializedData = Encoding.ASCII.GetBytes("Hello!") };
        }
        public override void ElementClicked(Guid ElementId) 
        {
            MessageBox.Show($"Received click of item {ElementId}");

            if (ElementId == Guid.Parse("cdddcdf9-9681-45b6-ada2-b2a47d96956f"))
            {
                if (openFrm != null)
                    openFrm.BringToFront();
                else
                {
                    openFrm = new Form();
                    OpenNewWindow(this, new PluginNewWindowEventArgs { NewWindow = openFrm });
                }
            }

        }
        public override void AddOrUpdateCharser(CharSet Set) 
        {
            MessageBox.Show("Added or updated charset");
        }
        public override void DeleteCharset(CharSet Set) 
        {
            MessageBox.Show("Deleted charset");
        }
    }
}
