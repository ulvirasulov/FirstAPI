using AutoMapper;
using BlogApp.API.DTO;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        BlogAppDbContext _db;
        IMapper mapper;

        public CategoryController(BlogAppDbContext db, IMapper mapper)
        {
            _db = db;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Categories.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var newCategory = mapper.Map<Category>(dto);
            _db.Categories.Add(newCategory);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created,newCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return StatusCode(StatusCodes.Status306SwitchProxy);
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var updatedCategory = _db.Categories.AsNoTracking().FirstOrDefault(x=>x.Id==dto.Id);

            updatedCategory = mapper.Map<Category>(dto);

            _db.Categories.Update(updatedCategory);
            _db.SaveChanges();
            return StatusCode(986);

        }

    }
}
