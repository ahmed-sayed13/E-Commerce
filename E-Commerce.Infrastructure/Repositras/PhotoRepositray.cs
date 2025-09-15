using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositras
{
    public class PhotoRepositray: GenericRepositray<Photo>, IPhotoRepositray
    {
        public PhotoRepositray(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
