Cours de GD2 sur les bases d'Unity


Mon projet Roll Ball 

Le joueur controle un petit vaisseau qui a pour but de ramener de la pierre sur la planete terre. En detruisant des asteroides le joueur pourra rattacher les rochers à l'arriere de son vaisseau. Ensuite le joueur devra ramener la pierre jusqu'a sa planete. En faisant ainsi celle ci s'ameliorera jusqu'a atteindre l'objectif du niveau.

Systeme à implementer

-Mouvement baser sur les réacteur du vaiseau, l'orientation du vaisseau soit par la souris ou touche du clavier à voir.
-Le tir dans la direction pointer par le vaisseau
-L'aimant lorsqu'il touche un asteroide de petite taille, celui ci s'attache à l'aimant. Si le joueur prend des dégats il perd un asteroide. En arrivant dans la zone de la terre les asteroides sont laché. Avoir un nombre de rocher max et les attaché en ligne 
-Mouvement des asteroides.
-La terre: systeme de points (bonus si en avance apporté des ameliorations au joueurs)
-Mort si le joueur se crash sur une planete ou si il se prend un gros asteroides.
-Relance du niveau

-Niveau 2 : Ajout de troue noir permettant de se teleporter à d'autre endroit
            -Boost autour des planete si pris dans la bonne courbe ( si trop complexe ou long des boost placé sur le niveau)

-Niveau 3 : Selon le temps : Planete ennemie ou des vaisseau ennemies ou une créature aliens qui est un faux asteroide.

Menu démarrer, menu de mort 

Son : pour chaque action. Son d'ambiance.
Effet : Effet pour le tir, le moteur, les asteroides qui prenne des dégats et détruit. Effet mort. 
UI : sur la planete terre visible le nombre de points


Biais d'amelioration selon le temps 

Plus le joueur à d'asteroide attaché plus il est difficile de manier le vaisseau 
Un turbo sur le joueur 
Des améliorations du vaisseau. 
D'autres ressources. 
D'autre type de tir 



DevLog: 
29/10
Objectif :-Implementer les movements 
          -Le tir 
          -Ameliorer la caméra 
          
La base des movements a été implementer, mais je n'arrive pas a obtenir un bon feeling
J'ai la base de tir, maintenant je dois appliquer les dégats au énnemis je le ferais ce soir, en ameliorant aussi le feeling de la caméra 
Les dégats sont appliqué et le tir fonctionne j'ai opté au final pour un spawn d'un component qui check lui meme la collision
Si j'ajoute une amelioration j'utiliserai peut etre un ray cast.


30/10
Ajout de l'aimant, puis modification de la maniabilité, et systeme de points lorsqu'il lache les asteroides sur la terre 
La mort du joueur si y a le temps 


