namespace Nttb.Domain;

/// <summary>
///     A clock that can be started and stopped. It should be used to track time, but not as an alert. The
///     <see cref="MaxDuration" /> is provided to ensure that viewers know how much time is left.
/// </summary>
/// <remarks>
///     Under ITTF rules: The timeout is 1 minute, a medical timeout is 10 minute and the expedite rule kicks in after 10
///     minutes of play.
/// </remarks>
/// <param name="Key">The key as defined by the rule engine.</param>
/// <param name="DisplayName">The name to be displayed to the viewers. We recommend the english technical name, the client can use the <see cref="Key" /> to determine the localized name.</param>
/// <param name="MaxDuration">How long this clock is allowed to run.</param>
/// <param name="Changes">All changes that is made to the clock</param>
public record CountDownClock(
    CountDownClockKey Key,
    string DisplayName,
    TimeSpan MaxDuration,
    CountDownChange[] Changes);