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
                Value = "0",
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
        public ActionResult Create(VehicleModelCreateVM modelModel)
        {
            VehicleModelEntity modelEntity = new VehicleModelEntity();

            modelEntity = _mapper.Map<VehicleModelCreateVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.CreateVehicleModel(modelEntity, modelEntity.VehicleMakeId);

            if (modelEntity.ModelId > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //vehicle Model list
        [HttpGet]
        public ActionResult Index(int? page, string filterId, string sortTerm)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var vehicleMakeEntities = _vehicleMakeService.GetAll();

            //storing current sorting and current filtering values here
            //if sorting is applied, we want filtering to be preserved
            //if filtering is applied we want sorting to be preserved
            //if another page is selected both filtering and sorting have to be preserved
            ViewBag.currentSort = sortTerm;
            ViewBag.currentFilter = filterId;


            //dropdownlist for filtering
            ViewBag.dropDownListOptions = PopulateDropDown();

            //checking and parsing filtering id
            int filterMakeId = 0;

            if(!string.IsNullOrEmpty(filterId))
            {
                filterMakeId = Int32.Parse(filterId);
            }

            //fetching data, returning sorted/filtered/paged result
            var pagedVehicleModelEntities = _vehicleModelService.GetPagedVehicleModels(pageSize, pageNumber, filterMakeId, sortTerm);
            var tempVehicleModelModels = _mapper.Map<IEnumerable<VehicleModelEntity>, IEnumerable<VehicleModelIndexVM>>(pagedVehicleModelEntities.ToArray());
            var pagedVehicleModelModels = new StaticPagedList<VehicleModelIndexVM>(tempVehicleModelModels, pagedVehicleModelEntities.GetMetaData());
            return View(pagedVehicleModelModels);
        }

        //sngle vehicle model
        [HttpGet]
        public ActionResult Details(int id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var makeEntity = _vehicleMakeService.GetVehicleMake(modelEntity.VehicleMakeId);
            modelEntity.VehicleMake = makeEntity;
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelDetailVM>(modelEntity);
            return View(modelModel);
        }

        //update model
        [HttpGet]
        public ActionResult Update(int id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelUpdateDeleteVM>(modelEntity);
            return View(modelModel);
        }

        [HttpPost]
        public ActionResult Update(VehicleModelUpdateDeleteVM modelModel)
        {
            var modelEntity = _mapper.Map<VehicleModelUpdateDeleteVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.UpdateVehicleModel(modelEntity);
            return RedirectToAction("Index");
        }

        //delete model
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var modelEntity = _vehicleModelService.GetVehicleModel(id);
            var modelModel = _mapper.Map<VehicleModelEntity, VehicleModelUpdateDeleteVM>(modelEntity);
            return View(modelModel);

        }
        [HttpPost]
        public ActionResult Delete(VehicleModelUpdateDeleteVM modelModel)
        {
            var modelEntity = _mapper.Map<VehicleModelUpdateDeleteVM, VehicleModelEntity>(modelModel);
            _vehicleModelService.DeleteVehicleModel(modelEntity);
            return RedirectToAction("Index");
        }

    }
}