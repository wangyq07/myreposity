
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BiTools
{
   public class StaticHelper
    {
        public static byte[] ConvertTiff2Jpeg(string tiffFileName,ref string extendname)
        {
            MemoryStream ms = new MemoryStream();
            byte[] bb = null;
            try
            { 
            Bitmap b = new Bitmap(tiffFileName);
            
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
             return ms.GetBuffer();
            }
            catch(Exception ex)
            {
                extendname = ex.Message;
            }
            finally
            {
                ms.Close();
            }

            return bb;
            //Bitmap bmp = null;
            //int[] raster = null;
            //if (extendname.Equals(".tif"))
            //{ 
            //    Tiff tif = Tiff.Open(tiffFileName, "r");
            //    if (tif == null)
            //    {
            //        return null;
            //    }
            //    // Find the width and height of the image
            //    FieldValue[] value = tif.GetField(TiffTag.IMAGEWIDTH);
            //    int width = value[0].ToInt();

            //    value = tif.GetField(TiffTag.IMAGELENGTH);
            //    int height = value[0].ToInt();

            //    // Read the image into the memory buffer
            //    raster = new int[height * width];

            //    if (!tif.ReadRGBAImage(width, height, raster))
            //    {
            //        tif.Close();
            //        tif.Dispose();
            //        return null;
            //    }
            //    tif.Close();
            //    tif.Dispose();
            //    // bitmap作成
            //    bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            //}
            //else
            //{
            //    bmp = Bitmap.FromFile(tiffFileName) as Bitmap;
            //    raster = new int[bmp.Height * bmp.Width];
            //}

            //    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //    BitmapData bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //    byte[] bits = new byte[bmpdata.Stride * bmpdata.Height];

            //    for (int y = 0; y < bmp.Height; y++)
            //    {
            //        int rasterOffset = y * bmp.Width;
            //        int bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;

            //        for (int x = 0; x < bmp.Width; x++)
            //        {
            //            int rgba = raster[rasterOffset++];
            //            bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
            //            bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
            //            bits[bitsOffset++] = (byte)(rgba & 0xff);
            //        }
            //    }

            //    bmp.UnlockBits(bmpdata);
            //    return bits;
        }
        public static Bitmap ConvertTiff2Jpeg(byte[] data)
        {
            Bitmap bmp = null;
            int[] raster = new int[data.Length]; 

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] bits = new byte[bmpdata.Stride * bmpdata.Height];

            for (int y = 0; y < bmp.Height; y++)
            {
                int rasterOffset = y * bmp.Width;
                int bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;

                for (int x = 0; x < bmp.Width; x++)
                {
                    int rgba = raster[rasterOffset++];
                    bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                    bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                    bits[bitsOffset++] = (byte)(rgba & 0xff);
                }
            }

            bmp.UnlockBits(bmpdata);
            return bmp;
        }

    }
    }

