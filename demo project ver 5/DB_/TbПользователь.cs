//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demo_project_ver_5.DB_
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbПользователь
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TbПользователь()
        {
            this.TbЗаказ = new HashSet<TbЗаказ>();
        }
    
        public int Код_пользователя { get; set; }
        public string Имя { get; set; }
        public int Код_заказа { get; set; }
        public string Пароль { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TbЗаказ> TbЗаказ { get; set; }
    }
}
