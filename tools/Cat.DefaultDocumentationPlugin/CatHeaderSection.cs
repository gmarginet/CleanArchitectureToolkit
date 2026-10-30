using System.Linq;
using Cat.Object.Extensions;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;

namespace Cat.DefaultDocumentationPlugin
{
    public class CatHeaderSection : ISection
    {
        // Every generated page lives in modules/<Module>/namespaces/<Namespace>/, so the relative paths are the same for all pages.
        private const string RootPath = "../../../../";
        private const string ModuleReadMeUrl = "../../README.md";
        private const string FallbackModuleLinkName = "MODULE";

        public string Name => "Header";

        public void Write(IWriter writer)
        {
            writer.ThrowIfNull(nameof(writer));

            if (writer.GetCurrentItem() != writer.Context.DocItem)
            {
                return;
            }

            var moduleLinkName = GetModuleLinkName(writer);
            var pageTitle = "Code Reference";

            // The header is the same table as in the module readme's. The menu line and the closing tags must start at column 0.
            // Otherwise Markdown treats them as code, and some previewers show them as text.
            var headerLines = new[]
            {
                $"<link href=\"{RootPath}resources/styles/style.css\" rel=\"stylesheet\" />",
                "<table>",
                "    <tr>",
                "        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>",
                "             Clean Architecture Toolkit for .NET",
                "        </td>",
                "    </tr>",
                "    <tr>",
                "        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>",
                "            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>",
                "            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>",
                "        <td style='padding: 0; border: none;' width='220'>",
                $"            <img src='{RootPath}resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>",
                "        </td>",
                "    </tr>",
                "    <tr>",
                "        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>",
                "",
                $"|&nbsp;&nbsp;&nbsp;[HOME]({RootPath}README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW]({RootPath}README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[{moduleLinkName}]({ModuleReadMeUrl})&nbsp;&nbsp;&nbsp;|",
                "",
                "</td>",
                "</tr>",
                "</table>",
                string.Empty
            };

            foreach (var headerLine in headerLines)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine(headerLine);
            }

            writer
                .EnsureLineStart()
                .Append($"# {pageTitle}")
                .AppendLine("  ");
            writer
                .AppendLine("  ");

            var firstWritten = false;
            var assembly = writer.Context.Items.Values.OfType<AssemblyDocItem>().Single();
            if (writer.Context.ItemsWithOwnPage.Contains(assembly))
            {
                writer
                    .EnsureLineStart()
                    .Append("##### >> ");
                AppendBreadcrumbLink(writer, assembly);
                firstWritten = true;
            }

            foreach (var parent in writer.Context.DocItem.GetParents().Skip(1))
            {
                if (!firstWritten)
                {
                    firstWritten = true;
                    writer
                        .EnsureLineStart()
                        .Append("##### >> ");
                }
                else
                {
                    writer.Append(" >> ");
                }

                AppendBreadcrumbLink(writer, parent);
            }
        }

        /// <summary>
        /// Writes a breadcrumb link with the kind of the item behind the name, like "Cat.Commands Namespace".
        /// The assembly and the namespace often share a name, so the kind tells them apart.
        /// </summary>
        private static void AppendBreadcrumbLink(IWriter writer, DocItem item)
        {
            var kind = GetKindName(item);

            if (kind == null)
            {
                writer.AppendLink(item);
                return;
            }

            writer.AppendLink(item, $"{item.Name} {kind}");
        }

        /// <summary>
        /// Returns the same kind word DefaultDocumentation puts at the end of the page title.
        /// </summary>
        private static string? GetKindName(DocItem item)
        {
            switch (item)
            {
                case AssemblyDocItem _: return "Assembly";
                case NamespaceDocItem _: return "Namespace";
                case ClassDocItem _: return "Class";
                case StructDocItem _: return "Struct";
                case InterfaceDocItem _: return "Interface";
                case EnumDocItem _: return "Enum";
                case DelegateDocItem _: return "Delegate";
                case ConstructorDocItem _: return "Constructor";
                case MethodDocItem _: return "Method";
                case PropertyDocItem _: return "Property";
                case FieldDocItem _: return "Field";
                case EnumFieldDocItem _: return "Field";
                case EventDocItem _: return "Event";
                case OperatorDocItem _: return "Operator";
                default: return null;
            }
        }

        /// <summary>
        /// Builds the menu name of the module from the output folder, which is modules/[Module]/namespaces/[Namespace].
        /// </summary>
        private static string GetModuleLinkName(IWriter writer)
        {
            var namespacesDirectory = writer.Context.Settings.OutputDirectory?.Parent;
            var moduleDirectory = namespacesDirectory?.Parent;

            if (namespacesDirectory?.Name != "namespaces" || moduleDirectory == null)
            {
                return FallbackModuleLinkName;
            }

            return moduleDirectory.Name.ToUpperInvariant();
        }
    }
}
