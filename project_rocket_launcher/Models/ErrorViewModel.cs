namespace project_rocket_launcher.Models;

/// <summary>
/// Error view model
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Get id
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Show requesed id on error view
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

