using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCwithTDD.Dto;
using MVCwithTDD.Repository;

namespace MVCwithTDD.Service
{
    public class CompactDiscService : ICompactDiscService
    {

        private musicEntities _context = new musicEntities();

        public musicEntities Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public List<CompactDisc> GetAllCompactDiscs()
        {
            //Context = new testdbEntities();
            return (CompactDiscConverter.Convert(_context.compact_discs.ToList()));
        }
    }
}