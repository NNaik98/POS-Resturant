using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSAPI.Migrations;
using POSAPI.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace POSAPI.Controllers
{
    [Route("pos/items")]
    [ApiController]
    [Produces("application/json")]
    public class ItemController : ControllerBase
    {
        private readonly Model _model;

        public ItemController(Model model)
        {
            _model = model;
        }

        [Route("getItems")]
        [HttpGet]
        public ActionResult<IEnumerable<MenuItem>> Get() 

        {
            var AllItems = _model.MenuItems;
            return Ok(AllItems); 
        }

       


        [Route("AddItem")]
        [HttpPost]
        public ActionResult<string> Add(MenuItemRequest newItem)
        {

            var category = _model.MenuCategories.FirstOrDefault(category => category.Id == newItem.Id);
            var SnapShotID = _model.GetNewId<MenuItemSnapshot>();
            MenuItem itemToAdd = new(SnapShotID, newItem, category);

            try
            {
                _model.MenuItems.Add(itemToAdd);
                _model.SaveChanges();
                return Ok("Item added successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to add");
            }
        }
    }
    }

