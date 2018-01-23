using Microsoft.AspNetCore.Mvc;
using MusicTools.Business;

namespace MusicTools.Web.Controllers
{
    public class KeyController : Controller
    {
        private readonly KeyBusiness _keyBusiness;

        public KeyController(KeyBusiness keyBusiness)
        {
            _keyBusiness = keyBusiness;
        }

        public JsonResult GetAll()
        {
            return Json(_keyBusiness.GetAll());
        }
    }
}