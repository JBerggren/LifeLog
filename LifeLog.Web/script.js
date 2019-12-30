var apiUrl = "http://localhost:5000/message";

var input = document.getElementById("input");
var output = document.getElementById("output");
var runBtn = document.getElementById("run");

input.addEventListener("keypress", keyEvent => {
    if (keyEvent.which == 10 && keyEvent.ctrlKey) {
        handleInput();
    }
});

runBtn.addEventListener("click",()=>{
    handleInput();
});

function handleInput(){
    var msg = input.value;
    if(!msg || msg.length == 0 || msg.trim().length == 0){
        load();
        return;
    }
    if(msg.indexOf("/") == 0){
        runQuery(msg.substr(1));
    }else{
        storeMessage(msg).then(()=>{load();});
    }
    input.value = "";
}

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

function runQuery(query){
    return fetch(apiUrl + "/query", {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({query:query})
    }).then(result=>{
        return result.json();
    }).then(data=>{
        output.innerHTML = "";
        var outputHtml = `<h3>${query}</h3>`;
        outputHtml += "<ul>";
        for(var i =0;i<data.messages.length;i++){
            var item = data.messages[i];
            outputHtml += renderItem(item);
        }
        outputHtml += "</ul>";
        if(data.messages.length == 0){
            outputHtml += "<span>No results</span>";
        }
        output.innerHTML = outputHtml;
    });
}

function renderItem(item){
    var html ="";
    var date = new Date(item.created);
    html += `<li class='message' data-id='${item.id}'>`;
    html += `<span class='date'>${date.getDate()}/${date.getMonth()+1}</span>`;
    html += `<span class='body'>${item.body}</span>`;
    html += "</li>";
    return html;
}

function load(){
    return fetch(apiUrl + "/today", {
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
            var item = data.messages[i];
            outputHtml += renderItem(item);
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