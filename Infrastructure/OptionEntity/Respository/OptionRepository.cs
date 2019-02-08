using infrastructure;
using infrastructure.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.OptionEntity.Respository
{
    public class OptionRepository
    {
        private DbModel _dBcontext;
        public OptionRepository()
        {
            _dBcontext = GlobalVariables.getDbContext();
        }

        public void AktualisiereOption(Option option)
        {
            _dBcontext.Entry(option).State = System.Data.Entity.EntityState.Modified;
            _dBcontext.SaveChanges();
            _dBcontext.DetachAll(_dBcontext.Options);
        }

        public Option getOption()
        {
            _dBcontext.DetachAll(_dBcontext.Options);
            return _dBcontext.Options.FirstOrDefault();         
        }
    }
}
