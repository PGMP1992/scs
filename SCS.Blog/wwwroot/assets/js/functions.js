document.addEventListener("DOMContentLoaded", _ => {
    const topNav = document.getElementsByClassName("topnav")[0];
    if (topNav) {
        window.onscroll = () => {
            if (window.scrollY > 50) {
                // add classes scrollednav py-0
                topNav.classList.add('scrollednav', 'py-0')
            }
            else {
                //remove classes srollednav py-0
                topNav.classList.remove('scrollednav', 'py-0')

            }
        };
    }
});

function toggleMenu(e) {
    e.target.classList.toggle('collapsed');
    const navbarWrapper = document.getElementById('topmenu');
    navbarWrapper.classList.toggle('show');
}
