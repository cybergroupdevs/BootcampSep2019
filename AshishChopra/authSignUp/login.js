$(document).ready(function(){
    $("#btn1").click(function(e){
       e.preventDefault();
           var username = $("#username1").val();
            var pwd = $("#pwd11").val();
            console.log(username + ' ' + pwd);  
           
          
                $.ajax("http://localhost:61226/api/login",{
           
                    type:"POST",
                    dataType:"JSON",
                    contentType:"application/json;charset=utf-8",
                    data: JSON.stringify( 
                        {
                            "Email" : username,
                            "Password": pwd,
                        }
                    ),
                    success:function(data,status){
                       console.log("successful",data,status);
                        window.location.replace("finalScreen.html");
                    },
                   error:function(receive){
                      window.alert("Username not found");
                    },  
        
        
        
        
                });
        
        
            });
        });