//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentExam.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Engineer
    {
        public int EngID { get; set; }
        public string SpecialityName { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
