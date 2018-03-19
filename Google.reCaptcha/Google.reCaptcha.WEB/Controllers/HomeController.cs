using System.Web.Mvc;
using Google.reCaptcha.WEB.Models;
using GoogleRecaptcha;

namespace Google.reCaptcha.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // 使用GoogleRecaptcha  => https://www.google.com/recaptcha/intro/index.html

        /// <summary>
        /// 方法一 - GoogleRecaptchaMvc 套件
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            IRecaptcha<RecaptchaV2Result> recaptcha =
                new RecaptchaV2(
                    new RecaptchaV2Data()
                    {
                        Secret = "6LfPUR0UAAAAAFLjTwT0uRag5mZb0tCjvF7R5wVT"
                    });

            // Verify the captcha
            var result = recaptcha.Verify();
            if (result.Success) // Success!!!
            {
                ViewBag.Success = "驗證成功";
            }
            else
            {
                ViewBag.Success = "驗證失敗";

            }

            return View();
        }

        public ActionResult Custom()
        {
            return View();
        }

        /// <summary>
        /// 方法二 - 自己寫
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Custom(FormCollection form)
        {
            var isVerify = new GoogleReCaptcha()
                 .GetCaptchaResponse(form["g-recaptcha-response"]);
            if (isVerify)
            {
                ViewBag.Success = "驗證成功";
            }
            else
            {
                ViewBag.Success = "驗證失敗";

            }
            return View();
        }
    }
}