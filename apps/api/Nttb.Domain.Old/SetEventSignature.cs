namespace Nttb.Domain.Old;

/// <summary>
///     The signature of an event in a set.
/// </summary>
/// <param name="Fingerprint">A fingerprint (a few bytes) of the public-private key used to sign.</param>
/// <param name="Signature">
///     The signature based on header and body that proofs it was created by the author. It can be
///     verified using the private key, but only the public key part is enough to verify authenticity.
/// </param>
/// <remarks>TODO: See http://cryptocoinjs.com/modules/crypto/ecdsa/ for one example</remarks>
public record SetEventSignature(string Fingerprint, string Signature);