using System.Collections.Generic;
using System.Linq;

namespace MyPhotoAlbum
{
    public class PhotoAlbum
    {
        public List<Page> Pages { get; set; }
        
        public string Name { get; set; }

        public PhotoAlbum(List<Page> pages, string name)
        {
            Pages = pages;
            Name = name;
        }
        
        public PhotoAlbum(int pages, string name)
        {
            Pages = new List<Page>();
            
            for (var i = 0; i < pages; i++)
            {
                Pages.Add(new Page());
            }
            Name = name;
        }
        
        public void SetPhotoName(int numberOfPage, int numberOfPhoto, string newNameOfPhoto)
        {
            Pages[numberOfPage].PhotosOnPage[numberOfPhoto].Name = newNameOfPhoto;
        }
        
        public void AddNewPhoto(int numberOfPage, Photo newPhoto)
        {
            Pages[numberOfPage].PhotosOnPage.Add(newPhoto);
        }

        public int GetNumberOfPhoto()
        {
            return Pages.Sum(page => page.PhotosOnPage.Count);
        }
    }
}