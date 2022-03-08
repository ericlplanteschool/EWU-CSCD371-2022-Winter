axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
.then(function (response){
    console.log(response.data.setup);
    setTimeout(function() {console.log(response.data.delivery)}, 4000);
})
.catch(function (error) {
    console.log(error);
});

