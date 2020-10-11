using System.Collections.Generic;
using System.Xml.Serialization;

namespace AspNetCore.Docusaurus.Core.Entitites.Docs
{
    [XmlRoot(ElementName = "assembly")]
	public class XmlAssembly
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "member")]
	public class Member
	{
		[XmlElement(ElementName = "summary")]
		public string Summary { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "returns")]
		public string Returns { get; set; }
		[XmlElement(ElementName = "param")]
		public Param Param { get; set; }
	}

	[XmlRoot(ElementName = "param")]
	public class Param
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "members")]
	public class Members
	{
		[XmlElement(ElementName = "member")]
		public List<Member> Member { get; set; }
	}

	[XmlRoot(ElementName = "doc")]
	public class Doc
	{
		[XmlElement(ElementName = "assembly")]
		public XmlAssembly Assembly { get; set; }
		[XmlElement(ElementName = "members")]
		public Members Members { get; set; }
	}
}
