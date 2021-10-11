using GeneralKnowledge.Test.App.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            var imgUrl = "https://sitecorecdn.azureedge.net/-/media/sitecoresite/images/home/company/brand-resource-page/brand-resource-hero.jpg?mw=800&hash=90E597B9B53B728731BF93375BBCE8B6&t=1008x952";
            var width = 100;
            var height = 80;
            using (var wc = new WebClient())
            {
                using (var imgStream = new MemoryStream(wc.DownloadData(imgUrl)))
                {
                    using (var srcImage = Image.FromStream(imgStream))
                    {
                        using (var result = (Bitmap)Resizer.ResizeImageKeepAspectRatio(srcImage, width, height))
                        {
                            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resized_img.jpg");
                            result.Save(destPath);
                        }
                    }
                }
            }
        }
    }
}
