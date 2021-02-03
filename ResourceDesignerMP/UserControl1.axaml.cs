using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace ResourceDesignerMP
{
    public class UserControl1 : UserControl
    {
        public const int PixelSize = 16;
        WriteableBitmap wbmp;
        public UserControl1()
        {
            InitializeComponent();
            this.MinWidth = PixelSize * 8;
            this.MaxWidth = PixelSize * 8;
            this.MinHeight = PixelSize * 8;
            this.MaxHeight = PixelSize * 8;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
        }
    }
}
