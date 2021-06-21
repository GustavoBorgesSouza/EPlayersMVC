// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function botaoDoMenu() {
    var menu = document.getElementById("links");
    if (menu.style.display === "flex") {
        menu.style.display = "none"
        // esconder menu
    } else{
        menu.style.display = "flex"
        // mostre menu
    }
}