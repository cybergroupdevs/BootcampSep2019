const mongoose = require('mongoose');
mongoose.connect('mongodb://127.0.0.1:27017/testdb', {
    useNewUrlParser: true,
    useUnifiedTopology: true
});
var db = mongoose.connection;




db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function() {
    // we're connected!
    console.log("connected");
});

var userSchema = new mongoose.Schema({
    name: String,
    age: Number,
    address: {
        city: String,
        state: String,
        pincode: Number
    }
});

var user = mongoose.model('user', userSchema);

module.exports = {
    user,
    db
}