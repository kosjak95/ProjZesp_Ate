//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meal
    {
        public int MealId { get; set; }
        public int FKUserId { get; set; }
        public int FKComponentId { get; set; }
        public long Weigth { get; set; }
        public short MealType { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual User User { get; set; }
    }
}
