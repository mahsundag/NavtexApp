using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NavtexApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public string NavtexMessage { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public async Task OnPostAsync()
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                using var reader = new StreamReader(UploadedFile.OpenReadStream());
                NavtexMessage = await reader.ReadToEndAsync();

                
            }
        }

    }
}