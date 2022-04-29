using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows;

namespace ImageConverter.Viewer
{
    /// <summary>
    /// Interação lógica para SingleControl.xam
    /// </summary>
    public partial class SingleControl : UserControl
    {
        public SingleControl()
        {
            InitializeComponent();
        }

        private void Border_ButtonSelect_Enter(object sender, MouseEventArgs e)
        {
            ButtonText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(240, 241, 250));
        }

        private void Border_ButtonSelect_Leave(object sender, MouseEventArgs e)
        {
            ButtonText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(37, 35, 45));
        }

        private void Border_ButtonSelect_Click (object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new();
                openFileDialog1.Multiselect = false;
                openFileDialog1.Filter = "Bmp image(*.bmp)|*.bmp|" + "Jpg image(*.jpg)|*.jpg|"
                    + "Png image(*.png)|*.png|" + "Gif image(*.gif)|*.gif|" + "Emf image(*.emf)|*.emf|"
                    + "Exif image(*.exif)|*.exif|" + "Icon image(*.ico)|*.ico|" +
                    "Wmf image(*.wmf)|*.wmf|" + "Tiff image(*.tiff)|*.tiff|" + "Todos os Arqs.(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == true)
                {
                    ImagePatch.Content = openFileDialog1.FileNames[0];
                }
            } catch (Exception err)
            {
                ImagePatch.Content = err.Message;
            }
        }

        private void Border_ButtonConvert_Enter(object sender, MouseEventArgs e)
        {
            ButtonConvertText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(240, 241, 250));
        }

        private void Border_ButtonConvert_Leave(object sender, MouseEventArgs e)
        {
            ButtonConvertText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(37, 35, 45));
        }

        private void Border_ButtonConvert_Click(object sender, MouseButtonEventArgs e)
        {
            string imagePatch = ImagePatch.Content.ToString();
            if (imagePatch != "Image Patch")
            {
                if(ComboBox_Image_Type.SelectedItem != null)
                {
                    string selectedType = ComboBox_Image_Type.Text;
                    string patch = System.IO.Path.GetFullPath(imagePatch).Split(".")[0];
                    System.Drawing.Image img = System.Drawing.Image.FromFile(imagePatch);
                    switch (selectedType)
                    {
                        case "Bmp":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "Emf":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.emf", System.Drawing.Imaging.ImageFormat.Emf);
                            break;
                        case "Exif":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.exif", System.Drawing.Imaging.ImageFormat.Exif);
                            break;
                        case "Gif":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.gif", System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "Icon":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.ico", System.Drawing.Imaging.ImageFormat.Icon);
                            break;
                        case "Jpeg":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "Png":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.png", System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case "Tiff":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.tiff", System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "Wmf":
                            MessageBox.Show("Image Saved");
                            img.Save(@$"{patch}.wmf", System.Drawing.Imaging.ImageFormat.Wmf);
                            break;
                        default:
                            MessageBox.Show("Erro");
                            break;
                    }
                }
            }
        }

    }
}
