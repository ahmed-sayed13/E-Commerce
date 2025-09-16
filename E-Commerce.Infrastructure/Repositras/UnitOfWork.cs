using AutoMapper;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Core.Service;
using E_Commerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositras
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;

        //  private readonly IGenerateToken token;

        public IProductRepositray productRepository { get;}

        public IOrderRepositray orderRepository { get; }

        public IOrderItemRepositray orderItemRepository { get; }

        public IPhotoRepositray photoRepositray { get; }

        public IAuthRepositry AuthRepositry { get; }
        public UnitOfWork(ApplicationDbContext context , IMapper mapper, IImageManagementService imageManagementService)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
            productRepository = new ProductRepositray(_context ,_mapper,_imageManagementService);
            orderRepository = new OrderRepositray(_context);
            orderItemRepository = new OrderItemRepositray(_context);
            photoRepositray = new PhotoRepositray(_context);
            //AuthRepositry = new AuthRepositry(_context, userManager, signInManager);
        }

    }
}
