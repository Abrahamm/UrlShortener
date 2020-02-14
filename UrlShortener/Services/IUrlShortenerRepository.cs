using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entities;

namespace UrlShortener.Services
{
    public interface IUrlShortenerRepository
    {
        IEnumerable<User> GetUsers();

        User GetUser(int userId);

        bool UserExists(int userId);

        void AddUser(User finalUser);

        IEnumerable<Url> GetUrls();

        bool UrlExists(int urlId);

        Url GetUrl(int urlId);

        List<String> GetTagsFromUrl(int urlId);

        void AddUrl(Url finalUrl);

        User GetUserUrlsWithTags(int userId);

        IEnumerable<Url> getUserUrls(int userId);

        bool Save();

    }
}
