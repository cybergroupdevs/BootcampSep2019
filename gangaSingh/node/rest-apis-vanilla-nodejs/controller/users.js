const {
  BaseController
} = require("./BaseController");


class Users extends BaseController {

  async getUsers(req,res) {
      return new Promise((resolve, reject) => {
          super.read(req,res).then(console.log("User Data Displayed successfully"))
      }).catch((error) => {
          console.log(error);
      });
  }

  async createUser(req, res) {
      return new Promise((resolve, reject) => {
          super.create(req, res).then(console.log("Created User Succesfully"));
      }).catch((error) => {
          console.log(error);
      });
  }

  async updateUser(req, res) {
      return new Promise((resolve, reject) => {
          super.update(req, res).then(console.log("Updated User successfully"))
      }).catch((error) => {
          console.log(error);
      });
  }

  async deleteUser(req, res) {
      return new Promise((resolve, reject) => {
          super.delete(req,res).then(console.log("deleted User successfully"))
      }).catch((error) => {
          console.log(error);
      });
  }
}

exports.Users = Users;