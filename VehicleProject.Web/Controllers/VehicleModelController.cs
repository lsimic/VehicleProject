using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleProject.Service;
using VehicleProject.Web.Models;
using VehicleProject.DAL;
using PagedList;
using AutoMapper;

namespace VehicleProject.Web.Controllers
{
    public class VehicleModelController : Controller
    {
        private IVehicleModelService _vehicleModelService;
        private IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;
        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        public SelectList PopulateDropDown()
        {
            var vehicleMakeEntities = _vehicleMakeService.GetAll();
            var dropDownEntities = new List<SelectListItem>();

            dropDownEntities.Add(new SelectListItem
            {
                Value = "",
                Text = " ",
                Selected = true
            });

            foreach (var item in vehicleMakeEntities)
            {
                dropDownEntities.Add(new SelectListItem
                {
                    Value = item.MakeId.ToString(),
                    Text = item.MakeName
                });
            }
            return new SelectList(dropDownEntities, "Value", "Text");
        }



        //create model
        [HttpGet]
        public ActionResult Create()
        {
            //dropdownlist for make selection, selects Id
            ViewBag.dropDownListOptions = PopulateDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleModelVM modelModel)
        {
            VehicleModelEntity modelEntity = new VehicleModelEntity();

            modelEntity = _mapper.Map<VehicleModelVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.CreateVehicleModel(modelEntity, modelEntity.VehicleMakeId);

            if (modelEntity.ModelId != Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //vehicle Model list
        [HttpGet]
        public ActionResult Index(int? page, string filterId, string sortTerm, string searchTerm)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.currentSort = sortTerm;
            ViewBag.currentFilter = filterId;
            ViewBag.currentSearch = searchTerm;

            //dropdownlist for filtering
            ViewBag.dropDownListOptions = PopulateDropDown();

            //fetching data, returning sorted/filtered/paged result
            var pagedVehicleModelEntities = _vehicleModelService.GetPagedVehicleModels(pageSize, pageNumber, filterId, sortTerm, searchTerm);
            var tempVehicleModelModels = _mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleModelVM>>(pagedVehicleModelEntities.ToArray());
            var pagedVehicleModelModels = new StaticPagedList<VehicleModelVM>(tempVehicleModelModels, pagedVehicleModelEntities.GetMetaData());
            return View(pagedVehicleModelModels);
        }

        //sngle vehicle model
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var makeEntity = _vehicleMakeService.GetVehicleMake(modelEntity.VehicleMakeId);
            modelEntity.VehicleMake = makeEntity;
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelVM>(modelEntity);
            return View(modelModel);
        }

        //update model
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelVM>(modelEntity);
            return View(modelModel);
        }

        [HttpPost]
        public ActionResult Update(VehicleModelVM modelModel)
        {
            var modelEntity = _mapper.Map<VehicleModelVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.UpdateVehicleModel(modelEntity);
            return RedirectToAction("Index");
        }

        //delete model
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelVM>(modelEntity);
            return View(modelModel);

        }
        [HttpPost]
        public ActionResult Delete(VehicleModelVM modelModel)
        {
            var modelEntity = _mapper.Map<VehicleModelVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.DeleteVehicleModel(modelEntity);
            return RedirectToAction("Index");
        }

    }
}