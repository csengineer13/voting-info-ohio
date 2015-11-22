using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using google_civic_api.Repository.Interfaces;

namespace google_civic_api.Repository.Common
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            //Context = new voteContext();
        }
        //DBContextTransaction _transaction;

        //public UnitOfWork(voteContext dtContext)
        //{
        //    Context = dtContext;
        //}


    }
}