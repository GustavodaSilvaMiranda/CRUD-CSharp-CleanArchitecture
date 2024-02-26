using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjChoc.Application.Interfaces;
using ProjChoc.Application.ViewModels;

namespace ProjChoc.MVC.Controllers;

public class ProductsController : Controller
{
	private readonly IProductService _productService;
	public ProductsController(IProductService productAppService)
	{
		_productService = productAppService;
	}

	[HttpGet]
	[Authorize]
	public async Task<IActionResult> Index()
	{
		var result = await _productService.GetProducts();
		return View(result);
	}

	[HttpGet]
	[Authorize]
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	[Authorize]
	public IActionResult Create([Bind("Id,Name,Description,Price")] ProductViewModel product)
	{
		if (ModelState.IsValid)
		{
			_productService.Add(product);
			return RedirectToAction(nameof(Index));
		}
		return View(product);
	}
	[HttpGet]
	[Authorize]
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null) return NotFound();
		var productVM = await _productService.GetById(id);
		if (productVM == null) return NotFound();
		return View(productVM);
	}
	[HttpPost]
	[Authorize]
	public IActionResult Edit([Bind("Id,Name,Description,Price")] ProductViewModel productVM)
	{
		if (ModelState.IsValid)
		{
			try
			{
				_productService.Update(productVM);
			}
			catch (Exception)
			{
				throw;
			}
			return RedirectToAction(nameof(Index));
		}
		return View(productVM);
	}

	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var ProductVM = await _productService.GetById(id);
		if (ProductVM == null)
		{
			return NotFound();
		}
		return View(ProductVM);
	}
	[HttpGet]
	[Authorize]
	public async Task<IActionResult> Delete(int? id)
	{
		if(id == null) 
			return NotFound();
		var productVM = await _productService.GetById(id);
		if (productVM == null) return NotFound();
		return View(productVM);
	}
	[HttpPost, ActionName("Delete")]
	public IActionResult DeleteConfirmed(int id)
	{
		_productService.Remove(id);
		return RedirectToAction(nameof(Index));
	}
}
