
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
    
public partial class Usuario
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Usuario()
    {

        this.MensagemDe = new HashSet<Mensagem>();

        this.MensagemPara = new HashSet<Mensagem>();

    }


    public long idUsuario { get; set; }

    public decimal telefone { get; set; }

    public string nome { get; set; }

    public string senha { get; set; }

    public string tipoUsuario { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Mensagem> MensagemDe { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Mensagem> MensagemPara { get; set; }

    public virtual Motorista Motorista { get; set; }

    public virtual Responsavel Responsavel { get; set; }

}

}
