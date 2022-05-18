using System.Collections.Generic;
using System.Linq;
using GalleryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/gallery")]
public class GalleryController : ControllerBase
{
    public static List<Gallery> Galleries = new List<Gallery> { 
        new Gallery() {Name = "MosGallery", Area = 2000, MaxPicturesCount = 200},
        new Gallery() {Name = "NYGallery", Area = 3000, MaxPicturesCount = 300},
        new Gallery() {Name = "OldGallery", Area = 1000, MaxPicturesCount = 100}
    };

    private readonly ILogger<GalleryController> _logger;

    public GalleryController(ILogger<GalleryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Gallery> Get()
    {
        return Galleries.ToArray();
    }

    [HttpGet("{galleryName}")]
    public IActionResult Get(string galleryName)
    {
        var gallery = Galleries.Where(e => e.Name.Equals(galleryName));
        return Ok(gallery);
    }
    
    [HttpGet("area/{area}")]
    public IActionResult GetByArea(int area)
    {
        var galleries = Galleries.Where(e => e.Area > area);
        if (!galleries.Any()) return NotFound();
        return Ok(galleries);
    }
}