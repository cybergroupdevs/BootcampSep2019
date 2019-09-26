$(document).ready(function(){
    $("#btn1").click(function(e){
        e.preventDefault();
        var nam=document.getElementById("uname").value;
        var password=document.getElementById("pwd").value;
        console.log(nam);
        console.log(password);
      $.ajax("http://localhost:61549/api/login",{
        type:"POST",
        dataType:"json",
        contentType:"application/json",
           headers:
           {
            "username":nam,
            "password":password,
           },
            data:JSON.stringify(
                {
                  "username":nam,
                  "password":password,
                }
            ),
            success:function(headers,status){ 
                console.log("hello",headers,status);
                window.location.replace("mainscreen.html");
            },
            error:function(msg)
            {
                console.log(msg);
                alert(msg.responseText);
            }
            
          });
      });
  });