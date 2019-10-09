const userDetails = require("../models/model")
module.exports = {
  getUsers,
  createUser,
  updateUser,
  deleteUser
};

const users = [];

async function getUsers() {

  // return new Promise((resolve, reject) => {
  //   resolve({
  //     status: 200,
  //     statusText: "OK",
  //     data: users
  //   });
  // });
  try{
    const det = await userDetails.find()
    return det
  }
  catch(err){
    console.log(err);
  }
}

async function createUser(req, res) {
  //const body = req.body;
  
  let body,details,response
  body = req.body;
  details = new userDetails(body)
  try{
  response = await details.save();
    return response
  }
  catch(err){
    response = (error , err)
    return response
  }
}

async function updateUser(req, res) {
  //const body = req.body;
  // const details = new userDetails(body)
  //const id = req.query.id;

  // console.log(id);

  // for (let key in body) {
  //   users[id][key] = body[key];
  const id = req.query.id;
  await userDetails.findByIdAndUpdate(id,req.body)
  

  res.send({
    status: 200,
    statusText: "OK",
    message: "Client Updated!"
  });
}


async function deleteUser(req, res) {
  const id = req.query.id;

  await userDetails.findByIdAndDelete(id);

  res.send({
    status: 200,
    statusText: "OK",
    message: "Client Deleted!"
  });
}