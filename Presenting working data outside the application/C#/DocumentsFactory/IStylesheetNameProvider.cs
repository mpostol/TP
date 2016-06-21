//<summary>
//  Title   : interface IStylesheetNameProvider
//  System  : Microsoft Visual C# .NET 2012
//  $LastChangedDate: 2013-12-24 13:53:54 +0100 (Tue, 24 Dec 2013) $
//  $Rev: 10134 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/branches/users/MPostol/trunk/SharePoint%202010%20Creating%20XML%20Documents%20Programmatically/C%23/CreateXMLFile/DocumentsFactory/IStylesheetNameProvider.cs $
//  $Id: IStylesheetNameProvider.cs 10134 2013-12-24 12:53:54Z mpostol $
//
//  Copyright (C) 2013, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

namespace Example.Xml.DocumentsFactory
{
  
  /// <summary>
  /// Represents XML file style sheet name provider
  /// </summary>
  public interface IStylesheetNameProvider
  {
    /// <summary>
    /// The style sheet name
    /// </summary>
    string StylesheetNmane { get; }

  }
}
