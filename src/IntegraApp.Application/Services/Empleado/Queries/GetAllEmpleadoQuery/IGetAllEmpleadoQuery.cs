namespace IntegraApp.Application.Services.Empleado.Queries.GetAllEmpleadoQuery
{
    public interface IGetAllEmpleadoQuery
    {
        Task<List<GetAllEmpleadoModel>> Execute();
    }
}
