﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        public ActionResult<String> AddItem([FromBody] MenuItem newitem)

        {

            var checkItem = _model.MenuItems.Any(u => u.Name.Equals(newitem.Name));
            if (checkItem == true)
            {
                return BadRequest("Item already exist; Please use another Item Name");
            }

            else
            {
                _model.MenuItems.Add(newitem);

            }
                try
                {
                    _model.SaveChanges();

                    return Ok("Successfully Added.");
                }
                catch (Exception)
                {
                    return StatusCode(500, "Server error, Couldnt add to database. Please try again");
                }
            
        }


        [Route("AddItem")]
        [HttpPost]
        public ActionResult<string> Add(MenuItemRequest newItem)
        {
            var category = _model.MenuCategories.FirstOrDefault(category => category.Id == newItem.Id);
            MenuItem itemToAdd = new(newItem, category);


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
