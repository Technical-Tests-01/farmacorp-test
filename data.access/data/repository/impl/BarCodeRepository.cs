using Microsoft.EntityFrameworkCore;
using models.erp.module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.data.repository.impl
{
    public class BarCodeRepository : Repository<BarCode>, IBarCodeRepository
    {
        public BarCodeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
