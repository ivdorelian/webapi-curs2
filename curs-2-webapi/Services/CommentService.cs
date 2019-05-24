﻿using curs_2_webapi.Models;
using curs_2_webapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Services
{
    public interface ICommentService
    {
        PaginatedList<CommentGetModel> GetAll(int page, string filterString);
    }
    public class CommentService : ICommentService
    {
        private FlowersDbContext context;
        public CommentService(FlowersDbContext context)
        {
            this.context = context;
        }

        public PaginatedList<CommentGetModel> GetAll(int page, string filterString)
        {
            IQueryable<Comment> result = context
                .Comments
                .Where(c => string.IsNullOrEmpty(filterString) || c.Text.Contains(filterString))
                .OrderBy(c => c.Id)
                .Include(c => c.Flower);
            var paginatedResult = new PaginatedList<CommentGetModel>();
            paginatedResult.CurrentPage = page;
            
            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<CommentGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<CommentGetModel>.EntriesPerPage)
                .Take(PaginatedList<CommentGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(c => CommentGetModel.FromComment(c)).ToList();

            return paginatedResult;
        }

    }
}
