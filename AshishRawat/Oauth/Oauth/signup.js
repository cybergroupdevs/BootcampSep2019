$(document).ready(function () {
    $("#submit").click(function (e) {
        e.preventDefault();
        var email = document.getElementById("Email1").value;
        var name = document.getElementById("Name").value;

        var collegename = document.getElementById("Collegename").value;

        var collegeid = parseInt(document.getElementById("Collegeid").value);

        var pass = document.getElementById("Password").value;
        console.log(name + ' ' + email + ' ' + collegename);
        $.ajax("http://localhost:56355/api/values", {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            // crosDomain:"true",
            data: JSON.stringify(
                {
                    "name": name,
                    "username": email,
                    "collegeid": collegeid,
                    "collegename": collegename,
                    "password": pass
                }
            ),
            success: function (data, status) {
                console.log("hello", data, status);
                window.location.replace("login.html");
            },
            error: function () {
                alert("Something went wrong")
            }
        });

    });
});
