using Cat.Object.Extensions;
using DefaultDocumentation;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Parameters;

namespace Cat.DefaultDocumentationPlugin
{
    /// <summary>
    /// Links method and constructor parameters to the page that documents them.
    /// </summary>
    /// <remarks>
    /// The built-in DocItem factory skips the overloads page for parameters and type parameters.
    /// It links to the page of the type instead, where the anchor does not exist.
    /// </remarks>
    public class CatMemberParameterUrlFactory : IUrlFactory
    {
        private readonly DocItemFactory _docItemFactory = new DocItemFactory();

        public string Name => "CatMemberParameter";

        public string? GetUrl(IPageContext context, string id)
        {
            context.ThrowIfNull(nameof(context));
            id.ThrowIfNull(nameof(id));

            if (!context.Items.TryGetValue(id, out var item)
                || !(item is ParameterDocItem || item is TypeParameterDocItem)
                || !(item.Parent is MethodDocItem || item.Parent is ConstructorDocItem))
            {
                return null;
            }

            var parameterUrl = _docItemFactory.GetUrl(context, id);
            var memberUrl = _docItemFactory.GetUrl(context, item.Parent.Id);
            var anchorIndex = parameterUrl?.IndexOf('#') ?? -1;
            if (memberUrl is null || anchorIndex < 0)
            {
                return null;
            }

            return memberUrl.Split('#')[0] + parameterUrl!.Substring(anchorIndex);
        }
    }
}
