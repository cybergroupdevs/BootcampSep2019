$(document).ready(function(){
    $("#sign_in").click(function(e){
       e.preventDefault();
           var username = $("#user_name").val();
            var pwd = $("#pwd1").val();
            console.log(username+" "+pwd);  
           
          var data1 =  {
                "Name" :username,
                "Password": pwd,
               
    
                };
                $.ajax({
           
                    type:"POST",
                    url:"http://localhost:61226/api/login",
                    dataType:"JSON",
                    
                    contentType:"application/json;charset=utf-8",
                    data: JSON.stringify(data1),
                    success:function(data,status){
                        console.log("successful",data,status);
                        window.location.replace("finalScreen.html");
                    },
                   error:function(){
                        console.log("Username not found");
                    }
        
        
        
        
                });
        
        
            });
        });