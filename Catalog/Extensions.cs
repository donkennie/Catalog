using Catalog.DTOs;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemsDto AsDto(this Item item)
         {
            return new ItemsDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
