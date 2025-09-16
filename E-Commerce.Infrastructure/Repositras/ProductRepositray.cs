using AutoMapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Core.Service;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositras
{
    public class ProductRepositray : GenericRepositray<Product>, IProductRepositray
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly IImageManagementService imageManagementService;

        public ProductRepositray(ApplicationDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            var Product = mapper.Map<Product>(productDTO);
            if (Product is null) return false;
            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();

            var ImagePath = await imageManagementService.AddImageAsync(productDTO.Photos, productDTO.Name);
            var photo = ImagePath.Select(path => new Photo
            {
                IamgName = path,
                ProductId = Product.Id
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO is null) return false;
            var product = await context.Products.Include(m => m.Photos).FirstOrDefaultAsync(p => p.Id == updateProductDTO.Id);

            if (product is null) return false;
            mapper.Map(updateProductDTO, product);
            context.Products.Update(product);
            await context.SaveChangesAsync();
            if (updateProductDTO.Photos is not null && updateProductDTO.Photos.Count > 0)
            {
                // delete old images
                var FindPhotos = await context.Photos.Where(p => p.ProductId == updateProductDTO.Id).ToListAsync();
                foreach (var item in FindPhotos)
                {
                    imageManagementService.DeleteImageAsync(item.IamgName);
                }
                context.Photos.RemoveRange(FindPhotos);

                // add new images
                var newImagePaths = await imageManagementService.AddImageAsync(updateProductDTO.Photos, updateProductDTO.Name);
                var newPhotos = newImagePaths.Select(path => new Photo
                {
                    IamgName = path,
                    ProductId = updateProductDTO.Id
                }).ToList();
                await context.Photos.AddRangeAsync(newPhotos);
                await context.SaveChangesAsync();
            }
            return true;

        }
        public async Task DeleteAsync(Product product)
        {
            // delete images from folder
            var photos = await context.Photos.Where(p => p.ProductId == product.Id).ToListAsync();
            foreach (var item in photos)
            {
                imageManagementService.DeleteImageAsync(item.IamgName);
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }

}
