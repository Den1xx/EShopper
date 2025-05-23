using ENTITY;
using EShopper.Models;
using EShopper.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Threading.Tasks;

namespace EShopper.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl == null ? "/Home/Index": returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }
        public IActionResult Register() {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.FirstName.ToLower().Replace(" ", "") + model.LastName.ToLower()
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new
                    {
                        token = code,
                        userId = user.Id
                    });
                    var activateUrl = "http://localhost:5221" + url;

                    var body = $"Sayın <strong>{user.FirstName + user.LastName};<br><br>Üyeliğinizi onaylamak için lütfen linke <a href={activateUrl}>tıklayınız</a>";

                    MailHelper.SendMail(body, user.Email, "Üyelik Onayı");

                    TempData["success"] = "Email adresinize gönderilen aktivasyon linkine tıklayınız";
                    return RedirectToAction("Login");
                }
                result.Errors.ToList().ForEach(i => ModelState.AddModelError(i.Code, i.Description));
                return View(model);
            }



            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }

        }
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            if (token == null || userId == null)
            {
                TempData["success"] = "Üyeliğiniz onaylanmadı. Lütfen sistem yöneticisi ile iletişime geçiniz.";
                return RedirectToAction("Login");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    TempData["success"] = "Üyeliğiniz onaylandı. Lütfen giriş yapınız.";
                    return RedirectToAction("Login");
                }

            }
            TempData["success"] = "Üyeliğiniz onaylanmadı. Kullanıcı bulunamadı";
            return RedirectToAction("Login");
        }
    }
}
