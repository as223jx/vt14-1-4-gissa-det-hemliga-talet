<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet!</title>
    <link href="~/Content/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="GuessBox">
    <div class="div">
        <asp:Label ID="Title" CssClass="title" runat="server" Text="Gissa det hemliga talet"></asp:Label><br />
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
        <asp:Label ID="Label" runat="server" Test="Ange ett tal mellan 1 och 100: "></asp:Label><br />
        <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredGuess" runat="server" ErrorMessage="Du måste ange en gissning!" Text="*" ControlToValidate="GuessBox"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="Du måste gissa på ett tal mellan 1-100!" Text="*" MaximumValue="100" MinimumValue="1" Type="Integer" ControlToValidate="GuessBox"></asp:RangeValidator><br />
        <asp:Button ID="SendButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" /><br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label><br />
        <asp:PlaceHolder ID="PlaceHolder" runat="server" Visible="false"><br />
            <asp:Label ID="PastGuesses" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="NewRandomButton" Enabled="false" runat="server" Text="Slumpa nytt hemligt tal" OnClick="NewRandomButton_Click" />
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
