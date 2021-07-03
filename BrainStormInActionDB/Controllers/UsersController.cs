using AutoMapper;
using BrainStormInActionDB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BrainStormInActionDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet("GetAllUserVideos")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUserVideos(int userId, int? videosId, string priority = null, string sortOrder="desc")
        {
            _logger.Info($"UsersController:GetAllUserVideos >>> Start, userId {userId}, videosId {videosId}, priority {priority}");
            try
            {

                var entities = await _unitOfWork.UsersToVideoRepository.FindAllWithIncludeAsync(sortOrder,
                     x => x.UserId== userId 
                          && (videosId > 0 ? x.VideoId == videosId : true) 
                          && (!string.IsNullOrEmpty(priority)? x.Priority == priority : true)
                            , x=>x.Priority
                     , x=>x.Video);

                
                if (entities == null)
                    return NotFound();


                return Ok(videosId==null?entities.FirstOrDefault():entities);
            }
            catch (Exception e)
            {
                _logger.Error($"UsersController:GetAllUserVideos >>> Message: {e.Message}, StackTrace: {e.StackTrace}");
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}
