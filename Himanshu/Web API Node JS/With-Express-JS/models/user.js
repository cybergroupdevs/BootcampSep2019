const fs = require('fs')
const  usersModel  = require('../models/model')

exports.getUsers = async function(req,res){
    return readFile();
}

exports.newUsers = async function(req,res){
    let filedata, body_data, users = []

    body_data = req.body
    filedata = await readFile();
    
    filedata = JSON.parse(filedata)
    for(let i=0;i<filedata.length;i++){
        users.push(filedata[i])
    }
    users.push(body_data)
    writeFile(users)

    return({
        status: 200,
        statusText: 'Ok',
        message: "Inserted data"
    })
}

exports.updateUsers = async function(req,res){
    let filedata,key

    filedata = await readFile()
    body = req.body
    key = Object.keys(body)[0]

    filedata = JSON.parse(filedata)
    for(var i=0;i<filedata.length;i++){
        if(filedata[i]['id'] == req.query.id){
            filedata[i][key] = body[key]
            break
        }
    }
    writeFile(filedata)

    return({
        status: 200,
        statusText: 'Ok',
        message: "Updated data"
    })
}

exports.deleteUser = async function(req,res){
    let filedata,index

    filedata = await readFile()

    filedata = JSON.parse(filedata)
    for(var i=0;i<filedata.length;i++){
        if(filedata[i]['id'] == req.query.id){
            index = filedata.indexOf(filedata[i])
            filedata.splice(index,1)
            break
        }
    }
    writeFile(filedata)

    return({
        status: 200,
        statusText: 'Ok',
        message: "Deleted data"
    })
}

function readFile(){
    return fs.promises.readFile('input.json', "utf-8");
}

function writeFile(new_data){
    return fs.promises.writeFile('input.json',JSON.stringify(new_data));
}

exports.getUsersFromDB = async function(req,res){
    return await usersModel.find()
}

exports.writeUsersToDB = async function(req,res){
    let response,body,jsondetail
    body = req.body
    jsondetail = new usersModel(body)
    try{
        response = await jsondetail.save()
        return response
    }
    catch(err){
        response = {error: ''}
        return response
    }
}

exports.updateUsersToDB = async function(req,res){
    let _id, toUpdate,response;
    _id = req.query.id
    toUpdate = req.body
    try{
        response = await usersModel.findByIdAndUpdate(_id,toUpdate,{new: true})
        return response
    }
    catch(err){
        response = {error: ''}
        return response
    }
}

exports.deleteUserFromDB = async function(req,res){
    let _id = req.query.id
    try{
        response = await usersModel.findByIdAndRemove(_id)
        return response;
    }
    catch(err){
        response = {error: ''}
        return response
    }

}