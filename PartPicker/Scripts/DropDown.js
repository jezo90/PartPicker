﻿
function dropdownNav() {
    var x = document.getElementById("top-nav");
    if (x.className === "top-nav") {
        x.className += " responsive";
    } else {
        x.className = "top-nav";


        var x = document.getElementById("image_up");
        if (x.className === "image_up") {
        } else {
            x.className = "image_up";
            var x = document.getElementById("image_down");
            x.className = "image_down";
        }

       
    }

    var x = document.getElementById("plus");
    if (x.className === "plus") {
        x.className += " hide";
    } else {
        x.className = "plus";
    }

    var x = document.getElementById("minus");
    if (x.className === "minus") {
        x.className += " show";
    } else {
        x.className = "minus";
    }
}








function drop() {
    document.getElementById("myDropdown").classList.toggle("show");


    var x = document.getElementById("image_down");
    if (x.className === "image_down") {
        x.className += " hide";
    } else {
        x.className = "image_down";
    }

    var x = document.getElementById("image_up");
    if (x.className === "image_up") {
        x.className += " show";
    } else {
        x.className = "image_up";
    }

    var x = document.getElementById("dropbtn");
    if (x.className === "dropbtn") {
        x.className += " orange";
    } else {
        x.className = "dropbtn";
    }

}

// Close the dropdown if the user clicks outside of it
window.onclick = function (e) {

    if (!e.target.matches('.dropbtn')) {
        var myDropdown = document.getElementById("myDropdown");
        if (myDropdown.classList.contains('show')) {
            myDropdown.classList.remove('show');
            
        }

        var x = document.getElementById("dropbtn");
        if (x.className === "dropbtn") {
           
        } else {
            x.className = "dropbtn";
        }


    }

}