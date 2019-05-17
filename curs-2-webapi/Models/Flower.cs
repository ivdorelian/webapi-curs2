using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Models
{
    public enum FlowerSize
    {
        Small,
        Medium,
        Large
    }
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colors { get; set; }
        [Range(1, 10)]
        public int SmellLevel { get; set; }
        public bool IsArtificial { get; set; }
        public DateTime DatePicked { get; set; }
        [EnumDataType(typeof(FlowerSize))]
        public FlowerSize FlowerSize { get; set; }
        public List<Comment> Comments { get; set; }
        // public User AddedBy { get; set; }
    }
}
