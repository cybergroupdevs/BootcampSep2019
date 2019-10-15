const model = require("../mongoose").user;
class BaseController {
    async create(req, res) {
            req.on("end", () => {
                const userInfoFromClient = req.body;
                const client = this.model(userInfoFromClient);
                model.create(client);
                const response = {
                    status: 200,
                    statusText: "OK",
                    message: "Client Inserted!"
                };

                res.setHeader("content-type", "application/json");
                res.end(JSON.stringify(response));
            })
    }

    async read(req,res) {
        req.on("end", () => {
          let userInfoFromClient = req.body;
                  let response = model.findOne(userInfoFromClient.email)
                  res.setHeader("content-type", "application/json");
                  res.end(JSON.stringify(response));
                })
    }

    async update(req, res) {
            req.on("end", () => {        
                const id = Number.parseInt(req.body._id);
                const user = req.body; 
                model.update({_id:id}, { $set: { name: req.body.name } })
                const response = {
                    status: 200,
                    statusText: "OK",
                    message: "Client Updated!"
                };

                res.setHeader("content-type", "application/json");
                res.end(JSON.stringify(response));
            });
    }

    async delete(req,res) {
          req.on("end", () => {
            let body = req.body;
            const _id = Number.parseInt(body._id); 
            model.remove(_id)
            const response = {
                status: 200,
                statusText: "OK",
                message: "User deleted!"
            };

            res.setHeader("content-type", "application/json");
            res.end(JSON.stringify(response));
        });
    }
}

exports.BaseController = BaseController;