$(document).ready(function(){
    $("#btn1").click(function(e){
        e.preventDefault();
        var nam=document.getElementById("uname").value;
        var password=document.getElementById("pwd").value;
        console.log(unam);
        console.log(password);
      $.ajax("http://localhost:61549/api/values",{
        type:"POST",
        dataType:"json",
        contentType:"application/json",
        
            data:JSON.stringify(
                {
                  "username":unam ,
                  "password":password,
                }
            ),
            success:function(data,status){ 
                console.log("hello",data,status);
                window.location.replace("mainscreen.html");
            },
            error:function()
            {
                alert("Something went wrong");
            }
            
          });
      });
  });