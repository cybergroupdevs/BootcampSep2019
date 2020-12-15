const { mongoose } = require('../db/connection')

const Schema = mongoose.Schema

const UsersModel = new Schema({
    name:{
        type: String
    },
    Age:{
        type: Number
    },
    Address:{
        Id: {
            type: Number
        },
        State: {
            type: String
        },
        Zip:{
            type: String
        }
    }
})

module.exports = mongoose.model('usersModel',UsersModel)