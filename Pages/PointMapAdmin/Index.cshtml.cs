﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IoTSharp.Gateway.Modbus.Data;

namespace IoTSharp.Gateway.Modbus.Pages.PointMapAdmin
{
    public class IndexModel : PageModel
    {
        private readonly IoTSharp.Gateway.Modbus.Data.ApplicationDbContext _context;

        public IndexModel(IoTSharp.Gateway.Modbus.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PointMapping> PointMapping { get;set; } = default!;

        public async Task OnGetAsync(Guid? id)
        {
            if (_context.PointMappings != null && id!=null)
            {
                PointMapping = await _context.PointMappings.Include(pt => pt.Owner).Where(fm => fm.Owner!=null &&  fm.Owner.Id == id).ToListAsync();
            }
        }
    }
}