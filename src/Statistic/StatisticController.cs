using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.DataAbstraction;
using noo.api.Work.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;
using FluentValidation;
using noo.api.Statistic;
using noo.api.Statistic.DataAbstraction;
using noo.api.Statistic.Service;

namespace noo.api.Statistics;
    [ApiController]

    public class StatisticController : ControllerBase
    {
        private readonly Core.Log.ILogger logger;
        private readonly StatisticWorksValidator validatorWork;
        private readonly StatisticStudentWorksValidator validatorWrokStudent;
        private readonly StatisticDeadlinesValidator validatorDeadlines;
        private readonly StatisticStudentDeadlinesValidator validatorDeadlinesStudent;
        private readonly IStatisticService statisticService;

        private readonly IRequestContext requestContext;

        public StatisticController(Core.Log.ILogger logger, 
            StatisticWorksValidator validatorWork, 
            StatisticStudentWorksValidator validatorWrokStudent, 
            StatisticDeadlinesValidator validatorDeadlines, 
            StatisticStudentDeadlinesValidator validatorDeadlinesStudent, 
            IStatisticService statisticService, 
            IRequestContext requestContext)
        {
            this.logger = logger;
            this.validatorWork = validatorWork;
            this.validatorWrokStudent = validatorWrokStudent;
            this.validatorDeadlines = validatorDeadlines;
            this.validatorDeadlinesStudent = validatorDeadlinesStudent;
            this.statisticService = statisticService;
            this.requestContext = requestContext;
        }

        [Route("statistics/works")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWorksStatistics(StatisticRequestBody statistic) 
        {
            try
            {
                if (requestContext.UserRole == "Student")
                {
                    validatorWrokStudent.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response = Enumerable.Repeat(await this.statisticService.GetWorksStatisticAsync(statistic, userId), 1);
                    return Ok(response);
                }
                else
                {
                    validatorWork.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response =await this.statisticService.GetWorksStatisticAdvancedAsync(statistic);
                    return Ok(response);                 
                }
            }
            catch (Exception e)
            {
                logger.Log(e);
                return BadRequest(e.Message);
            }
        }

        [Route("statistics/deadlines")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDeadlinesStatistics(StatisticRequestBody statistic) 
        {
            try
            {
                if (requestContext.UserRole == "Student")
                {
                    validatorDeadlinesStudent.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response = Enumerable.Repeat(await this.statisticService.GetDeadlinesStatisticAsync(statistic, userId), 1);                   
                    return Ok(response);                    
                }
                else
                {
                    validatorDeadlines.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response =await this.statisticService.GetDeadlinesStatisticAdvancedAsync(statistic);
                    return Ok(response);                    
                }
            }
            catch (Exception e)
            {
                logger.Log(e);
                return BadRequest(e.Message);
            }
        }
    }
