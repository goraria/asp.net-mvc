using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using mvc.Models.Tables;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc.Controllers {
    public class AdminController : Controller {
        private readonly ILogger<AdminController> _logger;

        private readonly DemoContext _context;

        public AdminController(ILogger<AdminController> logger, DemoContext context) {
            _logger = logger;
            _context = context;
        }

        public partial class CitiesViewModel {
            public List<City> cities {
                get; set;
            }
        }

        public partial class FormSaveNewCity {
            public string name {
                get; set;
            }
            public string country {
                get; set;
            }
        }

        public partial class FormSaveUpdateCity {
            public string Id {
                get; set;
            }
            public string name {
                get; set;
            }
            public string country {
                get; set;
            }
        }

        public partial class UpdateCitiesViewModel {
            public City city {
                get; set;
            }
        }

        public RedirectResult SaveNewCity(FormSaveNewCity formData) {
            try {
                if (!string.IsNullOrEmpty(formData.name)) {
                    using (var db = new DemoContext()) {
                        db.Cities.Add(new City {
                            // IdCity = "Japtor",
                            Name = formData.name,
                            Country = formData.country
                        });
                        db.SaveChanges();
                        _logger.LogInformation("City {CityName} created successfully.", formData.name);
                        return new RedirectResult(url: "/admin/table");
                    }
                } else {
                    _logger.LogWarning("Failed to create city. Name is null.");
                    return new RedirectResult(url: "/admin/createCity");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Error creating city {CityName}.", formData.name);
                ViewBag.ErrorMessage = ex.Message;
                return new RedirectResult(url: "/admin/error");
            }
        }

        public RedirectResult DeleteCategory(string id) {
            try {
                using (var db = new DemoContext()) {
                    var city = db.Cities.FirstOrDefault(e => e.IdCity == id);
                    if (city != null) {
                        db.Cities.Remove(city);
                        db.SaveChanges();
                        _logger.LogInformation("City {CityId} deleted successfully.", id);
                    } else {
                        _logger.LogWarning("Failed to delete city. City with ID {CityId} not found.", id);
                    }
                    return new RedirectResult(url: "/admin/table");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Error deleting city with ID {CityId}.", id);
                return new RedirectResult(url: "/admin/error");
            }
        }

        public IActionResult UpdateCategory(string id) {
            try {
                using (var db = new DemoContext()) {
                    var city = db.Cities.FirstOrDefault(e => e.IdCity == id);
                    if (city != null) {
                        var viewModel = new UpdateCitiesViewModel { city = city };
                        return View(viewModel);
                    } else {
                        _logger.LogWarning("City with ID {CityId} not found.", id);
                        return new RedirectResult(url: "/admin/table");
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Error loading city with ID {CityId}.", id);
                return new RedirectResult(url: "/admin/error");
            }
        }

        public RedirectResult SaveUpdateCity(FormSaveUpdateCity formData) {
            try {
                if (!string.IsNullOrEmpty(formData.name)) {
                    using (var db = new DemoContext()) {
                        var city = db.Cities.FirstOrDefault(c => c.IdCity == formData.Id);
                        if (city != null) {
                            city.Name = formData.name;
                            city.Country = formData.country;
                            db.SaveChanges();
                            _logger.LogInformation("City {CityId} updated successfully.", formData.Id);
                        }
                        return new RedirectResult(url: "/admin/table");
                    }
                } else {
                    _logger.LogWarning("Failed to update city. Name is null.");
                    return new RedirectResult(url: "/admin/createCity");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Error updating city with ID {CityId}.", formData.Id);
                return new RedirectResult(url: "/admin/error");
            }
        }
        
        public IActionResult Table() {
            try {
                using (var db = new DemoContext()) {
                    var citiesViewModel = new CitiesViewModel {
                        cities = db.Cities.ToList() ?? new List<City>()
                    };
                    return View(citiesViewModel);
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "Error loading cities for table view.");
                ViewBag.ErrorMessage = ex.Message;
                return new RedirectResult(url: "/admin/error");
            }
        }


        public IActionResult Login() {
            return View();
        }

        public IActionResult Cities() {
            return View();
        }

        public IActionResult Dashboard() {
            return View();
        }

        public IActionResult CreateCategory() {
            return View();
        }

        public IActionResult Charts() {
            return View();
        }
    }
}

