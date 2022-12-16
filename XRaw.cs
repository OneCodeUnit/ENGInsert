using System.Xml;
using System.Xml.Linq;

namespace ENGInsert
{
    internal class XRaw : XText
    {
        public XRaw(string text) : base(text) { }
        public XRaw(XText text) : base(text) { }

        public override void WriteTo(XmlWriter writer)
        {
            writer.WriteRaw(this.Value);
        }
    }
}
