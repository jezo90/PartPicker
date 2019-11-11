using PagedList;
using PartPicker.DAL;
using PartPicker.Infrastructure;
using PartPicker.Models;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Controllers
{
    public class CaseController : Controller
    {
        private BuildManager BuildManager;
        private PickerContext context = new PickerContext();
        private ISessionManager SessionManager { get; set; }

        public CaseController()
        {
            SessionManager = new SessionManager();
            BuildManager = new BuildManager(SessionManager, context);
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CaseList(List<string> manufacturers, List<string> formFactor, 
                                    int? page, int lengthMin = 0, string manufacturersString = "", string formsString = "")
        {
            var cas = context.Case.ToList();
            List<Case> caseOut = new List<Case>();
            List<Case> caseFound = new List<Case>();
            int filtred = 0;

            // MANUFACTURERS
            if (manufacturers != null)
            {
                foreach (var manu in manufacturers)
                {
                    caseOut = cas.Where(a => a.Manufacturer.Name == manu).ToList();
                    foreach (var caseout in caseOut)
                    {
                        caseFound.Add(caseout);
                    }
                }
                filtred = 1;
            }
            else if (manufacturersString != "")
            {
                string[] manusT = manufacturersString.Split('_');
                List<string> tempManus = new List<string>();
                foreach (var manu in manusT)
                {
                    caseOut = cas.Where(a => a.Manufacturer.Name == manu).ToList();
                    if (manu != "")
                    {
                        tempManus.Add(manu);
                    }
                    foreach (var caseout in caseOut)
                    {
                        caseFound.Add(caseout);
                    }
                }
                manufacturers = tempManus;
                filtred = 1;
            }

            if (filtred == 1)
            {
                cas.Clear();
                foreach (var add in caseFound)
                {
                    cas.Add(add);
                }
                caseFound.Clear();
                filtred = 0;
            }

            
            // FORMFACTOR
            if (cas.Count() > 0)
            {
                if (formFactor != null)
                {
                    foreach (var form in formFactor)
                    {
                        caseOut = cas.Where(a => a.FormFactor.Name == form).ToList();
                        foreach (var caseout in caseOut)
                        {
                            caseFound.Add(caseout);
                        }
                    }
                    filtred = 1;
                }
                else if (formsString != "")
                {
                    string[] formsT = formsString.Split('_');
                    List<string> tempForms = new List<string>();
                    foreach (var form in formsT)
                    {
                        caseOut = cas.Where(a => a.FormFactor.Name == form).ToList();
                        if (form != "")
                        {
                            tempForms.Add(form);
                        }
                        foreach (var caseout in caseOut)
                        {
                            caseFound.Add(caseout);
                        }
                    }
                    formFactor = tempForms;
                    filtred = 1;
                }
            }

            if (filtred == 1)
            {
                cas.Clear();
                foreach (var add in caseFound)
                {
                    cas.Add(add);
                }
                caseFound.Clear();
                filtred = 0;
            }

            // DŁUGOŚĆ

            if (lengthMin > 0)
            {
                if (cas.Count() > 0)
                {
                    caseOut = cas.Where(a => a.GpuLenght <= lengthMin).ToList();
                    foreach (var caseout in caseOut)
                    {
                        caseFound.Add(caseout);
                    }
                    filtred = 1;
                }
            }


            if (cas.Count() > 0)
            {
                var names = cas.Select(a => a.Name).Distinct().ToList();
                foreach (var name in names)
                {
                    var add = cas.Where(a => a.Name == name).Take(1).ToList();
                    caseFound.Add(add[0]);
                }
                cas = caseFound;
            }

            List<string> emptyList = new List<string> { "" };
            if (manufacturers == null) manufacturers = emptyList;
            if (formFactor == null) formFactor = emptyList;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (cas.Count() > pageSize) page = 1;
            CaseListViewModel caseListViewModel = new CaseListViewModel()
            {
                PagedList = cas.ToPagedList(pageNumber, pageSize),
                CaseFormCheckedViewModel = new CaseFormCheckedViewModel()
                {
                    ManufacturersChecked = manufacturers,
                    FormFactorChecked = formFactor,
                    LengthMinChecked = lengthMin
                }
            };

            return View(caseListViewModel);
        }


        [ChildActionOnly]
        public ActionResult Form(CaseFormCheckedViewModel checkd)
        {
            var cases = context.Case.ToList();

            var manufacturers = cases.OrderBy(a => a.Manufacturer.Name)
                                    .Select(a => a.Manufacturer.Name)
                                    .Distinct().ToList();

            var form = context.FormFactor.OrderBy(a => a.Name)
                                .Select(a => a.Name)
                                .ToList();


            List<string> emptyList = new List<string> { "" };
            if (checkd.ManufacturersChecked == null) checkd.ManufacturersChecked = emptyList;
            if (checkd.FormFactorChecked == null) checkd.FormFactorChecked = emptyList;

            var caseFormViewModel = new CaseFormViewModel()
            {
                Manufacturers = manufacturers,
                Cases = cases,
                FormFactor = form,
                CaseFormCheckedViewModel = checkd
            };

            return PartialView("_Form", caseFormViewModel);
        }


        public ActionResult CaseDetails(int id, string name)
        {
            var cases = context.Case.ToList();
            var cas = cases.Find(a => a.CaseId == id);
            var caseList = cases.Where(a => a.Name == cas.Name).ToList();
            List<string> prices = new List<string>();

            foreach (var c in caseList)
            {
                prices.Add(Functions.GetPrice(c));
            }


            var caseDetailsViewModel = new CaseDetailsViewModel()
            {
                Case = cas,
                CaseList = caseList,
                Prices = prices,
                NewBuildViewModel = new NewBuildViewModel()
                {
                    Cpu = BuildManager.GetCpu(),
                    Gpu = BuildManager.GetGpu(),
                    Ram = BuildManager.GetRam(),
                    Case = BuildManager.GetCase(),
                    Mobo = BuildManager.GetMobo(),
                    Psu = BuildManager.GetPsu(),
                    Storage = BuildManager.GetStorage()
                }

            };

            return View(caseDetailsViewModel);
        }
    }
}