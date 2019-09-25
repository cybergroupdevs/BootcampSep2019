$(document).ready(function(){
    $(".signupbtn").click(function(){
        $.ajax("http://localhost:58530/api/SignUp",{
            type:"POST",
            dataType: "json",
            contentType: "application/json",
            data:JSON.stringify(
                {  
                    "userId": $("#email").val(),
                    "pwd": $("#psw").val(),
                    "name": $("#name").val(),
                    "colName": $("#col_name").val(),
                    "colId": parseInt($("#col_id").val())
                }
            ),
            success:function(data, status){
                console.log("Hellow", data, status);
               
                window.open("login.html");
            },
            error: function( err ){
               
                alert('something went worng');
            }
        });
    });
});