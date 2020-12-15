const {MONGO_HOSTNAME,MONGO_PORT, MONGO_DB} = require('./keys')
const mongoose = require('mongoose')
//const MongoClient = require('mongodb').MongoClient;
//const format = require('util').format

//Connection Using Mongoose
const url = `mongodb://${MONGO_HOSTNAME}:${MONGO_PORT}/${MONGO_DB}`;
mongoose.connect(url,{useNewUrlParser: true, useCreateIndex: true})

mongoose.connection.once('open',()=>{
    console.log('Mongoose Connection is Successful')
}).on('error',(error)=>{
    console.log('Connection erorr : ',error)
})

module.exports = {
    mongoose
}

//Connection Using MongoClient
// const url = 'mongodb://127.0.0.1:27017'

// MongoClient.connect(url,{useNewUrlParser: true},(err,db) =>{
//     if(err) throw err;
//     else console.log('MOngo DB Connection Successful')
// })