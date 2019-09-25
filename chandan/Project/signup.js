$(document).ready(function(){
  $("#x").click(function(e){
      e.preventDefault();
      var nam=document.getElementById("name").value;
      var em=document.getElementById("email").value;
      var pwd=document.getElementById("password").value;
      var cname=document.getElementById("collegename").value;
      var cid=parseInt (document.getElementById("collegeid").value);
      console.log(nam);
      console.log(em);
      console.log(pwd);
      console.log(cname);
      console.log(cid);
    $.ajax("http://localhost:61549/api/values",{
      type:"POST",
      dataType:"json",
      contentType:"application/json",
      
          data:JSON.stringify(
              {
                "name": nam,
                "username":em ,
                "password": pwd,
                "collegename":cname,
                "collegeid": cid
              }
          ),
          success:function(data,status){ 
              console.log("hello",data,status);
              window.location.replace("loginscreen.html");
          },
          error:function()
          {
              alert("Something went wrong");
          }
          
        });
    });
});