using HW2WebApp.Data;
using HW2WebApp.Models;
using HW2WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW2WebApp.Controllers
{
    public class FilesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly BlobStorageService _blobSvc;

        public FilesController(AppDbContext db, BlobStorageService blobSvc)
        {
            _db = db;
            _blobSvc = blobSvc;
        }

        public IActionResult Index()
        {
            var files = _db.Files.OrderByDescending(f => f.Id).ToList();
            return View(files);
        }

        [HttpGet]
        public IActionResult Upload() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (!ModelState.IsValid || file == null || file.Length == 0)
                return View();

            var (blobName, url) = await _blobSvc.UploadAsync(file);

            var record = new FileRecord
            {
                BlobName = blobName,
                OriginalName = file.FileName,
                Url = url,
                ContentType = file.ContentType
            };
            _db.Files.Add(record);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Download(int id)
        {
            var file = await _db.Files.FindAsync(id);
            if (file == null)
                return NotFound();

            var blob = _blobSvc.GetBlobClient(file.BlobName);
            var stream = new MemoryStream();
            await blob.DownloadToAsync(stream);
            stream.Position = 0;

            return File(stream, file.ContentType, Path.GetFileName(file.Url));
        }
    }
}
