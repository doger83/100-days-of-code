var text = document.getElementById("text");
var x = 0;
var quotes = ["Believe you can and you're halfway there.",
    "Do what you can, with what you have, where you are.",
    "Nobody cares how much you know, until they know how much you care.",
    "Keep your eyes on the stars, and your feet on the ground.",
    "Far and away the best prize that life has to offer is the chance to work hard at work worth doing.",
    "Don't hit at all if it is honorably possible to avoid hitting; but never hit soft!",
    "It is hard to fail, but it is worse never to have tried to succeed.",
    "The government is us; we are the government, you and I."
];
function changeText(x) {
    text.innerHTML = '<p>"' + quotes[x] + '"</p>';
}

var interval = setInterval(function () {
    changeText(x);
    x++;
    if (x == quotes.length) {
        x = 0;
    }
}, 5000);

var events = [
    ["1983", ["Born in a small town called Bretten (district of Karlsruhe in Germany)"]],
    ["1994", ["Begins education at Secondary School Dörverden"]],
    ["2000", ["Graduates from Secondary School Dörverden"]],
    ["2000", ["Begins education at Vocational School Verden"]],
    ["2001", ["Graduates from Vocational School Verden with a degree in civil engineering basics"]],
    ["2000 - 2003", ["Training as a draftsman (architecture). Graduation and additional qualification for AVA."]],
    ["2003 - 2019", ["Work experiance as a draftsman in the field of architecture. Last main focus was on handling the announcement and leading the construction management during the 2 years General-Renovation of the public outdor- and indoor pool in his hometown Bretten"]]
];

function populateTimeline() {
    var timeline = document.getElementById("timeline");
    events.forEach(function (a) {
        var eventString = '';
        eventString += "<div class='item'>";
        eventString += "<div class='date'>" + a[0] + "</div>";
        a[1].forEach(function (b, ind) {
            eventString += "<div class='info'>" + b + "</div>";
        });
        eventString += "</div>";
        timeline.innerHTML += eventString;
    });
}

populateTimeline();