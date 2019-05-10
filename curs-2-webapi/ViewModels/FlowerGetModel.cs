using curs_2_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.ViewModels
{
    public class FlowerGetModel
    {
        public string Name { get; set; }
        public string Colors { get; set; }
        public int SmellLevel { get; set; }
        public int NumberOfComments { get; set; }

        public static FlowerGetModel FromFlower(Flower flower)
        {
            return new FlowerGetModel
            {
                Colors = flower.Colors,
                Name = flower.Name,
                SmellLevel = flower.SmellLevel,
                NumberOfComments = flower.Comments.Count
            };
        }
    }
}
