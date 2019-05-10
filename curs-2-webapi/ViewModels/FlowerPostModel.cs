using curs_2_webapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.ViewModels
{
    public class FlowerPostModel
    {
        public string Name { get; set; }
        public string Colors { get; set; }
        [Range(1, 10)]
        public int SmellLevel { get; set; }
        public bool IsArtificial { get; set; }
        public DateTime DatePicked { get; set; }
        public string FlowerSize { get; set; }

        public static Flower ToFlower(FlowerPostModel flower)
        {
            FlowerSize flowerSize = Models.FlowerSize.Small;
            if (flower.FlowerSize == "Medium")
            {
                flowerSize = Models.FlowerSize.Medium;
            }
            else if (flower.FlowerSize == "Large")
            {
                flowerSize = Models.FlowerSize.Large;
            }
            return new Flower
            {
                Colors = flower.Colors,
                Name = flower.Name,
                DatePicked = flower.DatePicked,
                IsArtificial = flower.IsArtificial,
                SmellLevel = flower.SmellLevel,
                FlowerSize = flowerSize
            };
        }
    }
}
