<!--
//____________________________________________________________________________________________________________________________________
//
// Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
// To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
// https://github.com/mpostol/TP/discussions/182
//
// by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________
-->

# Cryptography

## Hash

### Introduction

Now let's talk about securing streams using cryptography. Talking about cryptography in the context of streams may seem a little strange because usually cryptography is discussed in the context of data security and system security in general. For now, I mention this seemingly strange combination of topics to ask for your patience. Everything will be clear soon; I promise. Cryptography is a broad concept, but we will focus only on selected, very practical aspects related to the security of bitstreams.

We already know how to create bitstreams. We can also attach coding to them, i.e. the natural language alphabet. The next step is to assign syntax and semantics that allow the streams to be transformed into a coherent document and therefore enable recovery of information from these documents by a computer user. If this is not enough, we can also display these documents in graphical form. We will come back to this last issue because we have not said the last word here.

However, the most important thing is that a stream is still a stream, so it is a sequence of bits and can be sent, archived, and processed by another computer. It must be stressed again that this infrastructure is always binary. Well, this is where the problem arises. It is required that this binary document is protected against malicious operations. For example, if this document contains a transfer order to our bank, the problem becomes real, material, and meaningful in this context.

If we are talking about archiving streams or sending streams from one system to another, from one to another computer, the first thing we need to take care of is the integrity of such a stream. This means that from the moment it is produced until it is at its actual destination, where it will be processed, it is not modified. The best way to accomplish this is by using the hash function.

It often happens that only authorized persons should have access to the information represented by the binary stream, and therefore no unauthorized persons should have access to it. We can then proceed in such a way that using the bidirectional conversion mechanism, a source bitstream is replaced with another bitstream to which we cannot attach the encoding, syntax, and semantics rules any longer. As a result, it makes it impossible to associate information with this bitstream. It resembles a white noise. However, any person who has the right to access this information; should be able to recover the source bitstream and as a result associate back the encoding, syntax, and semantics rules to enable the recovery of the information represented by the source bitstream.

When talking about documents such as a transfer order, there is no need to provide any special justification that the recipient of such a document will be vitally interested in being able to determine that the document has been issued by an authorized person, for example by the owner of the account for which the order was issued.

## Hash Function

Let's move on to the first option for securing streams: the hash function. It is a function that transforms the input bitstream to calculate another fixed-size unique bitstream. A collision in a hash function occurs when two different inputs produce the same hash value as output. The next feature of the received output bitstream is that the reverse transformation, i.e. recovering the source bitstream is practically impossible. One way to use such a function is to associate this hash value with the bitstream we want to protect. Then the hash value can be used to check whether the bitstream has not been modified in the meantime by calculating this function again and comparing the result with the associated hash value with the source bitstream if the expanded bitstream is archived or sent from one place to another. A certain drawback of this solution is that the algorithms for these functions are widely known, so if a "man in the middle" wants to modify the source bitstream, they can modify the source bitstream and recalculate a new value of the hash function for the previously modified bitstream.

Anyway, there are a few scenarios where this approach makes sense. Well, for example, the value of the hash function may be entered into the next bitstream called block, and a chain protection is created. The next block, which is also a bitstream, containing this hash value and pointing to the previous block means that we cannot modify the previous block because the value of the hash function is stored in the next one. This type of chain security is called blockchain and is used widely to protect against double-spending on crypto-currencies, for example, Bitcoin (fig below).

![Blockchain](.Media/Blockchain.png)

Blockchain security helps ensure that if someone wants to modify one of the blocks in the chain, they must modify all the blocks that have been attached to that chain later. Of course, this is still possible, so further safeguards are needed. Among other things, the growth rate of this chain, i.e. the speed of adding subsequent blocks to the chain, is greater than the possibility of modifying fragments of the chain.

This topic is far beyond the scope of this document, but if you are interested in getting more I encourage you to check out a dedicated GitHub repository [NBlockchain][NBlockchain]. There is a practical example of how to implement such a chain.

### Cryptography Helpers Unit Test

