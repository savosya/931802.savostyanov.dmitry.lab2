using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace lab2.Controllers
{
    public class CalculateController : Controller
    {

        public IActionResult Manual()
        {
            if (Request.Method == "POST")
            {
                var model = new CalcModel
                {
                    a = Convert.ToInt32(HttpContext.Request.Form["a"]),
                    Operation = HttpContext.Request.Form["operation"],
                    b = Convert.ToInt32(HttpContext.Request.Form["b"])
                };
                ViewBag.Result = model.Calculate();
                return View("Result");
            }

            return View("HtmlHelpers");
        }
        [HttpGet]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualWithSeparateHandlersGet()
        {
            return View("HtmlHelpers");
        }
        [HttpPost]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualWithSeparateHandlersPost()
        {
            var model = new CalcModel
            {
                a = Convert.ToInt32(HttpContext.Request.Form["a"]),
                Operation = HttpContext.Request.Form["operation"],
                b = Convert.ToInt32(HttpContext.Request.Form["b"])
            };
            ViewBag.Result = model.Calculate();
            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View("HtmlHelpers");
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(int a, string operation, int b)
        {
            if (ModelState.IsValid)
            {
                var model = new CalcModel
                {
                    a = a,
                    Operation = operation,
                    b = b
                };
                ViewBag.Result = model.Calculate();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View("TagHelpers");
        }
        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalcModel model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Calculate()
                : "Invalid input";

            return View("Result");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
