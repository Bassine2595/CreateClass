using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
 
 
namespace BLL
{
    public class ThemeBLL
    {
        public List<ThemeDTO>  GetAll()
        {
            List<ThemeDTO> themes = new List<ThemeDTO>();
            themes = ThemeDb.GetAll();
           return ThemeDb.GetAll();
        }
    }
}
