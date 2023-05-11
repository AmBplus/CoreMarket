using System.ComponentModel.DataAnnotations;

namespace BlazorAdmin.Model
{
    public class text
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string CreationDate { get; set; }
    }
}
