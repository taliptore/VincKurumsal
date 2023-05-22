/*-----------------------------------------------------------------------------------

    Theme Name: Upfront - Transport and Logistics HTML Template
    Description: Transport and Logistics HTML Template
    Author: Website Design Templates
    Version: 2.0

    /* ----------------------------------

    JS Active Code Index
            
        01. Preloader
        02. Sticky Header
        03. Scroll To Top
        04. Parallax
        05. Video
        06. Copy to clipboard
        07. Tab Effect
        08. Resize function
        09. Wow animation - on scroll
        10. FullScreenHeight function
        11. ScreenFixedHeight function
        12. FullScreenHeight and screenHeight with resize function
        13. Sliders
        14. Tabs
        15. Current Year
        16. CountUp
        17. Countdown
        18. Gallery
        19. Stellar
                
    ---------------------------------- */    

(function($) {

    "use strict";

    var $window = $(window);

        /*------------------------------------
            01. Preloader
        --------------------------------------*/

        $('#preloader').fadeOut('normall', function() {
            $(this).remove();
        });

        /*------------------------------------
            02. Sticky Header
        --------------------------------------*/

        $window.on('scroll', function() {
            var scroll = $window.scrollTop();
            var logochange = $(".navbar-brand img");
            var logodefault = $(".navbar-brand.logodefault img");
            if (scroll <= 50) {
                $("header").removeClass("scrollHeader").addClass("fixedHeader");
                logochange.attr('src', '/Template/img/logos/logo.png');
                logodefault.attr('src', '/Template/img/logos/logo.png');
            } 
            else {
                $("header").removeClass("fixedHeader").addClass("scrollHeader");
                logochange.attr('src', '/Template/img/logos/logo.png');
                logodefault.attr('src', '/Template/img/logos/logo.png');
            }
        });

        /*------------------------------------
            03. Scroll To Top
        --------------------------------------*/

        $window.on('scroll', function() {
            if ($(this).scrollTop() > 500) {
                $(".scroll-to-top").fadeIn(400);

            } else {
                $(".scroll-to-top").fadeOut(400);
            }
        });

        $(".scroll-to-top").on('click', function(event) {
            event.preventDefault();
            $("html, body").animate({
                scrollTop: 0
            }, 600);
        });

        /*------------------------------------
            04. Parallax
        --------------------------------------*/

        // sections background image from data background
        var pageSection = $(".parallax,.bg-img");
        pageSection.each(function(indx) {

            if ($(this).attr("data-background")) {
                $(this).css("background-image", "url(" + $(this).data("background") + ")");
            }
        });
        
        /*------------------------------------
            05. Video
        --------------------------------------*/

        $('.story-video').magnificPopup({
            delegate: '.video',
            type: 'iframe'
        });

        $('.popup-social-video').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        });

        $('.source-modal').magnificPopup({
            type: 'inline',
            mainClass: 'mfp-fade',
            removalDelay: 160
        });

        /*------------------------------------
            06. Copy to clipboard
        --------------------------------------*/

        if ($(".copy-clipboard").length !== 0) {
            new ClipboardJS('.copy-clipboard');
            $('.copy-clipboard').on('click', function() {
                var $this = $(this);
                var originalText = $this.text();
                $this.text('Copied');
                setTimeout(function() {
                    $this.text('Copy')
                    }, 2000);
            });
        };

        /*------------------------------------
            07. Tab Effect
        --------------------------------------*/

        //Click on first li element
        $( ".tab1" ).click(function() {
        $( ".second, .third, .four" ).fadeOut();
        $( ".first" ).fadeIn(1000);
        });

        //Click on second li element
        $( ".tab2" ).click(function() {
        $( ".first, .third, .four" ).fadeOut();
        $( ".second" ).fadeIn(1000);
        });

        //Click on third li element
        $( ".tab3" ).click(function() {
        $( ".second, .first, .four" ).fadeOut();
        $( ".third" ).fadeIn(1000);
        });

        //Click on third li element
        $( ".tab4" ).click(function() {
        $( ".first, .second, .third" ).fadeOut();
        $( ".four" ).fadeIn(1000);
        });

        /*------------------------------------
            08. Resize function
        --------------------------------------*/

        $window.resize(function(event) {
            setTimeout(function() {
                SetResizeContent();
            }, 500);
            event.preventDefault();
        });

        /*------------------------------------
            09. Wow animation - on scroll
        --------------------------------------*/
        
        var wow = new WOW({
            boxClass: 'wow', // default
            animateClass: 'animated', // default
            offset: 0, // default
            mobile: false, // default
            live: true // default
        })
        wow.init();

        $(".text-animation").waypoint(function() {
            $('.text-animation.animated').textillate();
        }, { offset: '100%'});

        $('.page-title-section .text-animation').textillate();

        /*------------------------------------
            10. FullScreenHeight function
        --------------------------------------*/

        function fullScreenHeight() {
            var element = $(".full-screen");
            var $minheight = $window.height();
            element.css('min-height', $minheight);
        }

        /*------------------------------------
            11. ScreenFixedHeight function
        --------------------------------------*/

        function ScreenFixedHeight() {
            var $headerHeight = $("header").height();
            var element = $(".screen-height");
            var $screenheight = $window.height() - $headerHeight;
            element.css('height', $screenheight);
        }

        /*------------------------------------
            12. FullScreenHeight and screenHeight with resize function
        --------------------------------------*/        

        function SetResizeContent() {
            fullScreenHeight();
            ScreenFixedHeight();
        }

        SetResizeContent();

    
    // === when document ready === //
    $(document).ready(function() {

        /*------------------------------------
            13. Sliders
        --------------------------------------*/

        // portfolio-carousel
        $('.portfolio-carousel').owlCarousel({
            loop: true,
            responsiveClass: true,
            autoplay: true,
            autoplayTimeout: 3000,
            smartSpeed: 1500,            
            nav: false,
            center: false,
            autoplayHoverPause:true,
            dots: false,
            margin: 30,
            navText: ["<i class='ti-angle-left'></i>", "<i class='ti-angle-right'></i>"],
            responsive: {
                0: {
                    items: 1,
                },
                576: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                1200: {
                    items: 4,
                },
                1400: {
                    items: 5,
                }
            }
        });

        // portfolio2-carousel
        $('.portfolio2-carousel').owlCarousel({
            loop: true,
            responsiveClass: true,
            autoplay: true,
            autoplayTimeout: 3000,
            smartSpeed: 1500,            
            nav: false,
            center: false,
            dots: true,
            margin: 30,
            navText: ["<i class='ti-angle-left'></i>", "<i class='ti-angle-right'></i>"],
            responsive: {
                0: {
                    items: 1,
                    dots: false,
                },
                767: {
                    items: 2,
                },
                992: {
                    items: 3,
                },
                1200: {
                    items: 3,
                }
            }
        });

        // Testmonial2
        $('.testimonial-style2').owlCarousel({
            items: 1,
            loop: true,
            responsiveClass: true,
            nav: false,
            dots: true,
            autoplay: true,
            autoplayTimeout: 5000,
            margin: 0,
            smartSpeed:1500
        });

        // Testmonial2
        $('.testimonial-style3').owlCarousel({
            items: 1,
            loop: true,
            responsiveClass: true,
            nav: false,
            dots: true,
            autoplay: true,
            autoplayTimeout: 5000,
            margin: 0,
            smartSpeed:1500
        });

        // Sliderfade
        $('.slider-fade1').owlCarousel({
            items: 1,
            loop:true,
            dots: true,
            margin: 0,
            nav: false,
            navText: ["<i class='ti-arrow-left'></i>", "<i class='ti-arrow-right'></i>"],
            autoplay: true,
            smartSpeed:1500,
            mouseDrag:false,
            animateIn: 'fadeIn',
            animateOut: 'fadeOut',
            responsive: {
                992: {
                nav: true,
                dots: false
                }
            }
        });
        
        // Default owlCarousel
        $('.owl-carousel').owlCarousel({
            items: 1,
            loop:true,
            dots: false,
            margin: 0,
            autoplay:true,
            smartSpeed:500
        });

        // Slider text animation
        var owl = $('.slider-fade1');
        owl.on('changed.owl.carousel', function(event) {
            var item = event.item.index - 2;     // Position of the current item
            $('.small-title').removeClass('animated fadeInUp');
            $('.title').removeClass('animated fadeInUp');
            $('.butn').removeClass('animated fadeInUp');
            $('.owl-item').not('.cloned').eq(item).find('.small-title').addClass('animated fadeInUp');
            $('.owl-item').not('.cloned').eq(item).find('.title').addClass('animated fadeInUp');
            $('.owl-item').not('.cloned').eq(item).find('.butn').addClass('animated fadeInUp');
        });

        /*------------------------------------
            14. Tabs
        --------------------------------------*/

        //Horizontal Tab
        if ($(".horizontaltab").length !== 0) {
            $('.horizontaltab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                tabidentify: 'hor_1', // The tab groups identifier
                activate: function(event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
        }

        /*------------------------------------
            15. Current Year
        --------------------------------------*/

        $('.current-year').text(new Date().getFullYear());

        /*------------------------------------
            16. CountUp
        --------------------------------------*/

        $('.countup').counterUp({
            delay: 25,
            time: 2000
        });

        /*------------------------------------
            17. Countdown
        --------------------------------------*/

        // CountDown for coming soon page
        $(".countdown").countdown({
            date: "01 Dec 2024 00:01:00", //set your date and time. EX: 15 May 2014 12:00:00
            format: "on"
        });
      
    });
    
    // === when window loading === //
    $window.on("load", function() {

        /*------------------------------------
            18. Gallery
        --------------------------------------*/

        $('.portfolio-gallery').lightGallery();

        $('.portfolio-link').on('click', (e) => {
            e.stopPropagation();
        })        

        /*------------------------------------
            19. Stellar
        --------------------------------------*/

        // stellar
        $window.stellar();

    });

})(jQuery);