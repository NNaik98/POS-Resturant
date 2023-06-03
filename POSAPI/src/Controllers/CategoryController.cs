using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace POSAPI.src.Controllers
{
    [Route("pos/categories")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly Model _model;

        public CategoryController(Model model)
        {
            _model = model;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuCategory>> Get()
        {

            try
            {
                var categories = _model.MenuCategories;

                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(500, "Category could not be loaded at this moment");
            }


        }
    }
}

