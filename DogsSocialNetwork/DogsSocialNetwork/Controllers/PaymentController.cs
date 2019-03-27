using DogsSocialNetwork.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DogsSocialNetwork.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int userId)
        {
            return View(LiqPayHelper.GetLiqPayModel(Guid.NewGuid().ToString(), userId));
        }

        /// <summary>
        /// На цю сторінку LiqPay відправляє результат оплати. Вона вказана в data.result_url
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Redirect(int userId)
        {
            ViewBag.UserId = userId;
            ViewBag.ErrorDetails = "Something went wrong with payment";

            // --- Перетворюю відповідь LiqPay в Dictionary<string, string> для зручності:
            var request_dictionary = Request.Form.AllKeys.ToDictionary(key => key, key => Request.Form[key]);

            // --- Розшифровую параметр data відповіді LiqPay та перетворюю в Dictionary<string, string> для зручності:
            byte[] request_data = Convert.FromBase64String(request_dictionary["data"]);
            string decodedString = Encoding.UTF8.GetString(request_data);
            var request_data_dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedString);

            // --- Отримую сигнатуру для перевірки
            var mySignature = LiqPayHelper.GetLiqPaySignature(request_dictionary["data"]);

            // --- Якщо сигнатура серевера не співпадає з сигнатурою відповіді LiqPay - щось пішло не так
            if (mySignature != request_dictionary["signature"])
                return View("~/Views/Shared/Error.cshtml");


            // --- Якщо статус відповіді "Тест" або "Успіх" - все добре
            if (request_data_dictionary["status"] == "sandbox" || request_data_dictionary["status"] == "success")
            {
                // Тут можна оновити статус замовлення та зробити всі необхідні речі. Id замовлення можна взяти тут: request_data_dictionary[order_id]
                // ...

                return View("Thanks");
            }

            return View("~/Views/Shared/Error.cshtml");

        }
    }
}