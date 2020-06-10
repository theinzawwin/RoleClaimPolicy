using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoleClaimPolicyProject.Data;
using RoleClaimPolicyProject.Models;
using RoleClaimPolicyProject.ViewModels;

namespace RoleClaimPolicyProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }
        // GET: Role
        public ActionResult Index()
        {
            
            var roleList = _roleManager.Roles.Select(r => new RoleViewModel() { Id = r.Id, Name = r.Name }).ToList();
            return View(roleList);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            ViewData["Permissions"] = _context.Permissions.Select(p=>new PermissionViewModel() {Id=p.Id,Type=p.Type,Value=p.Value,IsSelected=false }).ToList();
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel role)
        {
            try
            {
                // TODO: Add insert logic here
                var adminRole = await _roleManager.FindByNameAsync(role.Name);
                if (adminRole == null)
                {
                    adminRole = new ApplicationRole(role.Name);
                    await _roleManager.CreateAsync(adminRole);
                    var roleList = role.Permissions.Where(r => r.IsSelected == true).ToList();
                    foreach(var r in roleList)
                    {
                        await _roleManager.AddClaimAsync(adminRole, new Claim(r.Type, r.Value));
                    }
                   /*
                    role.Permissions.Where(r => r.IsSelected == true).ToList().ForEach(r=>
                    {
                        await _roleManager.AddClaimAsync(adminRole, new Claim(r.Type, r.Value));

                    });
                    */
                   // await _roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.view"));
                    //await _roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.create"));
                    //await _roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "projects.update"));
                }

                /*if (!await userManager.IsInRoleAsync(user, adminRole.Name))
                {
                    await userManager.AddToRoleAsync(user, adminRole.Name);
                }

                var accountManagerRole = await roleManager.FindByNameAsync("Account Manager");

                if (accountManagerRole == null)
                {
                    accountManagerRole = new IdentityRole("Account Manager");
                    await roleManager.CreateAsync(accountManagerRole);

                    await roleManager.AddClaimAsync(accountManagerRole, new Claim(CustomClaimTypes.Permission, "account.manage"));
                }
                */
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {

                ViewData["Permissions"] = _context.Permissions.Select(p => new PermissionViewModel() { Id = p.Id, Type = p.Type, Value = p.Value, IsSelected = false }).ToList();
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}