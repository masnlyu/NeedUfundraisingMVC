function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
if (window.location.pathname == "/cms/login.html" && getCookie("employeeId") != '') {
    window.location = "./index.html"
} else if (window.location.pathname != "/cms/login.html" && getCookie("employeeId") == '') {
    window.location = "./login.html"
}
