using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados:IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context=context;
        }
        
        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            string sql = "SP_ALL_VEMPLEADOS";
            var consulta = this.context.EmpleadosViews.FromSqlRaw(sql);
            return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView>FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosViews
                           where datos.IdEmpleado==idEmpleado
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

    }
}
