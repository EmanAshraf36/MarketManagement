using System;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;
using CoreBusiness;
namespace WebApp.Controllers;

public class CategoriesController : Controller
{
    private readonly IViewCategoriesUseCase viewCategoriesUseCase;
    private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
    private readonly IEditCategoryUseCase editCategoryUseCase;
    private readonly IAddCategoryUseCase addCategoryUseCase;
    private readonly IDeleteCategoryUseCase deleteCategoryUseCase;
    // GET
    public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase, IViewSelectedCategoryUseCase viewSelectedCategoryUseCase, IEditCategoryUseCase editCategoryUseCase, IAddCategoryUseCase addCategoryUseCase, IDeleteCategoryUseCase deleteCategoryUseCase)
    {
        this.viewCategoriesUseCase = viewCategoriesUseCase;
        this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
        this.editCategoryUseCase = editCategoryUseCase;
        this.addCategoryUseCase = addCategoryUseCase;
        this.deleteCategoryUseCase = deleteCategoryUseCase;
    }

    public IActionResult Index()
    {
        var categories = viewCategoriesUseCase.Execute();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        ViewBag.Action = "edit";
        var category = viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);
                return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        Console.WriteLine("a7a");
        if(ModelState.IsValid)
        {
            ViewBag.Action = "edit";
            editCategoryUseCase.Execute(category.CategoryId, category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Action = "add";
        return View();
    }
    [HttpPost]
    public IActionResult Add(Category category)
    {
        if(ModelState.IsValid)
        {
            addCategoryUseCase.Execute(category);
            return RedirectToAction("Index");
        }
        ViewBag.Action = "add";
        return View(category);
    }
    
    public IActionResult Delete(int categoryId)
    {
        deleteCategoryUseCase.Execute(categoryId);
        return RedirectToAction("Index");
        
    }
}