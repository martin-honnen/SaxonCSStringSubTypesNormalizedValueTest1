using Saxon.Api;

var processor = new Processor(true);

processor.SetProperty(Feature.XSD_VERSION, "1.0");

processor.SchemaManager.Compile(new Uri(Path.Combine(Environment.CurrentDirectory, "schema1.xsd")));

var docBuilder = processor.NewDocumentBuilder();

docBuilder.SchemaValidator = processor.SchemaManager.NewSchemaValidator();

var xmlDoc = docBuilder.Build(new Uri(Path.Combine(Environment.CurrentDirectory, "sample1.xml")));

var xpathCompiler = processor.NewXPathCompiler();
xpathCompiler.SchemaAware = true;

foreach (XdmNode node in xpathCompiler.Evaluate("//*[not(*)]", xmlDoc))
{
    Console.WriteLine($"{node.NodeType} {node.NodeName} has typed value |{node.TypedValue}| of type {node.TypedValue.GetType()}");
}

