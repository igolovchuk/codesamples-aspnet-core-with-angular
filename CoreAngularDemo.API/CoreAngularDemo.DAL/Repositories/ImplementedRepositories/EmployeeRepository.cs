﻿using System;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CoreAngularDemoDBContext context)
               : base(context)
        {
        }

        public override Expression<Func<Employee, bool>> MakeFilteringExpression(string keyword)
        {
            Expression<Func<Employee, bool>> expression =
                entity =>
                       EF.Functions.Like(entity.Post.Name, '%' + keyword + '%')
                    || entity.FirstName != null && entity.FirstName != string.Empty &&
                           EF.Functions.Like(entity.FirstName, '%' + keyword + '%')
                    || entity.MiddleName != null && entity.MiddleName != string.Empty &&
                           EF.Functions.Like(entity.MiddleName, '%' + keyword + '%')
                    || entity.LastName != null && entity.LastName != string.Empty &&
                           EF.Functions.Like(entity.LastName, '%' + keyword + '%')
                    || EF.Functions.Like(entity.ShortName, '%' + keyword + '%');

            if (int.TryParse(keyword, out int parsedInteger))
            {
                Expression<Func<Employee, bool>> integerExpression =
                    entity => entity.BoardNumber == parsedInteger;

                expression = PredicateBuilder.New<Employee>().And(expression).And(integerExpression);
            }

            return expression;
        }

        protected override IQueryable<Employee> ComplexEntities => Entities
            .Include(e => e.Post)
            .Include(e => e.Create)
            .Include(e => e.Mod)
            .Include(e => e.AttachedUser)
            .OrderByDescending(u => u.UpdatedDate)
            .ThenByDescending(x => x.CreatedDate);
    }
}
