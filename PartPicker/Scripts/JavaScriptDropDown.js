 var dropdown = document.getElementsByClassName("dropdown-btn");
    var i;
/* Dodanie event listenera dla każdego z przycisków filtrowania */
    for (i = 0; i < dropdown.length; i++) {
        dropdown[i].addEventListener("click", function () {
            var dropdownContent = this.nextElementSibling;
            if (dropdownContent.style.display === "block") {
                dropdownContent.style.display = "none";
            } else {
                dropdownContent.style.display = "block";
            }
        });
}

