using BasicPointOfSale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.BL.IServices;
using PointOfSale.Models;

namespace BasicPointOfSale.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICashRegisterService _cashRegisterService;
        private readonly ITransactionService _transactionService;

        public TransactionController(ICashRegisterService cashRegisterService, ITransactionService transactionService)
        {
            _cashRegisterService = cashRegisterService;
            _transactionService = transactionService;
        }
        // GET: TransactionController
        public async Task<ActionResult> Index(DateTime date, string description)
        {
            try
            {
                int? BusinessUnitId = HttpContext.Session.GetInt32("BusinessUnitId");
                if (BusinessUnitId == null) return RedirectToAction("Index", "BusinessUnit");

                var list = await _transactionService.TransactionHistory((int)BusinessUnitId, date, description);
                var model = new TransactionListVM()
                {
                    BusinessUnitId = BusinessUnitId,
                    Transactions = list.OrderByDescending(s => s.DateTime).ToList()
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: TransactionController/Details/5
        public async Task<ActionResult> TransactionDetails()
        {
            return View();
        }

        // GET: TransactionController/Create
        public async Task<ActionResult> NewExpense(int BusinessUnitId)
        {
            try
            {
                var model = new Transaction()
                {
                    BusinessUnitId = BusinessUnitId
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewExpense(Transaction transaction)
        {
            try
            {
                if (!transaction.Amount.HasValue) transaction.Amount = 0;
                var amount = transaction.Amount;
                var result = await _transactionService.AddExpense(transaction);
                var cashRegister = await _cashRegisterService.AddExpense(transaction.BusinessUnitId, amount);

                return RedirectToAction("Index", "Transaction" );
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Create
        public async Task<ActionResult> NewIncome(int BusinessUnitId)
        {
            try
            {
                var model = new Transaction()
                {
                    BusinessUnitId = BusinessUnitId
                };
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewIncome(Transaction transaction)
        {
            try
            {
                if (!transaction.Amount.HasValue) transaction.Amount = 0;
                var amount = transaction.Amount;
                var result = await _transactionService.AddIncome(transaction);
                var cashRegister = await _cashRegisterService.AddIncome(transaction.BusinessUnitId, amount);

                return RedirectToAction("Index", "Transaction");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return RedirectToAction(nameof(Index));
            //return View();
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Delete/5
        public async Task<ActionResult> DeleteTransaction(int id)
        {

            return View();
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTransaction(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
