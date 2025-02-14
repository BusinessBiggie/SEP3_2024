function initializeHamburgerMenu() {
    const hamburgerMenu = document.querySelector('#hamburger-menu');
    const navActions = document.querySelector('#nav-actions');
    const closeHamburger = document.querySelector('.close-hamburger');

    if (!hamburgerMenu || !navActions) {
        console.error('Hamburger menu or navigation actions not found!');
        return;
    }

    // Toggle menu visibility
    hamburgerMenu.addEventListener('click', () => {
        hamburgerMenu.classList.toggle('active');
        navActions.classList.toggle('active');
    });

    // Close menu when clicking the close button
    if (closeHamburger) {
        closeHamburger.addEventListener('click', () => {
            navActions.classList.remove('active');
            hamburgerMenu.classList.remove('active');
        });
    }

    // Close menu when clicking outside
    document.addEventListener('click', (event) => {
        if (!hamburgerMenu.contains(event.target) && !navActions.contains(event.target)) {
            navActions.classList.remove('active');
            hamburgerMenu.classList.remove('active');
        }
    });
}

document.addEventListener('DOMContentLoaded', initializeHamburgerMenu);
