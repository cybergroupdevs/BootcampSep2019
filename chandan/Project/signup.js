function onSignIn(googleUser) {
  // Useful data for your client-side scripts:
  var profile = googleUser.getBasicProfile();
  console.log("ID: " + profile.getId()); // Don't send this directly to your server!
  console.log('Full Name: ' + profile.getName());
  console.log('Given Name: ' + profile.getGivenName());
  console.log('Family Name: ' + profile.getFamilyName());
  console.log("Image URL: " + profile.getImageUrl());
  console.log("Ehmail: " + profile.getEmail());
  var id_token = googleUser.getAuthResponse().id_token;
  console.log("ID Token: " + id_token);
  $.ajax("http://localhost:61549/api/values", {
  type: "POST",
  dataType: "json",
  contentType: "application/json",
  data: JSON.stringify(
    {
      "Name": profile.getName(),
      "Username":profile.getEmail(),

           // "password": pwd
     // "collegename": cname,
     // "collegeid": cid
    }
  ),
  success: function (data, status) {
    console.log("hello", data, status);
   // window.location.replace("loginscreen.html");
  },
  error: function () {
    alert("Something went wrong");
  }

});
}
$(document).ready(function () {
  $("#x").click(function (e) {
    e.preventDefault();
    var nam = document.getElementById("name").value;
    var em = document.getElementById("email").value;
    var pwd = document.getElementById("password").value;
    var pwd1 = document.getElementById("password1").value;
    var cname = document.getElementById("collegename").value;
    var cid = parseInt(document.getElementById("collegeid").value);
    /* $(".error").remove();
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
       $('#password').after('<span class="error">Password must have 5 character long</span>');
     }
     if(pwd1!=pwd)
     {
       $('#password1').after('<span class="error">Please enter same password</span>');
     }
     if(cname.length<1)
     {
       $('#collegename').after('<span class="error">Field Required</span>');
     }
   */



    $.ajax("http://localhost:61549/api/values", {
      type: "POST",
      dataType: "json",
      contentType: "application/json",

      data: JSON.stringify(
        {
          "name": nam,
          "username": em,
          "password": pwd,
          "collegename": cname,
          "collegeid": cid
        }
      ),
      success: function (data, status) {
        console.log("hello", data, status);
        window.location.replace("loginscreen.html");
      },
      error: function () {
        alert("Something went wrong");
      }

    });
  });
});