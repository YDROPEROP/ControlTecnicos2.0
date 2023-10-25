namespace ControlTecnicos.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T>  Insertar(T dto);
        Task<bool> Actualizar(T dto);
        Task<bool> Eliminar(int id);
        Task<T> Obtener(int id);
        Task<List<T>> ObtenerTodos();

    }
}
