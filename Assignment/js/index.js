tellJoke();


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

function tellJoke(){
axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
.then(function (response){
    var setup = response.data.setup;
    var delivery = response.data.delivery;
    if(typeof setup == 'undefined' || typeof delivery == 'undefined'){
        setup = "One-liner: ";
        delivery = response.data.joke;
    }
    document.getElementById("cardbodySetup").innerHTML = setup;
    setTimeout(function() {document.getElementById("cardbodyDelivery").innerHTML = delivery}, 4000);
})
.catch(function (error) {
    console.log(error);
    document.getElementById("cardbodySetup").innerHTML = "Try again in a few moments."
});
}

