using System;
using curs_2_webapi.Models;

namespace curs_2_webapi.ViewModels
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public int? FlowerId { get; set; }

        public static CommentGetModel FromComment(Comment c)
        {
            return new CommentGetModel
            {
                Id = c.Id,
                FlowerId = c.Flower?.Id,
                Important = c.Important,
                Text = c.Text
            };
        }
    }
}