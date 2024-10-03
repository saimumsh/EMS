using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EMS.service.Service
{
    public class CreateDocument : IDocument
    {
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            var tableData = new List<(string date, string year, string type, string share, string warrant, string batbCmsf, string collected, string uncollected, string transferred, string recollected)>
{
    ("08-Feb-2023", "2022", "Final", "3,242", "380089C", "CMSF", "0.00", "0.00", "27,557.00", "0.00")
};

            container.Page(page =>
            {
                page.Size(PageSizes.A2);
                page.Margin(1, Unit.Centimetre);

                // Page content starts here
                page.Content().Column(column =>
                {
                    column.Spacing(15); // Adds spacing between sections

                    // BO/Folio No, Name, Address, Bank details
                    column.Item().Text("BO/Folio No: 01000013").FontSize(12).Bold().FontColor(Colors.Black);
                    column.Item().Text("Name: ASRARUL HOSSAIN").FontSize(12).Bold().FontColor(Colors.Black);
                    column.Item().Text("Address: 3/B, OUTER CIRCULAR ROAD, DHAKA-17.")
                        .FontSize(12).FontColor(Colors.Grey.Darken2);
                    column.Item().Text("Bank Name: ").FontSize(12).FontColor(Colors.Grey.Darken2);
                    column.Item().Text("Account No: ").FontSize(12).FontColor(Colors.Grey.Darken2);
                    column.Item().Text("Branch: 00000").FontSize(12).FontColor(Colors.Grey.Darken2);
                    column.Item().Text("Routing No: ").FontSize(12).FontColor(Colors.Grey.Darken2);

                    // Space between sections
                    column.Item().PaddingVertical(15);

                    // Table Section
                    column.Item().Table(table =>
                    {
                        IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                        {
                            return container
                                .Border(1)
                                .BorderColor(Colors.Grey.Lighten1)
                                .Background(backgroundColor)
                                .PaddingVertical(5)
                                .PaddingHorizontal(10)
                                .AlignCenter()
                                .AlignMiddle();
                               
                        }

                        // Define the number of columns for the outer table
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(); // Dividend Date
                            columns.RelativeColumn(); // Year
                            columns.RelativeColumn(); // Dividend Type
                            columns.RelativeColumn(); // Total Share
                            columns.RelativeColumn(); // Warrant
                            columns.RelativeColumn(); // BATB/CMSF
                            columns.RelativeColumn(); // Collected (BATB)
                            columns.RelativeColumn(); // Uncollected (BATB)
                            columns.RelativeColumn(); // Transferred (CMSF)
                            columns.RelativeColumn(); // Recollected (CMSF)
                        });

                        // Consolidated Table Header for both main and sub-columns
                        table.Header(header =>
                        {
                            // First header row for main columns
                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("Dividend Date").Bold().FontColor(Colors.Black);

                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("Year").Bold().FontColor(Colors.Black);

                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("Dividend Type").Bold().FontColor(Colors.Black);

                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("Total Share").Bold().FontColor(Colors.Black);

                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("Warrant").Bold().FontColor(Colors.Black);

                            header.Cell().RowSpan(2).Padding(1).Element(CellStyle)
                                .Text("BATB/CMSF").Bold().FontColor(Colors.Black);

                             header.Cell().ColumnSpan(2).Padding(1).Element(CellStyle)
                                .Text("BATB").Bold().FontColor(Colors.Black);

                             header.Cell().ColumnSpan(2).Padding(1).Element(CellStyle)
                                .Text("CMSF").Bold().FontColor(Colors.Black);

                            // Sub-columns under BATB
                            header.Cell().Padding(1).Element(CellStyle)
                                .Text("Collected").Bold().FontColor(Colors.Black);

                            header.Cell().Padding(1).Element(CellStyle)
                                .Text("Uncollected").Bold().FontColor(Colors.Black);

                            // Sub-columns under CMSF
                            header.Cell().Padding(1).Element (CellStyle)
                                .Text("Transferred").Bold().FontColor(Colors.Black);

                            header.Cell().Padding(1).Element(CellStyle)
                                .Text("Recollected").Bold().FontColor(Colors.Black);
                            IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                        });

                        // Table Body
                        foreach (var row in tableData)
                        {
                            table.Cell().Element(CellStyle)
                                .Text(row.date).FontColor(Colors.Black);  // Dividend Date

                            table.Cell().Element (CellStyle)
                                .Text(row.year).FontColor(Colors.Black);  // Year

                            table.Cell().Element(CellStyle)
                                .Text(row.type).FontColor(Colors.Black);  // Dividend Type

                            table.Cell().Element(CellStyle)
                                .Text(row.share).FontColor(Colors.Black); // Total Share

                            table.Cell().Element(CellStyle)
                                .Text(row.warrant).FontColor(Colors.Black);  // Warrant

                            table.Cell().Element(CellStyle)
                                .Text(row.batbCmsf).FontColor(Colors.Black);  // BATB/CMSF

                            // BATB Collected and Uncollected
                            table.Cell().Element(CellStyle)
                                .Text(row.collected).FontColor(Colors.Black);  // Collected

                            table.Cell().Element(CellStyle)
                                .Text(row.uncollected).FontColor(Colors.Black);  // Uncollected

                            // CMSF Transferred and Recollected
                            table.Cell().Element(CellStyle)
                                .Text(row.transferred).FontColor(Colors.Black);  // Transferred

                            table.Cell().Element(CellStyle)
                                .Text(row.recollected).FontColor(Colors.Black);  // Recollected
                        }
                        IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                    });
                });

                // Footer Section
                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
            });

        }
    }


 }
