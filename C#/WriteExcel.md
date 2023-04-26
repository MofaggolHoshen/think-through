## Write Excel file and send email
```C#
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
        public static async Task Main()
        {
            // Create a new Excel file
            using (var memoryStream = new MemoryStream())
            using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a new worksheet
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add some data to the worksheet
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                var row = new Row();
                sheetData.Append(row);

                var cell = new Cell { CellValue = new CellValue("Hello, world!"), DataType = CellValues.String };
                row.Append(cell);

                // Save the changes
                workbookPart.Workbook.Save();
                document.Close();

                //Need to set the possition other, important
                memoryStream.Position = 0;

                // Send an email with the Excel file as an attachment
                using (var client = new SmtpClient("smtp.sendgrid.net", 587))
                {
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("apikey", "apikey");

                    var message = new MailMessage("mofaggol.hoshen@abc.com", "noreply@abv.com", "Excel file", "Please see the attached Excel file.");
                    //MediaTypeNames.Application.Octet
                    var attachment = new Attachment(memoryStream, "example.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    message.Attachments.Add(attachment);

                    client.Send(message);
                }

                await Task.CompletedTask;

            }
        }
```