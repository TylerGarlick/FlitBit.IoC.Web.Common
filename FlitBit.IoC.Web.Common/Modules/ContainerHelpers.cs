namespace FlitBit.IoC.Web.Common
{
    public static class ContainerHelpers
    {
        public static IContainer Current
        {
            get
            {
                return Create.New<IPerHttpRequestContainer>().Current;
            }
            set
            {
                var containerHelper = Create.New<IPerHttpRequestContainer>();
                if(containerHelper != null)
                    containerHelper.Current = value;
            }
        }
    }
}