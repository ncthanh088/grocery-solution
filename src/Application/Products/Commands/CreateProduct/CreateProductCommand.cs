using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Grocery.Domain.Entities;
namespace Grocery.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile ThumbnailImage { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public IList<IFormFile> NewImages { get; set; } = new List<IFormFile>();
        public IList<string> ImageUrls { get; set; } = new List<string>();
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public int StockQuantity { get; set; }
        public string NormalizedName { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public IList<int> CategoryIds { get; set; } = new List<int>();
    }    
}