﻿using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class HomeController : Controller
    {
        INewsRepository _repository;

        public HomeController(INewsRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}