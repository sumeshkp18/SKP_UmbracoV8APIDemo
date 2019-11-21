﻿using AyruzAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyruzAPIDemo.Services.Interfaces
{
    public interface IMasterCategoryService
    {
        IEnumerable<MasterCategory> GetAll();
    }
}