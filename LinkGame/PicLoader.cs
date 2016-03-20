using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace LinkGame
{
    class PicLoader
    {
        static public Image Read(String dir,String path) {
            Bitmap bmp;
            try
            {
                Assembly myAssembly = Assembly.LoadFrom("PicResource.dll");
                Stream myStream = myAssembly.GetManifestResourceStream(String.Format("PicResource.{0}.{1}", dir, path));
                bmp = new Bitmap(myStream);
            }
            catch {
                bmp = null;
            }
            return bmp;
        }
    }
}
