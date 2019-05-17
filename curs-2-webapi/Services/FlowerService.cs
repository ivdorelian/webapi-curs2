using curs_2_webapi.Models;
using curs_2_webapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Services
{
    public interface IFlowerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerable<FlowerGetModel> GetAll(DateTime? from=null, DateTime? to=null);
        Flower GetById(int id);
        Flower Create(FlowerPostModel flower);
        Flower Upsert(int id, Flower flower);
        Flower Delete(int id);
    }
    public class FlowerService : IFlowerService
    {
        private FlowersDbContext context;
        public FlowerService(FlowersDbContext context)
        {
            this.context = context;
        }

        public Flower Create(FlowerPostModel flower)
        {
            Flower toAdd = FlowerPostModel.ToFlower(flower);
            context.Flowers.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Flower Delete(int id)
        {
            var existing = context.Flowers
                .Include(f => f.Comments)
                .FirstOrDefault(flower => flower.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Flowers.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public IEnumerable<FlowerGetModel> GetAll(DateTime? from=null, DateTime? to=null)
        {
            IQueryable<Flower> result = context
                .Flowers
                .Include(f => f.Comments);
            if (from == null && to == null)
            {
                return result.Select(f => FlowerGetModel.FromFlower(f));
            }
            if (from != null)
            {
                result = result.Where(f => f.DatePicked >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DatePicked <= to);
            }
            return result.Select(f => FlowerGetModel.FromFlower(f));
        }

        public Flower GetById(int id)
        {
            // sau context.Flowers.Find()
            return context.Flowers
                .Include(f => f.Comments)
                .FirstOrDefault(f => f.Id == id);
        }

        public Flower Upsert(int id, Flower flower)
        {
            var existing = context.Flowers.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Flowers.Add(flower);
                context.SaveChanges();
                return flower;
            }
            flower.Id = id;
            context.Flowers.Update(flower);
            context.SaveChanges();
            return flower;
        }
    }
}
