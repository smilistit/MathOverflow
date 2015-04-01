//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public int Id { get; set; }
        public string Category { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public short Rate { get; set; }
        public bool IsLocked { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual User User { get; set; }
    }
}