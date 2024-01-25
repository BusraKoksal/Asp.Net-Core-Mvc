using Abc.Coree;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;


namespace Abc.Northwind.MvcWebUI.TagHelpers
{
    //28.08
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]//_-_-_->attribute
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("currernt-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
        // şimdi taghelper'i oluşturalım bunun için tag helperin process metodunu ezmemiz gerekiyor.
        //public override void Process(TagHelperContext context, TagHelperOutput output)//output:taghelperin çıktısı
        //{
        //    output.TagName = "div";
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append("<ul class='pagination'>");

        //    for(int i = 1; i <= PageCount; i++)
        //    {
        //        stringBuilder.AppendFormat("<li style='margin: 5px;{0}'>", i == CurrentPage ? "font-weight: bold; background-color: #007bff; color: white;" : "");
        //        stringBuilder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : " ");
        //        stringBuilder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory, i);
        //        stringBuilder.Append("</li>");  
        //    }
        //    output.Content.SetHtmlContent(stringBuilder.ToString());
        //    // divin içeriği için bir html content oluştur,onu da stringbuilderin stringe çevrilmiş halinden al demek.

        //    base.Process(context, output);
        //}




        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<div style='clear:both;'></div>"); // Altta boşluk bırakmak için
            stringBuilder.Append("<ul class='pagination' style='margin-top: 20px;'>"); // Sayfalama stilini düzenlemek için margin-top ekledik
            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.Append("<li style='display:inline-block; margin: 5px; padding: 5px; border: 1px solid #ccc;'>");
                stringBuilder.AppendFormat("<a href='/product/index?page={0}&category={1}' style='{2}'>{0}</a>",
                    i, CurrentCategory, i == CurrentPage ? "font-weight: bold; background-color: #007bff; color: white;" : "");
                stringBuilder.Append("</li>");
            }
            stringBuilder.Append("</ul>");
            stringBuilder.Append("<div style='clear:both;'></div>"); // Altta boşluk bırakmak için
            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
