using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
    
            _service = productService;
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDTOS = _mapper.Map<List<ProductDTO>>(products);
            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOS)); Kirli Yol 
           
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOS));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))] // Filterın constructru parametre alıyorsa Service Filter üzerinden. Ayrıca Program.cs de tanımlanmalı. 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreateActionResult<ProductDTO>(CustomResponseDTO<ProductDTO>.Success(200, productDTO));
        }
        [HttpPost()]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productDTO));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(ProductUpdateDTO productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))] // Filterın constructru parametre alıyorsa Service Filter üzerinden. Ayrıca Program.cs de tanımlanmalı. 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
    }
}
