# WebSocket notes

The example has been derived from the project [M. Postol; NBlockchain; NBlockchain/P2PPrototocol/NodeJSAPI/][WSExampleInBlockchain]

## Introduction

The WebSocket Protocol enables two-way communication between a client running untrusted code in a controlled environment to a remote host that has opted-in to communications from that code.  The security model used for this is the origin-based security model commonly used by web browsers.  The protocol consists of an opening handshake followed by basic message framing, layered over TCP.  The goal of this technology is to provide a mechanism for browser-based applications that need two-way communication with servers that does not rely on opening multiple HTTP connections (e.g., using XMLHttpRequest or \<iframe\>s and long polling).

## See also

- [The WebSocket Protocol; Request for Comments: 6455; 2011](https://tools.ietf.org/html/rfc6455)
- [The WebSocket API; W3C Candidate Recommendation 20 September 2012](https://www.w3.org/TR/websockets/)
- [M. Postol; NBlockchain; NBlockchain/P2PPrototocol/NodeJSAPI/; Rel.1.0][WSExampleInBlockchain]

<!--[OOI-GDD]: https://commsvr.gitbook.io/ooi/global-data-discovery/datadiscovery-->
[WSExampleInBlockchain]: https://github.com/mpostol/NBlockchain/tree/master/P2PPrototocol/NodeJSAPI
