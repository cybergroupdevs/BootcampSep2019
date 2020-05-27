$(document).ready(function () {
    $("#btn1").click(function (e) {
        e.preventDefault();
        var username = document.getElementById("exampleInputEmail1").value;
        var password = document.getElementById("exampleInputPassword1").value;

        console.log(username + ' ' + password);
        $.ajax("http://localhost:56355/api/login", {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            // crosDomain:"true",
            headers:{
                
                "username":username,
                "password": password
            },
            data: JSON.stringify(
                {

                    "username": username,
                    "password": password
                }
            ),
            success: function (headers, status) {
                console.log("hello", headers, status);
                localStorage.setItem("token",headers);
                window.location.replace("home.html");
            },
            error: function () {
                alert("Username or Password did not match");
            }
        });

    });
});
