using System;
using MyPhotoAlbum;

    /*Создать объект класса Фотоальбом, используя классы Фотография, Страница.
    Методы: задать название фотографии, дополнить фотоальбом фотографией,
    вывести количество фотографий.*/


namespace ConsoleApp3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var photoAlbum = new PhotoAlbum(10, "My photo album");
            
            photoAlbum.SetPhotoName(2,1, "My photo");
            
            photoAlbum.AddNewPhoto(5, new Photo());

            Console.WriteLine(photoAlbum.GetNumberOfPhoto());
        }
    }
}