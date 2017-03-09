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
        public ActionResult Create(VehicleMakeVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.CreateVehicleMake(makeEntity);
            if(makeEntity.MakeId != Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        //Vehicle make list
        [HttpGet]
        public ActionResult Index(int? page, string sortTerm, string searchTerm)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.currentSort = sortTerm;
            ViewBag.currentSearch = searchTerm;

            var pagedVehicleMakeEntities = _vehicleMakeService.GetPagedVehicleMakes(pageSize, pageNumber, sortTerm, searchTerm);
            var tempVehicleMakeModels = _mapper.Map<IEnumerable<VehicleMakeEntity>, IEnumerable<VehicleMakeVM>>(pagedVehicleMakeEntities.ToArray());
            var pagedVehicleMakeModels = new StaticPagedList<VehicleMakeVM>(tempVehicleMakeModels, pagedVehicleMakeEntities.GetMetaData());
            return View(pagedVehicleMakeModels);
        }

        //sngle vehicle make
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeVM>(makeEntity);
            return View(makeModel);
        }

        //update make
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeVM>(makeEntity);
            return View(makeModel);
        }

        [HttpPost]
        public ActionResult Update(VehicleMakeVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.UpdateVehicleMake(makeEntity);
            return RedirectToAction("Index");
        }

        //delete make
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var makeEntity = _vehicleMakeService.GetVehicleMake(id);
            var makeModel = _mapper.Map<VehicleMakeEntity, VehicleMakeVM>(makeEntity);
            return View(makeModel);

        }
        [HttpPost]
        public ActionResult Delete(VehicleMakeVM makeModel)
        {
            var makeEntity = _mapper.Map<VehicleMakeVM, VehicleMakeEntity>(makeModel);
            _vehicleMakeService.DeleteVehicleMake(makeEntity);
            return RedirectToAction("Index");
        }

    }
}