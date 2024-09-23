// App.js (ReactJS)
import React, { useState, useEffect } from 'react';
import $ from 'jquery'; // jQuery import

function App() {
    const [data, setData] = useState([]);

    useEffect(() => {
        // Sử dụng AJAX để gọi API
        $.ajax({
            url: "http://localhost:3000/api/data",
            method: "GET",
            success: function(response) {
                setData(response);
            },
            error: function(err) {
                console.error(err);
            }
        });
    }, []);

    return (
        <div>
            <h1>Danh sách người dùng</h1>
            <ul>
                {data.map(user => (
                    <li key={user.id}>{user.name} - {user.age} tuổi</li>
                ))}
            </ul>
        </div>
    );
}

export default App;
