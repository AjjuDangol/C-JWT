using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupAssignments.Views.Account
{
    public class VerifyModel : PageModel
    {
        public string Code { get; internal set; }
        public string VerificationCode { get; internal set; }

        public void OnGet()
        {
        }
    }
}
