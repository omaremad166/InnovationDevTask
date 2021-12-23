#nullable disable
using Microsoft.AspNetCore.Mvc;
using InnovationDevTask.Models;
using InnovationDevTask.Core;

namespace InnovationDevTask.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Orders.GetAll());
        }

        public IActionResult Details(int id)
        {
            var order =  _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderId,OrderSerialNo,OrderStatus,ShippingStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Orders.Add(order);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderId,OrderSerialNo,OrderStatus,ShippingStatus")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Orders.Update(order);
                _unitOfWork.Complete();
                
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Orders.Delete(id);
            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }
    }
}
