## Deployment documentatie
In dit document worden de stappen beschreven om de Angular app succesvol te deployen.

### Angular Deployment
#### Requirements
Software | Uitleg Software | Download
---------|-----------------------|----------------------------
NodeJS | Veel van Angular's CLI commando's gebruiken NodeJS. Om NPM packages te kunnen installeren hebben we ook NodeJS nodig. | [download](https://nodejs.org/en/)
Visual Studio Code | Gebruiken wij als IDE voor Angular. | [download](https://code.visualstudio.com)

1. #### NodeJS installeren
 * Download en installeer de laatste TLS versie van NodeJS via de download link hierboven.
 * Test of NodeJS en NPM goed geinstalleerd zijn door ``node -v`` en ``npm -v`` in de command prompt/terminal uit te voeren.

2. #### Angular project ophalen
 * Download de laatste versie van LabFarm door een ``pull`` uit te voeren van de ``master`` branch.
 * Navigeer in explorer/finder naar de directory waar LabFarm is opgeslagen.
 * Navigeer naar de map ``\iot1819--iot18lf1\src\labfarm-client``.
 * Open het project hier in ``Visual Studio Code``.
 
3. #### Angular deployen
 * Via de ``integrated terminal`` in Visual Studio Code, voer het volgende commando uit: ``npm install``. Hiermee gaan we alle Node pakketten downloaden.
 * Typ nu ook het volgende commando in om de webapp te starten: ``ng serve --open``. Na het initialiseren opent de browser met de LabFarm pagina.
