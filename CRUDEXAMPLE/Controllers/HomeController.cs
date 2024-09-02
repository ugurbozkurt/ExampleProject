using CRUDEXAMPLE.Data.Models;
using CRUDEXAMPLE.Models;
using CRUDEXAMPLE.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDEXAMPLE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskDataService   _taskDataService;
        public HomeController(ILogger<HomeController> logger,ITaskDataService taskdataservice)
        {
            _logger = logger;
            _taskDataService = taskdataservice;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _taskDataService.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return PartialView("_Add");
            }
            else
            {
                var model = await _taskDataService.GetByIdAsync(id.Value);
				return PartialView("_Add",model);
			}
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskDataModel taskDataModel)
        {
            if (taskDataModel.Id == null)
            {
               await _taskDataService.AddAsync(taskDataModel);
            }
            else
            {
                await _taskDataService.UpdateAsync(taskDataModel);
            }
            return Json(true);
        }

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
            await _taskDataService.SoftDeleteAsync(id);
            return Json(true);
		}

        public IActionResult Login()
        {
            return View();
        }
    
        public IActionResult Register()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
