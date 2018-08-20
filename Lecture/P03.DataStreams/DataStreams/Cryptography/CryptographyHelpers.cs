//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace TP.DataStreams.Cryptography
{

  public static class CryptographyHelpers
  {
    public static (string Hex, string Base64) CalculateSHA256(this string inputStream)
    {
      byte[] _inputStreamBytes = Encoding.UTF8.GetBytes(inputStream);
      using (SHA256 mySHA256 = SHA256Managed.Create())
      {
        byte[] hashValue = mySHA256.ComputeHash(_inputStreamBytes);
        return (BitConverter.ToString(hashValue), Convert.ToBase64String(hashValue, Base64FormattingOptions.InsertLineBreaks));
      }
    }
    public static void EncryptData(string inFileName, string outFileName, byte[] dESKey, byte[] dESIV, IProgress<long> progress)
    {
      //Create the file streams to handle the input and output files.
      using (FileStream _inFileStream = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
      {
        const int _bufferLength = 100;
        byte[] _buffer = new byte[_bufferLength]; //This is intermediate storage for the encryption.
        long _bytesWritten = 0; //This is the total number of bytes written.
        TripleDESCryptoServiceProvider _tripleProvider = new TripleDESCryptoServiceProvider();
        FileStream _outFileStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
        using (CryptoStream _outCryptoStream = new CryptoStream(_outFileStream, _tripleProvider.CreateEncryptor(dESKey, dESIV), CryptoStreamMode.Write))
        {
          //Read from the input file, then encrypt and write to the output file.
          while (true)
          {
            int _length = _inFileStream.Read(_buffer, 0, _bufferLength);
            if (_length == 0)
            {
              _outCryptoStream.FlushFinalBlock();
              break;
            }
            _outCryptoStream.Write(_buffer, 0, _length);
            _bytesWritten = _bytesWritten + _length;
            progress.Report(_bytesWritten);
          }
        }
      }
    }
    public static void DecryptData(string inCryptoFileName, string outFileName, byte[] dESKey, byte[] dESIV, IProgress<long> progress)
    {
      //Create the file streams to handle the input and output files.
      using (FileStream _outFileStream = new FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write))
      {
        _outFileStream.SetLength(0);
        const int _bufferLength = 100;
        byte[] _buffer = new byte[_bufferLength]; //This is intermediate storage for the decrypted content.
        long _bytesWritten = 0;
        TripleDESCryptoServiceProvider _tripleProvider = new TripleDESCryptoServiceProvider();
        FileStream _inFileStream = new FileStream(inCryptoFileName, FileMode.Open, FileAccess.Read);
        using (CryptoStream _inCryptoStream = new CryptoStream(_inFileStream, _tripleProvider.CreateDecryptor(dESKey, dESIV), CryptoStreamMode.Read))
        {
          while (true)
          {
            int _length = _inCryptoStream.Read(_buffer, 0, _bufferLength);
            if (_length == 0)
              break;
            _outFileStream.Write(_buffer, 0, _length);
            _bytesWritten = _bytesWritten + _length;
            progress.Report(_bytesWritten);
          }
        }
      }
    }
    /// <summary>
    /// Creates the RSA crypto service keys.
    /// </summary>
    /// <returns>Returns <see cref="ValueTuple"/> containing key RSA values </returns>
    public static (RSAParameters parameters, string publicKey, string privatePublicKeys) CreateRSACryptoServiceKeys()
    {
      using (RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider(2048))
      {
        RSAParameters _parameters = _rsa.ExportParameters(true);
        string _public = _rsa.ToXmlString(false);
        string _both = _rsa.ToXmlString(true);
        return (_parameters, _public, _both);
      }
    }
    /// <summary>
    /// Sign and save an XML document.
    /// </summary>
    /// <param name="document">Document to be signed</param>
    /// <param name="rsa">The keys ro be used by the <see cref="RSACryptoServiceProvider"/> RSA algorithm implementation.</param>
    /// <remarks>
    /// This document cannot be verified unless the verifying code has the public key with which it was signed.
    /// </remarks>
    public static void SignSaveXml(this XmlDocument document, string rSAKeys, string fileName)
    {
      #region Check arguments
      if (document == null)
        throw new ArgumentException($"The {nameof(document)} parameter cannot be null");
      if (string.IsNullOrEmpty(rSAKeys))
        throw new ArgumentException($"The {nameof(rSAKeys)} parameter cannot be null");
      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentException($"The {nameof(fileName)} parameter cannot be null");
      #endregion
      using (RSACryptoServiceProvider _rSAProvider = new RSACryptoServiceProvider())
      {
        _rSAProvider.FromXmlString(rSAKeys);
        KeyInfo _keyInfo = new KeyInfo();// Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
        _keyInfo.AddClause(new RSAKeyValue(_rSAProvider));
        SignedXml _signedXml = new SignedXml(document)
        {
          SigningKey = _rSAProvider, // Add the key to the SignedXml document.
          KeyInfo = _keyInfo
        };
        Reference _reference = new Reference // Create a reference to be signed.
        {
          Uri = "" //An entire XML document is to be signed using an enveloped signature.
        };
        XmlDsigEnvelopedSignatureTransform _envelope = new XmlDsigEnvelopedSignatureTransform(); // Add an enveloped transformation to the reference.
        _reference.AddTransform(_envelope);
        _signedXml.AddReference(_reference); // Add the reference to the SignedXml object.
        _signedXml.ComputeSignature(); // Compute the signature.
        XmlElement _xmlDigitalSignature = _signedXml.GetXml(); // Get the XML representation of the signature and save it to an XmlElement object.
        document.DocumentElement.AppendChild(document.ImportNode(_xmlDigitalSignature, true));// Append the element to the XML document.
      }
      document.Save(fileName);
    }
    /// <summary>
    /// Load and verify the signature of an XML file against an asymmetric RSA algorithm and return the document.
    /// </summary>
    /// <param name="rsaKeys">The RSA keys as the xml document.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>An instance of the <see cref="XmlDocument"/> capturing the xml file.</returns>
    /// <exception cref="ArgumentException">
    /// rsaKeys
    /// or
    /// fileName
    /// </exception>
    /// <exception cref="System.Security.Cryptography.CryptographicException"></exception>
    /// <remarks>There must be only one signature.</remarks>
    public static XmlDocument LoadVerifyXml(string rsaKeys, string fileName)
    {
      #region Check arguments
      if (string.IsNullOrEmpty(rsaKeys))
        throw new ArgumentException($"The {nameof(rsaKeys)} parameter cannot be null");
      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentException($"The {nameof(fileName)} parameter cannot be null");
      #endregion
      (XmlDocument _document, SignedXml _signedXml) = LoadSignedXmlFile(fileName);
      using (RSACryptoServiceProvider _provider = new RSACryptoServiceProvider())
      {
        _provider.FromXmlString(rsaKeys);
        if (!_signedXml.CheckSignature(_provider))// Check the signature using custom RSA keys.
          throw new CryptographicException($"Wrong signature of the document.");
      }
      return _document;
    }
    public static XmlDocument LoadVerifyXml(string fileName)
    {
      #region Check arguments
      if (string.IsNullOrEmpty(fileName))
        throw new ArgumentException($"The {nameof(fileName)} parameter cannot be null");
      #endregion
      (XmlDocument _document, SignedXml _signedXml) = LoadSignedXmlFile(fileName);
      if (!_signedXml.CheckSignature())// Check the signature and return the result.
        throw new System.Security.Cryptography.CryptographicException($"Wrong signature of the document.");
      return _document;
    }
    private static (XmlDocument document, SignedXml signedXml) LoadSignedXmlFile(string fileName)
    {
      XmlDocument _document = new XmlDocument();
      _document.Load(fileName);
      SignedXml _signedXml = new SignedXml(_document);
      XmlNodeList _nodeList = _document.GetElementsByTagName("Signature");// Find the "Signature" node and create a new XmlNodeList object.
      if (_nodeList.Count != 1) // There must be only one signature. Return false if 0 or more than one signatures was found.
        throw new CryptographicException($"Expected exactly one signature but the file contaons {_nodeList.Count}.");
      _signedXml.LoadXml((XmlElement)_nodeList[0]);// Load the first <signature> node.
      _document.DocumentElement.RemoveChild(_nodeList[0]);
      return (_document, _signedXml);
    }
  }
}