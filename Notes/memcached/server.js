// server.js (NodeJS + MemCached)
const Memcached = require('memcached');
const express = require('express');
const app = express();
const memcached = new Memcached('localhost:11211');
const port = 3000;

app.get('/api/data', (req, res) => {
    memcached.get('myData', (err, data) => {
        if (data) {
            return res.json(JSON.parse(data));
        } else {
            const newData = [
                { id: 1, name: "John Doe", age: 30 },
                { id: 2, name: "Jane Smith", age: 25 },
                { id: 3, name: "Jim Brown", age: 40 },
            ];

            memcached.set('myData', JSON.stringify(newData), 3600, (err) => {
                if (err) throw err;
                return res.json(newData);
            });
        }
    });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
