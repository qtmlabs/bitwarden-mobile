﻿using Android.Content;
using Bit.Core.Abstractions;
using Bit.Core.Utilities;

namespace Bit.Droid.Receivers
{
    [BroadcastReceiver(Name = "xyz.qtmlabs.internal.passwordmanager.EventUploadReceiver", Exported = false)]
    public class EventUploadReceiver : BroadcastReceiver
    {
        public async override void OnReceive(Context context, Intent intent)
        {
            var eventService = ServiceContainer.Resolve<IEventService>("eventService");
            await eventService.UploadEventsAsync();
        }
    }
}
