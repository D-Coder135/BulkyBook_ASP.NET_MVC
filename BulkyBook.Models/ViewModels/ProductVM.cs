using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.ViewModels
{
    public class ProductVM
    {
        Product product = new();
        IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
            u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }
            );
        IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverTypes.GetAll().Select(
            u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }
            );
    }
}
