const fs = require("fs"),
  path = require("path");
class BaseController {
  async create(req, res) {
    ///reading the file
    try {
      req.on("end", () => {
        readFile().then(data => {
          console.log('data : ' + data)
          this.users.push(JSON.parse(data))
          console.log(this.users);
          const user = req.body;
          this.users.push(user);
          //the above code is used to store previous values
          writeFile(this.users);

          const response = {
            status: 200,
            statusText: "OK",
            message: "Client Inserted!"
          };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        }).catch(e => {
          console.log(e);
        })
      });
    } catch (err) {
      console.error(err);
    }
  }
  async read(req, res) {
    try {
      ///reading all the data stored in the json file
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
  async update(req, res) {
    try {
      this.aman = []
      req.on("end", () => {
        let query = req.query;
        //query from link
        const id = Number.parseInt(query.id);
        //id from postman
        const user = req.body;


        readFile().then(data => {
          this.users = JSON.parse(data);
          console.log(this.users[0].school);
          console.log(id);
          console.log(this.users[0].username);
          for (let i = 0; i < this.users.length; i++) {
            //console.log("inside lop");
            if (this.users[i].id == id) {
              this.users[i].id = id;
              //matching and updating the school of the particular given id
              this.users[i].school = user;
              writeFile(this.users);
            }
          }
          //  let query = req.query;
          const response = {
            status: 200,
            statusText: "OK",
            message: "Client Updated!"
          };
          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        });
      })
    }
    catch (err) {
      console.error(err);
    }
  }
  async delete(req, res) {

  }
}

exports.BaseController = BaseController;
function readFile() {
  const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.readFile(dbPath, "utf-8");
}

function writeFile(data) {
  const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.writeFile(dbPath, JSON.stringify(data));
}

