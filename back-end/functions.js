var express = require('express');
var router = express.Router();

/* GET home page. */
/*
    router.[type de requete] : on met l'adresse, donc comment on va y accéder exemple : "localhost:3000/test"
    puis on met la fonction donc ce qu'elle va faire, ce qu'elle va envoyer et recevoir de la BDD
*/
router.get('/test', function(req, res, next) {
  //Ici on récupère de la base de donnée
});

router.put('/test', function(req, res, next){
    //Ici on envoie dans la base de donnée
});

module.exports = router;