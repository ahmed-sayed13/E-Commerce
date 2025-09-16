using AutoMapper;
using E_Commerce.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseControllers : ControllerBase
    {
        protected readonly IUnitOfWork _work;
        protected readonly IMapper _mapper;

        public BaseControllers(IUnitOfWork work)
        {
            _work = work;
        }

        public BaseControllers(IUnitOfWork work,IMapper mapper)
        {
            _work = work;
            _mapper = mapper;

        }
    }
}
