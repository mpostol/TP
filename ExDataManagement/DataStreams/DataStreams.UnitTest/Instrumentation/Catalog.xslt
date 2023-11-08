<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:exml="http://Viculu34.org/Catalog.xsd">
  <xsl:template match="/">
    <html>
      <body>
        <h2>My CD Collection</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Title</th>
            <th>Artist</th>
            <th>Price</th>
          </tr>
          <xsl:for-each select="exml:Catalog/exml:CD">
            <tr>
              <td>
                <xsl:value-of select="exml:Title"/>
              </td>
              <td>
                <xsl:value-of select="exml:Artist"/>
              </td>
              <td>
                <xsl:value-of select="exml:Price"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