So let's see how the hash function works and how it can be used in practice. In the [CryptographyHelpersUnitTest][CryptographyHelpersUnitTest] class, two unit tests have been prepared. They use the [CalculateSHA256][CalculateSHA256] method defined in the library. It is worth emphasizing once again that the argument of a hash function is always a bitstream. But obviously, the hash function may also be used for text, namely a bitstream for which an encoding has been defined. In the `CalculateSHA256Test` method, we have to protect a password. It is a string of random characters. Password may be associated with syntax and semantics to make it easier to remember but, fortunately, these syntax and semantics rules have no impact on the hash calculation. In this method, instead of a bitstream, we have a stream of characters compliant with the string type. The Alt+F12 key will take us to the definition of the [CalculateSHA256][CalculateSHA256] method. The input parameter of this method is a sequence of characters of the `string` type, but the hash function operates on an array of bytes, therefore we must transform this string of characters into a string of bytes. To do this, we need to have defined encoding. In the case of the method under consideration, this is `UTF8`. This is the first yellow light that should light up because everyone who will use the result of the hash function to check the correctness of the input string must use the same encoding (UTF8 in this case). If someone uses a different encoding, the hash function cannot necessarily be used to check the consistency of the input text. To be able to calculate the hash function in the [CalculateSHA256][CalculateSHA256] method, we need to create an object of the `SHA256Managed` class available in the language library. Since it implements `IDisposable`, I used the using statement.

In the next line:

``` csharp
return (BitConverter.ToString(hashValue), Convert.ToBase64String(hashValue, Base64FormattingOptions.InsertLineBreaks));
```

a bitstream generated by the hash function is converted into two text forms. The `BitConverter.ToString` converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal representation. The second form is a string with a notation consistent with the hexadecimal code compliant with the Base64 standard.

Base64 is a binary-to-text conversion. The output of this conversion represents binary data in an ASCII string format. It is commonly used in scenarios where binary data needs to be stored or transferred as text. This conversion method `Base64` is available in the language library and has many overloads. They all implement the RFC 2045 standard. And here another yellow flag should be raised because it is not the only standard that defines the Base64 conversion. Moreover, based on the RFC database, it is easy to conclude that several RFC documents previously defined this conversion. So we can expect that this standard has been modified over time. Therefore, the question is about the lifetime length of the calculated hash value if it is saved as text compliant with the Base64 standard. It may turn out that the input string has not changed, but in the meantime, the implementation of the `Base64` conversion has changed and therefore using this string for validation is useless.

In unit tests methods, we have two assertions, which compare the result returned by hash calculation methods with defined hard-coded text. If the encoding changes when converting the input string of characters and when the implementation of the conversion to hexadecimal text or `Base64` changes, we can expect that these assertions and invariants will not be true and the test will end with an error. And we also have to consider this as another yellow flag that has to be raised. In other words, the use of a string, although convenient, unfortunately, has the consequence that this conversion from a stream of bytes to text compliant with the string type does not always have to be the same and may change over time. So why use it; someone may ask; In that case, wouldn't it be better for us to base it on a sequence of bytes? Well, we cannot always attach such a sequence of bits to the text; if it is e-mail, for example, then the email system has strictly defined characters that it can use to control data flow. Hence, it has to be taken into consideration the fact that attaching such a raw bitstream could have invalid characters causing problems with the correct operation of the email system. Therefore, conversion to text is sometimes necessary, but you need to remember these caveats.

## Encryption

### Introduction

In this subsection of the cryptographic security of bitstreams, the encryption concept is addressed. Thanks to the hash function, we can secure the integrity of the controlled bitstream, provided that we can transfer the hash value to the destination in such a way that malicious users cannot modify it. Otherwise, modifying the source stream is not a problem because calculating a new hash function value that takes this modification into account is quite a trivial operation.

Hence, selective access is required to protect the hash value against unauthorized access. So let's deal with selective access. Selective access is the ability to modify data that is associated with a bitstream only by people who are authorized to do so, and who have the right to obtain such data. We can accomplish this in two ways.

The first way is to share the stream, for example, a file, only with people who have the right to do so. This can be achieved thanks to the authentication and authorization offered by most operating systems. Thanks to this, each time an attempt is made to operate on a file, it is first checked whether the identity that operates has the right to do so. Of course, if someone does not gain access to the bitstream (to the file), he will necessarily not have access to the information that is associated with this file, or rather with this stream. This topic generally deals with operating systems, so it is outside the scope of our interest. So we have to deal with another security method.

