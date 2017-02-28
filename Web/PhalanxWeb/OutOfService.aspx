<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutOfService.aspx.cs" Inherits="PhalanxWeb.OutOfService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Phalanx Security Manager</title>
</head>
<body>
    <form id="form1" runat="server">
    <TABLE id="TableHeader" height="129" cellSpacing="0" cellPadding="0" width="100%" border="0">
	    <TR>
		    <TD width="83" height="129" rowSpan="3"><IMG alt="" src="./image/PhxHead1.gif"></TD>
		    <TD width="362" background="./image/PhxHead21.gif" height="80">&nbsp;</TD>
		    <TD width="*" background="./image/PhxHead31.gif" height="80" vAlign="middle" noWrap
			    align="right">
                &nbsp;
		    </TD>
		    <TD width="28" background="./image/PhxHead41.gif" height="80">
                &nbsp;</TD>
		    <TD width="13" background="./image/PhxHead51.gif" height="80">
                &nbsp;</TD>
	    </TR>
	    <TR>
		    <TD align="left" width="362" bgColor="#000080" style="height: 20px">&nbsp;</TD>
		    <TD align="right" width="*" bgColor="#000080" noWrap style="height: 20px">&nbsp;</TD>
		    <TD width="28" bgColor="#000080" style="height: 20px">&nbsp;</TD>
		    <TD width="13" background="./image/PhxHead52.gif" style="height: 20px">&nbsp;</TD>
	    </TR>
	    <TR>
		    <TD width="362" background="./image/PhxHead23.gif" height="29">&nbsp;</TD>
		    <TD width="*" background="./image/PhxHead33.gif" height="29">&nbsp;</TD>
		    <TD width="28" background="./image/PhxHead43.gif" height="29">&nbsp;</TD>
		    <TD width="13" background="./image/PhxHead53.gif" height="29">&nbsp;</TD>
	    </TR>
    </TABLE>    
    <table height="300px" cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr valign="top">
            <td valign="top">
                <table width="100%" border="0">
					<tr>
						<td align="center" height="*">
							<DIV align="center"><br>
								<table style="HEIGHT: 94px" width="50%" border="0">
									<tr>
										<td width="*" align="center" colspan="2">
											</td>
									</tr>
									<tr>
										<td style="WIDTH: 20px">
											<asp:image id="Information" runat="server" ImageUrl=".\image\info.gif"></asp:image></td>
										<td width="*" align="center">
											<asp:label id="LabelMsg" runat="server" CssClass="LabelInInfo">El sistema se encuentra momentáneamente en mantenimiento. Contáctese con los administradores</asp:label></td>
									</tr>
									<tr>
										<td width="*" colspan="2"></td>
									</tr>
								</table>
								<br>
							</DIV>
							<div align="center"><br>
								<br>
                                &nbsp;</div>
							<div>
								&nbsp;&nbsp;
							</div>
						</td>
					</tr>
				</table>
            </td>
        </tr>
    </table>
    <asp:Table id="Table1" runat="server" Width="100%" Height="30px" CellPadding="0" CellSpacing="0"
	    BorderWidth="0px">
	    <asp:TableRow>
		    <asp:TableCell Height="46px" Width="125">
			    <asp:Image id="ImageF1" Width=125 Height=46 runat="server" ImageUrl="./image/PhxFoot1.gif"></asp:Image>
		    </asp:TableCell>
		    <asp:TableCell Height="46px">
			    <asp:Image id="ImageF2" Width=100% Height=46 runat="server" ImageUrl="./image/PhxFoot2.gif"></asp:Image>
		    </asp:TableCell>
		    <asp:TableCell Height="46px" Width="136px">
			    <asp:Image id="ImageF3" Width=136 Height=46 runat="server" ImageUrl="./image/PhxFoot3.gif"></asp:Image>
		    </asp:TableCell>
	    </asp:TableRow>
    </asp:Table>    
</form>
</body>
</html>
