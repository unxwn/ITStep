const url = require('url');

const adr = 'http://localhost:8080/default.htm?year=2017&month=february'
const parsedAdr = url.parse(adr, true);

console.log(parsedAdr);
console.log("hostname:", parsedAdr.hostname);
console.log("port:", parsedAdr.port);
console.log("Path to website:", parsedAdr.host + parsedAdr.pathname);

console.log("GET-request parameters:");
for (let key in parsedAdr.query)
  console.log(`\t${key}: ${parsedAdr.query[key]}`);
