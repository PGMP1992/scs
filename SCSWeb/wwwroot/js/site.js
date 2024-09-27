// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Used on Search/IndexView  - PM
onclick shows selected tab */
function openTab(evt, company) {
    var i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("active", "");
    }

    document.getElementById(company).style.display = "inline";
    evt.currentTarget.className += " active";
}

/* Used on Search/IndexView - PM
Get the element with id="defaultOpen" above and click on it */
function clickTab() {

    document.getElementById("defaultOpen").click();
    var tabcontent = document.getElementsByClassName("tabcontent");

    for (var i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    } let slideIndex = 0;
    showSlides();
}
