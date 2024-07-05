// const http = require('http');

// http.createServer(function (request, response) {
//   response.end("Hello from Nodemon")
// }).listen(3000, "127.0.0.1", () => {
//   console.log("Server is running");
// });


// const express = require("express");
 
// const app = express();
 
// app.get("/", function(request,response){
//     response.end("Hello from root path");
// });
// app.get("/main", function(request,response){
//     response.end("Hello from main page");
// });
 
// app.listen(3000);


// const fs = require('fs');

// fs.appendFile("test.txt", "New Test data\n", function (error) {
//   if (error) {
//     throw error;
//   }
//   console.log("Data was appended");
// });


const Emmiter = require("events");

let emmiter = new Emmiter();

let eventName = "Hello";

emmiter.on(eventName, function (msg) {
  console.log(msg);
});

emmiter.emit(eventName, "Hello event!");