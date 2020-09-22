using QuotingSystem.DAL;
using QuotingSystem.Models;
using System;
using System.Data.Entity;

namespace QuotingSystem.Helpers
{
    public static class QuotesContextHelper
    {
        public static void SyncObjectsStateBeforeSave(this DAL.QuotingSystemDbEntities dbContext)
        {
            foreach (var dbEntity in dbContext.ChangeTracker.Entries())
            {
                var trackableObject = dbEntity.Entity as ITrackable;

                if (trackableObject == null)
                    continue;

                var dateTimeNow = DateTime.Now;

                if (dbEntity.State == EntityState.Added)
                {
                    trackableObject.CreationDate = dateTimeNow;
                }

                if (dbEntity.State != EntityState.Unchanged)
                {
                    trackableObject.LastChangedDate = dateTimeNow;
                }
            }
        }
    }
}