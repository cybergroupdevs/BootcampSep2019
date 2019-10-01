const { objectParser} = require('./utils/utils')

const obj = objectParser(process.argv)
console.log(obj)

module.exports = {
    PORT: process.env.PORT || obj.PORT || 9000,
    HOST: process.env.HOST || obj.HOST || "0.0.0.0",
    baseURI: process.env.baseURI || obj.baseURI || "/api",
    database: {
        DB_USER: process.env.DB_USER || obj.DB_USER || "admin",
        DB_PASSWORD: process.env.DB_PASSWORD || obj.DB_PASSWORD || "root"
    }
}