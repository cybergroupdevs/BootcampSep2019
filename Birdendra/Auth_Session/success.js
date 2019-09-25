$(document).ready( function(){
    $('#btn').click( function(){
        // console.log(user_id+' '+pwd);
        $('div').append('<p>hello</p>');
        
        $.ajax("http://localhost:58530/api/SignUp",{
            type:"GET",
            dataType: "json",
            contentType: "application/json",
            
            success:function(data, status){

                console.log( data, status);
                console.log(data.length);
                console.log('first '+data[0].userId);
                // window.open("success.html");
                for ( var i = 0 ; i < data.length; i++ ){
                    $('#table').append('<tr><td>hello</td></tr>');
                    // var tbl = "<tr><td>"+i+"</td><td>"+data[i].name+"</td><td>"+data[i].userId+"</td><td>"+data[i].colName+"</td><td>"+data[i].colId+"</td></tr>";
                    // $("#table").append(tbl);
                }

            },
            error: function(msg){
                console.log(msg.responseText);
                alert(msg.responseText);
            }
        });
    });
});