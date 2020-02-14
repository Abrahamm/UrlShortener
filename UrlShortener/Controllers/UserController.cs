using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IUrlShortenerRepository _urlShortenerRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;


        public UserController(IUrlShortenerRepository urlShortenerRepository,
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
        /// Retrieves all Users
        /// </summary>
        [HttpGet]
        public IActionResult GetUsers()
        {
            _logger.LogInformation($"Entered the matrix");
            var userEntities = _urlShortenerRepository.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UserWithoutUrlsDto>>(userEntities));
        }

        /// <summary>
        /// Retrieves User with specified ID
        /// </summary>
        [HttpGet("{id}")]

        public IActionResult GetUser(int id)
        {
            _logger.LogInformation($"Searching for user with id {id} ");
            var userEntity = _urlShortenerRepository.GetUser(id);

            if (userEntity != null)
            {
                return Ok(_mapper.Map<UserWithoutUrlsDto>(userEntity));
            }

            return NotFound();
        }

        /// <summary>
        /// Retrieves all URLs from specified User
        /// </summary>
        [HttpGet("{id}/urls/")]

        public IActionResult GetUserUrls(int id)
        {
            _logger.LogInformation($"Searching for user with id {id} and finding his Urls.... ");
            if (!_urlShortenerRepository.UserExists(id))
            {
                _logger.LogInformation($"User with id {id} wasn't found when " +
                    $"accessing Urls.");
                return NotFound();
            }
            var urlsEntity = _urlShortenerRepository.getUserUrls(id);

            if (urlsEntity != null)
            {
                return Ok(urlsEntity);
                //return Ok(_mapper.Map<IEnumerable<UrlDto>>(urlsEntity));
            }

            return NotFound();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/user
        ///     {
        ///      "FirstName": "Zoran",
        ///       "LastName": "Milanović",
        ///       "BirthDate": "1965-03-19T00:00:00"
        ///       }
        /// </remarks>
    [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto userForCreationDto)
        {
            _logger.LogInformation(
                $" FIRSTNAME: {userForCreationDto.FirstName} " +
                $" LASTNAME: {userForCreationDto.LastName} " +
                $" BIRTHDATE: {userForCreationDto.BirthDate}    THANK YOU!!!!!");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalUser = _mapper.Map<Entities.User>(userForCreationDto);
            _urlShortenerRepository.AddUser(finalUser);
            _urlShortenerRepository.Save();


            return Ok(finalUser);
        }
        /// <summary>
        /// Updates user (FULL UPDATE)
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/user
        ///     {
        ///      "FirstName": "Zoran",
        ///       "LastName": "Grabar-Kitarović",
        ///       "BirthDate": "1965-03-19T00:00:00"
        ///       }
        /// </remarks>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,
            [FromBody] UserForUpdateDto userForUpdate)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_urlShortenerRepository.UserExists(id))
            {
                return NotFound();
            }

            var userEntity = _urlShortenerRepository.GetUser(id);

            _mapper.Map(userForUpdate, userEntity);

            //_cityInfoRepository.UpdatePointOfInterestForCity(cityId, pointOfInterestEntity);

            _urlShortenerRepository.Save();

            return NoContent();
        }

    }
}
