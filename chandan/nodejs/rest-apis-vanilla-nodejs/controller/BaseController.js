const fs = require('fs')
const users = [];
class BaseController {

  async create(req,res) {
    try {
      req.on("end", () => {
        readFile().then(data => {
          this.users.push(JSON.parse(data));
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

  async read(req,res) {
    fs.promises.readFile('./db/users.json').then(data=>{
      data = JSON.parse(data)
      res.end(JSON.stringify(data))
    }).catch(err=>{
      const response = {error: err};
      res.setHeader("content-type","application/json")
      res.end(JSON.stringify(response))
    })
     }

  async update(req,res) {
   
      req.on("end", () => {
        let query = req.query;

        console.log(query);

        const id = Number.parseInt(query.id);
        const user = req.body;
        readFile().then(data=>{
          this.users=JSON.parse(data);
          for(let i=0;i<this.users.length;i++)
          {
            if(this.users[i].age==id)
            {
              this.users[i].name=user.name;
              this.users[i].age=id;
              writeFile(this.users);
            }
          }
        })
        const response = {
          status: 200,
          statusText: "OK",
          message: "Client Updated!"
        };

        res.setHeader("content-type", "application/json");
        res.end(JSON.stringify(response));
    })
  }
  

  async deleteUsers(req,res) {
    res.setHeader("content-type", "application/json");
    res.end(JSON.stringify(response));
  try {
      let query = JSON.parse(req.query)
     //let query = req.query;
    console.log(query);
   const id = Number.parseInt(id);
     users.pop(id);
     res.send({
    status: 200,
    statusText: "OK",
    message: "Client Deleted!"
  })
    } catch (err) {
      console.error(err);
    }
  }
}


const path = require('path');

function readFile() {
  const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.readFile(dbPath, "utf-8");
}

function writeFile(data) {
  const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.writeFile(dbPath, JSON.stringify(data));
}
exports.BaseController= BaseController;