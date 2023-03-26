﻿using System.Text.RegularExpressions;

namespace Nttb.Domain.Old.Shared;

internal static partial class RegularExpressions
{
    [GeneratedRegex("^(?<home>\\d+)-(?<away>\\d+)$", RegexOptions.ExplicitCapture| RegexOptions.NonBacktracking | RegexOptions.CultureInvariant)]
    public static partial Regex ScoreRegex();
}