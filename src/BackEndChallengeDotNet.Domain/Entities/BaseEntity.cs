using Flunt.Notifications;
using Flunt.Validations;

namespace BackEndChallengeDotNet.Domain.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
	{
        public virtual string EntityId { get; protected set; }
		public bool IsInvalid => !IsValid;

		protected bool Validate<TEntity>(Contract<TEntity> contractValidator) where TEntity : BaseEntity
		{
			AddNotifications(contractValidator);
			return IsValid;
		}
	}
}
