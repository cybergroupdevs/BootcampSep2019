const express = require('express')
const Users = require('../controllers/users')
const { baseURI } = require('../config/config')
const { generateNewToken,checkAuthentication } = require('../auth/auth')


module.exports =()=> {
    const router = express.Router();

    router.get(`${baseURI}/users`, Users.getUsers)
    router.post(`${baseURI}/users`,Users.newUsers)
    router.put(`${baseURI}/users`, Users.updateUsers)
    router.delete(`${baseURI}/users`, Users.deleteUser)

    router.get(`${baseURI}/database`,Users.getUsersFromDB)
    router.post(`${baseURI}/database`,Users.writeUsersToDB)
    router.put(`${baseURI}/database`,Users.updateUsersToDB)
    router.delete(`${baseURI}/database`,Users.deleteUserFromDB)

    router.get('/login',(req,res)=>{
        return res.render('login.ejs')
    })

    router.get('/home',(req,res)=>{
        console.log('Trying to Authorize')
        if(checkAuthentication(req,res)){
            console.log('User is Authorized')
            return res.send({
                message:"Redirected to Home Page"
            }).redirect('home.ejs')    
        }
        else{
            console.log('User is not Authorized')
            return res.send({
                message:"Session Timed Out"
            }).redirect('/login')

            //return Ok("Session Timed Out")
            //return res.redirect('/login')
        }
        
    })

    router.post('/login/loginAuthentication',(req,res)=>{
        console.log('Trying to Authenticate')
        const logindata = req.body
        if(logindata.inputUsername == 'himanshu' && logindata.inputPassword == 'himanshu'){
            generateNewToken(req,res)
            console.log('Authentication Done Successfully')
            return res.redirect('/home')
        }
        else{
            return res.redirect('/login')
        }
    })
    return router;
}
