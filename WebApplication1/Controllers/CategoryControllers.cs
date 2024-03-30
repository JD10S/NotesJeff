using BLL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryControllers : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryControllers(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetCategory(int userId)
        {
            var categories = _categoryService.GetCategory(userId);
            if (categories == null)
            {
                return NotFound(); 
            }
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory(string Name, int IdUser)
        {
            var category = new Category { Name = Name, IdUser = IdUser };
            return Ok(_categoryService.AddCategory(category));
        }

        [HttpPut]
        
        public IActionResult UpdateCategory(int IdUser, string Name)
        {
            var category = new Category { IdUser = IdUser, Name = Name };
            return Ok(_categoryService.UpdateCategory(category));
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            return Ok(_categoryService.DeleteCategory(id));
        }
    }
}
