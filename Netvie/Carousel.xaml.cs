using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Netvie
{
    public sealed partial class Carousel : UserControl
    {
        private Storyboard animation = new Storyboard();
        private List<BitmapImage> list = new List<BitmapImage>();

        private Point point;
        private Point radius = new Point { X = -20, Y = 200 };
        private double speed = 0.0125;
        private double perspective = 55;
        private double distance;

        public Carousel()
        {
            this.InitializeComponent();
            init();
        }
        private void layout(ref Canvas display)
        {
            display.Children.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Image item = new Image();
                item.Width = 150;
                item.Source = list[i];
                item.Tag = i * ((Math.PI * 2) / list.Count);
                point.X = Math.Cos((double)item.Tag) * radius.X;
                point.Y = Math.Sin((double)item.Tag) * radius.Y;
                Canvas.SetLeft(item, point.X - (item.Width - perspective));
                Canvas.SetTop(item, point.Y);
                distance = 1 / (1 - (point.X / perspective));
                item.RenderTransform = new ScaleTransform();
                item.Opacity = ((ScaleTransform)item.RenderTransform).ScaleX = ((ScaleTransform)item.RenderTransform).ScaleY = distance;
                display.Children.Add(item);
            }
        }

        private void rotate()
        {
            foreach (Image item in Display.Children)
            {
                double angle = (double)item.Tag;
                angle -= speed;
                item.Tag = angle;
                point.X = Math.Cos(angle) * radius.X;
                point.Y = Math.Sin(angle) * radius.Y;
                Canvas.SetLeft(item, point.X - (item.Width - perspective));
                Canvas.SetTop(item, point.Y);
                if (radius.X >= 0)
                {
                    distance = 1 * (1 - (point.X / perspective));
                    Canvas.SetZIndex(item, -(int)(point.X));
                }
                else
                {
                    distance = 1 / (1 - (point.X / perspective));
                    Canvas.SetZIndex(item, (int)(point.X));
                }
                item.Opacity = ((ScaleTransform)item.RenderTransform).ScaleX = ((ScaleTransform)item.RenderTransform).ScaleY = distance;
            }
            animation.Begin();
        }

        private void init()
        {
            animation.Completed += (object sender, object e) =>
            {
                rotate();
            };
            animation.Begin();
        }

        public void Add(BitmapImage image)
        {
            list.Add(image);
            layout(ref Display);
        }
    }
}
