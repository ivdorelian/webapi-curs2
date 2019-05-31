using curs_2_webapi.Models;
using curs_2_webapi.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    class CommentsServiceTest
    {


        [Test]
        public void GetAllShouldReturnCorrectNumberOfPages()
        {
            var options = new DbContextOptionsBuilder<FlowersDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetAllShouldReturnCorrectNumberOfPages))
              .Options;

            using (var context = new FlowersDbContext(options))
            {

                var commentService = new CommentService(context);
                var flowerService = new FlowerService(context);
                var addedFlower = flowerService.Create(new curs_2_webapi.ViewModels.FlowerPostModel
                {
                    Colors = "fdsfsd",
                    DatePicked = new DateTime(),
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Important = true,
                            Text = "asd",
                            Owner = null
                        }
                    },
                    FlowerSize = "large",
                    Name = "fdsfds",
                    IsArtificial = false,
                    SmellLevel = 2
                }, null);

                var allComments = commentService.GetAll(1, string.Empty);
                Assert.AreEqual(1, allComments.NumberOfPages);
            }
        }
    }
}
