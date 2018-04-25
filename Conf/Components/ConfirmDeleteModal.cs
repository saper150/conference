using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ConfirmDeleteModal : ViewComponent {
    public IViewComponentResult Invoke() {
        return View();
    }
}
