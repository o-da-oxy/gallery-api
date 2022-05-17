using System.Collections.Generic;
using System.Linq;
using GalleryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/picture")]
public class PictureController : ControllerBase
{
    public static List<Picture> Pictures = new List<Picture>
    {
        new Picture() {Id = 1, Author = "Anton", Price = 10000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("MosGallery"))},
        new Picture() {Id = 2, Author = "Andrew", Price = 46000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("MosGallery"))},
        new Picture() {Id = 3, Author = "Human", Price = 88000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("MosGallery"))},
        new Picture() {Id = 4, Author = "Pavel", Price = 100000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("NYGallery"))},
        new Picture() {Id = 5, Author = "Kia", Price = 14000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("NYGallery"))},
        new Picture() {Id = 6, Author = "Pirate", Price = 190000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("OldGallery"))},
        new Picture() {Id = 7, Author = "Sir", Price = 110000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("OldGallery"))},
        new Picture() {Id = 8, Author = "Gray", Price = 90000, Gallery = GalleryController.Galleries.First(g => g.Name.Equals("OldGallery"))},
    };

    private readonly ILogger<PictureController> _logger;

    public PictureController(ILogger<PictureController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Picture> Get()
    {
        return Pictures.ToArray();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var picture = Pictures.First(e => e.Id==id);
        return Ok(picture);
    }

    [HttpGet("gallery/{galleryName}")]
    public IActionResult GetByGallery(string galleryName)
    {
        var picture = Pictures.Where(e => e.Gallery.Name.Equals(galleryName));
        return Ok(picture);
    }
}