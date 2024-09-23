// server.js (NodeJS + Express)
const express = require('express');
const app = express();
const port = 3000;

app.get('/api/data', (req, res) => {
    const data = [
        { id: 1, name: "John Doe", age: 30 },
        { id: 2, name: "Jane Smith", age: 25 },
        { id: 3, name: "Jim Brown", age: 40 },
    ];
    res.json(data);
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
