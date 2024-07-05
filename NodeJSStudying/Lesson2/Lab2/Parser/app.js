const fs = require('fs');
const parser = require('./parser');

fs.readFile("./data.txt", "utf-8", (err, data) => {
  if (err) {
    console.log(err);
    return;
  }
  data = data.replace(/[\n\r]/g, '');
  const parsedData = parser.parseStr(data);
  console.log(parsedData);

});