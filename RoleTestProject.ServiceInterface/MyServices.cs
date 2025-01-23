using ServiceStack;
using RoleTestProject.ServiceModel;

namespace RoleTestProject.ServiceInterface;

public class MyServices : Service
{

    [Authenticate]
    [RequiredRole("TheRoleThree")]
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }

    public class AdminServices : Service
    {
        public async Task<object> Any(ValidationRulesClearCache request)
        {
            var validationSource = base.TryResolve<IValidationSource>();
            if (validationSource == null)
                return false;

            await validationSource.ClearCacheAsync();
            return true;
        }

    }
}