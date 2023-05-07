// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function countdown(launch_date, id) {
    launch_date = new Date(launch_date.toString());

    setInterval(function () {
        time_to_launch = launch_date - new Date();

        days = Math.floor(time_to_launch / (1000 * 60 * 60 * 24));
        hours = Math.floor((time_to_launch % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        minutes = Math.floor((time_to_launch % (1000 * 60 * 60)) / (1000 * 60));
        seconds = Math.floor((time_to_launch % (1000 * 60)) / 1000);

        hours = hours < 10 ? "0" + hours : hours;
        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        document.getElementById(id).innerHTML =
            "T- " + days + ":" + hours + ":" + minutes + ":" + seconds + " UTC";
    }, 1000);
}   


