using AutoMapper;
using E_Commerce.API.Helper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Infrastructure.Data.Config;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseControllers
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
            

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _work.productRepository.GetAllAsync(x=>x.Photos);
                var result = _mapper.Map<List<ProductDto>>(products);
                if (products is null)
                    return BadRequest(new ResponsAPI(400));
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-byId")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var product = await _work.productRepository.GetByIdAsync(Id, c=>c.Photos);
                var result = _mapper.Map<ProductDto>(product);
                if (product is null)
                {
                    return BadRequest(new ResponsAPI(400));
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new ResponsAPI(400));
            }
        }
        [HttpPost("Add-product")]
        public async Task<IActionResult> add(AddProductDTO productDTO)
        {
            try
            {
                await _work.productRepository.AddAsync(productDTO);
                return Ok(new ResponsAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }
        [HttpPut("Update-product")]
        public async Task<IActionResult> update(UpdateProductDTO productDTO)
        {
            try
            {
                await _work.productRepository.UpdateAsync(productDTO);
                return Ok(new ResponsAPI(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }
        [HttpDelete("Delete-Peoduct")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _work.productRepository.GetByIdAsync(Id, x => x.Photos);
                await _work.productRepository.DeleteAsync(result);
                return Ok(new ResponsAPI(200));

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(400, ex.Message));
            }
        }
    }
}

