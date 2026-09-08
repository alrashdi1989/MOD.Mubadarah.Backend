using System;
  using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace   MOD.Pms

{
    public class DataSourceLoadOptionsBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DataSourceLoadOptions))
            {
                return new BinderTypeModelBinder(typeof(DataSourceLoadOptionsBinder));
            }

            return null;
        }
    }
}
