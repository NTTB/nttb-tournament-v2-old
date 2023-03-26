namespace Nttb.Domain.Old.RuleEngines;

/// <summary>
///    The type of a value.
/// </summary>
public enum ValueType
{
    /// <summary>
    /// A boolean value.
    /// </summary>
    Boolean,
    /// <summary>
    /// A integer value (int64).
    /// </summary>
    Integer,
    
    /// <summary>
    /// A floating point value (double, 64 bits)
    /// </summary>
    Numeric,
    
    /// <summary>
    /// A string value.
    /// </summary>
    String
}