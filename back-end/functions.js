var express = require('express');
var router = express.Router();
var AWS = require("aws-sdk");

AWS.config.update({
  region: "eu-west-3"
});
var docClient = new AWS.DynamoDB.DocumentClient();
/* GET home page. */
/*
    router.[type de requete] : on met l'adresse, donc comment on va y accéder exemple : "localhost:3000/test"
    puis on met la fonction donc ce qu'elle va faire, ce qu'elle va envoyer et recevoir de la BDD
*/
router.get('/', function(req, res, next) {
  //Ici on récupère de la base de donnée
  let params = {
    TableName:"Pokedex",
    Key:{
        "id":parseInt(req.body.id)
    }
  }
  
  docClient.get(params, function(err, data) {
    if (err) {
        res.json({error: err});
    } else {
        res.json({data:data.Item});
    }
  });
});

router.put('/test', function(req, res, next){
    //Ici on envoie dans la© base de donnée
});

module.exports = router;