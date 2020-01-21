<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <body>
    <h2>Files</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th>Extension</th>
        <th>Size</th>
	<th>Count</th>
      </tr>
      <xsl:for-each select="files_directory/files">
      <tr>
        <td><xsl:value-of select="file_ext" /></td>
        <td><xsl:value-of select="total_size" /></td>
	<td><xsl:value-of select="count" /></td>
      </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>

