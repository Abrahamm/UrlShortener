using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{

    [ApiController]
    [Route("api/urls")]
    public class UrlController : ControllerBase
    {

        private readonly IUrlShortenerRepository _urlShortenerRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;


        public UrlController(IUrlShortenerRepository urlShortenerRepository,
                                ILogger<UserController> logger
                              , IMapper mapper)
        {
            _urlShortenerRepository = urlShortenerRepository ??
                throw new ArgumentNullException(nameof(urlShortenerRepository));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Retrieves ALL URLs
        /// </summary>

        [HttpGet]
        public IActionResult GetUrls()
        {
            return Ok(_urlShortenerRepository.GetUrls());
        }
        /// <summary>
        /// Retrieve one URL specified by id
        /// </summary>

        [HttpGet("{id}")]
        public IActionResult GetUrl(int id)
        {
            if (!_urlShortenerRepository.UrlExists(id))
            {
                return NotFound();
            }

            return Ok(_urlShortenerRepository.GetUrl(id));
        }

        /// <summary>
        /// Retrieve a list of all tags for specified URL with given id
        /// </summary>

        //get all tags for url with id
        [HttpGet("{id}/tags")]
        public IActionResult GetTagsOfUrl(int id)
        {
            if (!_urlShortenerRepository.UrlExists(id))
            {
                return NotFound();
            }
            var urlWithTags = _urlShortenerRepository.GetTagsFromUrl(id);
            List<String> retVal = new List<String>();
            return Ok(urlWithTags);

        }
        /// <summary>
        /// Create new URL
        /// </summary>
        ///   <remarks>
        /// Sample request:
        /// 
        ///     POST api/urls
        ///     {
        ///     "longUrl": "https://flexbit.hr",
        ///     "shortUrl": "flxbt",
        ///     "dateCreated": "2020-01-25T11:30:49",
        ///     "dateExpires": "2020-02-25T11:30:49",
        ///     "userId": "2"
        ///    }
        /// </remarks>

        [HttpPost]
        public IActionResult CreateUrl([FromBody] UrlForCreationDto urlForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var finalUrl = _mapper.Map<Entities.Url>(urlForCreationDto);
            _urlShortenerRepository.AddUrl(finalUrl);
            _urlShortenerRepository.Save();
            return Ok();
        }


        /// <summary>
        /// Update an URL (FULL UPDATE)
        /// </summary>
        ///   <remarks>
        /// Sample request:
        /// 
        ///     POST api/urls/7
        ///     {
        ///     "longUrl": "https://flexbit.hr",
        ///     "shortUrl": "fleex",
        ///     "dateCreated": "2020-01-25T11:30:49",
        ///     "dateExpires": "2020-02-25T11:30:49",
        ///     "userId": "2"
        ///    }
        /// </remarks>
        [HttpPut("{id}")]
        public IActionResult UpdateUrl([FromBody] UrlForUpdateDto urlForUpdateDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_urlShortenerRepository.UrlExists(id))
            {
                return NotFound();
            }

            var urlEntity = _urlShortenerRepository.GetUrl(id);
            _mapper.Map(urlForUpdateDto, urlEntity);
            _urlShortenerRepository.Save();
            return NoContent();
        }
        

    }
}
