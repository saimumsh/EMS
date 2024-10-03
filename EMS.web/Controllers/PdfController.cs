using EMS.service.Service;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace EMS.web.Controllers
{
	public class PdfController : Controller
	{
		[HttpGet("CreateDocument")]
		public IActionResult CreateDocument()
		{
			var document = new CreateDocument();
			var pdfBytes = document.GeneratePdf();
			return File(pdfBytes, "application/pdf");
		}
	}
}
