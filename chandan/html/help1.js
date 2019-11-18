function back() {
    var sub = document.cal.screen.value;
    document.cal.screen.value = sub.substring(0, sub.length - 1);
}

function square() {
    var double = document.cal.screen.value;
    document.cal.screen.value = Math.pow(double, 2);
}

function perc() {
    var percentage = document.cal.screen.value;
    document.cal.screen.value = percentage / 100;
}