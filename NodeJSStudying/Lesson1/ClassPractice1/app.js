const os = require('os');
const Car = require('./car');
const http = require('http');
const url = require('url');

// let userInfo = os.userInfo().username;
// console.log(userInfo);

// let car = new Car("Audi", "Q7", "2024");
// car.drive();
// car.showInfo();

http.createServer(function (request, response) {
  response.end(`${url.parse(request.url, true).url}`);
}).listen(3000, "127.0.0.1", function () {
  console.log("Server is running");
});