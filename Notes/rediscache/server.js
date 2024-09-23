// server.js (NodeJS + Redis)
const express = require('express');
const redis = require('redis');
const app = express();
const client = redis.createClient();
const port = 3000;

client.on('error', (err) => {
    console.log("Error " + err);
});

app.get('/api/data', (req, res) => {
    client.get('myData', (err, data) => {
        if (data) {
            return res.json(JSON.parse(data));
        } else {
            const newData = [
                { id: 1, name: "John Doe", age: 30 },
                { id: 2, name: "Jane Smith", age: 25 },
                { id: 3, name: "Jim Brown", age: 40 },
            ];

            client.setex('myData', 3600, JSON.stringify(newData));
            return res.json(newData);
        }
    });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
