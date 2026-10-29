namespace Cat.Responses.Abstractions;

// ReSharper disable MemberHidesStaticFromOuterClass
/// <summary>
/// Identifies the specific outcome of an operation, such as <see cref="Ok"/> or <see cref="NotFound"/>. Every outcome
/// is either a <see cref="Succeeded"/> or a <see cref="Failed"/> variant, so matching on the base type tells you
/// whether a response succeeded without inspecting the concrete outcome.
/// </summary>
public abstract class CatResponseType
{
    /// <summary>The operation succeeded.</summary>
    public static Succeeded.Ok Ok => new();
    /// <summary>The operation succeeded and created a new resource.</summary>
    public static Succeeded.Created Created => new();
    /// <summary>The operation succeeded and has nothing to return.</summary>
    public static Succeeded.NoContent NoContent => new();

    /// <summary>The operation failed because the request was invalid.</summary>
    public static Failed.BadRequest BadRequest => new ();

    /// <summary>The operation failed because the requested resource doesn't exist.</summary>
    public static Failed.NotFound NotFound => new();

    /// <summary>The operation failed because the caller isn't authorized to perform it.</summary>
    public static Failed.Unauthorized Unauthorized => new();

    /// <summary>The operation failed because of an unexpected error.</summary>
    public static Failed.InternalServerError InternalServerError => new();

    /// <summary>
    /// Base type for every outcome that represents a successful operation.
    /// </summary>
    public abstract class Succeeded : CatResponseType
    {
        /// <summary>The response type for <see cref="CatResponseType.Ok"/>.</summary>
        public new class Ok : Succeeded { }

        /// <summary>The response type for <see cref="CatResponseType.Created"/>.</summary>
        public new class Created : Succeeded { }

        /// <summary>The response type for <see cref="CatResponseType.NoContent"/>.</summary>
        public new class NoContent : Succeeded { }
    }

    /// <summary>
    /// Base type for every outcome that represents a failed operation.
    /// </summary>
    public abstract class Failed : CatResponseType
    {
        /// <summary>The response type for <see cref="CatResponseType.BadRequest"/>.</summary>
        public new class BadRequest : Failed { }

        /// <summary>The response type for <see cref="CatResponseType.NotFound"/>.</summary>
        public new class NotFound : Failed { }

        /// <summary>The response type for <see cref="CatResponseType.Unauthorized"/>.</summary>
        public new class Unauthorized : Failed { }

        /// <summary>The response type for <see cref="CatResponseType.InternalServerError"/>.</summary>
        public new class InternalServerError : Failed { }
    }
}