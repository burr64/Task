using Microsoft.AspNetCore.Mvc;
using Task.BLL.DTO;
using Task.BLL.Interfaces;

namespace Task.Controllers;

public class OrdersController : Controller
    {
        private readonly IEntityService<OrdersDto> _orderService;

        public OrdersController(IEntityService<OrdersDto> orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAll();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _orderService.GetById(id);

            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrdersDto orderDto)
        {
            if (ModelState.IsValid)
            {
                _orderService.Create(orderDto);
                return RedirectToAction(nameof(Index));
            }

            return View(orderDto);
        }

        public IActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrdersDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderService.Update(orderDto);
                return RedirectToAction(nameof(Index));
            }

            return View(orderDto);
        }

        public IActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteConfirmed()
        {
            throw new NotImplementedException();
        }
    }