using Reservas.Domain.Model.Reservas;
using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Reservas.Infraestructure.EF.ReadModel
{
    public class VueloReadModel
    {
        public Nro_Vuelo NroVuelo { get; private set; }
        public string Tipo_Asiento { get; private set; }
        public PrecioValue Cantidad { get; private set; }
        public PrecioValue Precio { get; private set; }
        public Pasaje _Pasaje { get; private set; }

        ///   public ICollection<DetallePedidoReadModel> Detalle { get; set; }


    }
}
