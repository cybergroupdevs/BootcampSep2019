var signupsignindetailsschema = new mongoose.Schema({
    name     : String,
    email    : String,
    password : String
});

var signupsignindetailsmodel = mongoose.model('signupsignindetailsmodel', signupsignindetailsschema);
exports.signupsignindetailsmodel = signupsignindetailsmodel;