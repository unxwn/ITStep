const http = require('http');

http.createServer(function (request, response) {
  const url = request.url.toLowerCase();
  console.log(url);

  switch (url) {
    case "/":
      response.statusCode = 200;
      response.setHeader("Content-Type", "text/plain");
      response.end("Home page");
      break;
    case "/index.html":
      response.statusCode = 200;
      response.setHeader("Content-Type", "text/plain");
      response.end("Main page");
      break;
    default:
      createError(response);
      break;
  }
}).listen(3000, "127.0.0.1", function () {
  console.log(`Server is running`);
});

function createError(res) {
  res.statusCode = 404;
  res.setHeader("Content-Type", "text/plain")
  res.end("Page not found")
}