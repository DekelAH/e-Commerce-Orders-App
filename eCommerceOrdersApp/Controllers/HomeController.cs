using eCommerceOrdersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceOrdersApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index([Bind] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }

            //return Content($"Order: {order}");
            return Content($"Order: {order.OrderNumber}");
        }
    }
}
