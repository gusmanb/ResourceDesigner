using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.PluginSystem
{
    public abstract class PluginBase
    {
        public virtual event EventHandler<PluginNewWindowEventArgs> OpenNewWindow;
        public virtual event EventHandler<PluginRequestCharSetEventArgs> RequestCharSet;
        public virtual event EventHandler<PluginCharSetEventArgs> AddUpdateCharSet;
        public virtual event EventHandler<PluginCharSetEventArgs> DeleteCharSet;
        public virtual event EventHandler<PluginCharSetIdEventArgs> RequestCharSetIndex;
        public virtual event EventHandler<PluginEditorEventArgs> OpenEditorWindow;

        public abstract Guid PluginId { get; }
        public abstract string PluginName { get; }
        public abstract PluginMenuItem[] MenuItems { get; }
        public virtual void Initialize() { }
        public virtual void Terminate() { }
        public virtual void NewProject() { }
        public virtual void ProjectLoad(PluginData StoredConfig, CharSet[] Sprites, CharSet[] Tiles) { }
        public virtual void ProjectUnload() { }
        public virtual PluginData GetDataToStore() { return null; }
        public virtual void ElementClicked(Guid ElementId) { }
        public virtual void AddOrUpdateCharser(CharSet Set) { }
        public virtual void DeleteCharset(CharSet Set) { }
    }

    public class PluginNewWindowEventArgs : EventArgs
    {
        public Form NewWindow { get; set; }
    }

    public class PluginRequestCharSetEventArgs : EventArgs
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public CharSetType? SetType { get; set; }
        public CharSet[] FoundCharSets { get; set; }
    }

    public class PluginCharSetEventArgs : EventArgs
    {
        public CharSet Set { get; set; }
    }

    public class PluginCharSetIdEventArgs : EventArgs
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
    }

    public class PluginEditorEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class PluginData
    {
        public Guid OwnerPlugin { get; set; }
        public byte[] SerializedData { get; set; }
    }

    public class PluginMenuItem
    {
        public PluginMenuItemType ItemType { get; set; } 
        public Guid Id { get; set; }
        public string Tooltip { get; set; }
        public Bitmap Image { get; set; }
        public PluginDropdownItem[] DropdownItems { get; set; }
    }

    public class PluginDropdownItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Bitmap Image { get; set; }
    }

    public enum PluginMenuItemType
    {
        Button,
        Dropdown
    }
}