The next option is to transform a bitstream (for example the file content, hash function value, etc.) into a form that an unauthorized user cannot associate any information with the stream. This method we call encryption. In other words, encryption involves transforming bitstreams to make the underlying information unreadable.

### Encryption fundamentals

Encryption is a reversible bitstream transformation function into another bitstream. After transformation, the encoding, syntax, and semantics rules no longer apply. So, as a consequence, no information can be associated with the obtained this way document. The diagram below shows how it works.

![fig. encryption](.Media/encryption.png)

The result of this encryption function (Fe) depends on the K1 key. The K1 key is also a bitstream. The disadvantage of this solution is that the resulting stream is always the same because the Fe is a function. This is easily fixed after adding a few randomly generated bytes to the input stream; the so-called nonce. Thanks to this, the result will be different each time. This approach protects against the possibility of repetition, i.e. using the same bitstream even without understanding its meaning. To perform the reverse operation, i.e. restore the source bitstream that was originally encrypted, a decryption operation must be performed. For this we will need the second key marked K2 in the drawing above. If nonce has been added it has to be removed before the bitstream reusing. It is feasible if the source and destination of a bitstream use the same concatenation method.

### EncryptDecryptDataTest

It is proposed to analyze the encryption and decryption process using the [EncryptDecryptDataTest][EncryptDecryptDataTest] test method defined in the [CryptographyHelpersUnitTest][CryptographyHelpersUnitTest] class. In this method, symmetric encryption is used that implements the 3DES algorithm. We will encrypt the selected XML file [catalog.example.xml][catalog]. This text file is located in the `Instrumentation` folder. Therefore, the test method must be preceded by an attribute that ensures all necessary files are copied to the test workspace before this method is invoked. First, we check whether this file exists. An assertion must always be true indicating that the file exists. We will save the encrypted result in another file. If this file exists, it is deleted. `ProgressMonitor` is a local class that will be used to track the progress of encryption and decryption progress. We will come back to this class shortly. The next step is directly related to encryption. The purpose of the following instructions

```csharp-interactive
 TripleDESCryptoServiceProvider _tripleDesProvider = new TripleDESCryptoServiceProvider();
```

is to create an object that generates a key. The key consists of two independent parts and can have different lengths depending on your needs. For default parameters, the length is 192 bits.

The next method [EncryptData][EncryptData] encrypts the input file and places the result in the output file. But to perform the encryption operation, we still need to pass two parameters, a key and an initialization vector. Please note that both the initialization vector and the key are arrays of bytes, they are simply bitstreams. Where these keys are generated is important because access to these keys guarantees selective access. This means anyone who has both the key and the initialization vector will be able to decrypt the encrypted file. Although this example does not show it, we should take care of the distribution of keys and, of course, the initialization vector. We can treat these two things as one whole.

So let's see how the encryption process works. Let me remind you that we are encrypting an XML file that we already know from the previous examples and it is a directory containing CD descriptions. The [EncryptData][EncryptData] encryption method has the following parameters: input file name, output file name, key, and initialization vector. Next, [dependency injection][DI] is used to allow the calling method to keep track of the process as the encryption process happens in stages.

First, we open the file for the input stream, which contains the source data that will be encrypted. The data will be encrypted step by step and will be placed in a buffer that has a predetermined length. In this case, it is assumed to be 100 bytes. Encryption requires the creation of a stream complying with the `CryptoStream` type. To create its instance, we will need an object for which we pass the key and an initialization vector. The encryption itself is performed using the `Write` method, which writes bytes from the local buffer to the `CryptoStream` object. After saving, we inform the user about the process progress returning the total number of bytes that are saved in this step to monitor the progress of work. Please note here that although the source file is a text file, we treat it as a bitstream. So, to read it, we create an object of the `FileStream` type because when encrypting the encoding of the input file is irrelevant. In other words, encryption is always performed for the bitstream. The encryption process ends when we read zero bytes into the buffer.

Then in the test method, after encrypting the source file, we check that the output file exists. There is an assertion that checks that this file exists and finally, we check if the number of bytes in the source file is equal to the number reported and written in the output file.

