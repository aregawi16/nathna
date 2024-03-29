using System;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace NatnaAgencyDigitalSystem.Data.Pagination.Binders
{
    public class PageableBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(Pageable))
                return new BinderTypeModelBinder(typeof(PageableBinder));

            return null;
        }
    }
}
