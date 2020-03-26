#get {ADRESSE}/ debutcombat
À envoyer comme info :
    {
        "uid":"identifiant_du_user",
        "ouid":"identifiant_de_l'adversaire"
    }
Ce qui sera reçu :
{
    "pkmnA":{
        nom, identifiant, et plein d'autres infos du pokémon comme son niveau, ses attaques disponibles etc...
    }
    "pkmnB":{
        (Pokémon de l'adversaire)
        nom, identifiant, PV, et pas grand chose d'autre
    }
}

#put {ADRESSE}/atk
À envoyer comme info :
{
    "uid":"identifiant_du_user",
    "ouid":"identifiant_de_l'adversaire",
    "atk":"attaque_choisie_entre_0_et_3",
}
Ce qui sera reçu:
{
    "pkmnB":{
        toutes les infos du pokémon, pricipalement ses pvs
    }
}
#get {ADRESSE}/atk
À envoyer comme info :
{
    "uid":"identifiant_du_user",
    "ouid":"identifiant_de_l'adversaire",
    "pv":"pv_du_pokemon",
}
Afin d'envoyer les modifications quand ton pokémon se prend un coup
Ce qui sera reçu (uniquement quand le pokemon d'en face a attaqué):
{
    "changed": true ou false si les infos ont été changés, quand false rien d'autre n'est envoyé
    "pkmnA":{
        toutes les infos du pokémon, pour actualiser ses pvs
    }
    "pkmnB":{
        pas sur car pas forcément modifié
    }
}

#put {ADRESSE}/reset
À envoyer comme info :
{
    "uid":"identifiant_du_user"
}
Ce qui sera reçu:
{
    "fait": true ou false 
}
