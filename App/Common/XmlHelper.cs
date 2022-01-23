using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace PDFPatcher.Common;

internal static class XmlHelper
{
    private const string BooleanYes = "yes";
    private const string BooleanNo = "no";

    [DebuggerStepThrough]
    public static bool GetValue(this XmlElement element, string name, bool defaultValue)
    {
        if (element == null)
        {
            return defaultValue;
        }

        XmlAttribute a = element.GetAttributeNode(name);
        return a != null ? a.Value.ToBoolean(defaultValue) : defaultValue;
    }

    /// <summary>
    ///     Get <paramref name="element" /> element name is the attribute value of <paramref name="name" />, if there is no
    ///     this property, or attributes cannot be resolved into an integer value, then return
    ///     <paramref name="defaultValue" />.
    /// </summary>
    /// <param name="element">The element of the attribute value is required.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="defaultValue">The default value of the attribute.</param>
    /// <returns>The value of the attribute; if this property does not exist, return the default value.</returns>
    [DebuggerStepThrough]
    public static int GetValue(this XmlElement element, string name, int defaultValue)
    {
        if (element == null)
        {
            return defaultValue;
        }

        XmlAttribute a = element.GetAttributeNode(name);
        return a != null ? a.Value.ToInt32(defaultValue) : defaultValue;
    }

    [DebuggerStepThrough]
    public static long GetValue(this XmlElement element, string name, long defaultValue)
    {
        if (element == null)
        {
            return defaultValue;
        }

        XmlAttribute a = element.GetAttributeNode(name);
        return a != null ? a.Value.ToInt64(defaultValue) : defaultValue;
    }

    [DebuggerStepThrough]
    public static float GetValue(this XmlElement element, string name, float defaultValue)
    {
        if (element == null)
        {
            return defaultValue;
        }

        XmlAttribute a = element.GetAttributeNode(name);
        return a != null ? a.Value.ToSingle(defaultValue) : defaultValue;
    }

    [DebuggerStepThrough]
    public static double GetValue(this XmlElement element, string name, double defaultValue)
    {
        if (element == null)
        {
            return defaultValue;
        }

        XmlAttribute a = element.GetAttributeNode(name);
        return a == null ? defaultValue : a.Value.ToDouble(defaultValue);
    }

    [DebuggerStepThrough]
    public static bool GetValue(this XmlReader reader, string name, bool defaultValue)
    {
        if (reader == null)
        {
            return defaultValue;
        }

        string a = reader.GetAttribute(name);
        return a?.ToBoolean(defaultValue) ?? defaultValue;
    }

    [DebuggerStepThrough]
    public static int GetValue(this XmlReader reader, string name, int defaultValue)
    {
        if (reader == null)
        {
            return defaultValue;
        }

        string a = reader.GetAttribute(name);
        return a?.ToInt32(defaultValue) ?? defaultValue;
    }

    [DebuggerStepThrough]
    public static float GetValue(this XmlReader reader, string name, float defaultValue)
    {
        if (reader == null)
        {
            return defaultValue;
        }

        string a = reader.GetAttribute(name);
        return a?.ToSingle(defaultValue) ?? defaultValue;
    }

    [DebuggerStepThrough]
    public static string GetValue(this XmlElement element, string name) => element?.GetAttributeNode(name)?.Value;

    [DebuggerStepThrough]
    public static string GetValue(this XmlElement element, string name, string defaultValue) =>
        element?.GetAttributeNode(name)?.Value ?? defaultValue;

    [DebuggerStepThrough]
    public static void SetValue(this XmlElement element, string name, bool value, bool defaultValue)
    {
        if (element == null)
        {
            return;
        }

        if (value == defaultValue)
        {
            element.RemoveAttribute(name);
        }
        else
        {
            element.SetAttribute(name, value ? BooleanYes : BooleanNo);
        }
    }

    [DebuggerStepThrough]
    public static void SetValue(this XmlElement element, string name, int value, int defaultValue)
    {
        if (element == null)
        {
            return;
        }

        if (value == defaultValue)
        {
            element.RemoveAttribute(name);
        }
        else
        {
            element.SetAttribute(name, value.ToText());
        }
    }

    [DebuggerStepThrough]
    public static void SetValue(this XmlElement element, string name, float value, float defaultValue)
    {
        if (element == null)
        {
            return;
        }

        if (value == defaultValue)
        {
            element.RemoveAttribute(name);
        }
        else
        {
            element.SetAttribute(name, value.ToText());
        }
    }

    [DebuggerStepThrough]
    public static void SetValue(this XmlElement element, string name, string value)
    {
        if (element == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(value))
        {
            element.RemoveAttribute(name);
        }
        else
        {
            element.SetAttribute(name, value);
        }
    }

    [DebuggerStepThrough]
    public static void SetValue(this XmlElement element, string name, string value, string defaultValue)
    {
        if (element == null)
        {
            return;
        }

        if (value == null || value == defaultValue)
        {
            element.RemoveAttribute(name);
        }
        else
        {
            element.SetAttribute(name, value);
        }
    }

    [DebuggerStepThrough]
    public static void WriteValue(this XmlWriter writer, string name, bool value, bool defaultValue)
    {
        if (writer != null && value != defaultValue)
        {
            writer.WriteAttributeString(name, value ? BooleanYes : BooleanNo);
        }
    }

    [DebuggerStepThrough]
    public static void WriteValue(this XmlWriter writer, string name, int value) =>
        writer?.WriteAttributeString(name, value.ToText());

    [DebuggerStepThrough]
    public static void WriteValue(this XmlWriter writer, string name, int value, int defaultValue)
    {
        if (writer != null && value != defaultValue)
        {
            writer.WriteAttributeString(name, value.ToText());
        }
    }

    [DebuggerStepThrough]
    public static void WriteValue(this XmlWriter writer, string name, float value) =>
        writer?.WriteAttributeString(name, value.ToText());

    public static XmlElement GetOrCreateElement(this XmlNode parent, string name) =>
        parent == null
            ? null
            : GetElement(parent, name) ?? parent.AppendElement(name);

    public static XmlElement GetElement(this XmlNode parent, string name)
    {
        if (parent == null)
        {
            return null;
        }

        XmlNode n = parent.FirstChild;
        while (n != null)
        {
            if (n.NodeType == XmlNodeType.Element && n.Name == name)
            {
                return n as XmlElement;
            }

            n = n.NextSibling;
        }

        return null;
    }

    [DebuggerStepThrough]
    public static XmlElement AppendElement(this XmlNode element, string name)
    {
        if (element == null)
        {
            return null;
        }

        XmlDocument d = element.NodeType != XmlNodeType.Document ? element.OwnerDocument : element as XmlDocument;
        XmlElement e = d.CreateElement(name);
        element.AppendChild(e);
        return e;
    }

    public static XmlNode[] ToXmlNodeArray(this XmlNodeList nodes)
    {
        if (nodes == null)
        {
            return Empty<XmlNode>.Item;
        }

        XmlNode[] a = new XmlNode[nodes.Count];
        int i = -1;
        foreach (XmlNode item in nodes)
        {
            a[++i] = item;
        }

        return a;
    }

    public static IList<TNode> ToNodeList<TNode>(this XmlNodeList nodes) where TNode : XmlNode
    {
        if (nodes == null)
        {
            return Empty<TNode>.Item;
        }

        List<TNode> a = new(7);
        foreach (object item in nodes)
        {
            if (item is TNode n)
            {
                a.Add(n);
            }
        }

        return a;
    }

    private static class Empty<TNode>
    {
        public static readonly TNode[] Item = new TNode[0];
    }
}
