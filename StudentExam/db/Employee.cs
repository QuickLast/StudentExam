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
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string CipherID { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> Chief { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual Cafedra Cafedra { get; set; }
        public virtual Engineer Engineer { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ZavCafedra ZavCafedra { get; set; }
    }
}
