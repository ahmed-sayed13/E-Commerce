using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepositray productRepository  { get; }
        public IOrderRepositray orderRepository { get; }
        public IOrderItemRepositray orderItemRepository { get; }
        public IPhotoRepositray photoRepositray { get; }
      //  public IAuthRepositry AuthRepositry { get; }

    }
}
