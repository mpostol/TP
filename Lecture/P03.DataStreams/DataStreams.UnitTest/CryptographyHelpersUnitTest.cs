//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Xml;

namespace TP.DataStreams.Cryptography
{
  [TestClass]
  public class CryptographyHelpersUnitTest
  {
    [TestMethod]
    public void CalculateSHA256Test()
    {
      const string _pasword = "Fe4ZFH2VgpOOwBdM9dkI";
      (string HexString, string Base64) = _pasword.CalculateSHA256();
      Assert.AreEqual<string>("D9-CB-FB-B0-AD-87-D8-CE-0C-C0-D2-FF-1B-CF-F6-7C-69-33-D2-B4-B4-CC-4C-6F-A6-0C-E2-9F-73-32-2C-D8", HexString);
      Assert.AreEqual<int>(256 / 4 + 31, HexString.Length);
      Assert.AreEqual<string>("2cv7sK2H2M4MwNL/G8/2fGkz0rS0zExvpgzin3MyLNg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    public void CalculateSHA256LongTest()
    {
      const string _pasword = "UAXflAoVz8wcR1VkxUgTO8HAMBYK83yQvcHI9nqsQUiI4mx6jLlCAFGPrHj99XHi3uOoUfqe7wF7JkX2wBwwPADpn9f8s2Q0CfaA";
      (string HexString, string Base64) = _pasword.CalculateSHA256();
      Assert.AreEqual<string>("B7-7B-06-43-39-A0-D9-8C-72-2F-54-A7-B0-55-53-9B-D6-3B-AF-C0-7E-BD-2B-93-42-EA-24-7E-AA-86-FB-18", HexString);
      Assert.AreEqual<int>(256 / 4 + 31, HexString.Length);
      Assert.AreEqual<string>("t3sGQzmg2YxyL1SnsFVTm9Y7r8B+vSuTQuokfqqG+xg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    [DeploymentItem("Instrumentation")]
    public void EncryptDataTest()
    {
      const string _inFileName = @"catalog.example.xml";
      FileInfo _inFileInfo = new FileInfo(_inFileName);
      Assert.IsTrue(_inFileInfo.Exists);
      const string _outFileName = "encrypteDXmlFile.xml";
      if (File.Exists(_outFileName))
        File.Delete(_outFileName);
      ProgressMonitor _logger = new ProgressMonitor();
      TripleDESCryptoServiceProvider _tripleDesProvider = new TripleDESCryptoServiceProvider();
      CryptographyHelpers.EncryptData(_inFileName, _outFileName, _tripleDesProvider.Key, _tripleDesProvider.IV, _logger);
      Assert.AreEqual<int>(7, _logger.ReportedCycles);
      FileInfo _outFileInfo = new FileInfo(_outFileName);
      Assert.AreEqual<long>(_outFileInfo.Length, _inFileInfo.Length+1);
      Assert.AreEqual<long>(_outFileInfo.Length, _logger.ReportedValue+1);
    }
    [TestMethod]
    public void CreateRSACryptoServiceKeysTest()
    {
      (RSAParameters parameters, string publicKey, string privatePublicKeys) = CryptographyHelpers.CreateRSACryptoServiceKeys();
      Assert.IsNotNull(parameters);
      Assert.AreNotEqual<string>(publicKey, privatePublicKeys);
      Debug.WriteLine(publicKey);
      Debug.WriteLine(string.Empty);
      Debug.WriteLine(privatePublicKeys);
    }
    [TestMethod]
    [DeploymentItem("Instrumentation")]
    public void XmlSignatureTest()
    {
      const string _xmlFile = @"catalog.example.xml";
      Assert.IsTrue(File.Exists(_xmlFile));
      const string _publiKey = @"PubliKey.xml";
      Assert.IsTrue(File.Exists(_publiKey));
      const string _publiPrivateKeys = @"PubliPrivateKeys.xml";
      Assert.IsTrue(File.Exists(_publiPrivateKeys));
      XmlDocument _documentToSign = new XmlDocument();
      _documentToSign.Load(_xmlFile);
      const string _signedFileName = "SignedXmlFile.xml";
      if (File.Exists(_signedFileName))
        File.Delete(_signedFileName);
      string _rsaKeys = null;
      using (StreamReader _reader = new StreamReader(_publiPrivateKeys, System.Text.Encoding.UTF8))
        _rsaKeys = _reader.ReadToEnd();
      CryptographyHelpers.SignSaveXml(_documentToSign, _rsaKeys, _signedFileName);
      Assert.IsTrue(File.Exists(_signedFileName));
      XmlDocument _signedXmlDocument1 = CryptographyHelpers.LoadVerifyXml(_signedFileName);
      Assert.IsNotNull(_signedXmlDocument1);
      using (StreamReader _reader = new StreamReader(_publiKey, System.Text.Encoding.UTF8))
        _rsaKeys = _reader.ReadToEnd();
      XmlDocument _signedXmlDocument2 = CryptographyHelpers.LoadVerifyXml(_rsaKeys, _signedFileName);
      Assert.IsNotNull(_signedXmlDocument2);
      Assert.AreEqual<string>(_signedXmlDocument1.ToString(), _signedXmlDocument2.ToString());
    }
    private class ProgressMonitor : IProgress<long>
    {
      internal long ReportedValue = 0;
      internal int ReportedCycles = 0;
      public void Report(long value)
      {
        ReportedCycles++;
        ReportedValue = value;
      }
    }

  }
}

