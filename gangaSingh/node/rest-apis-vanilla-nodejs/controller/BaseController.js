var path = require("path");
var fs = require('fs');
class BaseController {
    constructor(model) {
        this.users = [];
    //  this.model = model;
    }
     // Create a file to write a information of client
     async create(req, res) {
        try {
            req.on("end", () => {
                const user = req.body;
                this.users.push(user);
                writeFile(user);
                const response = {
                    status: 200,
                    statusText: "OK",
                    message: "Client Inserted!"
                };

                res.setHeader("content-type", "application/json");
                res.end(JSON.stringify(response));
            })
        } catch (err) {
            console.error(err);
        }
    }
    // Read a file to get client data
    async read(res) {
        //return await this.model.find();
        try {
            readFile()
                .then(data => {
                    this.users = JSON.parse(data);

                    const response = {
                        total: this.users.length,
                        data: this.users
                    };

                    res.setHeader("content-type", "application/json");
                    res.end(JSON.stringify(response));
                })
                .catch(err => {
                    const response = {
                        error: err
                    };

                    res.setHeader("content-type", "application/json");
                    res.end(JSON.stringify(response));
                });
        } catch (err) {
            console.error(err);
        }
    }
    async update(req, res) {
        try {
            req.on("end", () => {
                let query = req.query;
                // console.log("Queru om controller");
                const age = Number.parseInt(query.age); // age from postman query
                const user = req.body; // from postman
                readFile()
                    .then(data => {
                        this.users = JSON.parse(data);
                        if (age == this.users.age) {
                            this.users.name = user;
                            user.age = age;
                            writeFile(user);
                        }
                        //const response = { total: this.users.length, data: this.users };
                    }).catch(err => {
                        const response = {
                            error: err
                        };
                      });
                const response = {
                    status: 200,
                    statusText: "OK",
                    message: "Client Updated!"
                };

                res.setHeader("content-type", "application/json");
                res.end(JSON.stringify(response));
            });
        } catch (err) {
            console.error(err);
        }
    }

    //delete client details in file
    async delete(req,res) {
        try {
          req.on("end", () => {
            let query = req.query;
            const age = Number.parseInt(query.age); // age from postman query

            readFile()
                .then(data => {
                    this.users = JSON.parse(data);
                    if (age == this.users.age) {
                      console.log("Age in delete function");
                        delete this.users.name;
                        delete this.users.age;
                        writeFile(this.users);
                    }
                }).catch(err => {
                    const response = {
                        error: err
                    };
                  });
            const response = {
                status: 200,
                statusText: "OK",
                message: "User deleted!"
            };

            res.setHeader("content-type", "application/json");
            res.end(JSON.stringify(response));
        });

    } catch (err) {
        console.error(err);
    }
}

}

// Functions to read and write data in file .... !! data means user details 

function readFile() {
    const dbPath = path.join(__dirname, "../db", "users.json");
    return fs.promises.readFile(dbPath, "utf-8");
}

function writeFile(data) {
    console.log("In WriteFile:", data);
    const dbPath = path.join(__dirname, "../db", "users.json");
    return fs.promises.writeFile(dbPath, JSON.stringify(data));
}
exports.BaseController = BaseController; 