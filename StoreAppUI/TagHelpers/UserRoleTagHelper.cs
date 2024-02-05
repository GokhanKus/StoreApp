using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Data;

namespace StoreAppUI.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "asp-role-users")] //td etiketi altında calısan "asp-role-users" tagi
	public class UserRoleTagHelper : TagHelper
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HtmlAttributeName("asp-role-users")]
		public string username { get; set; } = null!;
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var user = await _userManager.FindByNameAsync(username);

			TagBuilder ul = new TagBuilder("ul");

			var roles = _roleManager.Roles.Select(r => r.Name).ToList();

			foreach (var role in roles)
			{
				TagBuilder li = new TagBuilder("li");

				if (await _userManager.IsInRoleAsync(user, role))
				{
					li.InnerHtml.Append(role);
					ul.InnerHtml.AppendHtml(li);
				}

			}
			output.Content.AppendHtml(ul);
		}
	}

}

