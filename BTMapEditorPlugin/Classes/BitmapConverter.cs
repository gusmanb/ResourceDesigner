using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTMapEditorPlugin.Classes
{
    public class BitmapConverter : JsonConverter
    {
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Bitmap);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(Bitmap))
                return null;

            if (reader.Value == null)
                return null;

            var data = reader.Value as string;

            if (data == null)
                return null;

            MemoryStream ms = new MemoryStream(Convert.FromBase64String(data));
            Bitmap bmp = Image.FromStream(ms) as Bitmap;
            return bmp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bmp = value as Bitmap;
            if (bmp == null)
                return;
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] data = ms.ToArray();
            writer.WriteValue(Convert.ToBase64String(data));
        }
    }
}
