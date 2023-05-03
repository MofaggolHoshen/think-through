```C#
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.Security;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.Json;
using System;

namespace HandalingLargePayload.Controllers;

[Route("")]
[ApiController]
public class HomeController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestSoapXml"></param>
    /// <returns></returns>
    [HttpGet("XmlToJson", Name = "XmlToJson")]
    //[Consumes(MediaTypeNames.Application.Xml)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[Produces(contentType: "application/xml")]
    //[RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> XmlToJson()
    {
        await Task.CompletedTask;

        var fileStream = new FileStream("Files/LargeSample.xml", FileMode.Open, FileAccess.Read);

        using var xmlReader = XmlReader.Create(fileStream);

        var serializer = new XmlSerializer(typeof(Envelope));
        var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore }; // Ignore DTDs to avoid DoS attacks

        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.LocalName == "Envelope")
            {
                var myClass = (Envelope)serializer.Deserialize(xmlReader);

                var memoryStream = new MemoryStream();

                JsonSerializer.Serialize(memoryStream, myClass);

                memoryStream.Position = 0;

                return File(memoryStream, MediaTypeNames.Application.Octet, $"compressed.json");
            }
        }

        throw new Exception("");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestSoapXml"></param>
    /// <returns></returns>
    [HttpGet("process", Name = "Process")]
    //[Consumes(MediaTypeNames.Application.Xml)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[Produces(contentType: "application/xml")]
    //[RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> Process()
    {
        await Task.CompletedTask;

        var fileStream = new FileStream("Files/LargeSample.xml", FileMode.Open, FileAccess.Read);

        return File(fileStream, "application/octet-stream");
    }

    [HttpGet("process1", Name = "Process1")]
    public async Task<IActionResult> Process1()
    {
        await Task.CompletedTask;

        var fileStream = new FileStream("Files/LargeSample.xml", FileMode.Open, FileAccess.Read);

        return File(fileStream, "application/octet-stream", "sample.xml");
    }

    [HttpGet("large-response1")]
    public async Task<IActionResult> GetLargeResponse1()
    {
        await Task.CompletedTask;

        var fileStream = new FileStream("Files/LargeSample.xml", FileMode.Open, FileAccess.Read);

        var compressedStream = new MemoryStream();
        var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress);

        await fileStream.CopyToAsync(gzipStream);


        // Set the response headers
        //Response.Headers.Add("Content-Encoding", "gzip");
        //Response.Headers.Add("Content-Disposition", $"attachment; filename=\"abc.gz\"");
        //Response.ContentType = "application/octet-stream";

        // Return the compressed file data
        compressedStream.Seek(0, SeekOrigin.Begin);

        return File(compressedStream, MediaTypeNames.Application.Octet, $"compressed.xml.gz");
    }

    [HttpGet("large-response2")]
    public async Task<IActionResult> GetLargeResponse2()
    {
        await Task.CompletedTask;

        var stream = new FileStream("Files/LargeSample.xml", FileMode.Open);
        var compressedStream = new GZipStream(stream, CompressionMode.Compress);
        var result = new FileStreamResult(compressedStream, "application/octet-stream");
        result.EnableRangeProcessing = true; // allows clients to request partial content
        result.FileDownloadName = "large-data.txt.gz";
        Response.Headers.Add("Content-Encoding", "gzip");
        Response.Headers.Add("Content-Length", compressedStream.Length.ToString());
        return result;
    }

    //[HttpGet]
    //public async Task<IActionResult> CreateZipFromStream()
    //{
    //    await Task.CompletedTask;

    //    var fileStream = new FileStream("Files/LargeSample.xml", FileMode.Open, FileAccess.Read);

    //    // Create a new file stream to write the zip file
    //    var zipFileStream = new MemoryStream();

    //    // Create a new ZipArchive with the file stream and set the mode to Create
    //    var zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create, true);

    //    // Create a new zip entry with the name of the file
    //    var zipEntry = zipArchive.CreateEntry("bla.txt");

    //    // Open a stream to the zip entry and copy the input stream to it
    //    var zipEntryStream = zipEntry.Open();

    //    fileStream.CopyTo(zipEntryStream);

    //    return File(zipEntryStream, MediaTypeNames.Application.Zip);

    //}
}


´´´