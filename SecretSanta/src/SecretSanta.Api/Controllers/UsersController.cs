using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Api.Dto;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository UserRepository { get; }

        public UsersController(IUserRepository userRepository)
        {
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // /api/events
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserRepository.List();
        }

        // /api/events/<index>ss
        [HttpGet("{id}")]
        public ActionResult<User?> Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            User? returnedUser = UserRepository.GetItem(id);
            return returnedUser;
        }

        //DELETE /api/events/<index>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            if (UserRepository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        // POST /api/events
        [HttpPost]
        public ActionResult<User?> Post([FromBody] User? myUser)
        {
            if (myUser is null)
            {
                return BadRequest();
            }
            return UserRepository.Create(myUser);
        }

        // PUT /api/events/<id>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]UpdateUser? updatedUser)
        {
            if (updatedUser is null)
            {
                return BadRequest();
            }
            User? foundUser = UserRepository.GetItem(id);
            if (foundUser is not null)
            {
                if (!string.IsNullOrWhiteSpace(updatedUser.FirstName))
                {
                    foundUser.FirstName = updatedUser.FirstName;
                }

                if (!string.IsNullOrWhiteSpace(updatedUser.LastName))
                {
                    foundUser.LastName = updatedUser.LastName;
                }

                UserRepository.Save(foundUser);
                return Ok();
            }
            return NotFound();
        }
    }
}