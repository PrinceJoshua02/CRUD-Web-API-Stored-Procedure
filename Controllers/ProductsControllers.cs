using CRUD_Web_API_Stored_Procedure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Authorize] // Apply [Authorize] attribute to secure the endpoint
    public IActionResult Create(Product product)
    {
        _repository.CreateProduct(product.Name, product.Price);
        return Ok();
        // Return a success response or appropriate HTTP status code
    }

    // Implement other CRUD operations similarly

    [HttpGet("{id}")]
    [Authorize] // Apply [Authorize] attribute to secure the endpoint
    public IActionResult Get(int id)
    {
        var product = _repository.ReadProduct(id);
        return Ok();
        // Return the product or appropriate HTTP status code
    }

    [HttpPut]
    [Authorize] // Apply [Authorize] attribute to secure the endpoint
    public IActionResult Update(Product product)
    {
        _repository.UpdateProduct(product);
        return Ok();
        // Return a success response or appropriate HTTP status code
    }

    [HttpDelete("{id}")]
    [Authorize] // Apply [Authorize] attribute to secure the endpoint
    public IActionResult Delete(int id)
    {
        _repository.DeleteProduct(id);
        return Ok();
        // Return a success response or appropriate HTTP status code
    }
}
