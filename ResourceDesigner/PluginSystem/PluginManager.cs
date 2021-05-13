using ResourceDesigner.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.PluginSystem
{
    public static class PluginManager
    {
        public static event EventHandler<PluginNewWindowEventArgs> PluginOpenNewWindow;
        public static event EventHandler<PluginRequestCharSetEventArgs> PluginRequestCharSet;
        public static event EventHandler<PluginCharSetEventArgs> PluginAddUpdateCharSet;
        public static event EventHandler<PluginCharSetEventArgs> PluginDeleteCharSet;
        public static event EventHandler<PluginCharSetIdEventArgs> PluginRequestCharSetIndex;
        public static event EventHandler<PluginEditorEventArgs> PluginOpenEditorWindow;

        static List<PluginBase> loadedPlugins = new List<PluginBase>();
        static List<ToolStripItem> pluginItems = new List<ToolStripItem>();
        static MainForm mainWindow;

        public static void LoadPlugins(MainForm MainWindow, ToolStrip MainToolbar)
        {
            string pluginPath = Path.Combine(Application.StartupPath, "Plugins");

            if (!Directory.Exists(pluginPath))
                return;

            var libraries = Directory.GetFiles(pluginPath, "*.dll");

            foreach (var lib in libraries)
            {
                var asm = Assembly.LoadFrom(lib);
                
                var pluginTypes = asm.GetTypes().Where(tp => tp.IsAssignableTo(typeof(PluginBase)));

                foreach (var type in pluginTypes)
                {
                    var pluginInstance = Activator.CreateInstance(type) as PluginBase;
                    loadedPlugins.Add(pluginInstance);
                    if (pluginInstance.MenuItems != null && pluginInstance.MenuItems.Length > 0)
                    {
                        MainToolbar.Items.Add(new ToolStripSeparator());

                        foreach (var item in pluginInstance.MenuItems)
                        {
                            switch (item.ItemType)
                            {
                                case PluginMenuItemType.Button:

                                    var btn = new ToolStripButton();
                                    btn.ToolTipText = item.Tooltip;
                                    btn.Image = item.Image;
                                    btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
                                    btn.Text = item.Tooltip;
                                    btn.Tag = new MenuItemIdentifier { PluginId = pluginInstance.PluginId, ItemId = item.Id };
                                    btn.Enabled = false;
                                    btn.Click += PluginElement_Click;

                                    MainToolbar.Items.Add(btn);
                                    pluginItems.Add(btn);

                                    break;

                                case PluginMenuItemType.Dropdown:

                                    var dd = new ToolStripDropDownButton();
                                    dd.ToolTipText = item.Tooltip;
                                    dd.Image = item.Image;
                                    dd.Text = item.Tooltip;
                                    dd.DisplayStyle = ToolStripItemDisplayStyle.Image;
                                    dd.Tag = new MenuItemIdentifier { PluginId = pluginInstance.PluginId, ItemId = item.Id };
                                    dd.Enabled = false;
                                    dd.Click += PluginElement_Click;

                                    if (item.DropdownItems != null)
                                    {
                                        foreach (var drop in item.DropdownItems)
                                        {
                                            var ddd = new ToolStripMenuItem();
                                            ddd.Text = drop.Text;
                                            ddd.Image = drop.Image;
                                            ddd.Tag = new MenuItemIdentifier { PluginId = pluginInstance.PluginId, ItemId = drop.Id };
                                            ddd.Click += PluginElement_Click;
                                            dd.DropDownItems.Add(ddd);
                                        }
                                    }

                                    MainToolbar.Items.Add(dd);
                                    pluginItems.Add(dd);

                                    break;
                            }
                        }
                    }

                    pluginInstance.OpenNewWindow += PluginInstance_OpenNewWindow;
                    pluginInstance.RequestCharSet += PluginInstance_RequestCharSet;
                    pluginInstance.AddUpdateCharSet += PluginInstance_AddUpdateCharSet;
                    pluginInstance.DeleteCharSet += PluginInstance_DeleteCharSet;
                    pluginInstance.RequestCharSetIndex += PluginInstance_RequestCharSetIndex;
                    pluginInstance.OpenEditorWindow += PluginInstance_OpenEditorWindow;
                    pluginInstance.Initialize();
                }
            }
        }

        private static void PluginInstance_OpenEditorWindow(object sender, PluginEditorEventArgs e)
        {
            if (PluginOpenEditorWindow != null)
                PluginOpenEditorWindow(sender, e);
        }

        private static void PluginInstance_RequestCharSetIndex(object sender, PluginCharSetIdEventArgs e)
        {
            if (PluginRequestCharSetIndex != null)
                PluginRequestCharSetIndex(sender, e);
        }

        private static void PluginInstance_DeleteCharSet(object sender, PluginCharSetEventArgs e)
        {
            if (PluginDeleteCharSet != null)
                PluginDeleteCharSet(sender, e);
        }

        private static void PluginInstance_AddUpdateCharSet(object sender, PluginCharSetEventArgs e)
        {
            if (PluginAddUpdateCharSet != null)
                PluginAddUpdateCharSet(sender, e);
        }

        private static void PluginInstance_RequestCharSet(object sender, PluginRequestCharSetEventArgs e)
        {
            if (PluginRequestCharSet != null)
                PluginRequestCharSet(sender, e);
        }
        private static void PluginInstance_OpenNewWindow(object sender, PluginNewWindowEventArgs e)
        {
            if (PluginOpenNewWindow != null)
                PluginOpenNewWindow(sender, e);
        }
        public static PluginData[] GetPluginsData()
        {
            List<PluginData> datas = new List<PluginData>();

            foreach (var plugin in loadedPlugins)
            {
                var data = plugin.GetDataToStore();

                if (data != null)
                    datas.Add(data);
            }

            return datas.ToArray();
        }
        public static void EnablePluginItems()
        {
            foreach (var item in pluginItems)
                item.Enabled = true;
        }
        public static void DisablePluginItems()
        {
            foreach (var item in pluginItems)
                item.Enabled = false;
        }
        public static void Terminate() 
        {
            foreach (var plugin in loadedPlugins)
                plugin.Terminate();
        }
        public static void NewProject() 
        {
            foreach (var plugin in loadedPlugins)
                plugin.NewProject();
        }
        public static void ProjectLoad(PluginData[] StoredConfigs, CharSet[] Sprites, CharSet[] Tiles) 
        {
            foreach (var plugin in loadedPlugins)
                plugin.ProjectLoad(StoredConfigs?.Where(c => c.OwnerPlugin == plugin.PluginId).FirstOrDefault(), Sprites, Tiles);
        }
        public static void ProjectUnload() 
        {
            foreach (var plugin in loadedPlugins)
                plugin.ProjectUnload();
        }
        public static void AddOrUpdateCharset(CharSet Set) 
        {
            foreach (var plugin in loadedPlugins)
                plugin.AddOrUpdateCharser(Set);
        }
        public static void DeleteCharSet(CharSet Set) 
        {
            foreach (var plugin in loadedPlugins)
                plugin.DeleteCharset(Set);
        }
        private static void PluginElement_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            var ids = item.Tag as MenuItemIdentifier;

            if (ids != null)
            {
                var plugin = loadedPlugins.Where(p => p.PluginId == ids.PluginId).FirstOrDefault();

                if (plugin != null)
                    plugin.ElementClicked(ids.ItemId);
            }
        }
       
        class MenuItemIdentifier 
        {
            public Guid PluginId { get; set; }
            public Guid ItemId { get; set; }
        }
    }
}
