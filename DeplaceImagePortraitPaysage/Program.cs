using System;
using System.Drawing;
using System.IO;

namespace TailleImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminImage = @".\";
            string cheminEntierImage = "";
            string cheminPaysage = @".\paysage\";
            string cheminPortrait = @".\portrait\";
            string nomImage;
            string cheminImageNouvelle = "";
            int nbDeplaces = 0;

            try
            {
                var jpgFiles = Directory.EnumerateFiles(cheminImage, "*.jp*");
                foreach (var file in jpgFiles)
                {
                    cheminEntierImage = file;
                    nomImage = file.Substring(cheminImage.Length);

                    Image lImage = Image.FromFile(cheminEntierImage);
                    if (lImage.Height < lImage.Width)
                        cheminImageNouvelle = cheminPaysage;
                    else
                        cheminImageNouvelle = cheminPortrait;
                    lImage.Dispose();

                    Directory.Move(file, Path.Combine(cheminImageNouvelle, nomImage));
                    nbDeplaces++;
                    Console.WriteLine(nomImage + " : traité");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nImages déplacées : "+ nbDeplaces);
            Console.ReadLine();
        }
    }
}
