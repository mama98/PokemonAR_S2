var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');


var app = express()();
var server =require('http').Server(app);
var functions = require('./functions');
var io = require('socket.io')(server);

app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.get('/', function(req, res){
    res.send("Serveur PokemonAR ");
});

io.on('connection',function(socket){
    socket.emit('connected',{connected:true});

    socket.on('start', function(data){
        if(!data || !data.uid || !data.ouid){
            socket.emit('infoMissing');
            return;
        }
        let params1 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.uid
            }
        }
        let params2 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.ouid
            }
        }
        let dresseur1, dresseur2;
        docClient.get(params1, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur1 = dat.Item;
        });
        docClient.get(params2, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur2 = dat.Item;
        });
        socket.emit('dresseurs',{dresseur1:dresseur1, dresseur2:dresseur2});
        socket.emit('go',{player:data.uid});
    });

    socket.on('atk',function(data){
        if(!data || !data.uid || !data.ouid || !data.atk){
            socket.emit('infoMissing');
        }
        let params1 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.uid
            }
        }
        let params2 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.ouid
            }
        }
        let dresseur1, dresseur2;
        docClient.get(params1, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur1 = dat.Item;
        });
        docClient.get(params2, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur2 = dat.Item;
        });
        var paramsModif = {
            TableName:"Dresseur",
            Key:{
                "id":data.ouid
            },
            UpdateExpression: "set info.pkmn.pv = :p",
            ExpressionAttributeValues:{
                ":p":dresseur2.pkmn.pv - dresseur1.pkmn.atk[data.atk].degats
            },
            ReturnValues:"UPDATED_NEW"
        };
        docClient.update(paramsModif1, function(err, data) {
            if (err) {
                socket.emit('error');
                return;
            }
        });
        docClient.get(params2, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur2 = dat.Item;
        });
        socket.emit('atkSucceded', {uidAtked: data.ouid, dresseur:dresseur2});
        socket.emit('go',{player:data.ouid});
    });
    socket.on('reset', function(data){
        if(!data || !data.uid || !data.ouid){
            socket.emit('infoMissing');
        }
        let params1 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.uid
            }
        }
        let params2 = {
            TableName:"Dresseurs",
            Key:{
                "id":data.ouid
            }
        }
        let dresseur1, dresseur2;
        docClient.get(params1, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur1 = dat.Item;
        });
        docClient.get(params2, function(err, dat) {
            if (err) {
                socket.emit('error');
                return;
            }
            dresseur2 = dat.Item;
        });
        var paramsModif1 = {
            TableName:"Dresseur",
            Key:{
                "id":data.uid
            },
            UpdateExpression: "set info.pkmn.pv = :p",
            ExpressionAttributeValues:{
                ":p":dresseur1.pkmn.maxpv
            },
            ReturnValues:"UPDATED_NEW"
        };
        docClient.update(paramsModif1, function(err, data) {
            if (err) {
                socket.emit('error');
                return;
            }
        });
        var paramsModif2 = {
            TableName:"Dresseur",
            Key:{
                "id":data.ouid
            },
            UpdateExpression: "set info.pkmn.pv = :p",
            ExpressionAttributeValues:{
                ":p":dresseur2.pkmn.maxpv
            },
            ReturnValues:"UPDATED_NEW"
        };
        docClient.update(paramsModif2, function(err, data) {
            if (err) {
                socket.emit('error');
                return;
            }
        });
        socket.emit('ressetSuccess');
    });
});

var port = process.env.PORT || 3000;
