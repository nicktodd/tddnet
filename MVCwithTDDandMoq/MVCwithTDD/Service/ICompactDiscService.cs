using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCwithTDD.Dto;

namespace MVCwithTDD.Service
{
    public interface ICompactDiscService
    {
        List<CompactDisc> GetAllCompactDiscs();
    }
}
