$(document).ready(function(){
    
    $(".login-button").click(function(){
        $('.login-error-message').empty();
        if(!checkErrorStatus()){
            return
        }
        let studentDetail = {}
        studentDetail.Username = $("#userID").val();
        studentDetail.password = $("#userPassword").val();
        $.ajax({
            type:"POST",
            url: "http://localhost:52379/login",
            data:JSON.stringify(studentDetail),
            contentType:"application/json; charset=utf-8",
            success:function(data, success){
                localStorage.setItem('userToken',data.token)
                $(location).attr('href','home.html')
            },
            error:function(msg){ 
                $('.login-error-message').html(msg.responseText)
            }
        })
    })

    $('.save-details').click(function(){
        $('.error-message').empty()
        let studentDetail = {};
        studentDetail.username = $("#name").val();
        studentDetail.email = $("#email").val();
        studentDetail.password = $("#password").val();
        studentDetail.collegeName = $("#collegeName").val();
        studentDetail.collegeID = $("#collegeID").val();
        $.ajax({
            type:"POST",
            url:"http://localhost:52379/signup",
            data:JSON.stringify(studentDetail),
            contentType:"application/json; charset=utf-8",
            success: function(data,success){

                $(location).attr('href','index.html')
            },
            error: function(msg){ 
                $('.error-message').html(msg.responseText)
            }
        })
    })

    $('#userID').focus(function(){
        $('#user-icon').css({'color':'#38F6F9'})
    }).focusout(function(){
        $('#user-icon').css({'color':'black'})
        if($('#userID').val().length == 0){
            $('#user-error-message').html("Username cannot be empty")
            return
        }
        $('#user-error-message').empty();
        
    })

    $('#userPassword').focus(function(){
        $('#pass-icon').css({'color':'#38F6F9'})
    }).focusout(function(){
        $('#pass-icon').css({'color':'black'})
        if($('#userPassword').val().length  == 0){
            $('#password-error-message').html("Password cannot be empty")
            return
        }
        $('#password-error-message').empty();
    })


})

checkErrorStatus = ()=>{
    let a,b;
    a = $('#userID').val().length;
    b= $('#userPassword').val().length;
    if(a!=0 || b!=0){
        return true;
    }
    return false;
}

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    var googleData = {
        "Username":profile.getGivenName(),
        "Email":profile.getEmail(),
        "Password":profile.getImageUrl()
    }
    $.ajax({
        type:'POST',
        url:"http://localhost:52379/signup/googleDetails",
        data: JSON.stringify(googleData),
        contentType: "application/json; charset=utf-8",
        success: function(data,success){
            $(location).attr('href','home.html');
        },
        error: function(data,success){
            console.log('Error')
        }
    })
}