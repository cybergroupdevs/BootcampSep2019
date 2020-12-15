const webtoken = require('jsonwebtoken')
const { SECRET } = require('../config/config');
const localStorage = require('localStorage')

function generateNewToken(req,res){
    const token = webtoken.sign({token: req.body.inputUsername},SECRET,{expiresIn: 36000})
    tokenValue = {'token':token}
    localStorage.setItem('authToken',JSON.stringify(tokenValue))
}

function checkAuthentication(req,res){
    let tokenData = localStorage.getItem('authToken')
    tokenData = JSON.parse(tokenData)
    try{
        const result = webtoken.verify(tokenData['token'],SECRET)
        console.log('true')
        return true
    }
    catch(err){
        console.log('false')
        return false
    }
}


module.exports = {
    generateNewToken, checkAuthentication
}
