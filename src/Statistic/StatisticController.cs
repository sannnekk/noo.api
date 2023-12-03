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
        private readonly StatisticValidator validator;
        private readonly IStatisticService statisticService;

        private readonly IRequestContext requestContext;

        public StatisticController(Core.Log.ILogger logger, StatisticValidator validator, IStatisticService statisticService, IRequestContext requestContext)
        {
            this.logger = logger;
            this.validator = validator;
            this.statisticService = statisticService;
            this.requestContext = requestContext;
        }

        [Route("statistics/works")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWorksStatistics(StatisticRequestBody statistic)
        {
            if (requestContext.UserRole == "Student")
            {
                try
                {
                    this.validator.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response = Enumerable.Repeat(await this.statisticService.GetWorksStatisticAsync(statistic, userId), 1);
                    return Ok(response);
                }
                catch (Exception e)
                {
                    logger.Log(e);
                    return BadRequest(e.Message);
                }
            }
            else
            {
                try
                {
                    this.validator.ValidatorSetUp(false, true);
                    this.validator.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response =await this.statisticService.GetWorksStatisticAdvancedAsync(statistic);
                    return Ok(response);
                }
                catch (Exception e)
                {
                    logger.Log(e);
                    return BadRequest(e.Message);
                }
            }
        }

        [Route("statistics/deadlines")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDeadlinesStatistics(StatisticRequestBody statistic)
        {
            if (requestContext.UserRole == "Student")
            {
                try
                {
                    this.validator.ValidatorSetUp(true, false);
                    this.validator.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response = Enumerable.Repeat(await this.statisticService.GetDeadlinesStatisticAsync(statistic, userId), 1);
                    return Ok(response);
                }
                catch (Exception e)
                {
                    logger.Log(e);
                    return BadRequest(e.Message);
                }
            }
            else
            {
                try
                {
                    this.validator.ValidatorSetUp(false, false);
                    this.validator.ValidateAndThrow(statistic);
                    var userId = System.Ulid.Parse(requestContext.UserId);
                    var response =await this.statisticService.GetDeadlinesStatisticAdvancedAsync(statistic);
                    return Ok(response);
                }
                catch (Exception e)
                {
                    logger.Log(e);
                    return BadRequest(e.Message);
                }
            }
        }
    }
