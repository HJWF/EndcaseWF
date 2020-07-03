<h1>Readme Endcase Wilrico Feenstra</h1>

<h2>Installatie handleiding</h2>

Er wordt vanuit gegaan dat de volgende programma's geinstalleerd zijn:
- Visual Studio (https://visualstudio.microsoft.com/downloads/)
- Visual Studio Code (https://code.visualstudio.com/download)
- SQL Server (https://www.microsoft.com/nl-nl/sql-server/sql-server-downloads)
- NodeJs (https://nodejs.org/en/download/)

<h3> Backend</h3>
Open de solution file in de map BackEnd in Visual studio. Wanneer het propject geladen is rechter muis klik op het BackEnd project en kies voor <i>Manage NuGet Packages...</I> en bovenin komt een melding met dat er packages missen. Aan de rechterkant staat een knop met <i>Restore</i> druk hierop om de packages te restoren. Dit zou alle packages moeten downloaden.

Open de package package manager console voor het command <code> Update-Database</code> uit. Hierdoor wordt de Database geseed.

Ga daarna in het bovenste menu <i>Build ->  Clean Solution</i>, wanneer de clean voltooid is klik dan op <i>Build ->  Rebuild Solution</i> (de clean zit ook al bij de Rebuild inbegrepen, maar een dubbele clean is nooit verkeerd).

Klik daarna op de knop bovenin <i>IIS Express (browsernaam)</i> (bij voorkeur Google Chrome gebruiken). Er kan dan een popup komen met <i>Would you like to trust the IIS Express SSL certificate?</i> druk op ja en bij het volgende scherm klik weer op ja om het certificaat te installeren.

De browser opent op <i>http://localhost:8080/</i>. De error die in beeld komt hoort zo omdat er er geen UI is voor de Web API. Om te testen of de database gevuld is met data kun je gaan naar <i>http://localhost:8080/api/cursus</i>. 

<b>Houd deze browser open zodat de frontend hier straks tegen kan praten!</b>

<h3>Frontend</h3>
Open de map FrontEnd in Visual Studio code en open daarna een nieuw terminal window (bovenin <i> Terminal->New Terminal</i>). In de terminal voer de volgende commandos uit: <br>
<code>npm i</code><br>
<code>npm i bootstrap </code><br>
<code>cd Angular</code><br>
<code>npm i</code><br>
<code>npm i -g @angular/cli --save-dev</code><br>

Om de applicatie te laten draaien run het volgende commando: <br>
<code>ng serve </code><br>

De applicatie draait nu op http://localhost:4200/ 

Om de testen te draaien open een tweede terminal window en run het volgende commando: <br>
<code>ng test </code><br>

Om de end2end testen te draaien stop de applicatie (anders is de port al bezet) en run het volgende commando: <br>
<code>ng e2e </code><br>

<h2>URL's</h2>

<h3>Backend</h3>
De url voor de backend is: <code>http://localhost:8080/</code> <br>
Om alle cursus en cursusinstanties te bekijken vanuit de web api:
<code>http://localhost:8080/api/cursus</code>

<h3>Frontend</h3>
De url voor de frontend is: <code>http://localhost:4200/</code> <br>
Deze wordt automatisch doorverwezen naar: <code>http://localhost:4200/202027</code> - waarbij 2020 het jaartal is en 27 het weeknummer. Deze waarde is dus ook in dit formaat te wijzigingen om naar een andere jaar en/of week te gaan.<br>
Om alle cursus en cursusinstanties te bekijken:
<code>http://localhost:4200/all</code> <br>
Om cursussen en cursusinstanties toe te voegen ga naar:
<code>http://localhost:4200/add</code> - of druk op de knop Nieuwe cursus wanneer op de weekoverzicht pagina<br>