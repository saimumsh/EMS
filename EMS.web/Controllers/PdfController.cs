using EMS.service.Service;
using EMS.web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using iText;


namespace EMS.web.Controllers
{
	public class PdfController : Controller
    {
        
        public IActionResult Index()
		{
            // Sample data for demonstration
            var viewModel = new DividendRecordViewModel
            {
                BOFolioNo = "01000013",
                Name = "ASRARUL HOSSAIN",
                Address = "3/B, OUTER CIRCULAR ROAD, DHAKA-17",
                BankName = "Islami Bank Bangladesh",
                AccountNo = "0123456789",
                Branch = "00000",
                RoutingNo = "785496123548",
                PageNumber = 1,
                TotalPages = 1 // Assuming no pagination for this example, otherwise calculate based on data.
            };

            // Sample dividend records
            viewModel.TableData.Add(new DividendRecord
            {
                Date = "08-Feb-2023",
                Year = "2022",
                Type = "Final",
                Share = "3,242",
                Warrant = "380089C",
                BATBCMSF = "CMSF",
                Collected = "0.00",
                Uncollected = "0.00",
                Transferred = "27,557.00",
                Recollected = "0.00"
            });

            // You can add more records or fetch this data from the database based on your requirements.
            return View(viewModel);
        }
		[HttpGet("CreateDocument")]
		public IActionResult CreateDocument()
		{
			var document = new CreateDocument();
			var pdfBytes = document.GeneratePdf();
			return File(pdfBytes, "application/pdf");
		}

        public async Task<IActionResult> GeneratePdf()
        {
            var pdfConverter = new PdfConverter();
            var model = new DividendRecordViewModel
            {
              
            };

            var pdfBytes =  pdfConverter.CreatePdf(model);
            return File(pdfBytes, "application/pdf");
        }

       

    }
}
