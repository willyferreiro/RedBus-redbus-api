
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace RedBus_api.Models
{

using System;
    using System.Collections.Generic;
    
public partial class ViagemFilho
{

    public long idViagem { get; set; }

    public long idFilho { get; set; }

    public Nullable<System.DateTime> dataEmbarque { get; set; }

    public Nullable<System.DateTime> dataDesembarque { get; set; }

    public Nullable<double> posicaoEmbarque_latitude { get; set; }

    public Nullable<double> posicaoEmbarque_longitude { get; set; }

    public Nullable<double> posicaoDesembarque_latitude { get; set; }

    public Nullable<double> posicaoDesembarque_longitude { get; set; }



    public virtual Filho Filho { get; set; }

    public virtual Viagem Viagem { get; set; }

}

}
