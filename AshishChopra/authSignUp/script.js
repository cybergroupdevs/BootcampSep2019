$(document).ready(function(){
    $("#btn1").click(function(){
      var data=   {
            "ame" = $("#name").val();
            Uname= $("#email").val();
            pass = $("#pwd").val();
            cnf_pwd = $("#pwd1").val();
            collName = $("#collegeName").val();
            rollNo = $("#CollegeId").val();
        } 
        
        $.ajax({
            
            type:"POST",
            url:"http://localhost:61226/api/user",
            _data: JSON.stringify(data),
            get data() {
                return this._data;
            },
            set data(value) {
                this._data = value;
            },
            contentType:"application/json;charset=utf-8",
            success:function(data,success){
                console.log("successful");
            },
           error:function(){
                console.log("Username not found");
            }




        })


    })
})