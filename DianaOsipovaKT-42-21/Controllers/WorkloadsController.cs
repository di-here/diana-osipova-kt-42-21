﻿using DianaOsipovaKT_42_21.Interfaces.WorkloadInterfaces;
using DianaOsipovaKT_42_21.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaOsipovaKT_42_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkloadsController : ControllerBase
    {
        private readonly ILogger<WorkloadsController> _logger;
        private readonly IWorkloadService _workloadService;

        public WorkloadsController(ILogger<WorkloadsController> logger, IWorkloadService workloadService)
        {
            _logger = logger;
            _workloadService = workloadService;
        }

        [HttpPost("GetWorkloadByProfessor")]
        public async Task<IActionResult> GetWorkloadAsync(WorkloadFilterProfessor filter, CancellationToken cancellationToken = default)
        {
            var resp = await _workloadService.GetWorkloadAsync(filter, cancellationToken);

            return Ok(resp);
        }
    }
}