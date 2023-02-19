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

        private async Task<Stream> GetHtmlStream(string html)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });

            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);

            return await page.PdfStreamAsync();
        }
    }
}