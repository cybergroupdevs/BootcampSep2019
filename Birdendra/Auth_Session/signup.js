$(document).ready(function(){
    $(".signupbtn").click(function(){
        $.ajax("http://localhost:58530/values/Signup",{
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
               
                alert('something went worng hello');
            }
        });
    });
});
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
    var token = googleUser.getAuthResponse().id_token;
    localStorage.setItem("token",token);
    console.log(localStorage.getItem("token"));
    $.ajax("http://localhost:58530/api/SignUp",{
            type:"POST",
            dataType: "json",
            contentType: "application/json",
            data:JSON.stringify(
                {  
                    "userId": profile.getEmail(),
                    // "pwd": token,
                    "name": profile.getName(),
                    // "colName": "",
                    // "colId": ""
                }
            ),
            success:function(data, status){
                console.log("Hellow", data, status);
               
                window.open("login.html");
            },
            error: function( err ){
               
                alert('something went worng email');
            }
        });
}