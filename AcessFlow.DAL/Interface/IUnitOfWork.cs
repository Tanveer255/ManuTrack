using AcessFlow.Entity.Data;
using System;

namespace EBS.DAL.Interface
{
    /// <summary>
    /// Unit Of Work interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets context property.
        /// </summary>
        public AcessFlowDbContext Context { get; }

        /// <summary>
        /// Commit.
        /// </summary>
        public void Commit();
    }
}