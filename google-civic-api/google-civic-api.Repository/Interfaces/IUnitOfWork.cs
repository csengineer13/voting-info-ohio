using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace google_civic_api.Repository.Interfaces
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        //int Save();
        //TContext Context { get; }
        //IEnumerable<DBEntityValidationResult> GetValidationErrors();
    }

    public interface IUnitOfWork //: IUnitOfWork<voteContext>
    {
        //void DebugChangeTracker();
        //void BeginTransaction();
        //void CommitTransaction();
        //void RollbackTransaction();
    }
}