$(document).ready( function(){
    $('#btn').click( function(){
        // console.log(user_id+' '+pwd);
       
        
        $.ajax("http://localhost:58530/api/SignUp",{
            type:"GET",
            dataType: "json",
            contentType: "application/json",
            
            success:function(data, status){

                // window.open("success.html");
                $("table tbody").empty();
                    var th ="<tr><th>SL_NO</th><th>Name</th><th>Email</th><th>College Name</th><th>College Id</th></tr>";
                    $("table tbody").append(th);    
                for ( var i = 0 ; i < data.length; i++ ){
                    // $('#table').append('<tr><td>hello</td></tr>');
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