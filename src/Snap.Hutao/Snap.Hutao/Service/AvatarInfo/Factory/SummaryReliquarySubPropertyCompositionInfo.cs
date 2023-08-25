﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Model.Intrinsic;
using Snap.Hutao.Model.Intrinsic.Format;
using Snap.Hutao.Model.Metadata.Converter;
using Snap.Hutao.Model.Metadata.Reliquary;
using Snap.Hutao.Model.Primitive;
using Snap.Hutao.ViewModel.AvatarProperty;
using Snap.Hutao.Web.Enka.Model;
using System.Runtime.InteropServices;
using MetadataReliquary = Snap.Hutao.Model.Metadata.Reliquary.Reliquary;
using ModelAvatarInfo = Snap.Hutao.Web.Enka.Model.AvatarInfo;

namespace Snap.Hutao.Service.AvatarInfo.Factory;
internal sealed class SummaryReliquarySubPropertyCompositionInfo
{
    public SummaryReliquarySubPropertyCompositionInfo(FightProperty type)
    {
        Type = type;
    }

    public FightProperty Type { get; set; }

    public float Value { get; set; }

    public uint Count { get; set; }

    public ReliquaryComposedSubProperty ToReliquaryComposedSubProperty()
    {
        return new(Type, FightPropertyFormat.FormatValue(Type, Value), 0);
    }
}