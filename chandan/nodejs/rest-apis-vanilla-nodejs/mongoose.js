const mongoose=require('mongoose')
mongoose.connect('mongodb://127.0.0.1:9000/testDb',{
    useNewUrlParser: true,
    useUnifiedTopology: true
  });
  const User=mongoose.model('User',{
     title:{
         type:String
     } ,
     Name:{
         type:String
     },
     Age:{
         type:Number
     }
  })