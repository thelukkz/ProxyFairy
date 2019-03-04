using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;

namespace ProxyFairy.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectUserTagHelper : TagHelper
    {
        private IRepository _repository;

        public SelectUserTagHelper(IRepository repository)
        {
            _repository = repository;
        }

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync(false)).GetContent());

            string selected = ModelFor.Model as string;

            var appUsers = await _repository.All<AppUser>().ToListAsync();
            foreach (var user in appUsers)
            {
                if (selected != null && selected.Equals(user.Id))
                {
                    output.Content.AppendHtml($"<option selected value={user.Id}>{user.UserName}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option value={user.Id}>{user.UserName}</option>");
                }
            }
            output.Attributes.SetAttribute("Name", ModelFor.Name);
            output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}
