//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
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
      Assert.AreEqual<string>("D9CBFBB0AD87D8CE0CC0D2FF1BCFF67C6933D2B4B4CC4C6FA60CE29F73322CD8", HexString);
      Assert.AreEqual<int>(256/4, HexString.Length);
      Assert.AreEqual<string>("2cv7sK2H2M4MwNL/G8/2fGkz0rS0zExvpgzin3MyLNg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    public void CalculateSHA256LongTest()
    {
      const string _pasword = "UAXflAoVz8wcR1VkxUgTO8HAMBYK83yQvcHI9nqsQUiI4mx6jLlCAFGPrHj99XHi3uOoUfqe7wF7JkX2wBwwPADpn9f8s2Q0CfaA";
      (string HexString, string Base64) = _pasword.CalculateSHA256();
      Assert.AreEqual<string>("B77B064339A0D98C722F54A7B055539BD63BAFC07EBD2B9342EA247EAA86FB18", HexString);
      Assert.AreEqual<int>(256 / 4, HexString.Length);
      Assert.AreEqual<string>("t3sGQzmg2YxyL1SnsFVTm9Y7r8B+vSuTQuokfqqG+xg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    public void XmlSignatureTestMethod1()
    {
      (RSAParameters parameters, string publicKey, string privatePublicKeys) = CreateRSACryptoServiceKeys();
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
      string _rsaKeys = null;
      if (File.Exists(_signedFileName))
        File.Delete(_signedFileName);
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
    private (RSAParameters parameters, string publicKey, string privatePublicKeys) CreateRSACryptoServiceKeys()
    {
      using (RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider(2048))
      {
        RSAParameters _parameters = _rsa.ExportParameters(true);
        string _public = _rsa.ToXmlString(false);
        string _both = _rsa.ToXmlString(true);
        return (_parameters, _public, _both);
      }
    }
  }
}

