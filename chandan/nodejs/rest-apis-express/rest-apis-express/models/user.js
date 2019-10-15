
module.exports = {
  getUsers,
  createUser,
  updateUser,
  deleteUser
};
const info = require("../schema/UserComments");
const users = []; 

async function getUsers() {
 // console.log(info.find());
  try{
    const det= await info.find();
    return det;
  }
  catch(err)
  {
    console.log(err);
  }
}

async function createUser(req, res) {
    let response;
    let body,details;
    body=req.body;
    details= new info(body)
    console.log(details)
    try{
      response=await details.save()
      return response

    }
    catch(err)
    {
      response={error:err}
      return response
      }
    
}

async function updateUser(req, res) {
  const body = req.body;
  const _id = req.query.id;
  // console.log(id);
  console.log(body);
  await info.findByIdAndUpdate(_id,body)
  return({
    status: 200,
    statusText: "OK",
    message: "Client Updated!"
  });
}

async function deleteUser(req, res) {
  const id = req.query.id;
  console.log(id);
  await info.findByIdAndDelete(id);

  res.send({
    status: 200,
    statusText: "OK",
    message: "Client deleted!"
  });

}