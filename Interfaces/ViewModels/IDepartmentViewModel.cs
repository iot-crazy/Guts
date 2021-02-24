using System.Collections.Generic;

namespace Interfaces.ViewModels
{
    public interface IDepartmentViewModel : IViewModelBase
    {
        string Name { get; set; }
        string Description { get; set; }

    }
}
