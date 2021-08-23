using System;
using System.Collections.Generic;
using System.Linq;
using Sample.Domain.Entities;
using Sample.Domain.Context;
using Sample.Domain.Entities.Interfaces;
using Sample.Repository.Base;
using Sample.Hypermedia.Utils;
using Microsoft.EntityFrameworkCore;

namespace Sample.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base (context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;
            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName) 
                    && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(
                    p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName)).ToList();
            }
            return null;
        }

        public PagedSearch<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"SELECT * FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) 
            {
                query = query + $" AND p.first_name LIKE '%{name}%' ";
            }
            query = query + $" ORDER BY p.first_name {sort} LIMIT {size} OFFSET {offset};";

            string countQuery = @"SELECT COUNT(*) FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) 
            {
                countQuery = countQuery + $" AND p.first_name LIKE '%{name}%'";
            }

            var persons = _dataset.FromSqlRaw<Person>(query).ToList();
            int totalResults = this.GetCount(countQuery);

            return new PagedSearch<Person> {
                CurrentPage = page,
                List =  persons,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}