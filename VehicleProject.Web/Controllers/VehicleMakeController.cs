using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleProject.Service;
using VehicleProject.Web.Models;
using VehicleProject.DAL;
using AutoMapper;
using PagedList;

namespace VehicleProject.Web.Controllers
{
    public class VehicleMakeController : Controller
    {
        private IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }


        //create make
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleMakeCreateVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeCreateVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.CreateVehicleMake(makeEntity);

            if(makeEntity.MakeId>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        //Vehicle make list
        [HttpGet]
        public ActionResult Index(int? page, string sortTerm)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.CurrentSort = sortTerm;

            var pagedVehicleMakeEntities = _vehicleMakeService.GetPagedVehicleMakes(pageSize, pageNumber, sortTerm);
            var tempVehicleMakeModels = _mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleMakeIndexUpdateVM>>(pagedVehicleMakeEntities.ToArray());
            var pagedVehicleMakeModels = new StaticPagedList<VehicleMakeIndexUpdateVM>(tempVehicleMakeModels, pagedVehicleMakeEntities.GetMetaData());
            return View(pagedVehicleMakeModels);
        }

        //sngle vehicle make
        [HttpGet]
        public ActionResult Details(int id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeDeleteDetailVM>(makeEntity);
            return View(makeModel);
        }

        //update make
        [HttpGet]
        public ActionResult Update(int id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeIndexUpdateVM>(makeEntity);
            return View(makeModel);
        }

        [HttpPost]
        public ActionResult Update(VehicleMakeIndexUpdateVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeIndexUpdateVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.UpdateVehicleMake(makeEntity);
            return RedirectToAction("Index");
        }

        //delete make
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeDeleteDetailVM>(makeEntity);
            return View(makeModel);

        }
        [HttpPost]
        public ActionResult Delete(VehicleMakeDeleteDetailVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeDeleteDetailVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.DeleteVehicleMake(makeEntity);
            return RedirectToAction("Index");
        }

    }
}