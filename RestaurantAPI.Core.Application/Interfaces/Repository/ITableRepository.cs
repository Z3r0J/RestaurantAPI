﻿using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Repository
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<List<Table>> GetAllExtensiveInclude();
    }
}
