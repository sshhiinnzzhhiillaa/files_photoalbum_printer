using System.Collections.Generic;

namespace MyPhotoAlbum
{
    public class Page
    {
        public List<Photo> PhotosOnPage { get; set; }
        
        public string Description { get; set; }
        public Page()
        {
            PhotosOnPage = new List<Photo> {new Photo(), new Photo()};
        }

        public Page(List<Photo> photosOnPage, string description)
        {
            PhotosOnPage = photosOnPage;
            Description = description;
        }

        
    }
}