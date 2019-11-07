$(document).ready(function(){
    $.ajax('http://localhost:3000/loggedIn',{
        type: 'GET',
        dataType: 'JSON',
        headers:{
            "token":localStorage.getItem('token')
        },
        success: function(data){
            localStorage.setItem('name',data.name)
            document.getElementById('username').innerHTML = "Hie, "+data.name
        }
    })
})
$(document).on('click', '#checkAccessKey', function() {
    const tok = localStorage.getItem('token');

    if (tok == null) {
        location.replace("../../index.html")
    }
    $.ajax('http://localhost:3000/test/accessKey', {
        type: 'POST',
        dataType: 'JSON',
        data: {
            examCode: $(".inputBox").val()
        },
        success: function(data) {
            localStorage.setItem('examCode', $(".inputBox").val())
            $(location).attr('href', '../views/instructions.html')
        },
        error: function(error) {
            $('.error-msg').text("Wrong Access key")
        }
    })
})

function logout() {
    localStorage.removeItem("token")
    location.replace("../../index.html")
}