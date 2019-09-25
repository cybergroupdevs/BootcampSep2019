$(document).ready(function () {
    $("#btn1").click(function (e) {
        e.preventDefault();
        var username = document.getElementById("exampleInputEmail1").value;
        var password = document.getElementById("exampleInputPassword1").value;

        console.log(username + ' ' + password);
        $.ajax("http://localhost:56355/api/values", {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            // crosDomain:"true",
            data: JSON.stringify(
                {
                   
                    "username": username,
                    "password": password
                }
            ),
            success: function (data, status) {
                console.log("hello", data, status);
                window.location.replace("home.html");
            },
            error: function () {
                alert("Something went wrong")
            }
        });

    });
});
