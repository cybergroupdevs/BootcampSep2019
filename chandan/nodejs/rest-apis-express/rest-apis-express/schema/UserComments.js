//const Schema =mongoose.Schema;
//const mongoose = require("mongoose");
const {mongoose}=require('../models/models')
const User = new mongoose.Schema(
  {
  Comments: [{
    _id: String,
    subreddit: [{
      _id: String,
      Post: [{
        _id: String,
        Comment_on_post: [{
          Date: String,
          Time: String
        }]
      }]
    }]
  }]
}
);
module.exports= mongoose.model("user",User);