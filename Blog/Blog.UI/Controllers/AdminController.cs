﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.BLL;
using Blog.UI.Models;

namespace Blog.UI.Controllers
{
    public class AdminController : Controller
    {
        private BlogOperations _ops;

        public AdminController()
        {
            _ops = new BlogOperations();
        }

        [Authorize(Roles = "Admin")]
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            var vm = new AdminVM();
            vm.BlogPosts = _ops.GetAllBlogPosts().BlogPosts;

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddNewUser()
        {
            var vm = new RegisterViewModel();

            vm.CreateRolesList(_ops.GetAllRoles().IdRoles);

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageUsers()
        {
            var vm = new AdminVM();

            vm.Users = _ops.GetAllUsers().Users;
            vm.Roles = _ops.GetAllRoles().IdRoles;

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManagePosts()
        {
            _ops = new BlogOperations();

            var posts = _ops.GetAllBlogPosts().BlogPosts;

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageStaticPages()
        {
            _ops = new BlogOperations();
            
            var pages = _ops.GetAllStaticPages().StaticPages;

            return View(pages);
        }
    }
}