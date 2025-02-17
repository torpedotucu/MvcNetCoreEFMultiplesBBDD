using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosMySql : IRepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context=context;
        }

        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosViews
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return await consulta.FirstOrDefaultAsync();

        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            var consulta = from datos in this.context.EmpleadosViews
                           select datos;
            return await consulta.ToListAsync();
        }
    }
}
