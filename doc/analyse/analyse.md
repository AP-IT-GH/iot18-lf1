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
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/Software_Architecture_2.png)

#### Gedetailleerde diagrammen

Database model:  
![alt text](https://github.com/AP-Elektronica-ICT/iot18-LF1/blob/master/doc/img/DatabaseModel.png)

Software Flowchart:
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/Software_Flowchart_LabFarm_v1.jpg)

Hardware Blokdiagram:
![alt text](https://github.com/AP-Elektronica-ICT/iot1819--iot18lf1/blob/master/doc/img/Blokdiagram.png)

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

De functionaliteit van ons project kan u op deze link vinden:
https://jira.ap.be/projects/IOT18LF1/summary

## Release Plan 

Ons release plan kan u momenteel ook op deze link vinden: https://jira.ap.be/projects/IOT18LF1/summary

PS: De planning en de sprints zijn momenteel nog een heel ruwe schatting vanwege de deadline voor de analyse. Er zullen dus zeker nog wel updates komen, maar momenteel is het toch al een goede schatting naar wat u zou kunnen verwachten. 

## Inventarisatie Hardware

### Central Processing

#### ATMEGA644
    + goedkoop
    + 40 pinnen (32 I/O pinnen)
    + dubbel program memory van ATMEGA328
    - geheugen sterk genoeg voor foto's?
    
#### Arduino Mega (mag dit wel gebruikt worden?)
    + meer pinnen dan ATMEGA644
    + Makkelijker in gebruik
    - duurder
    - geheugen sterk genoeg voor foto's?

#### Raspberry Pi (mag dit wel gebruikt worden?)
    + sterk
    + uitbreidbaar geheugen
    + fysieke UTP/USB aansluitingen kunnen extra mogelijkheden bieden
    + Wifi Module ingebouwd
    - veel duurder
    
#### Uiteindelijke keuze
We hebben uiteindelijk besloten om voor 4 Raspberry Pi's te gaan in combinatie met 4 ATTiny85's. 1 Raspberry Pi zal dienen als Master voor de ATTiny's en de 3 anderen zullen elks 1 Pi Camera bevatten. Dit model werd ons aanbevolen bij de eerste presentatie.

De communicatie tussen de Raspberry Pi en de 4 ATTiny's zal gebeuren met behulp van het I2C protocol. 

### Light Sensor

#### Ambient light sensor (ALS) - ICOPT3001 (Texas Instruments)
     + I²C communicatie (= duidelijke output)
     + low dispersion
     + lichtgevoeligheid = menselijk oog
     - 6 aansluitingen
     
     http://www.ti.com/lit/ds/symlink/opt3001.pdf
        
#### LV0104CS (Onsemi)
     + i²c communicatie (= duidelijke output)
     + low dispersion
     + lichtgevoeligheid = menselijk oog
     + 4 aansluitingen
      
     http://www.onsemi.com/pub/Collateral/LV0104CS-D.PDF
     
#### Uiteindelijke keuze
Uiteindelijk hebben we besloten om gewoon een Light Dependent Resistor (LDR) te gebruiken. De LDR kan makkelijk de waarden via I2C doorsturen en heeft ook verscheidene formaten. Hieronder kan u nog even de voordelen en nadelen terugvinden zoals bij de voorgaande opties.

**Light Dependent Resistor (LDR)**

	+ Goedkoop
	+ Verschillende formaten
	+ Minder power consumptie
	+ Waarden zijn makkelijk te verkrijgen
	- Hebben een aantal millieseconden nodig om zich aan te passen aan het licht.
	- Sensitiviteit hangt af van toepassing tot toepassing

### PH Sensor 

#### Gravity: Analog pH Sensor / Meter Kit For Arduino
    + goedkoop
    + makkelijke aansluiting op pcb
    
    https://www.dfrobot.com/product-1025.html
    how to use:
    https://scidle.com/how-to-use-a-ph-sensor-with-arduino/
    
#### Uiteindelijke keuze
We hebben ervoor gekozen om de PH Sensor te verwijderen uit ons project, sinds deze een aantal voorwaarden heeft voor we deze kunnen laten werken. De PH Sensoren (meetprobes) die we hadden gevonden waren labo-probes. Dit waren probes die we niet 24/7 onder water konden steken. Dit was echter niet echt een probleem, sinds we zoals bij Smart Systems een systeem zouden kunnen maken waarbij deze op en neer gaat. Dat was echter niet het enige. Het tweede punt is dat deze PH sensoren om de zoveel tijd terug in chemisch water moeten worden afgespoeld. Dit zou er dus voor zorgen dat we een apart rail systeem zouden moeten voorzien, alleen voor deze sensor (tenzij we het er ergens anders zouden opkrijgen). 

Vanwege deze redenen zijn we dus overgeschakeld van een PH Sensor naar een Particle Sensor ofterwijl Stofsensor.

### Stof Sensor

#### PPD42NS
	Voordelen en nadelen zullen zo snel mogelijk worden aangevuld.
    
### Electrical Conductivity Sensor 

#### Zelf maken:
    https://www.youtube.com/watch?v=B0lrcvT2HRc
    
#### Uiteindelijke keuze
Voor de Conductivity Sensor is er uiteindelijk niets verandert. We blijven bij ons idee van deze zelf te maken.
    
### Camera 

#### ArduCAM Mini Camera Module Shield w/ 2 MP OV2640 for Arduino
    + goedkoop
    + speciaal gemaakt voor arduino projecten
    + I²C communicatie
    
    https://www.robotshop.com/eu/en/arducam-mini-camera-module-shield-2-mp-ov2640-arduino.html?gclid=Cj0KCQjwuafdBRDmARIsAPpBmVUi0YRoRtd5osaa2rMZMbvfKH_YiUFcq9rJzr4onahy1zTNfeqEHioaAtWFEALw_wcB
    
#### Uiteindelijke keuze
Voor de camera hadden ze ons bij de vorige presentatie de PiCam aanbevolen. Sinds we toch al Raspberry Pi's gingen gebruiken, konden we beter deze camera gebruiken die daar specifiek voor dient. De voordelen en nadelen kan u hieronder vinden:

**Raspberry Pi Camera**

	+ Goede kwaliteit
	+ Gemaakt voor de Raspberry Pi
	+ Raspberry Pi heeft er een aantal pinnen voor voorzien
	- Kabel kan best niet langer worden gemaakt
    
### Temperature Sensor 

#### LM35
    + goedkoop
    + klein LM component
    
    https://www.efxkits.us/lm35-temperature-sensor-circuit-working/
    
#### Uiteindelijke keuze
Onze uiteindelijke keuze voor de temperatuur sensor was een MCP9700. Dit was vooral omdat ze deze momenteel in stock hadden. Hieronder wederom de voordelen en nadelen:

**MCP9700**

	+ Goedkoop
	+ Klein component
	+ Kan makkelijk waarden doorgeven via I2C
	- Kwetsbaar
    
### Water/Nutrition Pump 

#### hoge kwaliteit dc 3v kleine waterpomp
    + goedkoop
    + klein component
   
    + makkelijk aan te sluiten (enkel DC aansluiting)
    + lage energie (3V-6V)
    
    https://www.lightinthebox.com/nl/p/dc-3v-kleine-waterpomp-4-5v-5v-6v-beschikbaar_p6070066.html?currency=EUR&litb_from=paid_adwords_shopping&country_code=be&utm_source=google_shopping&utm_medium=cpc&adword_mt=&adword_ct=223877363966&adword_kw=&adword_pos=1o1&adword_pl=&adword_net=g&adword_tar=&adw_src_id=4594603293_855506788_45795275174_pla-361404953667&gclid=Cj0KCQjwuafdBRDmARIsAPpBmVWKVdZD_gc1qj4MH86bJMxOe7419tGs_uNU7Yr1u_7QDa_opzLxonEaAvn1EALw_wcB
    
#### DC 12 V Doseerpomp Peristaltische Doseerkop
    + goedkoop
    + dosseren
    - traag? (max 60 ml/min)
    
    https://nl.aliexpress.com/item/12V-DC-DIY-Dosing-Pump-Peristaltic-Dosing-Head-For-Aquarium-Lab-Analytical-Water-Free-Shipping-From/32404308028.html?spm=a2g0z.search0104.3.25.3f352ab0mYwk9g&ws_ab_test=searchweb0_0,searchweb201602_5_10065_10068_5726820_10843_10546_10059_10884_10548_10887_10696_100031_5726920_10084_10083_10103_10618_10304_10307_10820_449,searchweb201603_45,ppcSwitch_5&algo_expid=0572c925-6725-4353-82e1-39e945880fe5-3&algo_pvid=0572c925-6725-4353-82e1-39e945880fe5&transAbTest=ae803_2&priceBeautifyAB=0
    
#### Uiteindelijke keuze
TODO - Deze moet nog aangevuld worden!

### WiFi Module

#### ESP8266 ESP-01 ESP01
    + goedkoop
    - betrouwbaar?
    
    https://nl.aliexpress.com/item/ESP8266-Serial-Esp-01-WIFI-Wireless-Transceiver-Module-Send-Receive-LWIP-AP-STA/32278773466.html?spm=a2g0z.search0104.3.16.3e0c4c2b114YK0&ws_ab_test=searchweb0_0,searchweb201602_5_10065_10068_5726815_10843_10059_10884_10887_10696_100031_10084_10083_5726915_10103_10618_10304_10307_10820_10821_10302,searchweb201603_60,ppcSwitch_5&algo_expid=ba6cfe04-9b5a-43a5-b1c6-314b907f42b2-2&algo_pvid=ba6cfe04-9b5a-43a5-b1c6-314b907f42b2&priceBeautifyAB=0

#### Uiteindelijke keuze
De WiFi module hebben we nu ook afgeschreven, sinds de Raspberry Pi al een ingebouwde WiFi module heeft. 

### Alternatieven en misschien nodig

### PH Sensor 

#### PH sensor controller
    LMP91200 (Texas Instruments)
        http://www.ti.com/product/LMP91200
	
### Moisture Sensor 

#### Soil Hygrometer Humidity Detection Module Moisture Sensor for Arduino
    + goedkoop
    + makkelijke aansluiting op pcb
    
    https://www.gearbest.com/lcd-led-display-module/pp_1604163.html?wid=1433363&currency=EUR&vip=4494060&gclid=Cj0KCQjwuafdBRDmARIsAPpBmVUVZ4v3PHXDPaJaefT5DMdvNO3SS2K4qrhyFczvhqV0_jlU99c4Qq8aAjazEALw_wcB
    how to use:
    https://www.instructables.com/id/Arduino-Soil-Moisture-Sensor/
    
### Servo/Motor

#### motor van school gebruiken?
    Is dit nodig?

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
