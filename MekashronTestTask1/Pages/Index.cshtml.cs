    using IcuTech;
using MekashronTestTask1.Models;
using MekashronTestTask1.Models.Requests;
    using MekashronTestTask1.Models.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using System.Text.Json.Serialization;

namespace MekashronTestTask1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
     
        private readonly ICUTechClient _icuTechClient;

        [BindProperty]
        public LoginDto Input { get; set; } = new();

        public string ResultMessage { get; set; } = string.Empty;

        public ResponseStatus ResponseStatus { get; set; } = ResponseStatus.Undefined;

        public CustomerInfoResponse? CustomerInfoResponse { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICUTechClient icuTechClient)
        {
            _logger = logger;
            _icuTechClient = icuTechClient;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var response = await _icuTechClient.LoginAsync(Input.Username, Input.Password, string.Empty);
                var customerInfoResponse = JsonConvert.DeserializeObject<CustomerInfoResponse>(response.@return);
                if (customerInfoResponse == null)
                {
                    ResponseStatus = ResponseStatus.Error;
                    ResultMessage = "Server error. Reload the page, or try later";

                    return Page();
                }

                ResponseStatus = customerInfoResponse.EntityId != 0 
                    ? ResponseStatus.Success 
                    : customerInfoResponse.ResponseStatus;

                CustomerInfoResponse = customerInfoResponse;
            }
            catch (Exception ex)
            {
                ResponseStatus = ResponseStatus.InternalError;
                ResultMessage = "Internal server error. Reload the page, or try later";
                _logger.LogError(ex, "Login error");
            }

            return Page();
        }
    }
}
