const express = require('express')
const router = require('../routers/routes')
const bodyParser = require('body-parser')
const { PORT, HOST } =require('./config')
const mongooseConnection = require('../db').connection;
const path = require('path')
const appDir = path.dirname(require.main.filename)

const app = express()

app.use(bodyParser.urlencoded({
    extended: true
}))
app.use(bodyParser.json())
app.use(router())

app.set('view engine', 'ejs')
app.set('views',appDir + '/views')
app.use(express.static(appDir + '/public'))


app.listen(PORT,HOST, err=>{
    if(err) throw err;
    console.log(`Running on http:${HOST}:${PORT}`)
})