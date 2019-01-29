using LumiraDX.Models;
using LumiraDX.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LumiraDX.Controllers
{
    public class HomeController : Controller
    {
        private IMathsService _mathsService;

        #region Constructor
        public HomeController(IMathsService mathsService)
        {
            _mathsService = mathsService;            
        }
        #endregion 

        #region Actions
        public IActionResult Index()
        {
            var model = new OperationViewModel();
            return View(model);            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OperationViewModel operationViewModel)
        {
            // Perform the calculation
            OperationResult operationResult = _mathsService.PerformOperation(
                new Operation() { OperandValue1 = operationViewModel.OperandValue1,
                                OperatorType = (OperatorType)System.Enum.Parse(typeof(OperatorType), operationViewModel.Operator),
                                OperandValue2 = operationViewModel.OperandValue2 });

            // Formulate a View Model for use
            OperationViewModel fullResult = new OperationViewModel()
            {
                Message = operationResult.Message,
                Result = operationResult.Result,
                OperandValue1 = operationResult.Operation.OperandValue1,
                OperandValue2 = operationResult.Operation.OperandValue2

            };        
            
            return View("Index", fullResult);
        }   
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion 
    }

}
