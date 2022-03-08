
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
  }
  
window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
            openDropdown.classList.remove('show');
        }
        }
    }
}

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

