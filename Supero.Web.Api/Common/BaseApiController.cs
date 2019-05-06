
namespace Supero.Web.Api.Common
{
    using System.Web.Http;
    using SimpleInjector;


    public class BaseApiController : ApiController
    {
        public Container ApiContainer
        {
            get
            {
                return IocConfig.IocContainer;
            }
        }

    }
}