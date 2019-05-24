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
        PaginatedList<FlowerGetModel> GetAll(int page, DateTime? from=null, DateTime? to=null);
        Flower GetById(int id);
        Flower Create(FlowerPostModel flower, User addedBy);
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

        public Flower Create(FlowerPostModel flower, User addedBy)
        {
            // TODO: how to store the user that added the flower as a field in Flower?
            Flower toAdd = FlowerPostModel.ToFlower(flower);
            toAdd.Owner = addedBy;
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

        public PaginatedList<FlowerGetModel> GetAll(int page, DateTime? from=null, DateTime? to=null)
        {
            IQueryable<Flower> result = context
                .Flowers
                .OrderBy(f => f.Id)
                .Include(f => f.Comments);
            PaginatedList<FlowerGetModel> paginatedResult = new PaginatedList<FlowerGetModel>();
            paginatedResult.CurrentPage = page;

            if (from != null)
            {
                result = result.Where(f => f.DatePicked >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DatePicked <= to);
            }
            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<FlowerGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<FlowerGetModel>.EntriesPerPage)
                .Take(PaginatedList<FlowerGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(f => FlowerGetModel.FromFlower(f)).ToList();

            return paginatedResult;
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
