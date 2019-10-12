using Microsoft.AspNetCore.Mvc;

namespace EquipmentReservation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}