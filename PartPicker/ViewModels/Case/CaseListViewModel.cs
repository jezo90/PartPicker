﻿using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.ViewModels
{
    public class CaseListViewModel
    {
        public PagedList.IPagedList<Case> PagedList { get; set; }
        public CaseFormCheckedViewModel CaseFormCheckedViewModel { get; set; }
    }
}