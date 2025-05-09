using Microsoft.FeatureManagement;

namespace HrWebApp.Api.Filters;

[FilterAlias("HeaderFeatureFilter")]
public class HeaderFeatureFilter : IFeatureFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HeaderFeatureFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            return Task.FromResult(false);
        }

        // Check for feature flag in header
        // Format: X-Feature-Flag: featureName=true
        var featureHeader = httpContext.Request.Headers["X-Feature-Flag"].ToString();
        if (string.IsNullOrEmpty(featureHeader))
        {
            return Task.FromResult(false);
        }

        var parts = featureHeader.Split('=');
        if (parts.Length != 2)
        {
            return Task.FromResult(false);
        }

        var featureName = parts[0].Trim();
        var isEnabled = bool.TryParse(parts[1].Trim(), out var enabled) && enabled;

        return Task.FromResult(featureName == context.FeatureName && isEnabled);
    }
}