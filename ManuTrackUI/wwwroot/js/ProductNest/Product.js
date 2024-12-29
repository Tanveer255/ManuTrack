$(document).ready(function () {
    // Your code here
    console.log("Hello World!");
});
function getAllProduct() {
    // Define the API URL
    const apiUrl = 'https://localhost:7067/Product';

    // Make a GET request
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            debugger;
            console.log(data); // Handle the response data
        })
        .catch(error => {
            console.error('Error:', error); // Handle any errors
        });
}

