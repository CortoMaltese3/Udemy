using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HushApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HushApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        HushDbContext _hushDbContext;

        public MenusController(HushDbContext hushDbContext)
        {
            _hushDbContext = hushDbContext;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = _hushDbContext.Menus.Include("SubMenus");

            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
            var menu = _hushDbContext.Menus.Include("SubMenus").FirstOrDefault(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);

        }
    }
}