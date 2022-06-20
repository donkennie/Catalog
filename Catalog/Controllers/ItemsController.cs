using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;


        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public IEnumerable<ItemsDto> GetItems()
        {
            var items = _repository.GetItems().Select( items => items.AsDto());
                

            return items; 
        }

        [HttpGet("{id}")]
        public ActionResult <ItemsDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]

        public ActionResult<ItemsDto> CreateItem(CreateItemsDto itemsDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemsDto.Name,
                Price = itemsDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }


        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemsDto itemsDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updateItem = existingItem with
            {
                Name = itemsDto.Name,
                Price = itemsDto.Price
            };

            _repository.UpdateItem(updateItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            _repository.DeleteItem(id);

            return NoContent();
        }


    }
}
