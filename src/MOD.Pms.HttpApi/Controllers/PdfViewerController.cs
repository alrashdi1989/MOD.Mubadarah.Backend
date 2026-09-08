using Azure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using MOD.Pms.Documents;
using MOD.Pms.Enums;
using Newtonsoft.Json;
using SixLabors.ImageSharp.ColorSpaces;
using SixLabors.ImageSharp.PixelFormats;
using Syncfusion.EJ2.PdfViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static SkiaSharp.HarfBuzz.SKShaper;
using static Stimulsoft.Report.Export.StiBidirectionalConvert;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MOD.Pms.Controllers
{
    [Route("api/PDFViewer")]
    public class PDFViewerController : PmsController
    {
        //Initialize the memory cache object   
        public IMemoryCache _cache;
        private readonly IConfiguration configuration;
        private readonly IDocumentAppService _documentAppService;
        private IHostingEnvironment _hostingEnvironment;

        public PDFViewerController(IMemoryCache cache, IConfiguration configuration, IDocumentAppService documentAppService, IHostingEnvironment hostingEnvironment)
        {
            _cache = cache;
            this.configuration = configuration;
            Console.WriteLine("PdfViewerController initialized");
            _documentAppService = documentAppService;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/Load")]
        //Post action for Loading the PDF documents   
        public IActionResult Load(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Load Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            MemoryStream stream = new MemoryStream();

            var jsonObject = JsonConverterstring(response);
            object jsonResult= new object();
            if (jsonObject != null && jsonObject.ContainsKey("document"))
            {
                if (bool.Parse(jsonObject["isFileName"]))
                {
                    if (!reffrenceDocumentType.HasValue)
                    {
                        string documentPath = GetDocumentPath(jsonObject["document"]);
                        if (!string.IsNullOrEmpty(documentPath))
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                            stream = new MemoryStream(bytes);

                        }
                        else
                        {
                            return this.Content(jsonObject["document"] + " is not found");

                        }
                    }
                    else
                    {

                        BlobDto data = _documentAppService.GetBlobByRefIdAsync(Guid.Parse(jsonObject["document"]), reffrenceDocumentType.Value).Result;
                        stream = new MemoryStream(data.Content);




                    }

                }
                else
                {
                    byte[] bytes = Convert.FromBase64String(jsonObject["document"]);
                    stream = new MemoryStream(bytes);
                }
            }
              jsonResult = pdfviewer.Load(stream, jsonObject);

            return Content(JsonConvert.SerializeObject(jsonResult));
        }


         [HttpPost]
        [Route("{reffrenceDocumentType}/RenderPdfPages")]
        public IActionResult RenderPdfPages(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Render PDF Page Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            object jsonResult = pdfviewer.GetPage(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }
        

        ////Post action for processing the bookmarks from the PDF documents
        [HttpPost]
        [Route("{reffrenceDocumentType}/Bookmarks")]
        public IActionResult Bookmarks(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BookMarks Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            var jsonResult = pdfviewer.GetBookmarks(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }



        [HttpPost]
        [Route("{reffrenceDocumentType}/Download")]
        //Post action for downloading the PDF documents
        public IActionResult Download(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Download Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            string documentBase = pdfviewer.GetDocumentAsBase64(jsonObject);
            return Content(documentBase);
        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/RenderPdfTexts")]
        public IActionResult RenderPdfTexts(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Render PDF Text Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            object jsonResult = pdfviewer.GetDocumentText(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }


        ////Post action for rendering the ThumbnailImages
        [HttpPost]
        [Route("{reffrenceDocumentType}/RenderThumbnailImages")]
        public IActionResult RenderThumbnailImages(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Render Thumbnail Images Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            object jsonResult = pdfviewer.GetThumbnailImages(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }


        [HttpPost]
        [Route("{reffrenceDocumentType}/RenderAnnotationComments")]

        public IActionResult RenderAnnotationComments(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Render Annotiation Comments Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            //string documentBase = pdfviewer.GetDocumentAsBase64(jsonObject);
            //return Content(documentBase);
            object result = pdfviewer.GetAnnotationComments(jsonObject);
            return Content(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/ExportAnnotations")]

        //Post action to export annotations
        public IActionResult ExportAnnotations(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Export Annotation Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            string result = pdfviewer.ExportAnnotation(jsonObject);
            return Content(result);
        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/ImportAnnotations")]
        //Post action to import annotations
        public IActionResult ImportAnnotations(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Import Annotation Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);

            var jsonObject = JsonConverterstring(response);
            string jsonResult = string.Empty;
            object JsonResult;

            if (jsonObject != null && jsonObject.ContainsKey("fileName"))
            {
                string documentPath = GetDocumentPath(jsonObject["fileName"]);
                if (!string.IsNullOrEmpty(documentPath))
                {
                    jsonResult = System.IO.File.ReadAllText(documentPath);
                }
                else
                {
                    return this.Content(jsonObject["document"] + " is not found");
                }
            }
            else
            {
                string extension = Path.GetExtension(jsonObject["importedData"]);
                if (extension != ".xfdf")
                {
                    var path = configuration.GetSection("Settings").GetSection("Pms.Shared.Path").Value;
                   var reportPath = path + "\\" + "41cfc71d-0444-95a0-3f57-3a0ed44d34f2.json";

                    byte[] bytes = System.IO.File.ReadAllBytes(reportPath);
                    jsonObject["importedData"] = Convert.ToBase64String(bytes);

                    JsonResult = pdfviewer.ImportAnnotation(jsonObject);
                    return Content(JsonConvert.SerializeObject(JsonResult));
                }
                else
                {
                    string documentPath = GetDocumentPath(jsonObject["importedData"]);
                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                        jsonObject["importedData"] = Convert.ToBase64String(bytes);
                        JsonResult = pdfviewer.ImportAnnotation(jsonObject);
                        return Content(JsonConvert.SerializeObject(JsonResult));
                    }
                    else
                    {
                        return this.Content(jsonObject["document"] + " is not found");
                    }
                }
            }
            return Content(jsonResult);
        }

        //[AcceptVerbs("Post")]
        [HttpPost]
        //[Microsoft.AspNetCore.Cors.EnableCors("MyPolicy")]
        [Route("{reffrenceDocumentType}/ExportFormFields")]
        public IActionResult ExportFormFields(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] Dictionary<string, string> jsonObject)

        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Export Form Field Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            string jsonResult = pdfviewer.ExportFormFields(jsonObject);
            return Content(jsonResult);
        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/ImportFormFields")]

        public IActionResult ImportFormFields(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] Dictionary<string, string> jsonObject)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Import From Fields Called");
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            jsonObject["data"] = GetDocumentPath(jsonObject["data"]);
            object jsonResult = pdfviewer.ImportFormFields(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        //[AcceptVerbs("Post")]
        //[HttpPost("Unload")]
        //[Microsoft.AspNetCore.Cors.EnableCors("MyPolicy")]
        //[Route("[controller]/Unload")]
        ////Post action for unloading and disposing the PDF document resources  

        [HttpPost]
        [Route("{reffrenceDocumentType}/Unload")]
        public IActionResult Unload(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unload Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            pdfviewer.ClearCache(jsonObject);
            return this.Content("Document cache is cleared");
        }



        [HttpPost]
        [Route("{reffrenceDocumentType}/PrintImages")]

        //[Microsoft.AspNetCore.Cors.EnableCors("MyPolicy")]
        //Post action for printing the PDF documents
        public IActionResult PrintImages(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] Dictionary<string, string> jsonObject)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Print Images Called");
            //Initialize the PDF Viewer object with memory cache object
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            object pageImage = pdfviewer.GetPrintImage(jsonObject);
            return Content(JsonConvert.SerializeObject(pageImage));
        }

        //Gets the path of the PDF document
        private string GetDocumentPath(string document)
        {
            string documentPath = string.Empty;
            var path = configuration.GetSection("Settings").GetSection("Pms.Shared.Path").Value;
            documentPath = path + "\\" + document;
               return documentPath;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        private Dictionary<string, string> JsonConverterstring(object results)
        {
            Dictionary<string, string> resultObjects = new Dictionary<string, string>();
            //resultObjects = results.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            //    .ToDictionary(prop => prop.Name, prop => prop.GetValue(results, null));
            //var emptyObjects = (from kv in resultObjects
            //                    where kv.Value != null
            //                    select kv).ToDictionary(kv => kv.Key, kv => kv.Value);
            //Dictionary<string, string> jsonResult = emptyObjects.ToDictionary(k => k.Key, k => k.Value.ToString());
            //return jsonResult;
            JsonConvert.PopulateObject(results.ToString(), resultObjects);
            return resultObjects;
        }

        [HttpPost]
        [Route("{reffrenceDocumentType}/SaveDocument")]
        //Post action for Loading the PDF documents   
        public ActionResult SaveDocument(ReffrenceDocumentType? reffrenceDocumentType, [FromBody] object response)
        {
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
            var jsonObject = JsonConverterstring(response);
            string documentBase = pdfviewer.GetDocumentAsBase64(jsonObject);
            string base64String = documentBase.Split(new string[] { "data:application/pdf;base64," }, StringSplitOptions.None)[1];
            if (base64String != null || base64String != string.Empty)
            {
                byte[] byteArray = Convert.FromBase64String(base64String); 
             
                MemoryStream ms = new MemoryStream(byteArray);
                FileDto fileDto = new FileDto()
                {
                    Content = byteArray,
                    ContentType = "application/pdf"
                };
                _documentAppService.UpdateDocumentAsync(Guid.Parse(jsonObject["documentId"]), fileDto);
                //var path = _hostingEnvironment.ContentRootPath;
                //System.IO.File.WriteAllBytes(path + "/test.pdf", byteArray);
            }
            return Content(string.Empty);
        }
    }
    //public class jsonObjects
    //{
    //    public string document { internal get; set; }
    //    public string password { internal get; set; }
    //    public int zoomFactor { internal get; set; }
    //    public bool isFileName { internal get; set; }
    //    public int xCoordinate { internal get; set; }
    //    public int yCoordinate { internal get; set; }
    //    public int pageNumber { internal get; set; }
    //    public int tilexcount { internal get; set; }
    //    public int tileycount { internal get; set; }
    //    public string extratext { internal get; set; }
    //    public string documentId { internal get; set; }
    //    public string hashId { internal get; set; }
    //    public float sizeX { internal get; set; }
    //    public float sizeY { internal get; set; }
    //    public int startPage { internal get; set; }
    //    public int endPage { internal get; set; }
    //    public string stampAnnotations { internal get; set; }
    //    public string textMarkupAnnotations { internal get; set; }
    //    public string stickyNotesAnnotation { internal get; set; }
    //    public string shapeAnnotations { internal get; set; }
    //    public string measureShapeAnnotations { internal get; set; }
    //    public string action { internal get; set; }
    //    public int pageStartIndex { internal get; set; }
    //    public int pageEndIndex { internal get; set; }
    //    public string fileName { internal get; set; }
    //    public string elementId { internal get; set; }
    //    public string pdfAnnotation { internal get; set; }
    //    public string importPageList { internal get; set; }
    //    public string annotationDataFormat { internal get; set; }
    //    public string uniqueId { internal get; set; }
    //    public string data { internal get; set; }
    //    public float viewPortWidth { internal get; set; }
    //    public float viewportHeight { internal get; set; }
    //    public int tilecount { internal get; set; }
    //    public bool isCompletePageSizeNotReceived { internal get; set; }
    //    public string freeTextAnnotation { internal get; set; }
    //    public string signatureData { internal get; set; }
    //    public string fieldsData { internal get; set; }
    //    public string documentLiveCount { internal get; set; }
    //    public string formDesigner { internal get; set; }
    //}
}
