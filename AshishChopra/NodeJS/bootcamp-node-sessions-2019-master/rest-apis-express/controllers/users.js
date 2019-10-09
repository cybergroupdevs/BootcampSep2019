const { user } = require("../models");

module.exports = {

  getUsers,
  createUser,
  updateUser,
  deleteUser
};

async function getUsers(req, res) {
  const response = await user.getUsers();
  res.send(response);
}

async function createUser(req, res) {
  // const body = req.body;
  // users.push(body);
  const response = await user.createUser(req,res);
  res.send({
    status: 200,
    statusText: "OK",
    message: "Client Inserted!"
  });
}

async function updateUser(req, res) {
 // const body = req.body;
  const ID = req.query.id;
  await user.updateUser(req,res)

  console.log(ID);

  // for (let key in body) {
  //   users[id][key] = body[key];
  // }

  res.send({
    status: 200,
    statusText: "OK",
    message: "Client Updated!"
  });
}

async function deleteUser(req, res) {
  const id = req.query.id;
  await user.deleteUser(req,res)

  // users.pop(id);

  res.send({
    status: 200,
    statusText: "OK",
    message: "Client Deleted!"
  });
}