
const fs=require('fs');
const path=require('path');
class BaseController {
  async create(req,res) { // to insert data into database
    try {
      req.on("end", () => {
        readFile().then(data => {
          this.users = JSON.parse(data);
          console.log(this.users);

          const user = req.body;
          this.users.push(user);

          writeFile(this.users);

          const response = {
            status: 200,
            statusText: "OK",
            message: "Client Inserted!"
          };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        });
      });
    } catch (err) {
      console.error(err);
    }
  }
  async read(req,res) { //To fetch data from database
    try {
      readFile()
        .then(data => {
          this.users = JSON.parse(data);

          const response = { total: this.users.length, data: this.users };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        })
        .catch(err => {
          const response = { error: err };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        });
    } catch (err) {
      console.error(err);
    }    
  }
  async update() {
    try {
      req.on("end", () => {
        let query = req.query;

        console.log(query);

        const id = Number.parseInt(query.id);
        const user = req.body;

        this.users[id] = user;

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
  async delete() {
    try {
    } catch (err) {
      console.error(err);
    }
  }

  
}

exports.BaseController = BaseController;

function readFile() {
  const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.readFile("users.json", "utf-8");
}

function writeFile(data) {
  const dbPath = path.join(__dirname, "users.json");
  return fs.promises.writeFile("users.json", JSON.stringify(data));
}