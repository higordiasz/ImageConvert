using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;
using System.IO;

namespace ImageConverter.Viewer
{
    /// <summary>
    /// Interação lógica para MultipleControl.xam
    /// </summary>
    public partial class MultipleControl : UserControl
    {
        public MultipleControl()
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

        private void Border_ButtonSelect_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog openFileDialog1 = new();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImagePatch.Content = openFileDialog1.SelectedPath;
                }
            }
            catch (Exception err)
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
            string folderPatch = ImagePatch.Content.ToString();
            string[] allFiles = Directory.GetFiles(folderPatch, "*.*", SearchOption.AllDirectories);
            foreach (string filePatch in allFiles)
            {
                if (filePatch.EndsWith(".bmp") || filePatch.EndsWith(".jpg") || filePatch.EndsWith(".png") || filePatch.EndsWith(".gif") || filePatch.EndsWith(".emf") || filePatch.EndsWith(".exif") || filePatch.EndsWith(".ico") || filePatch.EndsWith(".wmf") || filePatch.EndsWith(".tiff"))
                {
                    string imagePatch = filePatch;
                    if (imagePatch != "Image Patch")
                    {
                        if (ComboBox_Image_Type.SelectedItem != null)
                        {
                            string selectedType = ComboBox_Image_Type.Text;
                            string patch = System.IO.Path.GetFullPath(imagePatch).Split(".")[0] + @"Converted\";
                            if (!Directory.Exists(patch))
                                Directory.CreateDirectory(patch);
                            System.Drawing.Image img = System.Drawing.Image.FromFile(imagePatch);
                            switch (selectedType)
                            {
                                case "Bmp":
                                    img.Save(@$"{patch}.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                                    break;
                                case "Emf":
                                    img.Save(@$"{patch}.emf", System.Drawing.Imaging.ImageFormat.Emf);
                                    break;
                                case "Exif":
                                    img.Save(@$"{patch}.exif", System.Drawing.Imaging.ImageFormat.Exif);
                                    break;
                                case "Gif":
                                    img.Save(@$"{patch}.gif", System.Drawing.Imaging.ImageFormat.Gif);
                                    break;
                                case "Icon":
                                    img.Save(@$"{patch}.ico", System.Drawing.Imaging.ImageFormat.Icon);
                                    break;
                                case "Jpeg":
                                    img.Save(@$"{patch}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                    break;
                                case "Png":
                                    img.Save(@$"{patch}.png", System.Drawing.Imaging.ImageFormat.Png);
                                    break;
                                case "Tiff":
                                    img.Save(@$"{patch}.tiff", System.Drawing.Imaging.ImageFormat.Tiff);
                                    break;
                                case "Wmf":
                                    img.Save(@$"{patch}.wmf", System.Drawing.Imaging.ImageFormat.Wmf);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Done !");
        }
    }
}
