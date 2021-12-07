<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="hotel">
		<HTML>
			<BODY>
				<p>
					<H2>Список мешканців</H2>
				</p>
			</BODY>
			<BODY>
				<TABLE BORDER="2">
					<TR>
						<TD>
							<b>Ім'я</b>
						</TD>
						<TD>
							<b>Факультет</b>
						</TD>
						<TD>
							<b>Кафедра</b>
						</TD>
						<TD>
							<b>Курс</b>
						</TD>
						<TD>
							<b>Інформація</b>
						</TD>
					</TR>
					<xsl:apply-templates select="people"/>
				</TABLE>
			</BODY>
		</HTML>
	</xsl:template>
	<xsl:template match ="people">
		<TR>
			<TD>
				<b><xsl:value-of select="@secondname"/></b>&#160;
				<b><xsl:value-of select="@firstname"/> </b>&#160;
				<b><xsl:value-of select="@patronymic"/> </b>
				</TD>
			<TD>
				<b><xsl:value-of select="./faculty"/></b>
			</TD>
			<TD>
				<b>
					<xsl:value-of select="./cathedra"/>
				</b>
			</TD>
			<TD>
				<b>
					<xsl:value-of select="./course"/>
				</b>
			</TD>
			<TD>
				<b>
					<xsl:value-of select="./data"/>
				</b>
			</TD>
			</TR>
	</xsl:template>
</xsl:stylesheet>