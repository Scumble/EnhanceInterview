using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceInterview.Controllers
{
	[Route("api")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		[HttpPost("upload"), DisableRequestSizeLimit]
		public IActionResult Upload()
		{
			try
			{
				var file = Request.Form.Files[0];
				var folderName = Path.Combine("Resources", "Images");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

				if (file.Length > 0)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(pathToSave, fileName);
					var imagePath = Path.Combine(folderName, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}

					return Ok(new {imagePath});
				}

				return BadRequest();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Failed to upload the image: {ex}");
			}
		}
	}
}