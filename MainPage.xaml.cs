using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpScratch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            var src = typeof(MainPage)
               .GetTypeInfo()
               .Assembly.GetManifestResourceStream("UwpScratch.src.png");

            using (var image = SixLabors.ImageSharp.Image.Load(src))
            {
                var ms = new MemoryStream();
                image.SaveAsJpeg(ms);

                
                ms.Position = 0;
                var bitMap = new BitmapImage();
                bitMap.SetSource(ms.AsRandomAccessStream());
                img.Source = bitMap;
            }
        }
    }
}
