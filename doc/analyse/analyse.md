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

#### Algemene architectuur

#### Gedetailleerde diagrammen

Database model:  
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/DatabaseModel.JPG)

Software Flowchart:
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/Software_Flowchart_LabFarm_v1.jpg)

#### Schema's van het product
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/NFT-System.png)

#### Fysiek design (Optioneel)

#### Niet functionele analyse 

##### Inleiding

In deze analyse gaan we in korte lijnen 4 non-functionele requirements bespreken. Deze zijn:

* Durability
* Portability
* Maintainability
* Testability

##### Non-functionele Requirements

###### 1) Durability

Durability ofterwijl duurzaamheid is altijd een heel interessant gegeven. Men zou in ons geval natuurlijk niet willen dat de smart plantenbak het na een paar dagen al meteen zou begeven. Bij dit project komen er toch wel een aantal verschillende componenten van te pas die zo lang mogelijk moeten blijven werken. Hier spreken we dan bijvoorbeeld over:

* Sensoren
* Afsluitklemmen voor de buizen
* Pompen

We gaan hier ook nog even twee belangrijke types van duurzaamheid bespreken:

1) Het gegeven van "Waterproofing" is een type van duurzaamheid. Bij dit project is dit van levensbelang, sinds we het elektriciteitsnet goed gaan moeten onderscheiden van de watervoorraad.

2) Het gegeven van "Toughness" is ook een type van duurzaamheid. Bij dit project is het wel aangenaam als de smart plantenbak niet meteen zou breken na het op de grond te laten vallen.


###### 2) Portability

Portability vonden wij ook wel een leuke non-functionele requirement voor dit project. Sinds ons project wireless zal zijn, is het fijn dat de gebruiker de plantenbak zou kunnen neerzetten waar zij dat wensen. Het project moet dus niet te groot, maar ook niet te zwaar zijn. 

Dit sluit dan ook weer aan op het gegeven van "Toughness", wat we bij durability hebben besproken. Als men deze smart plantenbak verscheidene keren gaat verplaatsen, dan moet het er ook wel een zekere weerstand tegen hebben. 

###### 3) Maintainability

Maintainability is ook iets dat zeer belangrijk is. Het onderhouden van de smart plantenbak is iets wat via het online web portaal of handmatig gebeurd. Handmatig zal dit neerkomen op bijvoorbeeld het makkelijk verversen van water en nutriënten en bij het online web portaal komt het er op neer dat alle data duidelijk en overzichtelijk zal worden getoond, zodat er meteen actie kan ondernomen worden als er iets mis moest zijn.

Het online portaal moet natuurlijk door ons ook onderhouden worden. Dit gaan we dan zo efficiënt, betrouwbaar en veilig mogelijk doen. 

###### 4) Testability

Zoals bij de non-functionele requirement durability al staat vermeld, gaan wij toch wel wat hardware nodig hebben. In dit geval is het wel belangrijk dat we dit allemaal ook zo goed mogelijk kunnen testen. Testabilititeit werkt nauw samen met de SOLID principes. Een aantal factoren zijn bijvoorbeeld:

* Encapsulation
* Cohesion
* Coupling
* Redundancy

Hoe beter we onze tests kunnen maken, hoe makkelijker het zal zijn om alles te doen samenwerken.

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
