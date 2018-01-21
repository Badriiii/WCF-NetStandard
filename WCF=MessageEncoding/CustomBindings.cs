using System.Collections.Generic;
using System.ServiceModel.Channels;
using WCF_MessageEncoding;

class CustomBindings
{
    public static void main()
    {
        ICollection<BindingElement> bindingElements = new List<BindingElement>();
        HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
        CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement();
        bindingElements.Add(textBindingElement);
        bindingElements.Add(httpBindingElement);
        CustomBinding binding = new CustomBinding(bindingElements);
    }
}



