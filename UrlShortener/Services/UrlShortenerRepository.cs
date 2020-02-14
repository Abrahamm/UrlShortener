using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Context;
using UrlShortener.Entities;

namespace UrlShortener.Services
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {

        private readonly UrlShortenerContext _context;

        public UrlShortenerRepository(UrlShortenerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User GetUser(int userId) 
        {
           
            return _context.Users.FirstOrDefault(c => c.Id == userId);
           
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(c => c.FirstName).ToList();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(c => c.Id == userId);
        }

        public void AddUser(User finalUser)
        {
            _context.Users.Add(finalUser);
        }

        public IEnumerable<Url> GetUrls()
        {
            return _context.Urls.ToList();
        }

        public bool UrlExists(int urlId)
        {
            return _context.Urls.Any(c => c.Id == urlId);
        }

        public Url GetUrl(int urlId)
        {
            return _context.Urls.FirstOrDefault(c => c.Id == urlId);
        }

        public List<String> GetTagsFromUrl(int urlId)
        {
            var tagsRaw = _context.Taggeds
                .Where(tagged => tagged.UrlId == urlId)
                .Include(tagged => tagged.Tag)
                .Select(tagged => tagged.Tag.Name.ToUpper())
                .ToList();

            var tags = new List<String>();
            
            return tags;
        }

        public void AddUrl(Url finalUrl)
        {
            finalUrl.DateCreated = DateTime.Now;
            finalUrl.DateExpires = finalUrl.DateCreated.AddMonths(1);
            _context.Urls.Add(finalUrl);
        }

        public IEnumerable<Url> getUserUrls(int userId)
        {
            return _context.Urls.Where(c => c.UserId == userId).ToList();
            //return _context.Users.Where(c => c.Id == userId).Include(c => c.Urls).FirstOrDefault();
        }

        // all joins user>>>---....tags
        //return _context.Users.Where(c => c.Id == userId).Include(c => c.Urls).ThenInclude(u => u.Taggeds).ThenInclude(c => c.Tag).Find();


        public User GetUserUrlsWithTags(int userId) //not implemented
        {

            return _context.Users.FirstOrDefault(c => c.Id == userId);

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}
