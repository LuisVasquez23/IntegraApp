namespace IntegraApp.Application.Services.Empleado.Queries.GetEmpleadoByIdQuery
{
    public interface IGetEmpleadoByIdQuery
    {
        Task<GetEmpleadoByIdModel> Execute(int empleadoId);
    }
}
