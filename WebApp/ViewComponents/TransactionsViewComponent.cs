using System;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.TransactionsUseCases;

namespace WebApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;

        public TransactionsViewComponent(IGetTodayTransactionsUseCase getTodayTransactionsUseCase)
        {
            this.getTodayTransactionsUseCase = getTodayTransactionsUseCase;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var transactions = getTodayTransactionsUseCase.Execute(userName);
            
            return View(transactions);
        }
        // public IViewComponentResult Invoke(string userName)
        // {
        //     //Console.WriteLine(userName);
        //     var transactions = TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
        //     //Console.WriteLine(transactions);
        //     return View(transactions);
        // }

    }
}