const fs = require("fs"),
  path = require("path");

const { BaseController } = require("./BaseController");

class Users extends BaseController {
  constructor() {
    super();
    this.users = [];
  }

  async getUsers(req, res) {
    super.read(req,res);
  }

  async createUser(req, res) {
    super.create(req,res);
  }

  async updateUser(req, res) {
    console.log(req.query);
   super.update(req,res);
  }

  async delete(req, res) {
    console.log(req);
    super.deleteUsers(req,res);
  }
}

exports.Users = Users;


