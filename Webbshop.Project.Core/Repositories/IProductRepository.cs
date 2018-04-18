using System;
using System.Collections.Generic;
using System.Text;
using Webbshop.Project.Core.Models;

namespace Webbshop.Project.Core.Repositories
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();
    }
}
