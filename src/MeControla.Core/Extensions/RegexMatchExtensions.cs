using System;
using System.Text.RegularExpressions;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with Match.
/// </summary>
public static class RegexMatchExtensions
{
    /// <summary>
    /// Retrieves the matched value from the specified group within the provided match object.
    /// If the group is not successfully matched, the method will return <c>null</c>.
    /// </summary>
    /// <param name="match">The <see cref="Match"/> object containing the match results.</param>
    /// <param name="groupName">The name of the group to retrieve the value from.</param>
    /// <returns>The matched value if the group exists and is successfully matched; otherwise, <c>null</c>.</returns>
    public static string GetValueOrDefault(this Match match, string groupName)
        => GetValueOrDefault(match, groupName, null);

    /// <summary>
    /// Retrieves the matched value from the specified group within the provided match object.
    /// If the group is not successfully matched, the method will return the specified default value.
    /// </summary>
    /// <param name="source">The <see cref="Match"/> object containing the match results.</param>
    /// <param name="groupName">The name of the group to retrieve the value from.</param>
    /// <param name="defaultValue">The default value to return if the group is not successfully matched.</param>
    /// <returns>The matched value if the group exists and is successfully matched; otherwise, the specified default value.</returns>
    public static string GetValueOrDefault(this Match source, string groupName, string defaultValue)
    {
        ArgumentNullException.ThrowIfNull(source);

        ArgumentException.ThrowIfNullOrWhiteSpace(groupName);

        return source.Groups.TryGetValue(groupName, out Group group) && group.Success
             ? group.Value
             : defaultValue;
    }
}