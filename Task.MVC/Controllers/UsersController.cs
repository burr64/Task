using Microsoft.AspNetCore.Mvc;
using Task.BLL.DTO;
using Task.BLL.Interfaces;

namespace Task.Controllers;

public class UsersController : Controller
    {
        private readonly IEntityService<UsersDto> _userService;

        public UsersController(IEntityService<UsersDto> userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetById(id);

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersDto userDto)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(userDto);
                return RedirectToAction(nameof(Index));
            }

            return View(userDto);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, UsersDto userDto)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.Update(userDto);
                return RedirectToAction(nameof(Index));
            }

            return View(userDto);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteConfirmed()
        {
            throw new NotImplementedException();
        }
    }