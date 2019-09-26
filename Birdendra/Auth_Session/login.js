$(document).ready( function(){
    $('#btn').click( function(){
        var user_id = document.getElementById("ui").value;
        var pwd1 = document.getElementById("pwd").value;
        // console.log(user_id+' '+pwd);
        
        $.ajax("http://localhost:58530/api/values",{
            type:"POST",
            headers:{
                "userId":user_id,
                "pwd": pwd1
            },
            dataType: "json",
            contentType: "application/json",
            // data:JSON.stringify(
            //     {  
            //         "userId" : user_id,
            //         "pwd" : pwd1
            //     }
            // ),
            success:function(data, status){

                console.log( data, status);
               
                window.open("success.html");

            },
            error: function(msg){
                console.log(msg.responseText);
                alert(msg.responseText);
            }
        });
    });
});