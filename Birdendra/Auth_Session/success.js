$(document).ready( function(){
    $('#btn').click( function(){
        console.log("button click");
        //get the token using local storage and append Beraer infront it and assign authorization key
        var tkn =window.localStorage.getItem('token');
        $.ajax("http://localhost:58530/values/Get",{
            type:"GET",
            headers: {"Authorization": `Bearer ${tkn}`},
            dataType: "json",
            contentType: "application/json",
            success:function(data, status){
                $("table tbody").empty();
                    var th ="<tr><th>SL_NO</th><th>Name</th><th>Email</th><th>College Name</th><th>College Id</th></tr>";
                    $("table tbody").append(th);    
                for ( var i = 0 ; i < data.length; i++ ){
                    var tbl = "<tr><td>"+i+"</td><td>"+data[i].name+"</td><td>"+data[i].userId+"</td><td>"+data[i].colName+"</td><td>"+data[i].colId+"</td></tr>";
                    $("table tbody").append(tbl);
                }
            },
            error: function(msg){
                console.log(msg.responseText);
                alert(msg.responseText);
            }
        });
    });
});