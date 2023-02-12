namespace Nttb.Domain;

/// <summary>
///     Describes when a clock started to run and when it was stopped.
/// </summary>
/// <param name="StartedAt">When was the clock started.</param>
/// <param name="Running">Should the clock be running</param>
/// <param name="Zeroing">Should have zeroed at this time?</param>
public record CountDownChange(Timestamp StartedAt, bool Running, bool Zeroing);