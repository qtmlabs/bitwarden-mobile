﻿using System.Collections.Generic;
using Android.App;
using Android.Content;
using Bit.App.Utilities;
using Bit.Core.Abstractions;
using Bit.Core.Utilities;
using Bit.App.Droid.Utilities;

namespace Bit.Droid.Receivers
{
    [BroadcastReceiver(Name = "xyz.qtmlabs.internal.passwordmanager.RestrictionsChangedReceiver", Exported = false)]
    [IntentFilter(new[] { Intent.ActionApplicationRestrictionsChanged })]
    public class RestrictionsChangedReceiver : BroadcastReceiver
    {
        public async override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == Intent.ActionApplicationRestrictionsChanged)
            {
                await AndroidHelpers.SetPreconfiguredRestrictionSettingsAsync(context);
            }
        }
    }
}
