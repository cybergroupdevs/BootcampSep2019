class Calculator{
    constructor(){
        this.num = "",
        this.equalTo = false
    }
    getInput = (obj)=>{
        if(obj == 0 && this.num == ""){
            return
        }
        if(this.equalTo == true){
            document.getElementById('result').innerHTML = ""
            this.equalTo = false

        }
        let lastElement = this.num[this.num.length-1]
        
        if(this.num != "" && (lastElement.charCodeAt(0)>=42 && lastElement.charCodeAt(0)<=47)){
            this.num += obj
            document.getElementById('result').innerHTML = obj
            return
        }
        this.num += obj
        document.getElementById('result').innerHTML += obj             
    }

    getOperation = (obj) =>{
        let lastOperation = this.num[this.num.length-1]
        if(this.num != "" && !(lastOperation.charCodeAt(0)>=42 && lastOperation.charCodeAt(0)<=47)){
            this.num += obj
        }
    }

    showResult = ()=>{
        let lastOperation = this.num[this.num.length-1]
        if(lastOperation.charCodeAt(0)>=48 && lastOperation.charCodeAt(0)<=57){
            let result = eval(this.num)
            document.getElementById('result').innerHTML = result
            this.equalTo = true
        }
    }

    clearOperation = ()=>{
        this.num = ""
        document.getElementById('result').innerHTML = ""
    }

    clearLastElement = ()=>{
        let temp = eval(this.num).toString();
        this.num = temp.slice(0,temp.length-1);
        document.getElementById('result').innerHTML = this.num;
    }

    rootOperation = ()=>{
        let lastElement = document.getElementById("result").value;
        console.log(lastElement)
        // if(lastElement.charCodeAt(0)>=48 && lastElement.charCodeAt(0)<=57){
        //     let square = Math.sqrt(parseInt(lastElement,10));
        //     console.log(square)
        // }

    }
}

const cal = new Calculator();