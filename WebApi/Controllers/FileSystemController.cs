using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Common.Constants;
using Common.Enums;
using Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Dto;
using WebApi.Providers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("filesystem")]
    public class FileSystemController : ControllerBase
    {
        private readonly ILogger<FileSystemController> _logger;
        
        public FileSystemController(ILogger<FileSystemController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Возвращает информацию о дисках
        /// </summary>
        [HttpGet("drives")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FSNodeBaseInfo>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetRootInfos()
        {
            return Ok(new DriveProvider().GetDrives());
        }

        /// <summary>
        /// Возвращает детальную информацию по каталогу
        /// </summary>
        /// <param name="path">Абсолютный путь</param>
        /// <param name="filter">Фильтер</param>
        /// <param name="sortMode">Режим сортировки</param>
        /// <param name="sortDirection">Направление сортировки</param>
        [HttpGet("directories/detailed")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FSNodeExtendedInfo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetDirectoryDetailedInfos(
            [Required]
            [RegularExpression(CommonConstants.PathRegexp, ErrorMessage = "Path validation error")]
            string path,
            FSObjectFilter filter = FSObjectFilter.All,
            SortMode sortMode = SortMode.Size,
            SortDirection sortDirection = SortDirection.Descending)
        {
            var dir = new DirectoryInfo(path);
            return Ok(new DirectoryProvider(dir, sortMode, sortDirection).GetDetailedInfo(filter));
        }

        /// <summary>
        /// Возвращает информацию по каталогу
        /// </summary>
        /// <param name="path">Абсолютный путь</param>
        /// <param name="filter">Фильтер</param>
        [HttpGet("directories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FSNodeInfo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetDirectoryInfos(
            [Required]
            [RegularExpression(CommonConstants.PathRegexp, ErrorMessage = "Path validation error")]
            string path,
            FSObjectFilter filter = FSObjectFilter.Directories)
        {
            var dir = new DirectoryInfo(path);
            return Ok(new DirectoryProvider(dir, SortMode.Name, SortDirection.Ascending).GetInfo(filter));
        }
    }
}