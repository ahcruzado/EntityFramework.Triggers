using System;

#if EF_CORE
using Microsoft.EntityFrameworkCore;
#else
using System.Data.Entity;
#endif

namespace EntityFramework.Triggers {
	public interface ITriggers<out TTriggerable> where TTriggerable : class, ITriggerable {
		/// <summary>Raised just before this entity is added to the store</summary>
		event Action<IBeforeEntry<TTriggerable>> Inserting;

		/// <summary>Raised just before this entity is updated in the store</summary>
		event Action<IBeforeChangeEntry<TTriggerable>> Updating;

		/// <summary>Raised just before this entity is deleted from the store</summary>
		event Action<IBeforeChangeEntry<TTriggerable>> Deleting;

		/// <summary>Raised after Inserting event, but before Inserted event when an exception has occured while saving the changes to the store</summary>
		event Action<IFailedEntry<TTriggerable>> InsertFailed;

		/// <summary>Raised after Updating event, but before Updated event when an exception has occured while saving the changes to the store</summary>
		event Action<IChangeFailedEntry<TTriggerable>> UpdateFailed;

		/// <summary>Raised after Deleting event, but before Deleted event when an exception has occured while saving the changes to the store</summary>
		event Action<IChangeFailedEntry<TTriggerable>> DeleteFailed;

		/// <summary>Raised just after this entity is added to the store</summary>
		event Action<IAfterEntry<TTriggerable>> Inserted;

		/// <summary>Raised just after this entity is updated in the store</summary>
		event Action<IAfterChangeEntry<TTriggerable>> Updated;

		/// <summary>Raised just after this entity is deleted from the store</summary>
		event Action<IAfterChangeEntry<TTriggerable>> Deleted;
	}
	
	public interface ITriggers<out TTriggerable, out TDbContext> where TTriggerable : class, ITriggerable where TDbContext : DbContext {
		/// <summary>Raised just before this entity is added to the store</summary>
		event Action<IBeforeEntry<TTriggerable, TDbContext>> Inserting;

		/// <summary>Raised just before this entity is updated in the store</summary>
		event Action<IBeforeChangeEntry<TTriggerable, TDbContext>> Updating;

		/// <summary>Raised just before this entity is deleted from the store</summary>
		event Action<IBeforeChangeEntry<TTriggerable, TDbContext>> Deleting;

		/// <summary>Raised after Inserting event, but before Inserted event when an exception has occured while saving the changes to the store</summary>
		event Action<IFailedEntry<TTriggerable, TDbContext>> InsertFailed;

		/// <summary>Raised after Updating event, but before Updated event when an exception has occured while saving the changes to the store</summary>
		event Action<IChangeFailedEntry<TTriggerable, TDbContext>> UpdateFailed;

		/// <summary>Raised after Deleting event, but before Deleted event when an exception has occured while saving the changes to the store</summary>
		event Action<IChangeFailedEntry<TTriggerable, TDbContext>> DeleteFailed;

		/// <summary>Raised just after this entity is added to the store</summary>
		event Action<IAfterEntry<TTriggerable, TDbContext>> Inserted;

		/// <summary>Raised just after this entity is updated in the store</summary>
		event Action<IAfterChangeEntry<TTriggerable, TDbContext>> Updated;

		/// <summary>Raised just after this entity is deleted from the store</summary>
		event Action<IAfterChangeEntry<TTriggerable, TDbContext>> Deleted;
	}

	internal interface ITriggers {
		void OnBeforeInsert(ITriggerable triggerable, DbContext dbContext);
		void OnBeforeUpdate(ITriggerable triggerable, DbContext dbContext);
		void OnBeforeDelete(ITriggerable triggerable, DbContext dbContext);
		void OnInsertFailed(ITriggerable triggerable, DbContext dbContext, Exception exception);
		void OnUpdateFailed(ITriggerable triggerable, DbContext dbContext, Exception exception);
		void OnDeleteFailed(ITriggerable triggerable, DbContext dbContext, Exception exception);
		void OnAfterInsert(ITriggerable triggerable, DbContext dbContext);
		void OnAfterUpdate(ITriggerable triggerable, DbContext dbContext);
		void OnAfterDelete(ITriggerable triggerable, DbContext dbContext);
	}
}