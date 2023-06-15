using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoanCalculator.Models;
using LoanCalculator.Helpers;

namespace LoanCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public ActionResult App()
    {
        Loan loan = new Loan();

        loan.Amount = 1300m;
        loan.Rate = 3.1m;
        loan.Term = 60;
        loan.Payment = 0.0m;
        loan.TotalInterest = 0.0m;
        loan.TotalCost = 0.0m;

        return View(loan);
    }

    [HttpPost]
    [ActionName("App")]
    [AutoValidateAntiforgeryToken]
    public ActionResult App(Loan loan)
    {
        // Calculate the loan and get the payments
        var loanHelper = new LoanHelper();

        Loan newLoan = loanHelper.GetPayments(loan);

        return View(newLoan);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

