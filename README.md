# ApartmentRentingPOC-

Voici un POC d'une API permettant de créer une base de données d'appartements et chambres, ainsi que de clients.
L'application est basée sur le framework aspnetboilerplate.
Elle suit la structure suivante :

3 Classes dans la couche Core
  - Apartment
    - "name" : String, nom de l'appartement ;
    - "street" : String, rue de l'appartement ;
    - "zipCode" : String, code postal ;
    - "city" : String, ville ;
    - "rooms" : Liste d'objets Room, qui correspondent aux chambres de l'appartement
    
  - Room
    - `number` : Integer, numéro de la chambre ;
    - `area` : Float, surface de la chambre ;
    - `price` : Integer, prix de la chambre (en centimes) ;
    
  - Client
    - "firstName" : String, prénom ;
    - "lastName" : String, nom ;
    - "email" : String, adresse email ;
    - "phone" : String, numéro de téléphone ;
    - "birthDate" : DateTime, date de naissance ;
    - "nationality" : String, nationalité ;
    - "Room" : Room, la chambre assignée au client
 
Chaque classe possède un service associé dans la couche Application (ex: RoomAppService).
Ces services exposent des fonctions basiques permettant de créer/éditer/lire/supprimer les objets en questions.
Le ClientAppService permet aussi de lier un Client à une Room (sous réserve que son profil et que la chambre est disponible).

La base de données est gérée dans la couche EntityFramework en EDM.

La couche WebApi expose l'API.
La couche Web permet d'interfacer l'API avec l'utilisateur, mais l'interface n'a pas été écrite dans le cadre de cet exercice.

Afin de tester l'API, il faut compiler et lancer la solution (choisir ApartmentRentingPOC.Web comme projet de départ). 
(Note: Vous aurez besoin d'un serveur SQL local et de mettre à jour la connection string du Web.Config de la couche ApartmentRentingPOC.Web).
Se rendre à l'url "http://localhost:6234/swagger" et utiliser l'interface de swagger pour appeler directement l'API.

Une ébauche d'une couche de test unitaire est présente dans la couche Test.
