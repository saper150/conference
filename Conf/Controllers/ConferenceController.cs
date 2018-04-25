using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Conf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ConferenceEditViewModel {

    [StringLength(30, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }
    public int CityId { get; set; }
    public int Id { get; set; }
    public IEnumerable<SelectListItem> Cities { get; set; }

    public ConferenceEditViewModel(ConferenceContext ctx) {
        this.Cities = ctx.Cities
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
    }
    public ConferenceEditViewModel() { }
}

public class ConferenceUserViewModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

public class ConferenceUsersList: ViewComponent {

    readonly ConferenceContext ctx;
    public ConferenceUsersList(ConferenceContext ctx) {
        this.ctx = ctx;
    }

    public IViewComponentResult Invoke() {
        return View(ctx.ConferenceUsers.Select(x => new ConferenceUserViewModel() {
            Id = x.Id,
            Name = x.Name,
            City = x.City.Name
        }));
    }

}


namespace Conf.Controllers {

    public class ConferenceController : Controller {

        readonly ConferenceContext ctx;
        public ConferenceController(ConferenceContext ctx) {
            this.ctx = ctx;
        }

        public ActionResult Index() {
            return View(ctx.ConferenceUsers.Select(x => new ConferenceUserViewModel() {
                Id = x.Id,
                Name = x.Name,
                City = x.City.Name
            }));
        }

        public ActionResult Create() {
            return View(new ConferenceEditViewModel(ctx));
        }

        [HttpPost]
        public ActionResult Create(ConferenceEditViewModel user) {

            ctx.ConferenceUsers.Add(new ConferenceUser() {
                Name = user.Name,
                City = ctx.Cities.First(x => x.Id == user.CityId)
            });
            ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id) {
            var user = ctx.ConferenceUsers.Include(x => x.City).First(x => x.Id == id);
            var vm = new ConferenceEditViewModel(ctx) {
                Id = id,
                Name = user.Name,
                CityId = user.City.Id
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ConferenceEditViewModel vm) {
            var user = new ConferenceUser() {
                Name = vm.Name,
                Id = vm.Id,
                City = ctx.Cities.First(x => x.Id == vm.CityId)
            };
            ctx.Attach(user);
            ctx.Entry(user).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id) {

            var user = new ConferenceUser() { Id = id };
            ctx.ConferenceUsers.Attach(user);
            ctx.ConferenceUsers.Remove(user);
            ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
