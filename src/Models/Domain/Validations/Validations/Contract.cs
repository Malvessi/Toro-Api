using Domain.Validations.Notifications;
using System;
using System.Linq.Expressions;

namespace Domain.Validations.Validations
{
    public partial class Contract : Notifiable
    {
        public Contract Requires()
        {
            return this;
        }

        public Contract Join(params Notifiable[] items)
        {
            if(items != null)
            {
                foreach (var notifiable in items)
                {
                    if (notifiable.Invalid)
                        AddNotifications(notifiable.Notifications);
                }
            }

            return this;
        }

        public Contract IfNotNull(object paramenterType, Expression<Func<Contract,Contract>> contractExpression)
        {
            if (paramenterType != null)
                contractExpression.Compile().Invoke(this);

            return this;
        }
    }
}
