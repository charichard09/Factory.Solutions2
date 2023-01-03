using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Controllers
{
  public class HomeController : Controller
  {
    private readonly RegistrarContext _db;

    public HomeController(RegistrarContext db)
    {
      _db = db;
    }

  
    
  }
}
