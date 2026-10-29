using System.Reflection;

namespace Cat.Expressions;

/// <summary>
/// Identifies a compiled member expression by its member and the expression's text, so it can be used as a cache key.
/// </summary>
internal class CatCompiledMemberExpressionKey
{
    private readonly MemberInfo _memberInfo;
    private readonly string _expressionKey;

    /// <summary>
    /// Captures the member and the expression's string form, so two keys built from equivalent expressions compare equal.
    /// </summary>
    /// <param name="memberInfo">The member the expression resolves to.</param>
    /// <param name="expression">The expression to key on.</param>
    public CatCompiledMemberExpressionKey(MemberInfo memberInfo, System.Linq.Expressions.Expression expression)
    {
        _memberInfo = memberInfo;
        _expressionKey = expression.ToString();
    }

    /// <summary>
    /// Checks whether this key refers to the same member and expression text as <paramref name="other"/>.
    /// </summary>
    /// <param name="other">The key to compare against.</param>
    /// <returns><c>true</c> if both keys refer to the same member and expression text.</returns>
    public bool Equals(CatCompiledMemberExpressionKey other)
    {
        return _memberInfo.Equals(other._memberInfo) && _expressionKey.Equals(other._expressionKey);
    }

    /// <summary>
    /// Checks whether <paramref name="obj"/> is a key that refers to the same member and expression text.
    /// </summary>
    /// <param name="obj">The object to compare against.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is a key with the same member and expression text.</returns>
    public override bool Equals(object? obj) => obj is CatCompiledMemberExpressionKey other && (other._memberInfo, other._expressionKey).Equals((_memberInfo, _expressionKey));

    /// <summary>
    /// Builds a hash code from the member and the expression text, so equal keys land in the same cache bucket.
    /// </summary>
    /// <returns>A hash code for this key.</returns>
    public override int GetHashCode() => (_memberInfo, _expressionKey).GetHashCode();
}