﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user}: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    if (message == "") {
        return alert("Cannot send empty message!");
    }

    try {
        connection.invoke("SendMessage", user, message);
        document.getElementById("messageInput").value = "";

    } catch (err) {
        return console.error(err.toString());
    }

}); 