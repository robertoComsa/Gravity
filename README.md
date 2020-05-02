# Gravity 2D

Proiect Jocuri - Echipa 9

## Descriere 

      Jocul are ca inspiratie cel mai puternic eveniment spatial inregistrat vreodata , gaura neagra . Jucatorul reprezinta o entitate binevoitoare cu tehnologii avansate care are ca misiune salvarea navetelor spatiale de la o moarte iminenta . Misiunea insa nu este una usoara caci gravitatia gaurii negre atrage nenumarate obiecte spatiale care pot fi periculoase.
      
      Reflexele si atentia distributiva reprezinta componente cheie pentru a deveni maestru la acest joc .
      
## Jucator

      Jucatorul se misca prin input orizontal si vertical (*arrow keys*) permitand astfel avansarea in 8 directii posibile. De asemenea datorita tehnologiei avansate are acces la un set de abilitati utile:
      * Super viteza - Un burst de scurta durata in viteza de miscare a jucatorului - Cooldown : 10
      * Health Magnet - Sistem ce atrage asteroizii cu minereuri ce ajuta la vindecarea jucatorului - Cooldown : 10
      * Shield - Imunitate pe o anumita perioada de timp la coliziunea cu asteroizii - Cooldown : 8
      * Snap - Distruge toti asteroizii periculosi din scena si salveaza orice naveta - Cooldown : 25

## Space objects

      Toate obiectele din spatiu sunt atrase catre gaura neagra ( via script ) . In cazul navetelor spatiale in functia awake salvam destinatia initiala ( locul de instantiere ) , iar in caz de salvare a navetei noua destinatie a obiectului devine destinatia initiala , de asemenea distrugem obiectul la atingerea destinatiei ( pas de optimizare ).
      De asemenea viteza obiectelor spatiale este aleasa random (pentru diversitate)

## Spawn Manager 

      Sistemul de spawn foloseste Coroutine si Random.Range pentru a instantia obiecte spatiale in afara spatiului de joc , aleator (obiectele spatiale pot veni spre gaura neagra din orice directie) si intre intervale de timp setate , ce scad o data cu trecerea timpului ( creste dificultatea ) 
      
## Particule
    
      Efectele exploziilor si a culegerii asteroizilor cu minereu au fost realizate cu sistemul de particule ce apartine de Unity , fiind o cale eficienta si usoara.
      
## Assets

      - https://pngimage.net/green-cross-png/
      - https://webstockreview.net/pict/getfirst
      - https://www.seekpng.com/ipng/u2q8a9i1r5r5e6a9_energy-shield-png-energy-shield-transparent/
      - http://adamfelstead95.blogspot.com/2015/10/character-proposal.html
      - https://graphicriver.net/space-and-sprite-graphics-in-game-assets
      - Google images 
      
## Sursa esentiala pentru scripting (intelegerea metodelor) : https://docs.unity3d.com/ScriptReference/
