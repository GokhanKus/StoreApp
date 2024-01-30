using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreAppUI.TagHelpers
{
	[HtmlTargetElement("table")] //hedef alacagimiz html etiketi
	//razor pagelerde kullanilan ve html etiketlerini genisletmek ve ilgili etiketlere cesitli islevsellikler kazandirmak uzere kullandigimiz bir yapi
	public class TableTagHelper :TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Attributes.SetAttribute("class","table table-hover table-bordered");
		}
	}
}
