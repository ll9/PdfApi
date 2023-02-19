using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;

namespace PdfApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("1")]
        public async Task<ActionResult> Get()
        {
            var html = "<h1>bla</h1>";
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }


        [HttpGet("2")]
        public async Task<ActionResult> Get2()
        {
            var html = """
               <h1 style="color: red; margin-left: 10px; background: blue">bla</h1>
               <p>This is <strong>important</strong></p>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        [HttpGet("3")]
        public async Task<ActionResult> Get3()
        {
            var html = """
            <table style="border-collapse: collapse; width: 100%; border-width: 1px; background-color: #ECF0F1;" border="1">
                <colgroup>
                    <col style="width: 50%;">
                    <col style="width: 50%;">
                </colgroup>
                <tbody>
                    <tr>
                        <td style="border-width: 1px;">Nummer</td>
                        <td style="border-width: 1px;">02</td>
                    </tr>
                    <tr>
                        <td style="border-width: 1px;">Bezeichnung</td>
                        <td style="border-width: 1px;">Wohngeb&auml;ude</td>
                    </tr>
                </tbody>
            </table>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        [HttpGet("4")]
        public async Task<ActionResult> Get4()
        {
            var html = """
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                        html, body {
                            -webkit-print-color-adjust: exact !important;
                        }
                </style>
            </head>
            <body>
                <p style="background: red; color: white">Lipsum....</p>
                <p style="background: blue">Lipsum....</p>
            </body>
            </html>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        [HttpGet("5")]
        public async Task<ActionResult> Get5()
        {
            var html = """
                <style>
                        html, body {
                            -webkit-print-color-adjust: exact !important;
                        }
                </style>
            <table style="border-collapse: collapse; width: 100%; border-width: 1px; background-color: #ECF0F1;" border="1">
                <colgroup>
                    <col style="width: 50%;">
                    <col style="width: 50%;">
                </colgroup>
                <tbody>
                    <tr>
                        <td style="border-width: 1px;">Nummer</td>
                        <td style="border-width: 1px;">02</td>
                    </tr>
                    <tr>
                        <td style="border-width: 1px;">Bezeichnung</td>
                        <td style="border-width: 1px;">Wohngeb&auml;ude</td>
                    </tr>
                </tbody>
            </table>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        [HttpGet("6")]
        public async Task<ActionResult> Get6()
        {
            var html = """
            <head>
                        <link rel="preconnect" href="https://fonts.googleapis.com">
                        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
                        <link href="https://fonts.googleapis.com/css2?family=Gloock&display=swap" rel="stylesheet">
            </head>
                <style>
                        html, body {
                            -webkit-print-color-adjust: exact !important;
                            font-family: 'Gloock', serif;
            
                        }
                </style>
            <p>&nbsp;</p>
            <p>Geb&auml;ude</p>
            <hr>
            <table style="border-collapse: collapse; width: 100%; border-width: 0px; height: 72px;" border="1"><colgroup><col style="width: 50%;"><col style="width: 21.8062%;"><col style="width: 28.1938%;"></colgroup>
            <tbody>
            <tr style="height: 18px;">
            <td style="border-width: 0px; height: 18px;">Nummer</td>
            <td style="border-width: 0px; text-align: right; height: 18px;">02</td>
            <td style="border-width: 0px; text-align: right; height: 72px;" rowspan="4"><br><img src="https://www.sixdata.de/api/assets/6c9fe38a-53e8-4ee5-9fe9-c3719495eba3" width="200" height="120"></td>
            </tr>
            <tr style="background-color: rgb(236, 240, 241); height: 18px;">
            <td style="border-width: 0px; height: 18px;">Bezeichnung</td>
            <td style="border-width: 0px; text-align: right; height: 18px;">Wohngeb&auml;ude</td>
            </tr>
            <tr style="height: 18px;">
            <td style="border-width: 0px; height: 18px;">Liegenschaft</td>
            <td style="border-width: 0px; text-align: right; height: 18px;">Gewerbe</td>
            </tr>
            <tr style="background-color: rgb(236, 240, 241); height: 18px;">
            <td style="border-width: 0px; height: 18px;">Stra&szlig;e</td>
            <td style="border-width: 0px; text-align: right; height: 18px;">Seestra&szlig;e</td>
            </tr>
            </tbody>
            </table>
            <p>&nbsp;</p>
            <table style="border-collapse: collapse; width: 100%; height: 36px; border-width: 0px;" border="1"><colgroup><col style="width: 25.0276%;"><col style="width: 22.3815%;"><col style="width: 3.19942%;"><col style="width: 24.5845%;"><col style="width: 24.8071%;"></colgroup>
            <tbody>
            <tr style="height: 18px;">
            <td style="height: 18px; border-width: 0px;">Geb&auml;udeart</td>
            <td style="text-align: right; height: 18px; border-width: 0px;">Art1</td>
            <td style="text-align: right; border-width: 0px;">&nbsp;</td>
            <td style="height: 18px; border-width: 0px;">Gutachten</td>
            <td style="text-align: right; height: 18px; border-width: 0px;">Neu</td>
            </tr>
            <tr style="height: 18px; background-color: rgb(236, 240, 241);">
            <td style="height: 18px; border-width: 0px;">Nutzungsart</td>
            <td style="text-align: right; height: 18px; border-width: 0px;">Nutzbar</td>
            <td style="text-align: right; border-width: 0px;">&nbsp;</td>
            <td style="height: 18px; border-width: 0px;">Datum</td>
            <td style="text-align: right; height: 18px; border-width: 0px;">01.01.2023</td>
            </tr>
            </tbody>
            </table>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        [HttpGet("7")]
        public async Task<ActionResult> Get7()
        {
            var html = """
                <style>
                        html, body {
                        margin: 0;
                        padding: 0;
                            -webkit-print-color-adjust: exact !important;
                        }
                </style>
            <div style="display: flex">
              <div>
                blablabla
              </div>
              <div style="flex: 1; background: red">
                2
              </div>
                <div>
                blablabla
              </div>
            </div>
            """;
            var stream = await GetHtmlStream(html);
            return File(stream, "application/pdf");
        }

        private async Task<Stream> GetHtmlStream(string html)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });

            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);
            // wait for google font to load
            await Task.Delay(1000);

            await page.PdfAsync("C:\\Users\\wierer\\Desktop\\DESKTOP\\file1.pdf");

            return await page.PdfStreamAsync();
        }
    }
}