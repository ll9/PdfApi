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
            var html = "<h1>bla✓</h1>";
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
            <!DOCTYPE html>
            <html>
            <head>
            	<title>Minimal Resume Template</title>
            	<link rel="stylesheet" type="text/css" href="/styles.css">
            	<meta name="viewport" content="width=device-width, initial-scale=1.0">
            </head>

            <style>
                        html, body {
                            -webkit-print-color-adjust: exact !important;
                        }
            /* https://newtodesing.com/ 
               v2.0 | 20110126
               License: none (public domain)
            */



            /*Load google font*/
            @import url('https://fonts.googleapis.com/css?family=Lato:300,400,700');



            /* Reset Styles */

            html, body, div, span, applet, object, iframe,
            h1, h2, h3, h4, h5, h6, p, blockquote, pre,
            a, abbr, acronym, address, big, cite, code,
            del, dfn, em, img, ins, kbd, q, s, samp,
            small, strike, strong, sub, sup, tt, var,
            b, u, i, center,
            dl, dt, dd, ol, ul, li,
            fieldset, form, label, legend,
            table, caption, tbody, tfoot, thead, tr, th, td,
            article, aside, canvas, details, embed, 
            figure, figcaption, footer, header, hgroup, 
            menu, nav, output, ruby, section, summary,
            time, mark, audio, video {
            	margin: 0;
            	padding: 0;
            	border: 0;
            	font-size: 100%;
            	font: inherit;
            	vertical-align: baseline;
            }
            /* HTML5 display-role reset for older browsers */
            article, aside, details, figcaption, figure, 
            footer, header, hgroup, menu, nav, section {
            	display: block;
            }
            a{
            	text-decoration: none;
            	text-transform: none;
            	color: #4A90E2;
            }

            body {
            	line-height: 1;
            	font-family: lato, ubuntu,-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Oxygen,Ubuntu,Cantarell,Open Sans,Helvetica Neue,sans-serif;
            	text-rendering : optimizeLegibility;
            	-webkit-font-smoothing : antialiased;
            	font-size: 19px;
            	background-color: #FEFEFE;
            	color: #04143A;
            }
            ol, ul {
            	list-style: none;
            }
            blockquote, q {
            	quotes: none;
            }
            blockquote:before, blockquote:after,
            q:before, q:after {
            	content: '';
            	content: none;
            }
            table {
            	border-collapse: collapse;
            	border-spacing: 0;
            }

            p {
            	color: #15171a;
            	font-size: 17;
            	line-height: 31px;
            }

            strong {
            	font-weight: 600;
            }

            div , footer {
            	box-sizing: border-box;
            }

            /* Reset ends */


            /*Hero section*/

            .container {
            	max-width: 1100px;
            	height: auto;
            	margin: 60px auto;
            }

            .hero {
            	margin: 50px auto; 
            	position: relative;
            }

            h1.name {
            	font-size: 70px;
            	font-weight: 300;
            	display: inline-block;
            }

            .job-title {
            	vertical-align: top;
            	background-color: #D9E7F8;
            	color: #4A90E2;
            	font-weight: 600;
            	margin-top: 5px;
            	margin-left: 20px;
            	border-radius: 5px;
            	display: inline-block;
            	padding: 15px 25px;
            }

            .email {
            	display: block;
            	font-size: 24px;
            	font-weight: 300;
            	color: #81899C;
            	margin-top: 10px;
            }

            .lead {
            	font-size: 44px;
            	font-weight: 300;
            	margin-top: 60px;
            	line-height: 55px;
            }

            /*hero ends*/

            /*skills & intrests*/

            .sections {
            	vertical-align: top;
            	display: inline-block;
            	width: 49.7%;
            	height: 50px;
            }

            .section-title {
            	font-size: 20px;
            	font-weight: 600;
            	margin-bottom: 15px;
            }

            .list-card {
            	margin: 30px 0;
            }

            .list-card .exp , .list-card div{
            	display: inline-block;
            	vertical-align: top;
            }

            .list-card .exp {
            	margin-right: 15px;
            	color: #4A90E2;
            	font-weight: 600;
            	width: 100px;
            }

            .list-card div {
            	width: 70%;
            }

            .list-card h3 {
            	font-size: 20px;
            	font-weight: 600;
            	color: #5B6A9A;
            	line-height: 26px;
            	margin-bottom: 8px;
            }

            .list-card div span {
            	font-size: 16px;
            	color: #81899C;
            	line-height: 22px;
            }

            /*skill and intrests ends*/

            /* Achievements */


            .cards {
            	max-width: 1120px;
            	display: block;
            	margin-top: 280px;
            }

            .card {
            	width: 47.9%;
            	height: 200px;
            	background-color: #EEF0F7;
            	display: inline-block;
            	margin: 7px 5px;
            	vertical-align: top;
            	border-radius: 10px;
            	text-align: center;
            	padding-top: 50px
            }

            .card-active , .card:hover{
            	transform: scale(1.02);
            	transition: 0.5s;
            	background-color: #fff;
            	box-shadow: 0px 5px 50px -8px #ddd;
            	cursor: pointer;
            }


            .skill-level {
            	display: inline-block;
            	max-width: 160px;
            }

            .skill-level span {
            	font-size: 35px;
            	font-weight: 300;
            	color: #5B6A9A;
            	vertical-align: top;
            }

            .skill-level h2 {
            	font-size: 95px;
            	font-weight: 300;
            	display: inline-block;
            	vertical-align: top;
            	color: #5B6A9A;
            	letter-spacing: -5px;
            }

            .skill-meta {
            	vertical-align: top;
            	display: inline-block;
            	max-width: 300px;
            	text-align: left;
            	margin-top: 15px;
            	margin-left: 15px;
            }

            .skill-meta h3 {
            	font-size: 20px;
            	font-weight: 800;
            	color: #5B6A9A;
            	margin-bottom: 5px;
            }

            .skill-meta span{
            	color: #81899C;
            	line-height: 20px;
            	font-size: 16px;
            }

            /* Achievements ends */



            /* Timeline styles*/


            ol {
            	position: relative;
            	display: block;
            	margin: 100px 0;
            	height: 2px;
            	background: #EEF0F7;

            }
            ol::before,
            ol::after {
            	content: "";
            	position: absolute;
            	top: -10px;
            	display: block;
            	width: 0;
            	height: 0;
              	border-radius: 10px;
            	border: 0px solid #31708F;
            }
            ol::before {
            	left: -5px;
            }
            ol::after {
            	right: -10px;
            	border: 0px solid transparent;
            	border-right: 0;
            	border-left: 20px solid #31708F;
              	border-radius: 3px;
            }

            /* ---- Timeline elements ---- */
            li {
            	position: relative;
            	display: inline-block;
            	float: left;
            	width: 25%;
              	height: 50px;
            }
            li .line {
              position: absolute;
              top: -47px;
              left: 1%;
              font-size: 20px;
              font-weight: 600;
              color: #04143A;
            }
            li .point {
            	content: "";
            	top: -7px;
            	left: 0%;
            	display: block;
            	width: 8px;
            	height: 8px;
            	border: 4px solid #fff;
            	border-radius: 10px;
            	background: #4A90E2;
              position: absolute;
            }
            li .description {
              display: none;
              padding: 10px 0;
              margin-top: 20px;
              position: relative;
              font-weight: normal;
              z-index: 1;
              max-width: 95%;
              font-size: 18px;
              font-weight: 600;
              line-height: 25px;
              color: #5B6A9A;
            }
            .description::before {
              content: '';
              width: 0; 
              height: 0; 
              border-left: 5px solid transparent;
              border-right: 5px solid transparent;
              border-bottom: 5px solid #f4f4f4;
              position: absolute;
              top: -5px;
              left: 43%;
            }


            .timeline .date{
            	font-size: 14px;
            	color: #81899C;
            	font-weight: 300;
            }

            /* ---- Hover effects ---- */
            li:hover {
              color: #48A4D2;
            }
            li .description {
              display: block;
            }

            /*timeline ends*/



            /* Media queries*/

            @media(max-width: 1024px){
            	.container {
            		padding: 15px;
            		margin: 0px auto;
            	}
            	.cards {
            		margin-top: 250px;
            	}
            }

            @media(max-width: 768px){
            	.container {
            		padding: 15px;
            		margin: 0px auto;
            	}
            	.cards {
            		margin-top: 320px;
            	}

            	.card {
            		padding: 15px;
            		text-align: left;
            	}
            	.card h2 {
            		font-size: 70px;
            	}
            		.card , .sections {
            		width: 100%;
            		height: auto;
            		margin: 10px 0;
            		float: left;
            	}

            	.timeline{
            		border: none;
            		background-color: rgba(0,0,0,0);
            	}

            	.timeline li{
            		margin-top: 70px;
            		height: 150px;
            	}
            }


            @media(max-width: 425px) {
            	h1.name {
            		font-size: 40px;
            	}

            	.card , .sections {
            		width: 100%;
            		height: auto;
            		margin: 10px 0;
            		float: left;
            	}

            	.timeline{
            		display: none;
            		}

            	.job-title {
            		position: absolute;
            		font-size: 15px;
            		top: -40px;
            		right: 20px;
            		padding: 10px
            	}

            	.lead {
            		margin-top: 15px;
            		font-size: 20px;
            		line-height: 28px;
            	}
            	.container {
            		margin: 0px;
            		padding: 0 15px;
            	}
            	footer {
            		margin-top: 2050px;
            	}
            	}


            /* End of all :P*/
            </style>
            <body>

            	<div class="container">
            		<div class="hero">
            			<h1 class="name"><strong>Abbie</strong> Bradley</h1>
            			<span class="job-title">Developer</span>
            			<span class="email">abbie.bradley@gmail.com</span>

            			<h2 class="lead">Development and design of web applications 
            for startups and large companies</h2>
            		</div>
            	</div>

            <!-- Skills and intrest section -->
            	<div class="container">

            		<div class="sections">
            			<h2 class="section-title">Skills</h2>

            			<div class="list-card">
            				<span class="exp">+ 5 years</span>
            				<div>
            					<h3>Object programming & frameworks</h3>
            					<span>PHP, Symfony, Laravel, Silex, …</span>
            				</div>
            			</div>

            			<div class="list-card">
            				<span class="exp">+ 3 years</span>
            				<div>
            					<h3>Design integration</h3>
            					<span>Style and tools, JS Frameworks</span>
            				</div>
            			</div>	

            			<div class="list-card">
            				<span class="exp">+ 6 years</span>
            				<div>
            					<h3>Linux</h3>
            					<span>Scripting, Servers management and protocols, Automation</span>
            				</div>
            			</div>


            		</div>
            		<div class="sections">
            				<h2 class="section-title">Interests</h2>

            				<div class="list-card">
            					<div>
            						<h3>Scripting languages</h3>
            						<span>PHP, JS, Bash, Python</span>
            					</div>
            				</div>	

            				<div class="list-card">
            					<div>
            						<h3>Hacking</h3>
            						<span>Linux, Crawlers, Bots, Network</span>
            					</div>
            				</div>		
            		</div>
            	</div>

            	<!-- Achievements -->

            	<div class="container cards">

            		<div class="card">
            			<div class="skill-level">
            				<span>+</span>
            				<h2>60</h2>
            			</div>

            			<div class="skill-meta">
            				<h3>Projects</h3>
            				<span>Adapting and creating solutions for customer's needs</span>
            			</div>
            		</div>


            		<div class="card">
            			<div class="skill-level">
            				<h2>50</h2>
            				<span>%</span>
            			</div>

            			<div class="skill-meta">
            				<h3>Web</h3>
            				<span>Applications development integrating third-party services and mobile client(s)</span>
            			</div>
            		</div>


            		<div class="card">
            			<div class="skill-level">
            				<h2>30</h2>
            				<span>%</span>
            			</div>

            			<div class="skill-meta">
            				<h3>Technical solutions</h3>
            				<span>Such as web services, scripts, configurations</span>
            			</div>
            		</div>


            		<div class="card">
            			<div class="skill-level">
            				<h2>20</h2>
            				<span>%</span>
            			</div>

            			<div class="skill-meta">
            				<h3>Leading</h3>
            				<span>Web projects and ensure the quality of delivery</span>
            			</div>
            		</div>

            	</div>

            	<!-- Timeeline -->

            	<div class="container">
            		<ol class="timeline">
            		  <li>
            		    <p class="line">Experiences</p>
            		    <span class="point"></span>
            		    <p class="description">
            		      Lead Developer @Geronimo
            		    </p>
            		    <span class="date">Today - Apr. 2016</span>
            		  </li>

            		  <li>
            		    <span class="point"></span>
            		    <p class="description">
            		      Freelance
            		    </p>
            		    <span class="date">Apr. 2016 - Sep. 2015</span>
            		  </li>

            		  		  <li>
            		    <p class="line">Education</p>
            		    <span class="point"></span>
            		    <p class="description">
            		      DUT "Métiers du multimédia et de l'internet"
            		    </p>
            		    <span class="date">2015 - 2013</span>
            		  </li>

            		  		  <li>
            		    <span class="point"></span>
            		    <p class="description">
            		      Art & Design studies
            		    </p>
            		    <span class="date">2013 - 2008</span>
            		  </li>
            		</ol>

            	</div>


            	<br><br>


            	<footer class="container">
            		<span style="font-size: 16px; margin-top: ">Coded by <a href="https://newtodesign.com/">New to design </a> Designed by <a href="https://dribbble.com/shots/4342703-Minimal-resume-freebie-for-junior-self-taught-people">Nicolas Meuzard</a></span>
            	</footer>


            </body>
            </html>
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