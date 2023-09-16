using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NavtexApp.Services;

namespace NavtexApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICoordinateParserService _coordinateParserService;

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public string NavtexMessage { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ICoordinateParserService coordinateParserService)
        {
            _logger = logger;
            _coordinateParserService = coordinateParserService;
        }


        public async Task OnPostAsync()
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                using var reader = new StreamReader(UploadedFile.OpenReadStream());
                NavtexMessage = await reader.ReadToEndAsync();
                NavtexMessage = _coordinateParserService.Highlight(NavtexMessage);
                
            }
        }

    }
}