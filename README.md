# Gravity 2D

University of Bucharest - Faculty of Mathematics and Computer Science - Game Programming Course - Team 9's project

## Descriere (RO)
   Jocul are ca inspiratie cel mai puternic eveniment spatial inregistrat vreodata , gaura neagra . Jucatorul reprezinta o entitate binevoitoare cu tehnologii avansate care are ca misiune salvarea navetelor spatiale de la o moarte iminenta . Misiunea insa nu este una usoara caci gravitatia gaurii negre atrage nenumarate obiecte spatiale care pot fi periculoase.
      
   Reflexele si atentia distributiva reprezinta componente cheie pentru a deveni maestru la acest joc .
   
## Description (ENG)
   The game uses as insiration the strongest spatial event ever recorded which is THE BLACK HOLE. The player represents a kind entity with access to advanced technologies who has the mission of saving spatial ships from an iminent death. All things considered, this mission is not easy to accomplish because of the black hole's gravitational pull which attracts many dangerous spatial objects.
   
   Reflexes and action time represent key components in mastering this game.
   
   <img src="Images/Main_menu.PNG">
   
   <img src="Images/In_game.PNG">
      
## Jucator (RO)
   Jucatorul se misca prin input orizontal si vertical (*arrow keys*) permitand astfel avansarea in 8 directii posibile. De asemenea datorita tehnologiei avansate are acces la un set de abilitati utile:
   
      * Super viteza - Un burst de scurta durata in viteza de miscare a jucatorului - Cooldown : 10
      * Health Magnet - Sistem ce atrage asteroizii cu minereuri ce ajuta la vindecarea jucatorului - Cooldown : 10
      * Shield - Imunitate pe o anumita perioada de timp la coliziunea cu asteroizii - Cooldown : 8
      * Snap - Distruge toti asteroizii periculosi din scena si salveaza orice naveta - Cooldown : 25

## Player (ENG)
   The player moving system uses horizontal and vertical input from arrow keys, allowing for movement in 8 possible directions. Also the access to advanced technology provides unique and usefull abilities to the protagonist:
   
      * Super speed - Short time speed burst applied to the player's rigidbody - Cooldown : 10
      * Health Magnet - Strong magnet which pulls asteroids that heal the player on collision - Cooldown : 10
      * Shield - Short period of time immunity on collision with harmfull spatial objects - Cooldown : 8
      * Snap - Strong burst of gamma energy that saves every ship and destroys all harmfull spatial objects - Cooldown : 25

## Obiecte spatiale (RO)
   Toate obiectele din spatiu sunt atrase catre gaura neagra ( via script ) . In cazul navetelor spatiale in functia awake salvam destinatia initiala ( locul de instantiere ) , iar in caz de salvare a navetei noua destinatie a obiectului devine destinatia initiala , de asemenea distrugem obiectul la atingerea destinatiei ( pas de optimizare ).
   De asemenea viteza obiectelor spatiale este aleasa random (pentru diversitate)
   
## Spatial Objects (ENG)
   Every spatial object ( asteroid or space ship ) is instatiated outside of the game screen and follows a direction to the black hole's center via script. 
   In the case of space ships, Awake() method is used to store the initial spawn position and in case of rescue this initial position becomes the new destination of the space ship gameObject. Also as an optimization step once outside of screen boundaries the rescued objects are destroyed.
   
   Object speed is chosen randomly upon initialization for more diversity.

## Manager de instantiere (RO) 
   Sistemul de spawn foloseste Coroutine si Random.Range pentru a instantia obiecte spatiale in afara spatiului de joc , aleator (obiectele spatiale pot veni spre gaura neagra din orice directie) si intre intervale de timp setate , ce scad o data cu trecerea timpului (creste dificultatea).
   
## Spawn Manager (ENG) 
   The spawn system uses Coroutines and Random.Range to instantiate spatial objects outside of gameScreen in a random manner ( spatial objects can be pulled to the black hole from any direction) and in time intervals that decrease over time (increasing difficulty).
      
## Particule (RO) 
   Efectele exploziilor si a culegerii asteroizilor cu minereu au fost realizate cu sistemul de particule ce apartine de Unity , fiind o cale eficienta si usoara.
   
## Particule (ENG)
   Explosions and other special effects were created using the Unity build-in particle system which is easy to use.
      
## Assets 

      - https://pngimage.net/green-cross-png/
      - https://webstockreview.net/pict/getfirst
      - https://www.seekpng.com/ipng/u2q8a9i1r5r5e6a9_energy-shield-png-energy-shield-transparent/
      - http://adamfelstead95.blogspot.com/2015/10/character-proposal.html
      - https://graphicriver.net/space-and-sprite-graphics-in-game-assets
      - Google images 
      
## (RO) Sursa esentiala pentru scripting (intelegerea metodelor) : https://docs.unity3d.com/ScriptReference/
## (ENG) https://docs.unity3d.com/ScriptReference/ - Unity's documentation was used to better understand the behaviour of different methods used to create the game.
