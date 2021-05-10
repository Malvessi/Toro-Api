﻿namespace Domain.Validations.Notifications
{
    public sealed class Notification
    {
        public string Property { get; set; }
        public string Message { get; private set; }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
