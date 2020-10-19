using DoctorAppointmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentAPI.Repo
{
   public interface IAppointRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetT();
        Task<T> GetTById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> SaveAsync(T entity);


    }
}
