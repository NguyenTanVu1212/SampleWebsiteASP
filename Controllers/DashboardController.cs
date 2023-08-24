using FinalProject.Models;
using FinalProject.Models.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {          
            return View();
        }
        #region View All History Enter
        public ActionResult ViewAll()
        {
            return View(GetAllLogModle());
        }

        IEnumerable<LogModel> GetAllLogModle()
        {
            List<LogModel> logHistory = ClientRequest<LogModel>.instance.GetAllData();
            return logHistory;
        }
        #endregion
        #region Find History Enter 
        [Route("Dashboard/Find")]
        [HttpGet("{Key,Values}")]
        public ActionResult Find(string Key, String Values)
        {
            if (Key == null || Values == null)
            {
                return View(new List<LogModel>());
            }
            List<LogModel> logHistory = new List<LogModel>(); 
            if (Key != "ID")
            {
                logHistory = ClientRequest<LogModel>.instance.GetDatasByKeyValue(Key, Values);
            }
            else 
                logHistory = ClientRequest<LogModel>.instance.GetDatasByKeyValue("Id", Int32.Parse(Values));
            return View(logHistory);
        }

        #endregion
        #region Add History enter
        public ActionResult AddOrEdit(int Name)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(LogModel models)
        {
            List<StaffModel> lsStaff = ClientRequest<StaffModel>.instance.GetDatasById(models.ID);
            if(lsStaff.Count == 0)
            {
                ModelState.AddModelError(nameof(StaffModel.Id), "Cannot find preson with ID , plesae input id again");
                return View();
            }else
            {
                foreach(var e in lsStaff)
                {
                    if(e.Name.ToUpper() != models.Name.ToUpper() )
                    {
                        ModelState.AddModelError(nameof(StaffModel.Id), "ID or Name isn't correct , plesae input again");
                        return View();
                    }
                }
                string datas = models.ObjToJson();
                ClientRequest<LogModel>.instance.ClientSendData(datas);
                return RedirectToAction("ViewAll", "Dashboard");
            }
        }
        #endregion
        #region View all infor Staff
        public ActionResult ListStaff()
        {
            return View(GetAllStaffInfo());
        }
        IEnumerable<StaffModel> GetAllStaffInfo()
        {
            List<StaffModel> logHistory = ClientRequest<StaffModel>.instance.GetAllData();
            return logHistory;
        }
        #endregion
        #region Find Infor Staff
        [Route("Dashboard/SearchInfoStaff")]
        [HttpGet("{Key,Values}")]
        public ActionResult SearchInfoStaff(String Key , String Values)
        {
            List<StaffModel> listStaff = new List<StaffModel>();
            if(Key == null || Values ==  null)
            {
                return View(listStaff);
            }
            if(Key == "Id")
            {
                listStaff = ClientRequest<StaffModel>.instance.GetDatasByKeyValue(Key, Int32.Parse(Values));
            } else listStaff = ClientRequest<StaffModel>.instance.GetDatasByKeyValue(Key, Values);
            return View(listStaff);
        }

        #endregion
        #region Add new Staff
        public ActionResult AddNewStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewStaff(StaffModel models)
        {
            List<StaffModel> staffModels = ClientRequest<StaffModel>.instance.GetDatasByKeyValue("Id", models.Id);
            if (staffModels.Count != 0)
            {
                ModelState.AddModelError(nameof(StaffModel.Id), "ID has exist");
                return View();
            }
            else
            {
                string datas = models.ObjToJson();
                ClientRequest<StaffModel>.instance.ClientSendData(datas);
                return RedirectToAction("ListStaff", "Dashboard");
            }
        }
        #endregion
         
    }
}
