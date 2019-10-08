var googleauthdetailsschema = new mongoose.Schema({
    email       : String,
    imageurl    : String,
});

var googleauthdetailsmodel = mongoose.model('googleauthdetailsmodel', googleauthdetailsschema);