using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;

namespace ProxyFairy.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectCustomerTagHelper : TagHelper
    {
        private IRepository _repository;

        public SelectCustomerTagHelper(IRepository repository)
        {
            _repository = repository;
        }

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync(false)).GetContent());

            string selected = ModelFor.Model as string;

            var customers = await _repository.All<Customer>().ToListAsync();
            foreach (var c in customers)
            {
                if (selected != null && selected.Equals(c.Id))
                {
                    output.Content.AppendHtml($"<option selected value={c.Id}>{c.Name}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option value={c.Id}>{c.Name}</option>");
                }
            }
            output.Attributes.SetAttribute("Name", ModelFor.Name);
            output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}
