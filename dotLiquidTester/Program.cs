using DotLiquid;
using System.Globalization;

const string LiquidTemplateFilePath = "./Samples/NestedRootArray-SqlOutFromLogicApps/template.liquid";

string TemplateContents = System.IO.File.ReadAllText(LiquidTemplateFilePath);
string Json = System.IO.File.ReadAllText("./Samples/NestedRootArray-SqlOutFromLogicApps/template.liquid");

Template t = Template.Parse(TemplateContents);

//dynamic o = JObject.Parse(Json);
//object o = JsonSerializer.Deserialize(Json, typeof(object));

Hash h =
	Hash.FromAnonymousObject(new
	{
		products = new[] { new { ProductID = 7000, ProductName = "Name" },
		new { ProductID = 7001, ProductName = "Another name" }
	}
	});
string Rendered = t.Render(h, CultureInfo.CurrentUICulture);

Console.WriteLine(Rendered);