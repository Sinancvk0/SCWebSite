/*
Template Name: Minible - Admin & Dashboard Template
Author: Themesbrand
Version: 2.4.0
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Main Js File
*/


(function ($) {

    'use strict';

    function initMetisMenu() {
        //metis menu
        $("#side-menu").metisMenu();
    }

    function initLeftMenuCollapse() {
        var currentSIdebarSize = document.body.getAttribute('data-sidebar-size');
        $(window).on('load', function () {

            $('.switch').on('switch-change', function () {
                toggleWeather();
            });

            if (window.innerWidth >= 1024 && window.innerWidth <= 1366) {
                document.body.setAttribute('data-sidebar-size', 'sm');
                updateRadio('sidebar-size-small')
            }
        });

        $('.vertical-menu-btn').on('click', function (event) {
            event.preventDefault();
            $('body').toggleClass('sidebar-enable');
            if ($(window).width() >= 992) {
                if (currentSIdebarSize == null) {
                    (document.body.getAttribute('data-sidebar-size') == null || document.body.getAttribute('data-sidebar-size') == "lg") ? document.body.setAttribute('data-sidebar-size', 'sm'): document.body.setAttribute('data-sidebar-size', 'lg')
                } else if (currentSIdebarSize == "md") {
                    (document.body.getAttribute('data-sidebar-size') == "md") ? document.body.setAttribute('data-sidebar-size', 'sm'): document.body.setAttribute('data-sidebar-size', 'md')
                } else {
                    (document.body.getAttribute('data-sidebar-size') == "sm") ? document.body.setAttribute('data-sidebar-size', 'lg'): document.body.setAttribute('data-sidebar-size', 'sm')
                }
            }
        });
    }

    function initActiveMenu() {
        // === following js will activate the menu in left side bar based on url ====
        $("#sidebar-menu a").each(function () {
            var pageUrl = window.location.href.split(/[?#]/)[0];
            if (this.href == pageUrl) {
                $(this).addClass("active");
                $(this).parent().addClass("mm-active"); // add active to li of the current link
                $(this).parent().parent().addClass("mm-show");
                $(this).parent().parent().prev().addClass("mm-active"); // add active class to an anchor
                $(this).parent().parent().parent().addClass("mm-active");
                $(this).parent().parent().parent().parent().addClass("mm-show"); // add active to li of the current link
                $(this).parent().parent().parent().parent().parent().addClass("mm-active");
            }
        });
    }

    function initMenuItemScroll() {
        // focus active menu in left sidebar
        $(document).ready(function () {
            if ($("#sidebar-menu").length > 0 && $("#sidebar-menu .mm-active .active").length > 0) {
                var activeMenu = $("#sidebar-menu .mm-active .active").offset().top;
                if (activeMenu > 300) {
                    activeMenu = activeMenu - 300;
                    $(".vertical-menu .simplebar-content-wrapper").animate({ scrollTop: activeMenu }, "slow");
                }
            }
        });
    }

    function initHoriMenuActive() {
        $(".navbar-nav a").each(function () {
            var pageUrl = window.location.href.split(/[?#]/)[0];
            if (this.href == pageUrl) {
                $(this).addClass("active");
                $(this).parent().addClass("active");
                $(this).parent().parent().addClass("active");
                $(this).parent().parent().parent().addClass("active");
                $(this).parent().parent().parent().parent().addClass("active");
                $(this).parent().parent().parent().parent().parent().addClass("active");
            }
        });
    }

    function initFullScreen() {
        $('[data-bs-toggle="fullscreen"]').on("click", function (e) {
            e.preventDefault();
            $('body').toggleClass('fullscreen-enable');
            if (!document.fullscreenElement && /* alternative standard method */ !document.mozFullScreenElement && !document.webkitFullscreenElement) {  // current working methods
                if (document.documentElement.requestFullscreen) {
                    document.documentElement.requestFullscreen();
                } else if (document.documentElement.mozRequestFullScreen) {
                    document.documentElement.mozRequestFullScreen();
                } else if (document.documentElement.webkitRequestFullscreen) {
                    document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
                }
            } else {
                if (document.cancelFullScreen) {
                    document.cancelFullScreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitCancelFullScreen) {
                    document.webkitCancelFullScreen();
                }
            }
        });
        document.addEventListener('fullscreenchange', exitHandler);
        document.addEventListener("webkitfullscreenchange", exitHandler);
        document.addEventListener("mozfullscreenchange", exitHandler);
        function exitHandler() {
            if (!document.webkitIsFullScreen && !document.mozFullScreen && !document.msFullscreenElement) {
                console.log('pressed');
                $('body').removeClass('fullscreen-enable');
            }
        }
    }

    function initRightSidebar() {
        // right side-bar toggle
        $('.right-bar-toggle').on('click', function (e) {
            $('body').toggleClass('right-bar-enabled');
        });

        $(document).on('click', 'body', function (e) {
            if ($(e.target).closest('.right-bar-toggle, .right-bar').length > 0) {
                return;
            }

            $('body').removeClass('right-bar-enabled');
            return;
        });
    }

    function initDropdownMenu() {
        if(document.getElementById("topnav-menu-content")){
            var elements = document.getElementById("topnav-menu-content").getElementsByTagName("a");
            for(var i = 0, len = elements.length; i < len; i++) {
                elements[i].onclick = function (elem) {
                    if(elem.target.getAttribute("href") === "#") {
                        elem.target.parentElement.classList.toggle("active");
                        elem.target.nextElementSibling.classList.toggle("show");
                    }
                }
            }
            window.addEventListener("resize", updateMenu);
        }
    }

    function updateMenu() {
        var elements = document.getElementById("topnav-menu-content").getElementsByTagName("a");
        for(var i = 0, len = elements.length; i < len; i++) {
            if(elements[i].parentElement.getAttribute("class") === "nav-item dropdown active") {
                elements[i].parentElement.classList.remove("active");
                elements[i].nextElementSibling.classList.remove("show");
            }
        }
    }

    function initComponents() {
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        });

        var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
        var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
            return new bootstrap.Popover(popoverTriggerEl)
        });

        // Counter Up
        var delay = $(this).attr('data-delay') ? $(this).attr('data-delay') : 100; //default is 100
        var time = $(this).attr('data-time') ? $(this).attr('data-time') : 1200; //default is 1200
        $('[data-plugin="counterup"]').each(function (idx, obj) {
            $(this).counterUp({
                delay: delay,
                time: time
            });
        });
    }

    function initPreloader() {
        $(window).on('load', function () {
            $('#status').fadeOut();
            $('#preloader').delay(350).fadeOut('slow');
        });
    }



    function initSettings() {
        if (window.sessionStorage) {
            var alreadyVisited = sessionStorage.getItem("is_visited");
            if (!alreadyVisited) {
                sessionStorage.setItem("is_visited", "layout-ltr");
            } else {
                $("#" + alreadyVisited).prop('checked', true);
                // changeDirection(alreadyVisited);
            }
        }
    }

    function updateRadio(radioId) {
        document.getElementById(radioId).checked = true;
    }

    function layoutSetting(id) {
        var body = document.getElementsByTagName("body")[0];

        $('#mode-setting-btn').on('click', function (e) {
            if(body.hasAttribute("data-layout-mode") && body.getAttribute("data-layout-mode") == "dark") {
                document.body.setAttribute('data-layout-mode', 'light');
                document.body.setAttribute('data-topbar', 'light');
                document.body.setAttribute('data-sidebar', 'light');
                (body.hasAttribute("data-layout") && body.getAttribute("data-layout") == "horizontal") ? '' : document.body.setAttribute('data-sidebar', 'light');
                updateRadio('topbar-color-light')
                updateRadio('sidebar-color-light')
                updateRadio('topbar-color-light')
            } else {
                document.body.setAttribute('data-layout-mode', 'dark');
                document.body.setAttribute('data-topbar', 'dark');
                document.body.setAttribute('data-sidebar', 'dark');
                (body.hasAttribute("data-layout") && body.getAttribute("data-layout") == "horizontal") ? '' : document.body.setAttribute('data-sidebar', 'dark');
                updateRadio('layout-mode-dark')
                updateRadio('sidebar-color-dark')
                updateRadio('topbar-color-dark')
            }
        });

        $(document).on('click', 'body', function (e) {
            if ($(e.target).closest('.right-bar-toggle, .right-bar').length > 0) {
                return;
            }
            $('body').removeClass('right-bar-enabled');
            return;
        });

        if(body.hasAttribute("data-layout") && body.getAttribute("data-layout") == "horizontal") {
            updateRadio('layout-horizontal');
            $(".sidebar-setting").hide();
        } else {
            updateRadio('layout-vertical');
        }
        (body.hasAttribute("data-layout-mode") && body.getAttribute("data-layout-mode") == "dark") ? updateRadio('layout-mode-dark'): updateRadio('layout-mode-light');
        (body.hasAttribute("data-layout-size") && body.getAttribute("data-layout-size") == "boxed") ? updateRadio('layout-width-boxed'): updateRadio('layout-width-fuild');
        (body.hasAttribute("data-topbar") && body.getAttribute("data-topbar") == "dark") ? updateRadio('topbar-color-dark'): updateRadio('topbar-color-light');
        (body.hasAttribute("data-sidebar-size") && body.getAttribute("data-sidebar-size") == "sm") ? updateRadio('sidebar-size-small') : (body.hasAttribute("data-sidebar-size") && body.getAttribute("data-sidebar-size") == "md") ? updateRadio('sidebar-size-compact') : updateRadio('sidebar-size-default');
        (body.hasAttribute("data-sidebar") && body.getAttribute("data-sidebar") == "colored") ? updateRadio('sidebar-color-colored') : (body.hasAttribute("data-sidebar") && body.getAttribute("data-sidebar") == "dark") ? updateRadio('sidebar-color-dark') : updateRadio('sidebar-color-light');
        (document.getElementsByTagName("html")[0].hasAttribute("dir") && document.getElementsByTagName("html")[0].getAttribute("dir") == "rtl") ? updateRadio('layout-direction-rtl'): updateRadio('layout-direction-ltr');

        // on layou change
        $("input[name='layout']").on('change', function () {
            window.location.href = ($(this).val() == "vertical") ? "index.html": "layouts-horizontal.html";
        });
        
        // on layout mode change
        $("input[name='layout-mode']").on('change', function () {
            if($(this).val() == "light") {
                document.body.setAttribute('data-layout-mode', 'light');
                document.body.setAttribute('data-topbar', 'light');
                document.body.setAttribute('data-sidebar', 'light');
                (body.hasAttribute("data-layout") && body.getAttribute("data-layout") == "horizontal") ? '' : document.body.setAttribute('data-sidebar', 'light');
                updateRadio('topbar-color-light')
                updateRadio('sidebar-color-light')
            } else {
                document.body.setAttribute('data-layout-mode', 'dark');
                document.body.setAttribute('data-topbar', 'dark');
                document.body.setAttribute('data-sidebar', 'dark');
                (body.hasAttribute("data-layout") && body.getAttribute("data-layout") == "horizontal") ? '' : document.body.setAttribute('data-sidebar', 'dark');
                updateRadio('topbar-color-dark')
                updateRadio('sidebar-color-dark')
            }
        });

        // on RTL-LTR mode change
        $("input[name='layout-direction']").on('change', function () {
            if($(this).val() == "ltr") {
                document.getElementsByTagName("html")[0].removeAttribute("dir");
                document.getElementById('bootstrap-style').setAttribute('href', 'assets/css/bootstrap.min.css');
                document.getElementById('app-style').setAttribute('href', 'assets/css/app.min.css');
            } else {
                document.getElementById('bootstrap-style').setAttribute('href', 'assets/css/bootstrap-rtl.min.css');
                document.getElementById('app-style').setAttribute('href', 'assets/css/app-rtl.min.css');
                document.getElementsByTagName("html")[0].setAttribute("dir", "rtl");
            }
        });
    }

    function init() {
        initMetisMenu();
        initLeftMenuCollapse();
        initActiveMenu();
        initMenuItemScroll();
        initFullScreen();
        initHoriMenuActive();
        initRightSidebar();
        initDropdownMenu();
        initComponents();
        initSettings();
        initPreloader();
        layoutSetting();
        Waves.init();
    }

    init();

})(jQuery)
