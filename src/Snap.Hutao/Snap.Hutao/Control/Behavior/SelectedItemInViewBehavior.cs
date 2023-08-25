﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using CommunityToolkit.WinUI.Behaviors;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Snap.Hutao.Control.Behavior;

internal sealed class SelectedItemInViewBehavior : BehaviorBase<ListViewBase>
{
    protected override bool Initialize()
    {
        if (AssociatedObject.SelectedItem is { } item)
        {
            AssociatedObject.ScrollIntoView(item);
        }

        return true;
    }
}