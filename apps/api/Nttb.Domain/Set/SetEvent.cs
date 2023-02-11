using Nttb.Domain.Set.ValueObjects;

namespace Nttb.Domain.Set;

public class SetEvent
{
    /// <summary>
    /// Which set
    /// </summary>
    public required SetId SetId { get; set; }
    
    /// <summary>
    /// Who provided the information
    /// </summary>
    public required InstanceId InstanceId {get; set; }
    
    /// <summary>
    /// The sequence number of the event (using to detect technical issues)
    /// </summary>
    public required SequenceNumber SequenceNumber { get; set; }
    
    public required SetEventReference PreviousEvent { get; set; }

    public required object Payload{ get; set;}
    
    /// <summary>
    /// The meta dictionary is used to store additional information about the event.
    /// </summary>
    public Dictionary<string, object>? Meta { get; set; } = null;
    
    /// <summary>
    /// The view state according to the client that is providing the information.
    /// </summary>
    public required SetViewState ViewState { get; set; }
    
    
}

public class SetEventReference
{
}

public class SequenceNumber
{
}

public class InstanceId
{
}