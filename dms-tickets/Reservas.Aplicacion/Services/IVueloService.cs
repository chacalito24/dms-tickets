﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Application.Services
{
    public interface IVueloService 
    {
        Task<string> GenerarNroVueloAsync();

    }
}
