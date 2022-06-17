using ConfigurationManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager.Repository
{
    public class GenericContextOperation<TContext, TDbSet>
    {
        private IGenericContext<TContext, TDbSet> _genericContext;
        public GenericContextOperation(IGenericContext<TContext, TDbSet> genericContext)
        {
            _genericContext = genericContext;
        }
        public TContext CreateContext()
        {
            return _genericContext.CreateContext();
        }
        public TDbSet CreateDbSet()
        {
            return _genericContext.CreateDbSet();
        }
    }
}
