using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;

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
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Millimetre);

                // Page content starts here
                page.Content().Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        // First Column
                        row.RelativeItem().AlignLeft().Column(col =>
                        {
                            col.Item().Text("BO/Folio No: 01000013").FontSize(12).Bold().FontColor(Colors.Black);
                            col.Item().Text("Name: ASRARUL HOSSAIN").FontSize(12).Bold().FontColor(Colors.Black);
                            col.Item().Text("Address: 3/B, OUTER CIRCULAR ROAD, DHAKA-17.").Bold()
                                .FontSize(12).FontColor(Colors.Grey.Darken2);
                        });

                        // Second Column
                        row.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text("Bank Name: Islami Bank Bangladesh").FontSize(12).Bold().FontColor(Colors.Grey.Darken2);
                            col.Item().Text("Account No:0123456789 ").FontSize(12).Bold().FontColor(Colors.Grey.Darken2);
                            col.Item().Text("Branch: 00000").FontSize(12).Bold().FontColor(Colors.Grey.Darken2);
                            col.Item().Text("Routing No: 785496123548").FontSize(12).Bold().FontColor(Colors.Grey.Darken2);
                        });
                    });
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
                                .PaddingVertical(2)
                                .PaddingHorizontal(4)
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
                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("Dividend Date").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("Year").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("Dividend Type").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("Total Share").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("Warrant").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().RowSpan(2).Element(CellStyle)
                                .Text("BATB/CMSF").Bold().FontColor(Colors.Black).FontSize(7);

                             header.Cell().ColumnSpan(2).Element(CellStyle)
                                .Text("BATB").Bold().FontColor(Colors.Black).FontSize(7);

                             header.Cell().ColumnSpan(2).Element(CellStyle)
                                .Text("CMSF").Bold().FontColor(Colors.Black).FontSize(7);

                            // Sub-columns under BATB
                            header.Cell().Element(CellStyle)
                                .Text("Collected").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().Element(CellStyle)
                                .Text("Uncollected").Bold().FontColor(Colors.Black).FontSize(7);

                            // Sub-columns under CMSF
                            header.Cell().Element (CellStyle)
                                .Text("Transferred").Bold().FontColor(Colors.Black).FontSize(7);

                            header.Cell().Element(CellStyle)
                                .Text("Recollected").Bold().FontColor(Colors.Black).FontSize(7);
                            IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                        });

                        // Table Body
                        foreach (var row in tableData)
                        {
                                table.Cell().Element(CellStyle)
                                    .Text(row.date).FontColor(Colors.Black).FontSize(6);  // Dividend Date

                                table.Cell().Element(CellStyle)
                                    .Text(row.year).FontColor(Colors.Black).FontSize(6);  // Year

                                table.Cell().Element(CellStyle)
                                    .Text(row.type).FontColor(Colors.Black).FontSize(6);  // Dividend Type

                                table.Cell().Element(CellStyle)
                                    .Text(row.share).FontColor(Colors.Black).FontSize(6); // Total Share

                                table.Cell().Element(CellStyle)
                                    .Text(row.warrant).FontColor(Colors.Black).FontSize(6);  // Warrant

                                table.Cell().Element(CellStyle)
                                    .Text(row.batbCmsf).FontColor(Colors.Black).FontSize(6);  // BATB/CMSF

                                // BATB Collected and Uncollected
                                table.Cell().Element(CellStyle)
                                    .Text(row.collected).FontColor(Colors.Black).FontSize(6);  // Collected

                                table.Cell().Element(CellStyle)
                                    .Text(row.uncollected).FontColor(Colors.Black).FontSize(6);  // Uncollected

                                // CMSF Transferred and Recollected
                                table.Cell().Element(CellStyle)
                                    .Text(row.transferred).FontColor(Colors.Black).FontSize(6);  // Transferred

                                table.Cell().Element(CellStyle)
                                    .Text(row.recollected).FontColor(Colors.Black).FontSize(6);                           
                              // Recollected
                            IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                        }
                    });
                    column.Item().Text(Text =>
                    {
                        Text.Justify();
                        Text.Span("Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                            " sed do eiusmod tempor incididunt ut labore et dolore magna aliqused" +
                            " do eiusmod tempor incididunt ut labore et dolore magna aliqused do eiusmod " +
                            "tempor incididunt ut labore et dolore magna aliqused do eiusmod tempor incididunt" +
                            " ut labore et dolore magna aliquaut labore et dolore magna aliquaut labore et dolore " +
                            "magna aliquaut labore et dolore magna aliquaut labore et dolore magna aliquaut labore " +
                            "et dolore magna aliquaut labore et dolore magna aliquaut labore et dolore magna aliquaut" +
                            " labore et dolore magna aliquaut labore et dolore magna aliqua.")
                        .FontSize(12);
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
