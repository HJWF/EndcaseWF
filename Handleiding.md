<h1>Handleiding Endcase Wilrico Feenstra</h1>

<h2> Backend</h2>
Open de solution file in de map BackEnd in Visual studio. Wanneer het propject geladen is rechter muis klik op het BackEnd project en kies voor <i>Manage NuGet Packages...</I> en bovenin komt een melding met dat er packages missen. Aan de rechterkant staat een knop met <i>Restore</i> druk hierop om de packages te restoren. Dit zou alle packages moeten downloaden.

Open de package manager console en run het volgende command <code> Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r</code>

Ga daarna in het bovenste menu <i>Build ->  Clean Solution</i>, wanneer de clean voltooid is klik dan op <i>Build ->  Rebuild Solution</i> (de clean zit ook al bij de Rebuild inbegrepen, maar een dubbele clean is nooit verkeerd).

Klik daarna op de knop bovenin <i>IIS Express (browsernaam)</i>. Er kan dan een popup komen met <i>Would you like to trust the IIS Express SSL certificate?</i> druk op ja en bij het volgende scherm klik weer op ja om het certificaat te installeren.

De browser opent op <i>http://localhost:8080/</i>. De error die in beeld komt hoort zo omdat er er geen UI is voor de Web API. 
