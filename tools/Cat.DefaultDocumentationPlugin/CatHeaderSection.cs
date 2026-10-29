using System.Linq;
using Cat.Object.Extensions;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace Cat.DefaultDocumentationPlugin
{
    public class CatHeaderSection : ISection
    {
        public string Name => "Header";
        
        public void Write(IWriter writer)
        {
            writer.ThrowIfNull(nameof(writer));

            if (writer.GetCurrentItem() != writer.Context.DocItem)
            {
                return;
            }

            var stylesheetUrl = "../../../resources/styles/style.css";
            var solutionDocumentationTitle = "Clean Architecture Toolkit for .NET";
            var solutionCatReadMeUrl = "../../../../README.md";
            var solutionCatReadMeLinkName = "CAT";
            var solutionCatReadMeTooltip = "Readme of the CAT project.";
            var solutionModuleReadMeUrl = "../../README.md";
            var solutionModuleReadMeLinkName = "Module";
            var solutionModuleReadMeTooltip = "Readme of the module.";
            var solutionModulesUrl = "../../../../README.md#module-overview";
            var solutionModulesLinkName = "Module overview";
            var solutionModulesTooltip = "List of all the CAT modules.";
            var pageTitle = "Class Reference";

            writer
                .EnsureLineStart()
                .Append($"<link href=\"{stylesheetUrl}\" rel=\"stylesheet\"></link>")
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .Append($"# `{solutionDocumentationTitle}`")
                .AppendLine("  ");
            writer
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .AppendUrl(solutionCatReadMeUrl, solutionCatReadMeLinkName, solutionCatReadMeTooltip)
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .AppendUrl(solutionModuleReadMeUrl, solutionModuleReadMeLinkName, solutionModuleReadMeTooltip)
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .AppendUrl(solutionModulesUrl, solutionModulesLinkName, solutionModulesTooltip)
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .AppendLine("  ");
            writer
                .EnsureLineStart()
                .Append($"# `{pageTitle}`")
                .AppendLine("  ");
            writer
                .AppendLine("  ");

            var firstWritten = false;
            var assembly = writer.Context.Items.Values.OfType<AssemblyDocItem>().Single();
            if (writer.Context.ItemsWithOwnPage.Contains(assembly))
            {
                writer
                    .EnsureLineStart()
                    .Append("##### > ")
                    .AppendLink(assembly);
                firstWritten = true;
            }

            foreach (var parent in writer.Context.DocItem.GetParents().Skip(1))
            {
                if (!firstWritten)
                {
                    firstWritten = true;
                    writer
                        .EnsureLineStart()
                        .Append("##### > ");
                }
                else
                {
                    writer.Append(" > ");
                }

                writer.AppendLink(parent);
            }
        }
    }
}