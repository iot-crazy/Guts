using Interfaces.ViewModels;
using System;

namespace ViewModels
{
    public class ViewModelBase : IViewModelBase
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }

        public string RowVersion { get; set; }
    }
}
