using Nttb.Domain.Player.ValueObjects;

namespace Nttb.Domain.Set;

/// <summary>
/// A record of a card that was given to the player
/// </summary>
public class PlayingCardRecord
{
    /// <summary>
    ///     The participant who received the card
    /// </summary>
    public required ParticipantId Participant { get; init; }

    /// <summary>
    ///     The color of the card.
    /// </summary>
    public required CardColor Color { get; init; }

    /// <summary>
    ///     The time at which the infraction was given.
    /// </summary>
    public required DateTime GivenAt { get; init; }

    /// <summary>
    ///     The code associated with the reason of the infraction. Is determined by the RuleEngine.
    /// </summary>
    /// <remarks>
    ///     The following are used by the NTTB:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>#</term>
    ///             <description>Reason</description>
    ///         </listheader>
    ///         <item>
    ///             <term>01</term>
    ///             <description>kicking the table or fence etc.</description>
    ///         </item>
    ///         <item>
    ///             <term>02</term>
    ///             <description>throw the paddle</description>
    ///         </item>
    ///         <item>
    ///             <term>03</term>
    ///             <description>swearing, swearing or using indecent language</description>
    ///         </item>
    ///         <item>
    ///             <term>05</term>
    ///             <description>kick or hit the ball away</description>
    ///         </item>
    ///         <item>
    ///             <term>07</term>
    ///             <description>not returning in time from the break between two games or a time out (after warning)</description>
    ///         </item>
    ///         <item>
    ///             <term>08</term>
    ///             <description>coaching during the game in words and/or gestures</description>
    ///         </item>
    ///         <item>
    ///             <term>10</term>
    ///             <description>hit the table with fist or bat</description>
    ///         </item>
    ///         <item>
    ///             <term>12</term>
    ///             <description>deliberately moving or remodeling the cordon</description>
    ///         </item>
    ///         <item>
    ///             <term>18</term>
    ///             <description>hitting the ground or other object with the bat</description>
    ///         </item>
    ///         <item>
    ///             <term>20</term>
    ///             <description>other (to be specified)</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    public required int? Code { get; init; }

    /// <summary>
    ///     Comments by the referee, can be used to capture additional information of the reason.
    /// </summary>
    public required string Comments { get; init; }
}