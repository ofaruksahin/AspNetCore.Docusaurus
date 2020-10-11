using AspNetCore.Docusaurus.Sample.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCore.Docusaurus.Sample.Controllers
{
    /// <summary>
    /// Kullanıcı İşlemlerinden Sorumludur
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {
        /// <summary>
        /// qwe
        /// </summary>
        public static List<User> users = new List<User>()
        {
            new User()
            {
                Name = "Ömer Faruk",
                Surname = "Şahin"
            },
            new User()
            {
                Name = "Ömer Faruk 2",
                Surname = "Şahin"
            }
        };

        /// <summary>
        /// asd
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult Index()
        {
            return new JsonResult(users);
        }

        /// <summary>
        /// Tekli Kullanıcı Listelemek İçin Kullanılır
        /// </summary>
        /// <param name="index">Görüntülenmek İstenilen Model</param>
        /// <returns></returns>
        [HttpGet("get/{index:int}")]
        public IActionResult Get(int index)
        {
            return new JsonResult(users[index]);
        }

        /// <summary>
        /// Kullanıcı Güncellemek İçin Kullanılır.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(int index,User user)
        {
            return new JsonResult(true);
        }

        [NonAction]
        public void ExampleMethod()
        {

        }
    }
}
