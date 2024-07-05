//Task 1
const express = require('express');

const app = express();

app.use(express.static(__dirname + "/public"));

app.get("", function (req, res) {
    res.end("U can search for:\n\tlocalhost:3000/1.jpg\n\tlocalhost:3000/2.jpg\n\tlocalhost:3000/JPEG.jpg");
})

app.listen(3000, function () {
    console.log("Server is running on http://localhost:3000");
});