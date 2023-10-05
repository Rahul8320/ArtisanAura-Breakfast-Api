using System.ComponentModel.DataAnnotations;

namespace ArtisanAura.Api.Models
{
    public class Breakfast
    {
        [Required]
        public Guid Id { get; }
        [Required]
        [MinLength(3)]
        public string Name { get; }
        [Required]
        [MinLength(10)]
        public string Description { get; }
        [Required]
        public DateTime StartDateTime { get; }
        [Required]
        public DateTime EndDateTime { get; }
        [Required]
        public DateTime LastModifiedDateTime { get; }
        public List<string> Savory { get; }
        public List<string> Sweet { get; }

        public Breakfast(
            Guid id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime,
            List<string> savory,
            List<string> sweet)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.LastModifiedDateTime = lastModifiedDateTime;
            this.Savory = savory;
            this.Sweet = sweet;
        }
    }
}