And now we move on to the phase where we will decrypt this file; the one we created. The entire procedure is carried out in the [DecryptData][DecryptData] method. This is again the library method. We pass similar parameters to it. Let me stress that to succeed the same key and the initialization vector that was used earlier have to be passed. Of course, in a real scenario, decryption is performed in a completely different in a different location usually by a different computer, or even in a completely different place in the world, therefore we must ensure that whoever performs the decryption process in the location where the decryption process will be carried out need the same key and the initial vector used while the stream is encrypted.

So let's take a look at how the decryption procedure is implemented in the [DecryptData][DecryptData] method. It is easy to note that it is very similar to the encryption method. Again, we treat the output file as a bitstream opened for writing so that we can store the decrypted bytes. We will carry out the entire process step by step using the buffer, which has the same length as the previous one. What is important is that we must have an object of the `TripleDESCryptoServiceProvider` class that provides the same key and the same initialization vector that was previously used. This time, `CryptoString` will have a `mode` parameter indicating that it will be used to read the content, so it will generally operate by decrypting the content of the specified file. In the [DecryptData][DecryptData] we have created an object that is responsible for performing decryption operations. Again, we end the process when we have read all the bits from the file containing encrypted content. We report the progress of this process using the `Report` method. The operation finishes when everything has been saved to the output file. Of course, the output file is automatically closed thanks to the `using` statement. For the sake of simplicity, in the [EncryptDecryptDataTest][EncryptDecryptDataTest] test method, the only correctness validation of the encryption/decryption round trip process is that the length of the file after decryption is equal to the length of the input file, the source file.

### Conclusion

In the examples discussed in this section, the encryption method of bitstreams is the subject of examination. We have two types of encryption. Encryption using symmetric keys, where the encryption side and the decryption side, i.e. recovering the original bitstream, use identical keys. From the point of encryption up to decryption, the bitstream is highly likely to be secure because no information can be associated with it. So, it cannot be used to recover the information it originally represents. In the next part, we move on to asymmetric encryption. Precisely, not the encryption itself because the performance of asymmetric encryption is not enough hence it is only used in selected procedures. We will analyze examples illustrating scenarios in which encryption can and should be used.

[EncryptDecryptDataTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/CryptographyHelpersUnitTest.cs#L49-L76
[DecryptData]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L62-L86
[CryptographyHelpersUnitTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/CryptographyHelpersUnitTest.cs#L23-L140
[CalculateSHA256]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L23-L31
[EncryptData]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L33-L60

## Digital Signature

### Preface

Because we use file systems and transfer bitstream data over computer networks streaming data security must inherently be the subject of our particular concern. Therefore, in this subsection, I propose to continue discussions on cryptographic security in this respect.

We have already learned about the hash function to protect bitstream integrity. However, there is still a problem with how to distribute its result so that in different places of the IT system, and different locations in the world this hash value can be used to check the integrity of a bitstream. Bitstream integrity refers to the assurance that the bitstream remains unchanged and intact during transmission or storage. It ensures that each bit in the data stream retains its original value without corruption or errors. The previous subsection addressed also symmetric encryption, in which we use the same keys in the encryption and decryption processes. And again we have the problem of distributing these keys among the authorized users who have the right to access the information represented by this stream. There is another problem with the use of symmetric encryption, namely scalability. It consists of the fact that the number of keys that we need to manage for encryption and decryption increases rapidly, that is, it increases with the square of the number of parties that participate in sharing data. 

Let's check how asymmetric encryption could help in this subsection. First of all, I propose to deal with the confirmation of authorship. I have associated this issue with the topic of ensuring bitstream integrity. So let's move on to how a digital signature works, and how we ensure that the document's author cannot deny that he is the author.

### XML Document Syntax

But before we move on to discussing how it works, I wanted to draw attention to a few important issues related to the XML documents. For example, consider the [catalog.example.xml][catalog] document that we already used in previous examples. Let's try to add a text to this document, for example, previously calculated hash function result expressed as hexadecimal text. Well, of course, we can easily predict the result. There is a syntax error reported, hence it can be stated that this document is no longer an XML document. Because the syntax is not correct it is not possible to recover the meaning of this document as one whole including added text. It is simply a free text document and is not suitable for further processing when we expect the document to follow XML syntax rules.

What can we do? We can move this text to an element, which is called for example `Hash`. As a result, we no longer have an XML syntax error, but we do have an error that such an element does not exist according to the schema we have defined. We can dumb down this document again and remove references to the schema, which defines what an XML document should contain. But this again leads to further consequences, such that if we expect that this document complies with a certain schema, then this document will be rejected because the schema is not defined for it. I would like us to remember this when following the method of implementing a digital signature. They will be very important to us.

### Signing Process

First, let me remind you of the goals. We have three of them. The first is to ensure that all users of the source bitstream can verify that the stream was not modified while it was being archived or transmitted. The second goal is to confirm authorship, so all users of this stream can determine who created this stream and who is responsible for its content. The third goal is the nonrepudiation of the author. In the latter case, let me remind you of an example involving a wire transfer. It would be better for the bank to have a guarantee that the person issuing the wire transfer order will not be able to deny authorship of the order and blame someone fraud who transferred money.

The following diagram shows how we can achieve these goals

![Fig. 1 Digital Signature](.Media/PodpisCyfrowy.png)

In the first step, we calculate the hash, just like before. But then we encrypt this hash using a private key, which is assumed to be assigned to a certain identity, which is assumed to be exclusively at the disposal of this identity. So, at least theoretically, no one else can use this key. If we encrypt the hash using a private key and asymmetric algorithm, the result is called a signature. We can therefore attach this signature to the original bitstream, send the whole result to another place, archive it, and in any case make it available to other users of this bitstream.

To check its integrity and authorship, we can first recalculate the hash for the part that constitutes the source bitstream. This hash should be the same. To determine the initial hash value, it can be decrypted using the public key. The public key is associated with the private key (both are the keys pair), and we will then obtain the decrypted hash calculated by the author of the bitstream. To check the correctness of the bitstream before further calculation, we can now compare the received initial hash value with the hash value that is calculated after receiving the bitstream. If these two hashes are the same, it means that the input bitstream has not been affected because the hash value is still the same. Since we used a public key that is paired with a private key, we can also conclude that a specific person created this stream. For any other person, this decryption operation will not produce an identical hash.

And now the last thing is how to ensure nonrepudiation. How to ensure that the person who originally signed this stream will not say after some time that it is not him/she, that it is someone else? We can do it only after ensuring that the public key has been provided by a public benefit organization, just like an ID that confirms our identity. This means that we trust a certain organization that issued this key. This key is made available to us in the context of personal data, data that describes the identity that has the private key, and therefore, based on this trust, we can conclude that this is a specific person, a specific identity.

### CreateRSACryptoServiceKeysTest

Let's move on to discussing how to implement this scenario using program text. As we can see from the description of this scenario, one of the important problems we have is creating and distributing keys. Hence, the first test method [CreateRSACryptoServiceKeys][CreateRSACryptoServiceKeys] is an example of how to generate keys and indicates some methods on how these keys may be distributed as an XML text. Of course, the topic related to key distribution - in general - is far beyond the scope of this subject, therefore let me encourage you to check out other publications at this point. In this test, I use a method that generates keys. Let's go to its definition and see that in the first step an object `RSACryptoServiceProvider` is created for which we define the key length. This is a parameter that also determines the strength of security, but at the same time, it has some impact on the performance of this process. Depending on the equipment we have, this number should not be outsized here.

Once this object is created, the keys are generated. We can use these keys and we have three options. First, we can return the keys as an `RSParameters` object. An object of this class contains both private and public keys but is intended only for use inside the program. It is not intended to be used for key distribution outside of the program hosting realm. The next two lines show how to generate XML text that contains the keys. The XML form is suitable for archiving or distribution over the network. Anyway, in the investigated sample, all three forms of keys are returned as a result of this method.

Let's go back to the [CreateRSACryptoServiceKeysTest][CreateRSACryptoServiceKeysTest] test method, where we check that the first variable is not `null`, so an object of the `RSAParameters` class is returned. We further check that the content of the XML documents - they are simply a text - that contains only the public key [PubliKey.xml][PubliKey] and the one that contains the public key and private key, are not the same. From the point of view of testing, these operations are not important, but they show how the `CreateRSACryptoServiceKeys` method works. The XML document that contains both the public and the private keys is located in the file [PubliPrivateKeys.xml][PubliPrivateKeys]. Of course, in the case of a private key, identity information is not important because, by design, a private key is only used by the owner.

The situation is different when we have a document containing only the public key. [PubliKey.xml][PubliKey] is an XML document that contains only the public key. Since this key will be used by third parties (stream users), by definition the distributed document must contain information about the identity to which this public key is associated. Of course, this is not fulfilled here. For this to be true, information about the public key must be added to another document called a certificate. A certificate is a document that has just been issued by the appropriate organization and it is this office that certifies with its signature that the certificate is authentic and contains correct information. From the certificate itself, we can find out what identity the public key is assigned to. Discussing these issues in detail, as I said earlier, is far beyond the scope of this document.

### XmlSignatureTest

Let us now discuss how to implement the operation of signing an XML document and how to place the obtained signature in the document so as not to violate the rules of syntax control consistent with its schema. First, we will need an input file that will serve as a signed source document. For this purpose, we will use the file [catalog.example.xml][catalog] again. We will also need the keys. We will use the public key to check the validity of the signature. However, we will use the private key to sign the document.

The signing operation is performed in the [XmlSignatureTest][XmlSignatureTest] test method. The signature is implemented in the [SignSaveXml][SignSaveXml] method to which we send the source document to be signed, the keys that will be used for signing, and the name of the document where the signed document is to be saved. In this method, apart from checking the correctness of the input arguments, we create an object of the `RSACryptoServiceProvider` class, which will be used to create a signature so that we can place the signature in this document. Signing itself means that we add a signature in the last instruction. To create this signature, we use the keys that we sent, so this object is initialized with the keys that were sent here so that the entire signing process takes place using the keys that will be further used to check the signature. Finally, the signed document is saved to a file.

So let's go back to the [XmlSignatureTest][XmlSignatureTest] test method. We assume that we have already signed the document saved in the file and now we can move on to discussing the methods that check the correctness of this document. There are two overloads of the [LoadVerifyXml][LoadVerifyXml] methods. Calling the first overload, we do not transfer the keys. It is worth emphasizing that the document is loaded and checked using the public key stored in this document. With this solution, we do not have to bother with providing the public key. Of course, with this type of checking, we cannot confirm the author's identity because anyone can enter such a public key. The only thing we can do is check whether the document is consistent from the point of view of this key. The second overload of this method uses the already transferred keys and initializes the `RSACryptoServiceProvider` object, which is used to check the document authorship.

Finally, let's look at the signed XML document [SignedXmlFile.xml][SignedXmlFile]. We can see that the `Signature` element has been added. This document is currently erroneous because it is incompatible with the declared document schema. To explain we must go back to the code for a while. To fix it this element `Signature` element has to be removed just after validation against the signature, and before using this document, for example for a deserialization operation; i.e. creating a graph of objects based on it.

A `Signature` element complies with the XML Digital Signature standard, namely XML Signature Syntax and Processing Version 1.1 issued by W3C in 2013. It is used to encapsulate digital signatures within an XML document. The `Signature` element contains information about the signature, including the cryptographic signature value and details about the key used for signing. Thanks to this it can be easily removed from the XML document before further processing.

[SignSaveXml]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L111-L146
[XmlSignatureTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/CryptographyHelpersUnitTest.cs#L91-L118
[CreateRSACryptoServiceKeysTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/CryptographyHelpersUnitTest.cs#L79-L87
[CreateRSACryptoServiceKeys]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L88-L101
[PubliPrivateKeys]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/PubliPrivateKeys.xml#L1-L11
[PubliKey]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/PubliKey.xml#L1-L5
[catalog]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/catalog.example.xml#L1-L23
[LoadVerifyXml]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Cryptography/CryptographyHelpers.cs#L161-L195
[SignedXmlFile]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SignedXmlFile.xml#L3-L42

## See Also

- [XSL\(T\) Languages][XSLW3C]
- [Serialization in .NET][STLZTN]
- [XML Schema Definition Tool (Xsd.exe)][XSD]
- [Generic implementation of the Blockchain agent in .NET][NBlockchain]
- [dependency injection][DI]

[DI]: https://www.udemy.com/course/information-computation/?referralCode=9003E3EF42419C6E6B21
[XSLW3C]: (https://www.w3schools.com/xml/xsl_languages.asp)
[XSD]: (http://msdn.microsoft.com/library/x6c1kb0s.aspx)
[STLZTN]: (http://msdn.microsoft.com/library/7ay27kt9.aspx)
[NBlockchain]: https://github.com/mpostol/NBlockchain#nblockchain
