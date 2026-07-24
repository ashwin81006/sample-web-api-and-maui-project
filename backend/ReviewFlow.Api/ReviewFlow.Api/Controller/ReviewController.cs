using Microsoft.AspNetCore.Mvc;
using ReviewFlow.Api.Models;
using ReviewFlow.Api.Services;

namespace ReviewFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly DatabaseService _databaseService;

    public ReviewController(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_databaseService.GetAllReviews());
    }

    [HttpPost]
    public IActionResult Post(ReviewRequest review)
    {
        _databaseService.AddReview(review);

        return Ok("Review Added Successfully");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, ReviewRequest review)
    {
        _databaseService.UpdateReview(id, review);

        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _databaseService.DeleteReview(id);

        return Ok("Deleted Successfully");
    }

    [HttpGet("{id:int}")]
    public IActionResult GetId(int id)
    {
        var review = _databaseService.GetReviewById(id);

        if (review == null)
            return NotFound();

        return Ok(review);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetName(String name)
    {
        var review = _databaseService.GetByName(name);

        if (review == null)
            return NotFound();

        return Ok(review);
    }
}
