using Application.Users;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Users;

namespace Web.Controllers;

[Route("users")]
public sealed class UsersController(IUsersService usersService) : Controller
{
    [HttpGet, Route("add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost, Route("add")]
    public async Task<IActionResult> Add(UsersAddModel model)
    {
        await usersService.Create(model.Name, model.Password);

        return RedirectToAction("Index", "Employees");
    }
}