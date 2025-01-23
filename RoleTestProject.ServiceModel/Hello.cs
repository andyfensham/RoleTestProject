using ServiceStack;

namespace RoleTestProject.ServiceModel;

[Route("/hello/{Name}")]
public class Hello : IGet, IReturn<HelloResponse>
{
    public required string Name { get; set; }
}

public class HelloResponse
{
    public required string Result { get; set; }
}

[Route("/meta/validationrulesclearcache", "GET")]
//[ValidateHasRole("SCADAdmin")]
public class ValidationRulesClearCache : IReturn<bool>
{
    /// <summary>
    /// If true, all operations will be refreshed/reconstructed as if this endpoint was run for the first time. NOTE: This is a destuctive operation and will remove all existing CUSTOM routes (such as "/staticvalues?StaticCategoryId=10" // PaymentFrequency).
    /// </summary>

}
