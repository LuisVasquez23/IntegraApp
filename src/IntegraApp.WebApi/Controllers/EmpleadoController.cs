using FluentValidation;
using IntegraApp.Application.Exceptions;
using IntegraApp.Application.Feature;
using IntegraApp.Application.Models;
using IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.DeleteEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Queries.GetAllEmpleadoQuery;
using IntegraApp.Application.Services.Empleado.Queries.GetEmpleadoByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace IntegraApp.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EmpleadoController : ControllerBase
    {

        private readonly IFileManager _imageFileManager;
        private readonly string _baseUrl;

        public EmpleadoController(IFileManager imageFileManager , IHttpContextAccessor httpContextAccessor)
        {
            var request = httpContextAccessor.HttpContext.Request;
            _baseUrl = $"{request.Scheme}://{request.Host}";
            _imageFileManager = imageFileManager;
        }


        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetAllEmpleadoQuery getAllEmpleadoQuery)
        {
            var data = await getAllEmpleadoQuery.Execute();

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data, "Ok"));
        }

        // GET EMPLEADO 
        [HttpGet("{empleadoId}")]
        public async Task<IActionResult> GetById( int empleadoId,[FromServices] IGetEmpleadoByIdQuery getEmpleadoByIdQuery)
        {
            if (empleadoId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest));
            }

            var data = await getEmpleadoByIdQuery.Execute(empleadoId);

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data, "Ok"));
        }

        // CREATE EMPLEADO
        [HttpPost]
        public async Task<IActionResult> Create(
                [FromForm] CreateEmpleadoModel model,
                [FromServices] ICreateEmpleadoCommand createEmpleadoCommand,
                [FromServices] IValidator<CreateEmpleadoModel> validator)
        {


            var validate = validator.Validate(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest, validate.Errors, "Error"));
            }

            var fileModel = new FileManagerModel
            {
                Archivo = model.Archivo
            };

            var fileName = await _imageFileManager.SaveAsync(fileModel);

            model.FotoPath = $"{_baseUrl}/{fileName}";
            var data = await createEmpleadoCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiServices.Response(StatusCodes.Status201Created, data, "Ok"));
        }

        // UPDATE EMPLEADO
        [HttpPut]
        public async Task<IActionResult> Update(
                [FromForm] UpdateEmpleadoModel model,
                [FromServices] IUpdateEmpleadoCommand updateEmpleadoCommand,
                [FromServices] IValidator<UpdateEmpleadoModel> validator)
        {

            var validate = validator.Validate(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest, validate.Errors, "Error"));
            }

            var fileModel = new FileManagerModel
            {
                Archivo = model.Archivo,
                fileName = model.FotoPath?.Replace(_baseUrl , "")
            };

            if (fileModel.Archivo != null)
            {
                var fileName = await _imageFileManager.SaveAsync(fileModel);

                model.FotoPath = $"{_baseUrl}/{fileName}";
            }

            var data = await updateEmpleadoCommand.Execute(model);

            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data, "Ok"));
        }

        // DELETE EMPLEADO 
        [HttpDelete("{empleadoId}")]
        public async Task<IActionResult> Delete(
                int empleadoId,
                [FromServices] IDeleteEmpleadoCommand deleteEmpleadoCommand,
                [FromServices] IGetEmpleadoByIdQuery getEmpleadoByIdQuery)
        {
            if (empleadoId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiServices.Response(StatusCodes.Status400BadRequest));
            }

            var empleado = await getEmpleadoByIdQuery.Execute(empleadoId);
            

            if (empleado.FotoPath != null)
            {
                empleado.FotoPath = empleado.FotoPath?.Replace($"{_baseUrl}/", "");

                await _imageFileManager.DeleteAsync(empleado.FotoPath);
            }

            var data = await deleteEmpleadoCommand.Execute(empleadoId);

            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiServices.Response(StatusCodes.Status404NotFound));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, data, "Ok"));
        }


    }
}
