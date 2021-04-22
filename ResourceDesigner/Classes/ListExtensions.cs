using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Classes
{
    public static class ListExtensions
    {
        public static void MoveUp<T>(this List<T> list, T item)
        {
            if (item != null)
            {
                var oldIndex = list.IndexOf(item);

                int newIndex = oldIndex - 1;

                if (newIndex > -1)
                {
                    list.RemoveAt(oldIndex);
                    list.Insert(newIndex, item);
                }
            }

        }

        public static void MoveDown<T>(this List<T> list, T item)
        {
            if (item != null)
            {
                var oldIndex = list.IndexOf(item);

                int newIndex = oldIndex + 1;

                if (newIndex < list.Count)
                {
                    list.RemoveAt(oldIndex);
                    list.Insert(newIndex, item);
                }
            }

        }
    }
}
