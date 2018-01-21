//------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------------------------


using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ClassLibrary1
{
    public abstract class BindingElementExtensionElement
    {
        protected BindingElementExtensionElement()
        {

        }
        public virtual void ApplyConfiguration(BindingElement bindingElement)
        {
            // Some items make sense just as tags and have no other configuration
            if (null == bindingElement)
            {
                var argumentNull = (ArgumentNullException)ThrowHelperArgumentNull(nameof(bindingElement));
                throw argumentNull;

            }
        }

        private object ThrowHelperArgumentNull(string bindingElementName)
        {
            return (ArgumentNullException)this.ThrowHelperError((Exception)new ArgumentNullException(bindingElementName));
        }

        private ArgumentNullException ThrowHelperError(Exception exception)
        {
            return this.ThrowHelper(exception, TraceEventType.Error);
        }

        private ArgumentNullException ThrowHelper(Exception exception, TraceEventType error)
        {
            throw new ArgumentNullException();
        }

        public abstract Type BindingElementType
        {
            get;
        }

        protected abstract BindingElement CreateBindingElement();

        protected internal virtual void InitializeFrom(BindingElement bindingElement)
        {
            if (bindingElement == null)
            {
                throw new ArgumentException("bindingElement");
            }
            if (bindingElement.GetType() != this.BindingElementType)
            {

                var throwHelperError = (ArgumentException)this.ThrowHelperError((Exception)new ArgumentException(nameof(bindingElement), SR.GetString("ConfigInvalidTypeForBindingElement", (object)this.BindingElementType.ToString(), (object)bindingElement.GetType().ToString())));
                throw throwHelperError;
            }
        }
    }


}
