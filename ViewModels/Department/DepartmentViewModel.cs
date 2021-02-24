using Interfaces.ViewModels;
using System.Collections.Generic;

namespace ViewModels
{
    public class DepartmentViewModel : ViewModelBase, IDepartmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
