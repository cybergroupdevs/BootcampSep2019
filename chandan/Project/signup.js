$(document).ready(function(){
  $("#x").click(function(e){
      e.preventDefault();
      var nam=document.getElementById("name").value;
      var em=document.getElementById("email").value;
      var pwd=document.getElementById("password").value;
      var cname=document.getElementById("collegename").value;
      var cid=parseInt (document.getElementById("collegeid").value);
      $(".error").remove();
      if(nam.length<1)
      {
        $('#name').after('<span class="error">Field Required</span>');
      }
      if(em.length<1)
      {
        $('#email').after('<span class="error">Field Required</span>');
      }
      if(pwd.length<5)
      {
        $('#password').after('<span class="error">Field Required</span>');
      }
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