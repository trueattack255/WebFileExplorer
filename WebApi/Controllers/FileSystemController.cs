using System;
using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Args;
using WebApi.Contracts;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("filesystem")]
    public class FileSystemController : ControllerBase
    {
        private readonly ILogger<FileSystemController> _logger;
        private readonly IDataProvider<FSNodeExtendedInfo[]> _detailDirectoryProvider;
        private readonly IDataProvider<FSNodeInfo[]> _directoryProvider;
        private readonly IDataProvider<FSNodeBaseInfo[]> _driveProvider;
        
        public FileSystemController(ILogger<FileSystemController> logger, 
            IDataProvider<FSNodeExtendedInfo[]> detailDirectoryProvider,
            IDataProvider<FSNodeInfo[]> directoryProvider,
            IDataProvider<FSNodeBaseInfo[]> driveProvider)
        {
            _logger = logger;
            _detailDirectoryProvider = detailDirectoryProvider;
            _directoryProvider = directoryProvider;
            _driveProvider = driveProvider;
        }
        
        /// <summary>
        /// Возвращает информацию о дисках
        /// </summary>
        [HttpGet("drives")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FSNodeBaseInfo[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetDriveInfos()
        {
            _logger.LogDebug(nameof(GetDriveInfos));
            try
            {
                var result = _driveProvider.GetData(null);
                return Ok(result);
            }
            catch (AppBaseException e)
            {
                _logger.LogError($"{nameof(GetDriveInfos)} - {e}");
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetDriveInfos)} - {e}");
                throw;
            }
        }

        /// <summary>
        /// Возвращает детальную информацию по каталогу
        /// </summary>
        [HttpGet("directories/detailed")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FSNodeExtendedInfo[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetDirectoryDetailedInfos([FromQuery] FSBaseInfoArgs args)
        {
            _logger.LogDebug(nameof(GetDirectoryDetailedInfos));
            
            try
            {
                var result = _detailDirectoryProvider.GetData(args);
                return Ok(result);
            }
            catch (AppBaseException e)
            {
                _logger.LogError($"{nameof(GetDirectoryDetailedInfos)} - {e}", args);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetDirectoryDetailedInfos)} - {e}", args);
                throw;
            }
        }

        /// <summary>
        /// Возвращает информацию по каталогу
        /// </summary>
        [HttpGet("directories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FSNodeInfo[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetDirectoryInfos([FromQuery] FSInfoArgs args)
        {
            _logger.LogDebug(nameof(GetDirectoryInfos));
            
            try
            {
                var result = _directoryProvider.GetData(args);
                return Ok(result);
            }
            catch (AppBaseException e)
            {
                _logger.LogError($"{nameof(GetDirectoryInfos)} - {e}", args);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetDirectoryInfos)} - {e}", args);
                throw;
            }
        }
    }
}