using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11_Delegate_Event
{
    public class Image
    {
        public Image()
        {
            Console.WriteLine("An image created");
        }
    }

    public class ImageProcessor
    {
        // Dinh nghia mot uy quyen, co the dong goi bat cu phuong thuc 
        // khong co gia tri tra ve va cung khong nhan bat cu tham so nao het
        public delegate void DoEffect();

        // tao cac uy quyen tinh
        public DoEffect BlurEffect = new DoEffect(Blur);
        public DoEffect SharpenEffect = new DoEffect(Sharpen);
        public DoEffect FilterEffect = new DoEffect(Filter);
        public DoEffect RotateEffect = new DoEffect(Rotate);

        // khai bao bien
        DoEffect[] arrayOfEffects;
        Image image;
        int numEffectsRegistered = 0;

        public ImageProcessor(Image image)
        {
            this.image = image;
            arrayOfEffects = new DoEffect[10];
        }

        // Phuong thuc them cac uy quyen vao mang (them hieu ung vao mang)
        public void AddToEffects(DoEffect theEffect)
        {
            if (numEffectsRegistered >= 10)
            {
                throw new Exception("Too many members in array");
            }
            arrayOfEffects[numEffectsRegistered++] = theEffect;
        }

        // Phuong thuc thuc su goi cac uy quyen 
        public void ProcessImage()
        {
            for (int i = 0; i < numEffectsRegistered; i++)
            {
                arrayOfEffects[i]();
            }
        }

        // cac phuong thuc xu li anh
        // Phuong thuc lam mo anh
        public static void Blur()
        {
            Console.WriteLine("Blurring image");
        }
        
        // Phuong thuc loc anh
        public static void Filter()
        {
            Console.WriteLine("Filtering image");
        }

        // Phuong thuc lam dam anh
        public static void Sharpen()
        {
            Console.WriteLine("Sharpening image");
        }

        // Phuong thuc quay anh
        public static void Rotate()
        {
            Console.WriteLine("Rotating image");
        }
    }

    public class SerialDelegate
    {
        public static void Main()
        {
            Image theImage = new Image();
            // Do khong co GUI de thuc hien
            // Chung ta se chon lan luot cac hanh dong va thuc hien
            ImageProcessor theProc = new ImageProcessor(theImage);
            theProc.AddToEffects(theProc.FilterEffect);
            theProc.AddToEffects(theProc.RotateEffect);
            theProc.AddToEffects(theProc.BlurEffect);            
            theProc.AddToEffects(theProc.SharpenEffect);
            theProc.ProcessImage();

            Console.ReadLine();
        }
    }
}
