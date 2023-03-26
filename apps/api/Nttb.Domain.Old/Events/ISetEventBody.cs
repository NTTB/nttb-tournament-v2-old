namespace Nttb.Domain.Old.Events;

/// <summary>
///     The generic format, holds no value and is only used for mapping.
/// </summary>
public interface ISetEventBody
{
    /// <summary>
    ///     The type of event, required for mapping.
    /// </summary>
    public string Type { get; }
}