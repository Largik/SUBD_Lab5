using System;
using System.Collections.Generic;
using System.Text;

namespace JournalBusinessLogic.BindingModels
{
    public class AddMarkBindingModel
    {
        public int UserId { get; set; }
        public int DisciplineId { get; set; }
        public decimal Mark { get; set; }
    }
}
