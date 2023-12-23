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
        public async Task<ActionResult> TransactionDetails(int TransactionId)
        {
            try
            {
                var model = await _transactionService.GetTransaction(TransactionId);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> NewExpense(int BusinessUnitId)
        {
            try
            {
                var cashRegisterList = await _cashRegisterService.CashRegisterList(BusinessUnitId);
                //var cashRegisterNames = cashRegisterList.Select(n => n.Name);
                ViewBag.CashRegisterList = cashRegisterList.ToList();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewExpense(Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //inicializando la cashregister
                    if (!transaction.Amount.HasValue) transaction.Amount = 0; //TODO: esta validacion debería estar en la view o un required en la entidad
                    //var amount = transaction.Amount;
                    var result = await _transactionService.AddExpense(transaction); //crea una transaccion y esta funcionando

                    var cashRegister = await _cashRegisterService.AddExpense(transaction.BusinessUnitId, transaction.Amount);

                    return RedirectToAction("Index", "Transaction");
                }
                return View(transaction);

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
                var cashRegisterList = await _cashRegisterService.CashRegisterList(BusinessUnitId);
                //var cashRegisterNames = cashRegisterList.Select(n => n.Name);
                ViewBag.CashRegisterList = cashRegisterList.ToList();
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
                if (ModelState.IsValid)
                {
                    if (!transaction.Amount.HasValue) transaction.Amount = 0;
                    var amount = transaction.Amount;
                    var result = await _transactionService.AddIncome(transaction);
                    var cashRegister = await _cashRegisterService.AddIncome(transaction.BusinessUnitId, amount);

                    return RedirectToAction("Index", "Transaction");
                }
                return View(transaction);

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
        public async Task<ActionResult> DeleteTransaction(int TransactionId)
        {

            try
            {
                var model = await _transactionService.GetTransaction(TransactionId);
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
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
