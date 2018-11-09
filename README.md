# Internet of Things - Leave It
## Groepsleden

Wouter Huygen  
Joris Van Looy    
Denny Matthijs   
Steven De Keuster  
Melvin Boetsgezel 

## Teamrollen

2 Personen Conditioning : Wouter & Denny  
* Sensoren: Vochtigheidsgraad, temperatuur, pH-Waarde v/d grond + omgevingstemperatuur, omgevingslicht,  
* Data verstuurd naar database  
* Zorgen voor juiste sensor data  
* Ontwerp Dataset/backend web  

1 Persoon beeldherkenning: Joris
* Foto’s trekken van plant en versturen naar database  
* Herkennen welke plant in de bak zit  
* Plant analyseren a.d.h.v. getrokken foto’s  
    
2 Personen Plant Robot: Robbe & Steven
* Toevoer water, stroom, voedingsstoffen  
* Hardware connecties sensoren  
* PCB-ontwerp  
* Design plantenbak  
    
1 Persoon Project Manager/Web development: Melvin  
* Frontend web  
* Project management  


## Documentatie

### Algemeen

Voor meer informatie over het project zelf kan u volgende links volgen:

* [Analyse](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/doc/analyse)

* [Flowcharts + Blokdiagrammen](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/doc/img)
 
* [Meetings](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/doc/meetings)

PS: We hebben ook zo goed als elke les, aan het begin, een kleine meeting. In deze map hierboven staan echter alleen de grote meetings na dat er een sprint is afgerond of als er een nieuwe gestart wordt. 

PPS: Als er nog niets in bepaalde mappen moest in staan, dan moeten we het eerst nog even pushen! 

### Backend

De ASP.NET core web API en de SQL database draaien op azure services.

Base url web API: http://labfarmwebapp.azurewebsites.net/

Example url (GET labfarms): http://labfarmwebapp.azurewebsites.net/api/v1/labfarm

Voor extra documentatie over route's, endpoints, DB modellen en SQL queries : [API endpoint ocumentatie](https://github.com/AP-Elektronica-ICT/iot18-LF1/blob/master/doc/backend/Labfarm%20API%20endpoint%20documentation.pdf)

### Sensoren

Voor het verkrijgen van de data vanuit de sensoren gebruiken we een Raspberry Pi als master met daarbij 4 ATTiny85s als slaves. De communicatie van de ATTiny85s naar de Raspberry Pi gebeurd via het I2C protocol. Meer informatie kan u op volgende links vinden:

* [Sensor code (master / slave)](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/Sensors)

* [Gebruikte Libraries](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/Libraries)

* [Sensor datasheets](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/doc/datasheet)

### Hardware / Elektrische Schema's / Code betreffende hardware

Meer informatie over de hardware alsook de elektrische schema's kan u vinden via volgende links:

* [Hardware tekeningen](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/doc/Drawings)

* [Elektrische schema's](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/Electrical%20Designs)

* [Hardware code](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/MCU%20Programs)

### Camera

Updates betreffende de camera zal u in deze map kunnen vinden:

* [Camera](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/cameras)

### Online Platform 

Natuurlijk maken we, voor ons project, ook gebruik van een online platform. Belangrijke informatie kan u vinden via volgende link:

* [Online Platform](https://github.com/AP-Elektronica-ICT/iot18-LF1/tree/master/src/labfarm-client)

### Presentaties

De presentaties kan u hier terugvinden:

* [Presentatie 1 & 2](https://prezi.com/view/gqtpL6frQNvXV23dgvv2) 
Deze gebruiken hetzelfde design, alleen was er bij de tweede presentatie meer duidelijkheid over wat we allemaal gingen gebruiken. Het is daaraan ook aangepast. Onze excuses voor geen kopie te nemen van de eerste presentatie apart.

Presentatie 3: Komt er aan wanneer we de presentatie gegeven hebben. No spoilers! 

