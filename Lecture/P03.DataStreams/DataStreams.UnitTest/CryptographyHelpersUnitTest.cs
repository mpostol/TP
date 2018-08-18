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
using System.Text;
using System.Xml;

namespace TP.DataStreams.Cryptography
{
  [TestClass]
  public class CryptographyHelpersUnitTest
  {
    [TestMethod]
    public void CalculateSHA256Test()
    {
      const string _password = "Fe4ZFH2VgpOOwBdM9dkI";
      (string HexString, string Base64) = _password.CalculateSHA256();
      Assert.AreEqual<string>("D9-CB-FB-B0-AD-87-D8-CE-0C-C0-D2-FF-1B-CF-F6-7C-69-33-D2-B4-B4-CC-4C-6F-A6-0C-E2-9F-73-32-2C-D8", HexString);
      Assert.AreEqual<int>(256 / 4 + 31, HexString.Length);
      Assert.AreEqual<string>("2cv7sK2H2M4MwNL/G8/2fGkz0rS0zExvpgzin3MyLNg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    public void CalculateSHA256LongTest()
    {
      const string _password = "UAXflAoVz8wcR1VkxUgTO8HAMBYK83yQvcHI9nqsQUiI4mx6jLlCAFGPrHj99XHi3uOoUfqe7wF7JkX2wBwwPADpn9f8s2Q0CfaA";
      (string HexString, string Base64) = _password.CalculateSHA256();
      Assert.AreEqual<string>("B7-7B-06-43-39-A0-D9-8C-72-2F-54-A7-B0-55-53-9B-D6-3B-AF-C0-7E-BD-2B-93-42-EA-24-7E-AA-86-FB-18", HexString);
      Assert.AreEqual<int>(256 / 4 + 31, HexString.Length);
      Assert.AreEqual<string>("t3sGQzmg2YxyL1SnsFVTm9Y7r8B+vSuTQuokfqqG+xg=", Base64);
      Assert.AreEqual<int>(44, Base64.Length);
    }
    [TestMethod]
    [DeploymentItem("Instrumentation")]
    public void EncryptDecryptDataTest()
    {
      //encrypt
      const string _inFileName = @"catalog.example.xml";
      FileInfo _inFileInfo = new FileInfo(_inFileName);
      Assert.IsTrue(_inFileInfo.Exists);
      const string _encryptedFileName = "encryptedXmlFile.xml";
      if (File.Exists(_encryptedFileName))
        File.Delete(_encryptedFileName);
      ProgressMonitor _logger = new ProgressMonitor();
      TripleDESCryptoServiceProvider _tripleDesProvider = new TripleDESCryptoServiceProvider();
      Assert.AreEqual<int>(192, _tripleDesProvider.KeySize);
      CryptographyHelpers.EncryptData(_inFileName, _encryptedFileName, _tripleDesProvider.Key, _tripleDesProvider.IV, _logger);
      FileInfo _encryptedFileInfo = new FileInfo(_encryptedFileName);
      Assert.IsTrue(_encryptedFileInfo.Exists);
      Assert.AreEqual<long>(_inFileInfo.Length, _logger.ReportedValue);
      //decrypt
      const string _decryptedFileName = "decryptedXmlFile.xml";
      if (File.Exists(_decryptedFileName))
        File.Delete(_decryptedFileName);
      _logger = new ProgressMonitor();
      CryptographyHelpers.DecryptData(_encryptedFileName, _decryptedFileName, _tripleDesProvider.Key, _tripleDesProvider.IV, _logger);
      FileInfo _decryptedFileInfo = new FileInfo(_decryptedFileName);
      Assert.IsTrue(_decryptedFileInfo.Exists);
      Assert.AreEqual<long>(_decryptedFileInfo.Length, _logger.ReportedValue);
      Assert.AreEqual<long>(_decryptedFileInfo.Length, _inFileInfo.Length);
      //TODO Compare input and decrypted files. Must be equal.
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
      const string _publicKey = @"PubliKey.xml";
      Assert.IsTrue(File.Exists(_publicKey));
      const string _publicPrivateKeys = @"PubliPrivateKeys.xml";
      Assert.IsTrue(File.Exists(_publicPrivateKeys));
      XmlDocument _documentToSign = new XmlDocument();
      _documentToSign.Load(_xmlFile);
      const string _signedFileName = "SignedXmlFile.xml";
      if (File.Exists(_signedFileName))
        File.Delete(_signedFileName);
      string _rsaKeys = null;
      using (StreamReader _reader = new StreamReader(_publicPrivateKeys, System.Text.Encoding.UTF8))
        _rsaKeys = _reader.ReadToEnd();
      CryptographyHelpers.SignSaveXml(_documentToSign, _rsaKeys, _signedFileName);
      Assert.IsTrue(File.Exists(_signedFileName));
      XmlDocument _signedXmlDocument1 = CryptographyHelpers.LoadVerifyXml(_signedFileName);
      Assert.IsNotNull(_signedXmlDocument1);
      using (StreamReader _reader = new StreamReader(_publicKey, System.Text.Encoding.UTF8))
        _rsaKeys = _reader.ReadToEnd();
      XmlDocument _signedXmlDocument2 = CryptographyHelpers.LoadVerifyXml(_rsaKeys, _signedFileName);
      Assert.IsNotNull(_signedXmlDocument2);
      const string _signedModifiedFileName = "SignedXmlFileWithSpace.xml";
      AddSpace(_signedFileName, _signedModifiedFileName);
      Assert.ThrowsException<CryptographicException>(() => { XmlDocument _ = CryptographyHelpers.LoadVerifyXml(_rsaKeys, _signedModifiedFileName); });
    }

    #region instrumentation
    private static void AddSpace(string inFileName, string outFilename)
    {
      string _content = File.ReadAllText(inFileName, Encoding.UTF8);
      _content = _content.Replace("Bob Dylan", "Bob  Dylan");
      File.WriteAllText(outFilename, _content, Encoding.UTF8);
    }
    private class ProgressMonitor : IProgress<long>
    {
      internal long ReportedValue = 0;
      public void Report(long value)
      {
        ReportedValue = value;
      }
    }
    #endregion

  }
}

