using System.Collections.Generic;
using System.Xml;

public interface IExportable
{
    string ToXML(string filePath);
    IExportable Import(string filePath);
}
