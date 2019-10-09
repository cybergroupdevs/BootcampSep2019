$(document).ready(function()
{
    $.ajax({
        type: "GET",
        url: "http://localhost:61226/authorization",
        contentType:"application/json;charset=utf-8",
        headers:{
            "Authorization":"Bearer" + localStorage.getItem('token')
        },
        dataType:"json",
       // recent:localStorage.getItem('token');
        success:function(recent){
            console.log('Authorized User');
        },
        error:function(data,success){
            console.log('Unauthorized User');
        }
  




    });




});