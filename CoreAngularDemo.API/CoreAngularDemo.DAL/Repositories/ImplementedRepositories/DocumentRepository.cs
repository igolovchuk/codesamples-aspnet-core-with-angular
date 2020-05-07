﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(CoreAngularDemoDBContext context)
            : base(context)
        {
        }

        protected override IQueryable<Document> ComplexEntities => Entities
            .Include(t => t.Create)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.Issue.State)
            .Include(x => x.IssueLog)
            .ThenInclude(x => x.Issue.Vehicle)
            .ThenInclude(x => x.VehicleType)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.Supplier)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.ActionType)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.Issue.Malfunction)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.NewState)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.OldState)
            .Include(z => z.IssueLog)
            .ThenInclude(x => x.Issue.AssignedTo)
            .Include(a => a.Mod)
            .OrderByDescending(u => u.UpdatedDate)
            .ThenByDescending(x => x.CreatedDate);

        public override Expression<Func<Document, bool>> MakeFilteringExpression(string keyword)
        {
            return entity => entity.Name != null &&
                             entity.Name != string.Empty &&
                             EF.Functions.Like(entity.Name, '%' + keyword + '%') ||
                             entity.Description != null &&
                             entity.Description != string.Empty &&
                             EF.Functions.Like(entity.Description, '%' + keyword + '%');
        }
    }
}
