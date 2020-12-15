

var mongoose = require('mongoose');
mongoose.connect('mongodb://127.0.0.1:27017/testDataBase', {
   useNewUrlParser: true,
   useCreateIndex:true});
  var db = mongoose.connection;
  db.on('error', console.error.bind(console, 'connection error:'));
  db.once('open', function() {//once connection opens,callback will be called
  //connected
  console.log("connected")
});

const Schema = mongoose.Schema
const User = new Schema({
   
    Name:{
        type : String
    },
    Age:{
        type : Number
    },
    Address:{
        

        State : {
            type:String
        },

        zipCode : {
            type : String
        }
    }
});
module.exports = mongoose.model('userDetails',User);

