var usserauthdetailsschema = new mongoose.Schema({
    email     : String,
    token     : String,
});

var userauthdetailsmodel = mongoose.model('userauthdetailsmodel', userauthdetailsschema);