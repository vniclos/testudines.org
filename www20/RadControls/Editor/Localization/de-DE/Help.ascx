<%@ Control Language="c#" Inherits="Telerik.WebControls.EditorDialogControls.BaseDialogControl"%>
<table cellspacing="0" cellpadding="2" border="1" bordercolor="#000000" style="font:normal 10px Arial">
	<tr>
		<td colspan="3" align="middle"><strong>Allgemeine Werkzeuge</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonDesign.gif"></td>
		<td>Entwurfknopf - Schaltet r.a.d.editor in Entwurfmodus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonHtml.gif"></td>
		<td>HTML Knopf - Schaltet r.a.d.editor in HTML Modus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Img/ButtonPreview.gif"></td>
		<td>Vorschauknopf - Schaltet r.a.d.editor in Vorschaumodus.</td>
		<td>-</td>
	</tr>
	
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToUpper.gif"></td>
		<td>Das Werkzeug verwandelt den Text von der jetzigen Auswahl zu Grobuchstaben. Es bewahrt die Elemente wie Bildnisse und Tabellen (Elemente, die keine Textelemente sind).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ConvertToLower.gif"></td>
		<td>Das Werkzeug verwandelt den Text von der jetzigen Auswahl zu Kleinbuchstaben. Es bewahrt Elemente wie Bildnisse und Tabellen (Elemente, die keine Textelemente sind).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>Das Werkzeug erlaubt, dass der Benutzer Bildnissekarten durch ein Setzen ber den Bildnissen schaffen, und schafft dann Gebiete mit verschiedenen Gestalten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Dropdown, der den Verbraucher erlaubt, Schriftartgre zur jetzigen Auswahl zu verwenden. Der Schriftartgre ist in Bildpunkten gemessen. Der Schriftartgre ist nicht gesetzt wie im FontSize Werkzeug (1 zu 7).</td>
		<td>-</td>
	</tr>
	
	
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleScreenMode.gif"></td>
		<td>Umschaltschirmmodus - Schaltet r.a.d.editor in Vollbildmodus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleTableBorder.gif"></td>
		<td>Zeige/Verstecke Rahmen - Zeigen/Verstecken Sie Rahmen um Tabelle im Inhaltgebiet.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ModuleManager.gif"></td>
		<td>Modulmanager - Aktiviert /Deaktiviert Module von einem drop-down Liste verfgbarer Module.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleDocking.gif"></td>
		<td>Schalten Sie Andocken um - Dockt alle schwebenden Werkzeugleisten zu ihren jeweiligen dockenden Gebieten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/RepeatLastCommand.gif"></td>
		<td>Wiederholen Sie Letzten Befehl - Eine Abkrzung, um die letzte Handlung zu wiederholen. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FindAndReplace.gif"></td>
		<td>Suchen und Ersetzen - findet und ersetzt Text im Editor.</td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Print.gif"></td>
		<td>Druck-Knopf - Druckt den Inhalt des r.a.d.editors oder der gesamten 
			Internetseite.</td>
		<td>Ctrl+P</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Spellcheck.gif"></td>
		<td>Rechtschreibung - startet den Assistenten fr die Rechtschreibung.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Cut.gif"></td>
		<td>Ausschneide-Knopf - schneidet den markierten Bereich aus und kopiert ihn in die 
			Zwischenablage.</td>
		<td>Ctrl+X</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Copy.gif"></td>
		<td>Kopier-Knopf - kopiert den markierten Bereich in die Zwischenablage.</td>
		<td>Ctrl+C</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Paste.gif"></td>
		<td>Einfgen-Knopf - fgt den Inhalt der Zwischenablage in den Editor ein.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PastePlaintext.gif"></td>
		<td>Fgen Sie Standardtext ein Knopf - Fgt Standardtext (keine Formatierung) in den r.a.d.editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PasteFromWord.gif"></td>
		<td>Fgen Sie von Word ein Knopf  - Fgt Inhalt Ein, der von Wort kopiert wurde und nimmt heraus das Gewebe unfreundliche. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/PasteAsHtml.gif"></td>
		<td>Fgen Sie als HTML Knopf - Fgt HTML Code im Inhaltgebiet ein und behlt alle HTML-Tags.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Undo.gif"></td>
		<td>Rckgngig-Knopf - macht den letzten Arbeitsschritt rckgngig.</td>
		<td>Ctrl+Z</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Redo.gif"></td>
		<td>Wiederholen-Knopf - wiederholt den letzten Schritt, der rckgngig gemacht 
			wurde.</td>
		<td>Ctrl+Y</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Sweeper.gif"></td>
		<td>Formatierungs-Knopf - entfernt alle Formatierungen (auch benutzerdefinierte) 
			aus dem Text.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Help.gif"></td>
		<td>Direkthilfe - der Bildschirm den Sie gerade betrachten.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/AboutDialog.gif"></td>
		<td>ber Dialog - Zeigt die jetzige Version und die Befhigungsunterlagen von r.a.d.editor.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>Tabellen, Links, Sonderzeichen, Bilder und 
				Medien einfgen und verwalten</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageManager.gif"></td>
		<td>Bild einfgen - fgt ein Bild aus einem vordefinierten Verzeichnis ein.</td>
		<td>Ctrl+G</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ImageMapDialog.gif"></td>
		<td>Bildniskarte - Erlaubt, dass Benutzer anklickbare Bereiche innerhalb Bildnis definieren.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/AbsolutePosition.gif"></td>
		<td>Absolute Position - legt die absolute Position eines Objektes fest (frei 
			beweglich).</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertTable.gif"></td>
		<td>Tabelle einfgen - fgt eine Tabelle in den r.a.d.editor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ToggleBorders.gif"></td>
		<td>Toggle Table Borders - Schaltet alle Rahmen innerhalb des Editors um.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertSnippet.gif"></td>
		<td>Code Elemente einfgen - fgt vorgefertigte Code-Elemente ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertFormElement.gif"></td>
		<td>Fgen Sie Formelement ein - Fgt ein Formelement von einer Drop-Down Liste mit verfgbaren Elementen ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertDate.gif"></td>
		<td>Fgen Sie Datum Knopf ein - Fgt jetziges Datum ein. </td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertTime.gif"></td>
		<td>Fgen Sie Zeit der Knopf ein - Fgt jetzige Zeit ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FlashManager.gif"></td>
		<td>Flash einfgen - fgt eine Flash-Animation ein und lt sie ihre Eigenschaften 
			verndern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/MediaManager.gif"></td>
		<td>Windows Media einfgen - fgt ein Windows Media Objekt (AVI, MPEG, WAV, etc.) 
			ein und lt sie die Eigenschaften ndern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/DocumentManager.gif"></td>
		<td>Dokument einfgen - fgt ein Dokument in den Editor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Link erstellen - Macht aus dem ausgewhlten Text, Nummer oder Bild einen 
			Hyperlink.</td>
		<td>Ctrl+K</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Unlink.gif"></td>
		<td>Link entfernen - entfernt einen Link aus dem gewhlten Text, Nummer oder Bild.</td>
		<td>Ctrl+Shift+K</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Symbols.gif"></td>
		<td>Sonderzeichen einfgen - fgt Sonderzeichen ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/LinkManager.gif"></td>
		<td>Benutzerdefinierten Link hinzufgen - fgt einen internen oder externen Link 
			aus einer vorgefertigten Liste hinzu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/TemplateManager.gif"></td>
		<td>Whlen Sie HTML Modellrahmen - Verwendet einen HTML Modellrahmen von einer vordefinierten Liste der Modellrahmen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ERSTELLEN, FORMATIEREN UND BEARBEITEN von 
				ZEICHEN UND LINIEN</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertParagraph.gif"></td>
		<td>Neues Zeichen einfgen - fgt ein neues Zeichen ein.</td>
		<td>
			Ctrl+M<br>
			Ctrl+Enter
		</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Paragraph.gif"></td>
		<td>Standard-Zeichen Auswahlfeld - fgt Standard-Eigenschaften zu dem ausgwhlten 
			Text zu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Outdent.gif"></td>
		<td>Links Ausrichten - richtet Zeichen links aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Indent.gif"></td>
		<td>Rechts ausrichten - richtet Zeichen recht aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertHorizontalRule.gif"></td>
		<td>Horizontale Linie - fgt eine horizontale Linie bei 
			dem Cursor ein.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyLeft.gif"></td>
		<td>Links ausrichten - richtet die ausgewhlten Zeichen links aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyCenter.gif"></td>
		<td>Mittig ausrichten - richtet die ausgewhlten Zeichen in der Mitte aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/JustifyRight.gif"></td>
		<td>Rechts ausrichten - richtet die ausgewhlten Zeichen rechts aus.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertOrderedList.gif"></td>
		<td>Numerierte Liste - erstellt aus der Markierung eine numerierte Liste.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/InsertUnorderedList.gif"></td>
		<td>Aufzhlungszeichen - erstellt aus der Markierung eine Liste mit 
			Auszhlungszeichen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ERSTELLEN, FORMATIEREN UND BEARBEITEN von TEXT, 
				SCHRIFTART und LISTEN</strong></td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Bold.gif"></td>
		<td>Fett - formatiert den markierten Text fett.</td>
		<td>Ctrl+B</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Italic.gif"></td>
		<td>Kursiv - formatiert den markierten Text kursiv.</td>
		<td>Ctrl+I</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Underline.gif"></td>
		<td>Unterstrichen - unterstreicht den markierten Text.</td>
		<td>Ctrl+U</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Superscript.gif"></td>
		<td>Hochgestellt - formatiert Text oder Nummern als hochgestellt.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Subscript.gif"></td>
		<td>Tiefgestellt - formatiert Text oder Nummern als tiefergestellt.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontName.gif"></td>
		<td>Schriftart - Schriftart whlen.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/FontSize.gif"></td>
		<td>Schriftgre - Schriftgre ndern.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/ForeColor.gif"></td>
		<td>Textfarbe (Vordergrund) - ndert die Vordergrundfarbe des ausgewhlten Textes.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/BackColor.gif"></td>
		<td>Textfarbe (Hintergrundbild) - ndert die Hintergrundbild des ausgewhlten Textes.</td>
		<td>-</td>
	</tr>
	<tr>
		<td align="middle"><img src="<%= this.SkinPath %>Buttons/Class.gif"></td>
		<td>Benutzerdefinierte Formate - fgt benutzerdefinierte, vordefinierte 
			Formatierungen zum ausgewhlten Text hinzu.</td>
		<td>-</td>
	</tr>
	<tr>
		<td colspan="3" align="middle"><strong>ANDERE TASTENKOMBINATIONEN</strong></td>
	</tr>
	<tr>
		<td>-</td>
		<td>Markiert den gesamten Text, alle Bilder und Tabellen im Editor</td>
		<td>Ctrl+A</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Findet Text oder Zahlen im aktuellen Dokument.</td>
		<td>Ctrl+F</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Schliet das aktive Fenster.</td>
		<td>Ctrl+W</td>
	</tr>
	<tr>
		<td>-</td>
		<td>Schliet die aktive Anwendung.</td>
		<td>Ctrl+F4</td>
	</tr>
</table>