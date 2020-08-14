function SetActiveNavItem(old, active) {
    var oldBtn = document.getElementById(old);
    var newBtn = document.getElementById(active);
    oldBtn.className = "nav-link";
    newBtn.className = "nav-link active";
}
function Scroll() {
    var prevScrollPos = window.pageYOffset;
    window.onscroll = function () {
        var currentScrollPos = window.pageYOffset;
        if (prevScrollPos < currentScrollPos) {
            document.getElementById("BottomBar").style.height  = "2rem"
        }
        else {
            document.getElementById("BottomBar").style.height = "15rem";
        }
    }

}
function ToggleModal() {
    $('#modal').modal({
        show: 'true'
    }); 
}