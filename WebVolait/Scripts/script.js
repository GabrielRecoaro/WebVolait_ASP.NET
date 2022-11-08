class NavigationMenu {
    constructor(mobileMenu, navMenu, navItems) {
        this.mobileMenu = document.querySelector(mobileMenu);
        this.navMenu = document.querySelector(navMenu);
        this.navItems = document.querySelectorAll(navItems);

        this.activeClass = "active";
        this.overflowY = true;
        this.handleClick = this.handleClick.bind(this);
    }
    disableOverflowY() {
        document.body.style.overflowY = this.overflowY ? "hidden" : "visible";
        this.overflowY = !this.overflowY;
    }
    animateLinks() {
        this.navItems.forEach((item, index) => {
            item.style.animation
                ? (item.style.animation = "")
                : (item.style.animation = `navItemFade 0.5s ease forwards ${index / 7 + 0.3}s`);
        });
    }
    showNavMenu() {
        this.navMenu.classList.toggle(this.activeClass);
        if (this.navMenu.classList.contains("active")) {
            this.navMenu.style.maxHeight = this.navMenu.scrollHeight + "px";
        } else {
            this.navMenu.style.maxHeight = 0;
        }
    }
    handleClick() {
        this.mobileMenu.classList.toggle(this.activeClass);
        this.showNavMenu();
        this.disableOverflowY();
        this.animateLinks();
    }
    addClickEvent() {
        this.mobileMenu.addEventListener("click", this.handleClick);
    }
    init() {
        if (this.mobileMenu) {
            this.addClickEvent();
        }
        return this;
    }
}
const navigationMenu = new NavigationMenu(
    ".header__navbar__mobile-menu",
    ".header__navbar__navigation-menu",
    ".header__navbar__navigation-menu__list__item"
);

navigationMenu.init();

// Hide Header and Header Shadow
let scrollPage = window.pageYOffset;
let header = document.querySelector(".header");

if (header) {
    window.addEventListener("scroll", () => {
        let lastScrollPage = window.pageYOffset;
        if (scrollPage > lastScrollPage) {
            header.style.top = "0";
            if (lastScrollPage > 0) {
                header.classList.add("header--shadow");
            } else {
                header.classList.remove("header--shadow");
            }
        } else {
            hideHeader = (window.innerHeight) / 8;
            header.style.top = `-${hideHeader}px`;
        }
        scrollPage = lastScrollPage;
    });
}
