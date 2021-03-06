﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Barebone;
using Platformus.Forms.Data.Abstractions;
using Platformus.Forms.Data.Models;
using Platformus.Globalization.Backend.ViewModels;

namespace Platformus.Forms.Backend.ViewModels.Shared
{
  public class FieldViewModelFactory : ViewModelFactoryBase
  {
    public FieldViewModelFactory(IHandler handler)
      : base(handler)
    {
    }

    public FieldViewModel Create(Field field)
    {
      return new FieldViewModel()
      {
        Id = field.Id,
        Name = this.GetLocalizationValue(field.NameId),
        FieldOptions = this.handler.Storage.GetRepository<IFieldOptionRepository>().FilteredByFieldId(field.Id).Select(
          fo => new FieldOptionViewModelFactory(this.handler).Create(fo)
        )
      };
    }
  }
}