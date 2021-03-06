﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Platformus.Barebone;
using Platformus.Content.Data.Abstractions;
using Platformus.Content.Data.Models;
using Platformus.Globalization.Frontend.ViewModels;

namespace Platformus.Content.Frontend.ViewModels.Shared
{
  public class PropertyViewModelFactory : ViewModelFactoryBase
  {
    public PropertyViewModelFactory(IHandler handler)
      : base(handler)
    {
    }

    public PropertyViewModel Create(Property property)
    {
      return new PropertyViewModel()
      {
        MemberCode = this.handler.Storage.GetRepository<IMemberRepository>().WithKey(property.MemberId).Code,
        Html = this.GetLocalizationValue(property.HtmlId)
      };
    }

    public PropertyViewModel Create(CachedProperty cachedProperty)
    {
      return new PropertyViewModel()
      {
        MemberCode = cachedProperty.MemberCode,
        Html = cachedProperty.Html
      };
    }
  }
}