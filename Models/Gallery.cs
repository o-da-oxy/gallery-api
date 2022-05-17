using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GalleryApi.Models
{
    public class Gallery
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int MaxPicturesCount { get; set; }
        [JsonIgnore]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}