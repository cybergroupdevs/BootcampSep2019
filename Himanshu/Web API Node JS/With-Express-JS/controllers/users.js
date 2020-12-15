const { user } = require('../models')

module.exports = {
    getUsers,
    newUsers,
    updateUsers,
    deleteUser,
    getUsersFromDB,
    writeUsersToDB,
    updateUsersToDB,
    deleteUserFromDB
}
async function getUsers(req,res){
    try{
        let response = await user.getUsers()
        response = JSON.parse(response);
        res.send(response)
    }
    catch(err){
        console.error(err);
    }
}

async function newUsers(req,res){
    try{
        let response = await user.newUsers(req,res)
        res.send(response)
    }
    catch(err){
        console.error(err)
    }
}

async function updateUsers(req,res){
    try{
        let response = await user.updateUsers(req,res)
        res.send(response)
    }
    catch(err){
        console.log(err)
    }
}

async function deleteUser(req,res){
    try{
        let response = await user.deleteUser(req,res)
        res.send(response)
    }
    catch(err){
        console.log(err)
    }
}

async function getUsersFromDB(req,res){
    try{
        let response = await user.getUsersFromDB(req,res);
        res.send(JSON.stringify(response))
    }
    catch(err){
        res.end(JSON.stringify(err))
    }
}

async function writeUsersToDB(req,res){
    try{
        let response = await user.writeUsersToDB(req,res);
        res.send(JSON.stringify(response))
    }
    catch(err){
        res.end(JSON.stringify(err))
    }
}


async function updateUsersToDB(req,res){
    try{
        let response = await user.updateUsersToDB(req,res)
        res.send(JSON.stringify(response))
    }
    catch(err){
        res.end(JSON.stringify(err))
    }   
}

async function deleteUserFromDB(req,res){
    try{
        let response = await user.deleteUserFromDB(req,res)
        res.send(JSON.stringify(response))
    }
    catch(err){
        res.end(JSON.stringify(err))
    }
}