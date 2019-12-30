var apiUrl = "http://localhost:5000/chat";

var input = document.getElementById("input");
var output = document.getElementById("output");

input.addEventListener("keypress", keyEvent => {
    if (keyEvent.which == 10 && keyEvent.ctrlKey) {
        var msg = input.value;
        storeMessage(msg).then(()=>{load();});
        input.value = "";
    }
});

function storeMessage(msg) {
    return fetch(apiUrl, {
        method: "POST",
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({message:msg})
    });
}

function load(){
    return fetch(apiUrl, {
        method: "GET",
        headers: {
            'Accept': 'application/json',
        }
    }).then(result=>{
        return result.json();
    }).then(data=>{
        output.innerHTML = "";
        var outputHtml = "<ul>";
        for(var i =0;i<data.messages.length;i++){
            outputHtml += "<li>" + data.messages[i].body + "</li>";
        }
        outputHtml += "</ul>";
        output.innerHTML = outputHtml;
    });
}

load();
/*
return fetch(this.baseUrl, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({msg:msg})
    });
     */