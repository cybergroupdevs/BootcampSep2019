const fs = require('fs')
const path = require('path')


class BaseController{
    constructor(){
        this.users = []
    }
    async read(req,res){
        let filedata = await readFile(req,res);
        res.end(filedata)
    }

    async create(req,res){
        let filedata,body_data,response,users = []
        let msg = "Data Inserted"
        filedata = await readFile()
        

        body_data = req.body
        filedata = JSON.parse(filedata)
        for(var i=0;i<filedata.length;i++){
            users.push(filedata[i])
        }
        users.push(body_data)
        writeFile(req,res,users,msg) 
    }

    async update(req,res){
        let filedata,body,key
        let msg = "Data deleted"
        filedata = await readFile()
        body = req.body

        filedata = JSON.parse(filedata)
        key = Object.keys(body)

        for(var i=0;i<filedata.length;i++){
            if(filedata[i]['id'] == req.query.id){
                for(var j=0;j<key.length;j++){
                    filedata[i][key[j]] = body[key[j]]
                }
                break
            }
        }
        writeFile(req,res,filedata,msg)
    }

    async delete(req,res){
        let filedata,index
        let msg = "Data deleted"
        filedata = await readFile(req,res)
        filedata = JSON.parse(filedata)
        console.log(req.query)
        for(var i=0;i<filedata.length;i++){
            if(filedata[i]['id'] == req.query.id){
                index = filedata.indexOf(filedata[i])
                filedata.splice(index,1)
                break
            }
        }
        writeFile(req,res,filedata,msg)
    }
}
 
exports.BaseController = BaseController;


function readFile(req,res){
    try{
        let filedata = fs.promises.readFile('input.json', "utf-8")
        console.log(filedata)
        return filedata
    }
    catch(err){
        const response = { error: err }
        res.setHeader("content-type","application/json")
        res.end(JSON.stringify(response))
    }

}

function writeFile(req,res,new_data,msg){
    try{
        fs.promises.writeFile('input.json',JSON.stringify(new_data));
        response = {status: 200, statusText: "OK", message: msg}
        res.setHeader("content-type","application/json")
        res.end(JSON.stringify(response))
    }
    catch(err){
        const response = { error: err }
        res.setHeader("content-type","application/json")
        res.end(JSON.stringify(response))
    }
    
}