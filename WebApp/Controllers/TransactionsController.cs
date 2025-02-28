using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using WebApp.ViewModels;
using UseCases;
using UseCases.TransactionsUseCases;
using WebApp.Models;

public class TransactionsController : Controller
{
    private readonly ISearchTransactionsUseCase searchTransactionsUseCase;
    // GET
    public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
    {
        this.searchTransactionsUseCase = searchTransactionsUseCase;
    }

    public IActionResult Index()
    {
        TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
        return View(transactionsViewModel);
        
    }

    public IActionResult Search(TransactionsViewModel transactionsViewModel)
    {
        var transactions = searchTransactionsUseCase.Execute(
            transactionsViewModel.CashierName??string.Empty,
            transactionsViewModel.StartDate,
            transactionsViewModel.EndDate);
        transactionsViewModel.Transactions = transactions;
        
        return View("Index",transactionsViewModel);
    }
}