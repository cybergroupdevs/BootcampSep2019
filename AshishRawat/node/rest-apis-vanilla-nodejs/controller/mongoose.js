const mongoose =require('mongoose')
mongoose.connect('mongodb://127.0.0.1:27017/db-0',
{
    useNewUrlParser: true,
    useCreateIndex:true
});
const User =mongoose.model('document1',
{
    title:{
        type:String

    },
    Name:{  
        type:String

    },
    age:{
        type:Number

    }

}
)