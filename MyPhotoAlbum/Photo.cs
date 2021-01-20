namespace MyPhotoAlbum
{
    public class Photo
    {
        public string Description { get; set; }
        
        public string Name { get; set; }

        public Photo(string size, string name)
        {
            Description = size;
            Name = name;
        }

        public Photo()
        {
            Description = "";
            Name = "";
        }

    }
}