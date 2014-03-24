<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" defaultfocus="GuessBox">
    <div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
        <asp:Label ID="Title" runat="server" Text="Gissa det hemliga talet"></asp:Label>
        <asp:Label ID="Label" runat="server" Test="Ange ett tal mellan 1 och 100: "></asp:Label>
        <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredGuess" runat="server" ErrorMessage="Du måste ange en gissning!" Text="*" ControlToValidate="GuessBox"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="Du måste gissa på ett tal mellan 1-100!" Text="*" MaximumValue="100" MinimumValue="1" Type="Integer" ControlToValidate="GuessBox"></asp:RangeValidator>
        <asp:Button ID="SendButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" /><br />
        <asp:PlaceHolder ID="EndGame" runat="server" Visible="false">
            <asp:Label ID="PastGuesses" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="NewRandomButton" runat="server" Text="Slumpa nytt hemligt tal" />
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
