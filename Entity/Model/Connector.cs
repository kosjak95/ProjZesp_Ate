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
    
    public partial class Connector
    {
        public int ConnectorId { get; set; }
        public Nullable<int> FK_MealId { get; set; }
        public int FK_ComponentId { get; set; }
        public Nullable<int> FK_DishId { get; set; }
        public Nullable<double> ComponentWeigth { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
