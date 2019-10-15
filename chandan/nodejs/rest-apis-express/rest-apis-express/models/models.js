const mongoose = require('mongoose');
const Schema = mongoose.Schema;
mongoose.connect('mongodb://127.0.0.1:27017/chandan',
  {
    useNewUrlParser: true,
    useUnifiedTopology: true
  });
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
  //connection established
  console.log("Mongoose Connected");
});
module.exports={mongoose};