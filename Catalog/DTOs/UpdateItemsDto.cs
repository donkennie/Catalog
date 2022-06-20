using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.DTOs
{
    public record UpdateItemsDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; init; }
    }
}
