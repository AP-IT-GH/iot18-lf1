# Analyse

## Functionale analyse project 

### Beschrijving

Als we kijken naar een doodgewone plant, dan zien we feitelijk een ingenieus biologische fabriek aan het werk. Met een proces genaamd fotosynthese.

Kort uitgelegd, fotosynthese is een proces waarbij lichtenergie wordt gebruikt om koolstofdioxide om te zetten in energierijke verbindingen (koolhydraten). Die de plant nodig heeft om te groeien.

Ieder levend wezen heeft water nodig, dus ook planten. Ook zoals ieder levend wezen mag een plant niet te veel en niet te weinig water krijgen.

Buiten deze 2 basis behoeften zijn er nog extra externe factoren belangrijk om een gezonde planten groei te kunnen garanderen. De kwaliteit van het water (hoeveel voedingsstoffen er in zitten) en temperatuur/lichtinval van de omgeving.

Al deze factoren zullen gemonitord worden door verschillende sensoren. Met al deze data kunnen we controleren of de plant in gezonde omstandigheden groeit. Met dat we zelf het licht en voedingsstoffen gaan regelen kunnen we de planten groei ook optimaliseren als dit gewenst is door extra licht/en of voedingsstoffen aan de plant te geven.

Wat we ook kunnen monitoren is de groei en gezondheid van de plant. Dit doen we m.b.v. een camera die periodieke foto&#39;s zal nemen en hier een analyse op gaat doen. Deze analyse zal omtrent de groei (in de hoogte) en de gezondheid (kleur van de bladeren) gaan. Met deze foto&#39;s kunnen we na een tijd ook de groei en gezondheid over een bepaalde tijdspanne weergeven.

De toevoer van water gaan we niet op de gebruikelijke manier doen, namelijk de pot met zand waar de plant instaat vullen met water. Wij gaan gebruik maken van hydrocultuur. Hiermee kweken we planten in water waaraan de noodzakelijke voedingsstoffen aan zijn toegevoegd. Hierdoor wordt het overbodige zand verwijderd uit de opstelling.

Enkele voordelen van hydrocultuur:

- De planten zijn minder vatbaar voor ziekten, omdat er geen grond wordt gebruikt waarin een hogere vervuilingsgehalte schuilt. De bodem is een ideale habitat voor micro-organismen en bacteriën die de oorzaak zijn van deze ziekten.

- Geen onkruidgroei.

- Er kan gerichter voeding gegeven worden.

Wij gaan een specifiekere vorm van hydrocultuur gebruiken, namelijk Nutrient film technique of NFT.  Bij deze techniek stroomt er water onder de planten door, dit water bevat een aantal toegevoegde voedingsstoffen. Het water wordt opgenomen door de plant via de wortels die los in het water hangen. Hierdoor is het zelfs mogelijk om planten die een verschillende waterbehoefte hebben naast elkaar te laten groeien. Naargelang de beschikbaarheid van water zullen de planten meer wortels aanmaken om meer water op te nemen.

Het water zal via een pompje uit het reservoir gepompt worden waarna het rustig onderdoor de planten stroomt, door een kleine helling van de ondergrond. Op het einde valt het water terug in het reservoir. Het water in dit reservoir wordt aangevuld met de juiste hoeveelheid voedingsstoffen en met zuurstof.

Eerder is gezegd geweest dat we zelf het licht en voedingsstoffen gaan regelen. Uiteraard is dit niet letterlijk bedoeld, met de metingen dat de sensoren en de camera doen zal ons smart device zelf bepalen hoeveel (extra)licht en extra voedingstoffen de plant nodig heeft.

Dit is voor iedere plant anders dus eerst zal ons device m.b.v. de camera de soort plant bepalen. Nu weet ons device in welke omstandigheden de specifieke plant moet leven om gezond te groeien. En wordt de plant volledig autonoom dankzij ons device.

Aangezien we NFT gebruiken, moeten we ook de hoeveelheid water in het reservoir en de hoeveelheid voedingstoffen in voorraad gaan meten. Deze zijn externe factoren die ons device niet zelf kan aanpassen maar wel kan meten. Als er aanpassingen nodig zijn aan een of meerdere van de voorafgaande factoren zal ons device een melding geven aan de gebruiker.

Deze melding zal de gebruiker te zien krijgen op de webapplicatie die communiceert met ons smart device. Hier zijn meerdere zaken aanspreekbaar zoals alle sensor data, foto&#39;s van de camera en instel waardes voor het voedingstoffen en licht toevoer van de plant.

![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/NFT-System.png)

### Marktonderzoek
|               	| Click & Grow  | Niwa  		| SproutsIO  	| Windowfarms  | GROW duo  |
| ----------------------|---------------|-----------------------|---------------|--------------|-----------|
|Type           	| Binnenhuis smart tuin	| Binnenhuis groeikast| Binnenhuis smart tuin | Binnenhuis tuin | Buitenhuis
|Camera         	| /|/|Bovenaan|/|/|
|Sensoren       	|/|Omgevingstemperatuur  Omgevingslicht  pH(?)  Waterniveau|Omgevingstemperatuur  Omgevingslicht  pH(?)  Waterniveau  Geleidbaarheid  Bodemtemperatuur|/|Omgevingstemperatuur  Omgevingslicht  Waterniveau  Bodemtemperatuur|
|Belichting    		| Led op beweegbare arm | Led met apart warmte element| LED | Natuurlijk Zonlicht | Natuurlijk Zonlicht |
|App Control   	| / |Groeiprofielen  Onderhoud Reminders  Monitoring groeicyclus |Cameracontrol  Realtimedata  Monitoring Groeicyclus | /  | Info over tuinieren  Marketplace voor extra zaden|
|Communicatie protocol  |/ |Wifi |Wifi |/ |/ |
|Bodem Type             | "Smart Soil" | Anorganisch | Anorganisch | Anorganisch | Organisch |
|Irrigatie  		| Automatisch |  Hydroponie | Hydroponie | Hydroponie | Sproeiers|
|Extra info 		|/| /|/ |Verticaal geplaatst | Beschikt over "Plant-AI"|

Waar een "/" gezet is betekent dit dat er niets gevonden werd of dat het niet bestaat.

### Diagrammen
Database model:  
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/DatabaseModel.JPG)

#### Algemene architectuur

#### Gedetailleerde diagrammen

#### Schema's van het product

#### Fysiek design (Optioneel)

#### Niet functionele analyse 

## Functionaliteit

## Release Plan 

## Inventarisatie Hardware

## Inventarisatie Software 

Programs (tools):  
	* Visual studio code  
	* Visual studio  
	
Application Server:    
	* Azure    
	* ASP .NET MVC  
	* .NET core  
	* SQL  
	
Frontend + End Nodes:  
	* Angular  
	* Ionic  
	* Typescript  
	* HTML  
	* CSS  
	* Arduino  

##### Alternatieven:  
Programs (tools):  
	* Android Studio  
	* Xamarin  
	
Application Server:  
	* Firebase  
	
Frontend + End Nodes:  
	* Java  
	* C#  
	* Python3 (if using raspberryPi)  

## Test document

## Verdediging
