$('.owl-carousel-family').owlCarousel({
    loop: true,
    margin: 15,
    dots: false,
    nav: false,
    center: false,
    autoplay: true,
    stagePadding: 5,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 2.5,
            margin: 10,
            autoplay: true,
        },
        1200: {
            items: 6.5,
            nav: false,
            loop: true,
            autoplay: true,
            margin: 30,
        }
        ,
        1700: {
            items:10,
            margin: 38,
            autoplay: false,
        }
    },
});
$('.owl-carousel-team').owlCarousel({
    loop: true,
    margin: 15,
    dots: false,
    nav: false,
    center: false,
    autoplay: true,
    stagePadding: 5,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1.2,
            margin: 10,
            autoplay: true,
        },
        1200: {
            items: 3.5,
            nav: false,
            loop: true,
            autoplay: true,
            margin: 30,
        }
        ,
        1700: {
            items: 5,
            margin: 70,
            autoplay: false,
        }
    },
});
$('.owl-carousel-student-review').owlCarousel({
    loop: true,
    margin: 15,
    dots: true,
    nav: false,
    center: false,
    autoplay: true,
    stagePadding: 5,
    autoplayTimeout: 10000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items:1,
            margin: 10,
            autoplay: true,
        },
        1200: {
            items: 1,
            nav: false,
            loop: true,
            autoplay: true,
            margin: 30,
        }
        ,
        1700: {
            items: 1,
            autoplay: true,
            margin: 40
        }
    },
});
$('.owl-carousel-images').owlCarousel({
    loop: true,
    margin: 15,
    dots: true,
    nav: false,
    center: false,
    autoplay: true,
    stagePadding: 5,
    autoplayTimeout: 10000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1.5,
            margin: 10,
            autoplay: true,
        },
        1200: {
            items: 2.5,
            nav: false,
            loop: true,
            autoplay: true,
            margin: 30,
        }
        ,
        1700: {
            items: 3.5,
            autoplay: false,
            margin: 46
        }
    },
});