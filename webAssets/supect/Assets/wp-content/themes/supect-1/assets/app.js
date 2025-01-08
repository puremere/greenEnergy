(() => {
    var e = {
        651: (e, t, a) => {
            var n, s;
            (n = [a(311)]),
                void 0 ===
                (s = function (e) {
                    return (function (e) {
                        e.easing.jswing = e.easing.swing;
                        var t = Math.pow,
                            a = Math.sqrt,
                            n = Math.sin,
                            s = Math.cos,
                            o = Math.PI,
                            i = 1.70158,
                            r = 1.525 * i,
                            l = i + 1,
                            c = (2 * o) / 3,
                            d = (2 * o) / 4.5;
                        function u(e) {
                            var t = 7.5625,
                                a = 2.75;
                            return e < 1 / a ? t * e * e : e < 2 / a ? t * (e -= 1.5 / a) * e + 0.75 : e < 2.5 / a ? t * (e -= 2.25 / a) * e + 0.9375 : t * (e -= 2.625 / a) * e + 0.984375;
                        }
                        e.extend(e.easing, {
                            def: "easeOutQuad",
                            swing: function (t) {
                                return e.easing[e.easing.def](t);
                            },
                            easeInQuad: function (e) {
                                return e * e;
                            },
                            easeOutQuad: function (e) {
                                return 1 - (1 - e) * (1 - e);
                            },
                            easeInOutQuad: function (e) {
                                return e < 0.5 ? 2 * e * e : 1 - t(-2 * e + 2, 2) / 2;
                            },
                            easeInCubic: function (e) {
                                return e * e * e;
                            },
                            easeOutCubic: function (e) {
                                return 1 - t(1 - e, 3);
                            },
                            easeInOutCubic: function (e) {
                                return e < 0.5 ? 4 * e * e * e : 1 - t(-2 * e + 2, 3) / 2;
                            },
                            easeInQuart: function (e) {
                                return e * e * e * e;
                            },
                            easeOutQuart: function (e) {
                                return 1 - t(1 - e, 4);
                            },
                            easeInOutQuart: function (e) {
                                return e < 0.5 ? 8 * e * e * e * e : 1 - t(-2 * e + 2, 4) / 2;
                            },
                            easeInQuint: function (e) {
                                return e * e * e * e * e;
                            },
                            easeOutQuint: function (e) {
                                return 1 - t(1 - e, 5);
                            },
                            easeInOutQuint: function (e) {
                                return e < 0.5 ? 16 * e * e * e * e * e : 1 - t(-2 * e + 2, 5) / 2;
                            },
                            easeInSine: function (e) {
                                return 1 - s((e * o) / 2);
                            },
                            easeOutSine: function (e) {
                                return n((e * o) / 2);
                            },
                            easeInOutSine: function (e) {
                                return -(s(o * e) - 1) / 2;
                            },
                            easeInExpo: function (e) {
                                return 0 === e ? 0 : t(2, 10 * e - 10);
                            },
                            easeOutExpo: function (e) {
                                return 1 === e ? 1 : 1 - t(2, -10 * e);
                            },
                            easeInOutExpo: function (e) {
                                return 0 === e ? 0 : 1 === e ? 1 : e < 0.5 ? t(2, 20 * e - 10) / 2 : (2 - t(2, -20 * e + 10)) / 2;
                            },
                            easeInCirc: function (e) {
                                return 1 - a(1 - t(e, 2));
                            },
                            easeOutCirc: function (e) {
                                return a(1 - t(e - 1, 2));
                            },
                            easeInOutCirc: function (e) {
                                return e < 0.5 ? (1 - a(1 - t(2 * e, 2))) / 2 : (a(1 - t(-2 * e + 2, 2)) + 1) / 2;
                            },
                            easeInElastic: function (e) {
                                return 0 === e ? 0 : 1 === e ? 1 : -t(2, 10 * e - 10) * n((10 * e - 10.75) * c);
                            },
                            easeOutElastic: function (e) {
                                return 0 === e ? 0 : 1 === e ? 1 : t(2, -10 * e) * n((10 * e - 0.75) * c) + 1;
                            },
                            easeInOutElastic: function (e) {
                                return 0 === e ? 0 : 1 === e ? 1 : e < 0.5 ? (-t(2, 20 * e - 10) * n((20 * e - 11.125) * d)) / 2 : (t(2, -20 * e + 10) * n((20 * e - 11.125) * d)) / 2 + 1;
                            },
                            easeInBack: function (e) {
                                return l * e * e * e - i * e * e;
                            },
                            easeOutBack: function (e) {
                                return 1 + l * t(e - 1, 3) + i * t(e - 1, 2);
                            },
                            easeInOutBack: function (e) {
                                return e < 0.5 ? (t(2 * e, 2) * (2 * (r + 1) * e - r)) / 2 : (t(2 * e - 2, 2) * ((r + 1) * (2 * e - 2) + r) + 2) / 2;
                            },
                            easeInBounce: function (e) {
                                return 1 - u(1 - e);
                            },
                            easeOutBounce: u,
                            easeInOutBounce: function (e) {
                                return e < 0.5 ? (1 - u(1 - 2 * e)) / 2 : (1 + u(2 * e - 1)) / 2;
                            },
                        });
                    })(e);
                }.apply(t, n)) || (e.exports = s);
        },
        311: (e) => {
            "use strict";
            e.exports = jQuery;
        },
    },
        t = {};
    function a(n) {
        var s = t[n];
        if (void 0 !== s) return s.exports;
        var o = (t[n] = { exports: {} });
        return e[n](o, o.exports, a), o.exports;
    }
    (() => {
        "use strict";
        a(651);
        var e = a(311);
        function t(e) {
            return null == e || ("object" == typeof e && 0 === Object.keys(e).length) || ("string" == typeof e && 0 === e.trim().length);
        }
        function n(a, n, s = null, o = null) {
            const i = n.find(".kt-form-errors");
            o = o || ("object" == typeof a && a.success ? "success" : "error");
            const r = e('<div class="kt-form-errors-inner ' + o + '"></div>');
            if ((n.find(".field-error").remove(), n.find("input.is-invalid, select.is-invalid, textarea.is-invalid").removeClass("is-invalid"), "string" == typeof a)) r.append(e("<div>" + a + "</div>"));
            else if (!t(a))
                if (a.success) r.append(e("<div>" + a.success + "</div>"));
                else if (!t(a.errors)) {
                    let s = a.errors;
                    Array.isArray(a.errors) ||
                        ((s = []),
                            Object.keys(a.errors).forEach(function (t) {
                                const o = n.find(`[name="${t}"], #${t}`),
                                    i = a.errors[t];
                                o.length ? (o.addClass("is-invalid"), e('<span class="field-error">' + i + "</span>").insertAfter(o)) : s.push(i);
                            })),
                        t(s) ||
                        s.forEach(function (t) {
                            r.append(e("<div>" + t + "</div>"));
                        });
                }
            i.length && (i.empty(), r.children().length && i.append(r)), "function" == typeof s && s();
        }
        function s(t) {
            const a = e("<input class='button-copy-field' value='" + t + "'>");
            e("body").append(a), a.trigger("select"), document.execCommand("copy"), a.remove();
        }
        function o(e, t) {
            const a = new Date();
            a.setTime(a.getTime() + 46656e7), (document.cookie = e + "=" + t + "; expires=" + a.toUTCString() + ";path=/");
        }
        function i(e) {
            const t = e.closest(".kt-modal-inner").attr("data-options");
            return t ? JSON.parse(t) : null;
        }
        function r(e, t, a = null, n = null) {
            if (!e.length || !t) return;
            clearInterval(e.data("timer") || 0), --t;
            const s = function (e, t) {
                let a = Math.floor(e / 60),
                    n = parseInt(e % 60);
                a < 10 && (a = "0" + a), n < 10 && (n = "0" + n);
                const s = a + ":" + n;
                return t ? t.replace("%timer%", s) : s;
            };
            e.text(s(t, a)),
                --t,
                e.data(
                    "timer",
                    setInterval(function () {
                        e.text(s(t, a)), --t < 0 && (clearInterval(e.data("timer")), "function" == typeof n && n());
                    }, 1e3)
                );
        }
        function l(e, t, a, n = "timeout") {
            !(function (e, t = "timeout") {
                clearTimeout(e.data(t) || null);
            })(e, n),
                e.data("timeout", setTimeout(t, a));
        }
        var c = a(311);
        function d(e, t) {
            t(!0);
        }
        var u = a(311);
        function p() {
            u(".kt-social-twitter-posts-holder").length && u(".kt-social-twitter-posts-holder").css("height", u(".kt-social-blog-posts-inner").outerHeight());
        }
        function h() {
            if (u(".scroll-progress-bar").length) {
                const e = u(".blog-single-content-holder").outerHeight() + u(".blog-single-top-holder").offset().top + u(".blog-single-top-holder").outerHeight() - 1.38 * u(window).outerHeight() + (u("body").hasClass("admin-bar") ? 32 : 0);
                let t = ((u(window).scrollTop() - u(".blog-single-top-holder").offset().top + 0.12 * u(window).outerHeight()) / e) * 100;
                t > 100 && (t = 100), t < 0 && (t = 0), u(".scroll-progress-bar").css("width", t + "%");
            }
        }
        function f() {
            if (u(".blog-page-note, .blog-cat-box").length) {
                const e = u(".kt-col-md-8 .blog-item-holder").outerHeight();
                u(".blog-page-note, .blog-cat-box").css("height", e + "px"),
                    u(".masonry-item.kt-col-md-8").css("height", e + 30 + "px"),
                    u(".blog-note-text").length && u(".blog-note-text").css("max-height", 36 * Math.floor((e - 300) / 36) + "px");
            }
        }
        function m() {
            if (u(".kt-modal-inner").length) {
                const e = 0.95 * u(window).outerHeight();
                u(".kt-modal-inner").css("max-height", e);
            }
        }
        function g() {
            u(".kt-lazyload").each(function () {
                u(this).hasClass("loaded") ||
                    u(this).hasClass("loading") ||
                    u(this).attr(
                        "src",
                        "data:image/svg+xml;utf8," + encodeURIComponent('<svg xmlns="http://www.w3.org/2000/svg" width="' + (parseInt(u(this).attr("width")) || 0) + '" height="' + (parseInt(u(this).attr("height")) || 0) + '"></svg>')
                    );
            });
        }
        function v(e) {
            const a = parseInt(e.val());
            a > 0
                ? (e.next(".price-format-text").length || u('<span class="price-format-text"></span>').insertAfter(e),
                    e.next(".price-format-text").text(
                        "str" === e.attr("data-format")
                            ? (function (e) {
                                const a = [];
                                (e = e
                                    .toString()
                                    .replace(/[۰-۹]/g, (e) => e.charCodeAt(0) - "۰".charCodeAt(0))
                                    .replace(/[٠-٩]/g, (e) => e.charCodeAt(0) - "٠".charCodeAt(0))),
                                    (e = parseInt(e));
                                const n = [
                                    { value: Math.pow(10, 12), label: "تریلیون" },
                                    { value: Math.pow(10, 9), label: "میلیارد" },
                                    { value: Math.pow(10, 6), label: "میلیون" },
                                    { value: Math.pow(10, 3), label: "هزار" },
                                ];
                                if (e.toString().length <= 15) {
                                    for (const t of n)
                                        if (e >= t.value) {
                                            const n = Math.floor(e / t.value);
                                            a.push(`${n} ${t.label}`), (e -= n * t.value);
                                        }
                                    (t(a) || (e > 0 && "" !== a)) && a.push(e);
                                } else a.push(e);
                                return (function (e) {
                                    const t = "۰۱۲۳۴۵۶۷۸۹";
                                    return e
                                        .toString()
                                        .replace(/\d/g, (e) => t[e])
                                        .replace(/[٠-٩]/g, (e) => t[e.charCodeAt(0) - "٠".charCodeAt(0)]);
                                })(a.join(" و ") + " تومان");
                            })(a)
                            : `${a.toLocaleString()} تومان`
                    ))
                : e.next(".price-format-text").remove();
        }
        function b() {
            u(".header-search-btn").removeClass("active"), u(".header-search-form-holder").stop(!0, !0).delay(100).fadeOut(150);
        }
        function k() {
            const e = u(window).scrollTop(),
                t = 106,
                a = window.innerHeight - t,
                n = Math.round(265) + 100;
            if (!u(".carousel-table-holder").length)
                if (e > a && e > 318) {
                    if (u(".menu-holder").hasClass("scrolled")) return !1;
                    u(".menu-holder").addClass("scrolled").removeClass("hiding").css("top", "-106px"), w();
                } else {
                    if (!u(".menu-holder").hasClass("scrolled") || u(".menu-holder").hasClass("hiding")) return !1;
                    u(".menu-holder")
                        .stop(!0, !0)
                        .addClass("hiding")
                        .animate({ top: -106 }, n - 100, "easeInCubic", function () {
                            u(".menu-holder").css("top", "0px").removeClass("scrolled show").removeClass("hiding"), w();
                        });
                }
        }
        function C() {
            u(".row-full-height").css("height", u(window).height() + "px");
        }
        function w() {
            u(".menu-holder .main-menu .menu .menu-item-style-normal .sub-menu, .menu-holder .main-menu .menu-item-style-mega-menu .kt-mega-menu-holder").css("visibility", "hidden").css("display", "block"),
                u(".menu-holder .main-menu .menu .menu-item-style-normal .sub-menu").each(function () {
                    const t = u(this).offset().left + (e("body").hasClass("rtl") ? 0 : u(this).outerWidth());
                    u(window).width() < t && (u(this).addClass("sub-menu-left"), u(this).parents(".sub-menu").addClass("sub-menu-left"));
                }),
                u(".menu-holder .main-menu .menu-item-style-mega-menu").each(function () {
                    u(this).find(".kt-mega-menu-holder .kt-mega-menu-shortcode-holder").css("height", u(this).find(".kt-mega-menu-holder .mega-menu-sub-menu-outer").outerHeight()),
                        u(this)
                            .find(".kt-mega-menu-holder")
                            .css({ right: u(this).offset().left + u(this).outerWidth() - (u(".menu-inner").offset().left + u(".menu-inner").outerWidth()), width: u(".menu-inner").outerWidth() });
                }),
                u(
                    ".header-top-widget .menu .menu-item .sub-menu, .header-widget .menu .menu-item .sub-menu, .menu-holder .main-menu .menu .menu-item-style-normal .sub-menu, .menu-holder .main-menu .menu-item-style-mega-menu .kt-mega-menu-holder"
                )
                    .css("display", "none")
                    .css("visibility", "visible");
        }
        var x = a(311);
        function y(e, t = !0) {
            (e = JSON.parse(e)),
                t &&
                (x(".kt-minicart-modal").remove(),
                    x(".kt-modal-holder").append(x(e.modal_content)),
                    x(".kt-minicart-modal").css("max-height", 0.95 * x(window).outerHeight()),
                    x('<a href="#" class="kt-modal-button" data-modal="minicart"></a>').appendTo("body").trigger("click").remove()),
                x(".header-minicart-content").empty().append(x(e.content)),
                e.quantity > 0
                    ? x(".header-minicart-quantity").length
                        ? x(".header-minicart-quantity").text(e.quantity)
                        : x(".kt-minicart-btn").append(x('<span class="header-minicart-quantity">' + e.quantity + "</span>"))
                    : x(".header-minicart-quantity").remove();
        }
        function j(e, t) {
            e.hasClass("is-loading") ||
                (e.addClass("is-loading"),
                    x.ajax({
                        url: ktAjax.ajaxUrl,
                        type: "post",
                        data: { action: "kt_ajax_add_to_cart", params: JSON.stringify(t), clear_cart: "1" === e.attr("data-empty") },
                        success: function (t) {
                            "1" !== e.attr("data-redirect") ? (e.removeClass("is-loading"), y(t)) : (window.location = JSON.parse(t) ?.cart_url);
                        },
                        error: function () {
                            e.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                        },
                    }));
        }
        function _() {
            x(".kt-ebook-modal").length &&
                x(".post-content").length &&
                !x(".kt-ebook-modal").hasClass("active") &&
                !x(".kt-ebook-modal").hasClass("opened") &&
                x(".post-content").offset().top + x(".post-content").outerHeight() / 2 < x(window).scrollTop() + x(window).outerHeight() / 2 &&
                (x('<a href="#" class="kt-modal-button" data-modal="ebook"></a>').appendTo("body").trigger("click").remove(), x(".kt-ebook-modal").addClass("opened"), o("remove_ebook_" + x(".kt-ebook-modal").attr("data-id"), "yes"));
        }
        function O() {
            const e = x(".mobile-fixed-button");
            if (e.length) {
                const t = e.attr("href");
                x(t).length && (x(window).scrollTop() < x(t).offset().top - x(window).outerHeight() / 2 ? e.fadeIn(200) : e.fadeOut(200));
            }
        }
        function I() {
            const e = new XMLHttpRequest();
            let t = x(".courses-filters-holder").attr("data-url");
            const a = x(".courses-types-filter").attr("data-value"),
                n = x(".courses-categories-filter").attr("data-value"),
                s = {};
            "" !== a && (s.courses_type = a),
                "" !== n && (s.courses_category = n),
                (t += s ? "?" + x.param(s) : ""),
                x(".courses-items-outer-holder").addClass("is-loading"),
                e.open("GET", t),
                e.addEventListener("loadend", function () {
                    const e = document.createElement("html");
                    (e.innerHTML = this.responseText),
                        x(".courses-items-outer .courses-items-holder", e).waitForImages(function () {
                            x(".courses-items-outer-holder .pagination-holder").remove(),
                                x(".courses-items-outer-holder").removeClass("is-loading").append(x(".courses-items-outer-holder .pagination-holder", e)),
                                x(".courses-items-outer .courses-items-holder")
                                    .isotope("remove", x(".courses-items-outer .courses-items-holder .masonry-item"))
                                    .isotope("insert", x(x(".courses-items-outer .courses-items-holder", e).html()))
                                    .isotope("layout")
                                    .ktLazyLoad(),
                                g(),
                                setTimeout(function () {
                                    x(".courses-items-outer .courses-items-holder").isotope("layout");
                                }, 100);
                        });
                }),
                e.send();
        }
        var T = a(311);
        function H() {
            T(".blog-note-share-icons").css("width", T(".blog-note-share").outerWidth() + "px");
        }
        function S(e) {
            window.ktAjaxSearchCurrentContent !== e && "" !== e
                ? T.ajax({
                    type: "POST",
                    dataType: "html",
                    url: ktAjax.ajaxUrl,
                    data: { action: "kt_ajax_search_results", searchContent: e },
                    success: function (t) {
                        const a = T(t);
                        if (((window.ktAjaxSearchCurrentContent = e), a.length > 0)) {
                            if (T(".header-search-content").hasClass("has-animation")) {
                                T(".header-search-content").css("height", T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px");
                                let e = 0;
                                a.find(".header-search-item,.header-search-not-found").each(function () {
                                    e > 0 && T(this).css("animation-delay", 50 * e + "ms"), e++;
                                });
                            }
                            T(".header-search-content-outer").empty().append(a),
                                T(".header-search-content-inner").length &&
                                (T(".header-search-content-inner").css("max-height", 0.4 * T(window).outerHeight()),
                                    new PerfectScrollbar(".header-search-content-inner", { wheelPropagation: !0, suppressScrollX: !0, wheelSpeed: 0.7 })),
                                T(".header-search-content").hasClass("has-animation") &&
                                T(".header-search-content").animate(
                                    { height: T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px" },
                                    700,
                                    "easeInOutQuint"
                                );
                        } else
                            T(".header-search-content").hasClass("has-animation") &&
                                T(".header-search-content").css("height", T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px"),
                                T(".header-search-content").hasClass("has-animation")
                                    ? T(".header-search-content").animate({ height: T(".header-search-content .search-form").outerHeight() + "px" }, 700, "easeInOutQuint", function () {
                                        T(".header-search-content-outer").empty();
                                    })
                                    : T(".header-search-content-outer").empty();
                        T(".header-search-content").removeClass("is-loading");
                    },
                    error: function () {
                        let e;
                        T(".header-search-content").hasClass("has-animation") &&
                            ((e = " header-search-item-animated"),
                                T(".header-search-content").css("height", T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px")),
                            T(".header-search-content-outer")
                                .empty()
                                .append(
                                    '<div class="header-search-content-holder"><div class="header-search-content-inner"><div class="header-search-not-found' + e + '">با عرض پوزش، مشکلی پیش آمد. لطفا بعدا امتحان کنید.</div></div></div>'
                                ),
                            T(".header-search-content").removeClass("is-loading"),
                            T(".header-search-content").hasClass("has-animation") &&
                            T(".header-search-content").animate(
                                { height: T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px" },
                                700,
                                "easeInOutQuint"
                            );
                    },
                })
                : (T(".header-search-content").removeClass("is-loading"),
                    "" === e &&
                    ((window.ktAjaxSearchCurrentContent = e),
                        T(".header-search-content").hasClass("has-animation") &&
                        T(".header-search-content")
                            .css("height", T(".header-search-content .header-search-content-outer").outerHeight() + T(".header-search-content .search-form").outerHeight() + "px")
                            .animate({ height: T(".header-search-content .search-form").outerHeight() + "px" }, 700, "easeInOutQuint", function () {
                                T(".header-search-content-outer").empty();
                            })));
        }
        function U() {
            if (T(".carousel-table-holder").length) {
                const e = T(window).scrollTop(),
                    t = T(window).outerHeight(),
                    a = T(".carousel-table-holder"),
                    n = a.outerHeight(),
                    s = a.offset().top,
                    o = T(".carousel-table-top");
                n > t
                    ? e >= s
                        ? (o.addClass("fixed").css({ width: a.outerWidth(), left: a.offset().left, top: 0 }),
                            e <= s + 75
                                ? o.css({ height: 145 - (e - s), top: 0 }).removeClass("scrolled")
                                : e + 0.65 * t >= s + n
                                    ? o.css({ width: "", left: "", top: n - 0.65 * t }).removeClass("fixed")
                                    : o.addClass("scrolled").css({ height: 70, top: 0 }))
                        : o.removeClass("fixed scrolled").css({ height: "", width: "", left: "", top: 0 })
                    : o.css({ height: "", width: "", left: "", top: 0 }).removeClass("fixed scrolled");
            }
        }
        function A() {
            if (T(".carousel-table-holder").length) {
                const e = T(window).width() - (T(".logo-holder").offset().left + T(".logo-holder").outerWidth()),
                    t = T(window).width() - (T(".post-content").offset().left + T(".post-content").outerWidth()),
                    a = T(".menu-inner").outerWidth();
                T(".carousel-table-holder").css({ "margin-right": -(t - e), width: a }), T(".carousel-table-headings .carousel-table-heading:not(:first-child)").css("width", a);
                let n = 1;
                T(".carousel-table-headings > *").each(function () {
                    const e = T(".carousel-table-headings > :nth-child(" + n + "), .carousel-table-item > :nth-child(" + n + ")"),
                        t = e
                            .css("height", "auto")
                            .map(function () {
                                return T(this).outerHeight();
                            })
                            .get();
                    e.css("height", Math.max.apply(null, t)), n++;
                });
            }
        }
        var M = a(311);
        function D() {
            const e = [];
            return (
                M(".google-ad-preview-item input, .google-ad-preview-item select, .google-ad-preview-item textarea, .google-ad-preview-checkbox").each(function () {
                    let t = "";
                    (t = void 0 !== M(this).attr("type") && "checkbox" === M(this).attr("type") ? (M(this).is(":checked") ? "on" : "off") : M(this).val()), e.push({ option: M(this).attr("data-field"), value: t });
                }),
                JSON.stringify(e)
            );
        }
        function $() {
            const e = M(".google-ad-preview-snippets select").val();
            if (e.length) {
                let t = [];
                M(".google-ad-preview-snippets input").each(function () {
                    M(this).val().length && t.push(M(this).val());
                }),
                    t.length ? ((t = t.join(", ")), M(".gadp-snippets").text(e + ": " + t)) : M(".gadp-snippets").text("");
            } else M(".gadp-snippets").text("");
        }
        function L(e) {
            return e
                .find("span, b")
                .map(function () {
                    return M(this).outerWidth();
                })
                .get()
                .reduce(function (e, t) {
                    return e + t;
                }, 0);
        }
        function E(e) {
            return e
                .find("span:not(.hidden), b")
                .map(function () {
                    return M(this).outerWidth();
                })
                .get()
                .reduce(function (e, t) {
                    return e + t;
                }, 0);
        }
        var F = a(311);
        function q() {
            const e = F(".experts-filters-holder")
                .serializeArray()
                .filter((e) => !t(e.value)),
                a = { orderby: F(".experts-orderby select").val() };
            for (const n of e) t(n.value) || (a[n.name] = n.value);
            return {
                filters: a,
                url: `${window.location.href.split("?")[0]}${t(a) ? "" : "?"}${Object.keys(a)
                    .map((e) => `${e}=${a[e]}`)
                    .join("&")}`,
            };
        }
        function W() {
            const e = (e) => `<div class="kt-skeleton${e ? ` experts-archive-skeleton-${e}` : ""}"></div>`;
            return `<div class="experts-archive-skeleton experts-list-item-holder">\n\t<div class="experts-list-item">\n\t<div class="experts-list-item-header">\n\t${e("avatar")}\n\t<div class="experts-list-item-name-holder">${e().repeat(
                2
            )}</div>\n\t${e("rating")}\n\t</div>\n\t<div class="experts-list-portfolio-holder">${e("skills")}</div>\n\t<div class="experts-list-item-footer">${e().repeat(2)}</div>\n\t</div>\n\t</div>`;
        }
        function P() {
            const e = F(".experts-list");
            if (e.hasClass("is-loading") || e.hasClass("is-paging") || !e.hasClass("has-pagination") || F(window).scrollTop() + F(window).height() <= e.offset().top + e.outerHeight()) return;
            e.addClass("is-paging"), e.append(F(W().repeat(8)));
            const { filters: t, url: a } = q(),
                n = { action: "kt_ajax_experts_filter", page: (parseInt(e.attr("data-page")) || 1) + 1, ...t };
            F.ajax({
                url: ktAjax.ajaxUrl,
                type: "post",
                data: n,
                success: function ({ items: t, pagination: n, page: s }) {
                    const o = parseInt(e.attr("data-page")) || 1;
                    q().url === a &&
                        o + 1 === s &&
                        (n ? e.addClass("has-pagination") : e.removeClass("has-pagination"), e.attr("data-page", s), e.find(".experts-archive-skeleton").remove(), t.length > 0 && e.append(t.map((e) => F(e))), e.removeClass("is-paging"));
                },
                error: function () {
                    e.removeClass("is-paging");
                },
            });
        }
        function z({ target: e }) {
            const t = F(".experts-list");
            t.hasClass("is-loading") || (t.addClass("is-loading"), t.empty().append(F(W().repeat(8))));
            const { filters: a, url: n } = q();
            window.history.replaceState({}, null, n);
            const s = { action: "kt_ajax_experts_filter", page: 1, ...a },
                o = F(window).width();
            let i = F(".experts-archive-content").offset().top - (F("#wpadminbar").length ? F("#wpadminbar").outerHeight() : 0);
            (i -= o >= 992 ? 32 : o >= 768 ? 20 : 12),
                Math.abs(F(window).scrollTop() - i) > 80 && F("html, body").animate({ scrollTop: i }, 1e3, "easeInOutQuint"),
                F(e).closest(".experts-filters-skills, .experts-archive-sidebar-button, .experts-archive-sidebar-title").length &&
                F(".experts-archive-header-title")
                    .not(":has(.kt-skeleton)")
                    .each(function () {
                        F(this).addClass("is-loading").find("span").append(F('<span class="kt-skeleton"></span>'));
                    }),
                F(e).closest(".experts-archive-sidebar-holder").length &&
                F(".experts-archive-header-count")
                    .not(":has(.kt-skeleton)")
                    .each(function () {
                        F(this).addClass("is-loading").find("span").append(F('<span class="kt-skeleton"></span>'));
                    }),
                F.ajax({
                    url: ktAjax.ajaxUrl,
                    type: "post",
                    data: s,
                    success: function ({ items: e, pagination: a, count: s, title: o }) {
                        q().url === n &&
                            (a ? t.addClass("has-pagination") : t.removeClass("has-pagination"),
                                t.attr("data-page", 1),
                                t.empty(),
                                s > 0 ? t.append(e.map((e) => F(e))) : t.append(F('<div class="experts-list-error"><div class="alert">با عرض پوزش، متخصصی پیدا نشد. لطفا جستجوی خود را با فیلتر‌های دیگری امتحان کنید.</div></div>')),
                                t.removeClass("is-loading"),
                                F(".experts-archive-header-title, .experts-archive-header-count").removeClass("is-loading"),
                                F(".experts-archive-header-title span").text(o),
                                F(".experts-archive-header-count span").text(s > 0 ? `${s} متخصص` : "متخصصی پیدا نشد"));
                    },
                    error: function () {
                        q().url === n && window.location.reload();
                    },
                });
        }
        function N() {
            P(),
                F(".experts-filters-category-label").on("click", function () {
                    const e = F(this),
                        t = F(this).parents(".experts-filters-category").find(".experts-filters-category-inner");
                    e.hasClass("active") ? (e.removeClass("active"), t.stop(!0, !0).slideUp(400, "easeOutCubic")) : (e.addClass("active"), t.stop(!0, !0).slideDown(450, "easeOutCubic"));
                }),
                F(".archive-filter-toggle").on("click", function () {
                    const e = F(this),
                        t = e.parent().find(".archive-filter-holder");
                    if (t.length)
                        if (e.hasClass("active")) e.removeClass("active").find("span").text(e.attr("data-text")), Q(t, !0);
                        else {
                            const a = t.find("ul").outerHeight(),
                                n = Math.round(0.75 * a);
                            t.stop(!0, !0).animate({ height: a }, n, "easeOutCubic", function () {
                                t.css("height", "auto");
                            }),
                                e.addClass("active").find("span").text(e.attr("data-close"));
                        }
                    return !1;
                }),
                F(".archive-filter-holder[data-limit]").each(function () {
                    Q(F(this));
                }),
                F(".experts-orderby select").on("change", function (e) {
                    z(e);
                }),
                F(".experts-archive-filter-btn").on("click", function () {
                    const e = F(".experts-archive-sidebar-holder");
                    F("html").addClass("kt-modal-opened"), e.addClass("show"), e.attr("data-url", q().url), l(e, () => e.addClass("active"), 1);
                }),
                F(".experts-archive-sidebar-title button, .experts-archive-sidebar-button button").on("click", function (e) {
                    const t = F(".experts-archive-sidebar-holder");
                    t.attr("data-url") !== q().url && z(e), t.removeAttr("data-url"), t.addClass("hiding").removeClass("active"), F("html").removeClass("kt-modal-opened"), l(t, () => t.removeClass("show hiding"), 375);
                }),
                F(".experts-filters a, .experts-filters span").on("click", function (e) {
                    if (e.ctrlKey) return;
                    const t = F(this).closest(".experts-filters-category"),
                        a = t.find(".experts-filters > ul > li"),
                        n = t.find("input"),
                        s = [];
                    return (
                        F(this).hasClass("active")
                            ? (F(this).removeClass("active"), F(this).hasClass("has-child") && F(this).next().stop(!0, !0).slideUp(400, "easeInOutCubic"))
                            : (F(this).addClass("active"), F(this).hasClass("has-child") && F(this).next().stop(!0, !0).slideDown(450, "easeInOutCubic")),
                        a.find("> .active, > .active.has-child + .experts-filters-childs .active").each(function () {
                            (!F(this).hasClass("has-child") || (F(this).hasClass("has-child") && !F(this).next().find("a.active").length)) && s.push(parseInt(F(this).attr("data-id")));
                        }),
                        n.val(s.join(",")),
                        F(window).width() >= 992 && z(e),
                        !1
                    );
                });
        }
        function Q(e, t = !1) {
            if (!e.length || !e.parent().find(".archive-filter-toggle:not(.active)").length || e.is(":hidden")) return;
            const a = parseInt(e.attr("data-limit")) || null;
            if (!a || e.find("ul li").length <= a) return;
            let n = 0;
            if (
                (e
                    .find("ul li")
                    .slice(0, a)
                    .each(function (e) {
                        n += F(this).outerHeight(e + 1 !== a);
                    }),
                    t)
            ) {
                const t = e.find("ul").outerHeight();
                e.css("height", t), e.stop(!0, !0).animate({ height: n }, Math.round(0.75 * t), "easeOutCubic");
            } else e.css("height", n);
        }
        F(window).on("resize load scroll", function () {
            P();
        });
        var X = a(311);
        function J() {
            X(".image-before-after").each(function () {
                const e = X(this),
                    t = e.find(".cursor"),
                    a = e.find(".before-image"),
                    n = t.outerWidth();
                a.find("img").css("width", e.outerWidth()),
                    t.off("mousedown mouseup touchend touchcancel"),
                    t
                        .on("mousedown", function (s) {
                            t.addClass("draggable"), a.addClass("resizable");
                            const o = s.pageX ? s.pageX : s.originalEvent.touches[0].pageX,
                                i = t.offset().left + n - o,
                                r = e.offset().left,
                                l = e.outerWidth(),
                                c = r + 10,
                                d = r + l - n - 10;
                            t.parents().off("mousemove touchmove mouseup touchend touchcancel"),
                                t
                                    .parents()
                                    .on("mousemove touchmove", function (t) {
                                        if (t.pageX > 0) {
                                            let s = (t.pageX ? t.pageX : t.originalEvent.touches[0].pageX) + i - n;
                                            s < c ? (s = c) : s > d && (s = d);
                                            const o = (100 * (s + n / 2 - r)) / l + "%";
                                            e.find(".cursor.draggable").off("mousemove touchmove mouseup touchend touchcancel"),
                                                e
                                                    .find(".cursor.draggable")
                                                    .css("left", o)
                                                    .on("mouseup touchend touchcancel", function () {
                                                        X(this).removeClass("draggable"), a.removeClass("resizable");
                                                    }),
                                                e.find(".before-image.resizable").css("width", o);
                                        }
                                    })
                                    .on("mouseup touchend touchcancel", function () {
                                        t.removeClass("draggable"), a.removeClass("resizable");
                                    }),
                                s.preventDefault();
                        })
                        .on("mouseup touchend touchcancel", function (e) {
                            t.removeClass("draggable"), a.removeClass("resizable");
                        });
            });
        }
        function R() {
            X(".parallax").each(function () {
                const e = X(window).scrollTop(),
                    t = X(this);
                let a = 0.4;
                const n = t.outerHeight(),
                    s = X(window).height(),
                    o = t.offset().top;
                let i, r;
                const l = t.find(".parallax-image-holder");
                t.data("parallax-speed") && (a = parseFloat(t.data("speed")) < 100 ? parseFloat(t.data("speed")) / 100 : 1);
                const c = Math.round((e - o) * a);
                o > 0 ? ((r = o < s ? (n < s ? ((s + o) / n) * 1.8 : n / s) : n < s ? ((2 * s) / n) * 1.8 : n / s), (i = Math.round(n + 70 * r * a))) : 0 === o && (i = n),
                    o + n > e && o < e + s && (l.css("transform", "translate(0px, " + c + "px)"), l.css("height", i + "px"));
            });
        }
        function B() {
            X(".masonry-items-holder").length &&
                X(".masonry-items-holder").isotope({
                    itemSelector: ".masonry-item",
                    layoutMode: "masonry",
                    masonry: { columnWidth: ".masonry-size" },
                    originLeft: !1,
                    hiddenStyle: { opacity: 0, transform: "translate(0, 80px)" },
                    visibleStyle: { opacity: 1, transform: "translate(0, 0)" },
                    transitionDuration: "0.5s",
                });
        }
        function G() {
            K(X(".blog-single-social-links"), X(".blog-single-content"), X(".blog-single-content-sidebar")),
                K(X(".course-details-inner"), X(".course-details-inner").parent(), X(".course-details-inner").parent()),
                K(X(".kt-reviews-sidebar"), X(".kt-reviews-sidebar").parent(), X(".kt-reviews-sidebar").parent());
        }
        function K(e, t, a) {
            const n = X(window).outerHeight(),
                s = X(window).scrollTop(),
                o = e.outerHeight(),
                i = t.outerHeight();
            if (o < i) {
                const t = a.width(),
                    r = a.offset().left + parseFloat(a.css("padding-left")),
                    l = a.offset().top,
                    c = n - e.outerHeight() - 40,
                    d = (X("#wpadminbar").length ? X("#wpadminbar").outerHeight() : 0) + 126;
                o + d < n
                    ? l + i > s + o + d
                        ? l - d < s
                            ? e.css({ position: "fixed", top: d + "px", left: r, width: t })
                            : e.css({ position: "relative", left: "0", top: "0" })
                        : e.css({ position: "relative", top: i - o + "px", left: "0" })
                    : l + i > s + o + c
                        ? l + 40 + o < s + n
                            ? e.css({ left: r, width: t, position: "fixed", top: c + "px" })
                            : e.css({ position: "relative", top: "0", left: "0" })
                        : e.css({ position: "relative", top: i - o + "px", left: "0" });
            } else e.css({ position: "relative", top: "0", left: "0" });
        }
        (window.ktCanAutoHide = !1),
            (window.ktLastScrollTop = 0),
            X(function () {
                !(function () {
                    (function () {
                        function e(e) {
                            x(".campaign-form")
                                .empty()
                                .append(x('<div class="border rounded-top border-bottom-0 px-20 pt-14 pb-12 text-muted">با نام <span class="font-weight-medium">' + e + "</span> وارد شده‌اید.</div>"))
                                .append(
                                    x(
                                        '<button type="submit" class="button button-green rounded-bottom kt-ajax-button w-100 d-flex mt-0 px-20 py-12 align-items-center justify-content-between"><span class="pt-2">ثبت‌نام در دوره</span><i class="elegant-icon arrow_left text-xxl pt-2 ml-n2"></i></button>'
                                    )
                                ),
                                x(".campaign-login-form, .campaign-change-password-form").remove();
                        }
                        x(".campaign-form").on("submit", function () {
                            const e = x(this),
                                a = e.attr("data-id"),
                                s = e.find('input[name="name"]').val(),
                                o = e.find('input[name="mobile"]').val(),
                                i = e.find(".campaign-item").length ? (e.find(".campaign-item.active").length ? e.find(".campaign-item.active").attr("data-id") : -1) : null;
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (r) {
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_campaign", id: a, item_id: i, name: s, mobile: o, token: r },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? a.url && (window.location = a.url)
                                                    : a.errors.number_exists
                                                        ? e.slideUp(400, "easeInOutCubic", function () {
                                                            e.removeClass("is-loading"), n({}, e), n(a, x(".campaign-login-form"), null, "info"), x(".campaign-login-form").slideDown(400, "easeInOutCubic");
                                                        })
                                                        : n(a, e, function () {
                                                            e.removeClass("is-loading");
                                                        });
                                            },
                                            error: function () {
                                                e.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                            x(".campaign-login-form").on("submit", function () {
                                const a = x(this),
                                    s = a.find('button[type="submit"]'),
                                    o = x('.campaign-form input[name="mobile"]').val(),
                                    i = a.find('input[name="password"]').val();
                                if (!s.hasClass("is-loading"))
                                    return (
                                        s.addClass("is-loading"),
                                        d(0, function (r) {
                                            x.ajax({
                                                url: ktAjax.ajaxUrl,
                                                type: "post",
                                                data: { action: "kt_ajax_campaign_login", password: i, mobile: o, token: r },
                                                success: function (o) {
                                                    t(o.errors)
                                                        ? o.name &&
                                                        a.slideUp(400, "easeInOutCubic", function () {
                                                            s.removeClass("is-loading"), n({}, a), e(o.name), x(".campaign-form").slideDown(400, "easeInOutCubic");
                                                        })
                                                        : n(o, a, function () {
                                                            s.removeClass("is-loading");
                                                        });
                                                },
                                                error: function () {
                                                    a.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                                },
                                            });
                                        }),
                                        !1
                                    );
                            }),
                            x(".campaign-forgot-password, .campaign-send-password-again").on("click", function () {
                                const e = x(this),
                                    a = e.closest(".campaign-login-form, .campaign-change-password-form"),
                                    s = x('.campaign-form input[name="mobile"]').val();
                                if (!e.hasClass("is-loading"))
                                    return (
                                        e.addClass("is-loading"),
                                        d(0, function (o) {
                                            x.ajax({
                                                url: ktAjax.ajaxUrl,
                                                type: "post",
                                                data: { action: "kt_ajax_campaign_reset_password", mobile: s, token: o },
                                                success: function (s) {
                                                    t(s.errors)
                                                        ? e.hasClass("campaign-forgot-password")
                                                            ? a.slideUp(400, "easeInOutCubic", function () {
                                                                e.removeClass("is-loading"),
                                                                    x(".campaign-send-password-again").addClass("button-dark clicked").removeClass("button-default"),
                                                                    r(x(".campaign-send-password-again"), 60, "ارسال مجدد در %timer%", function () {
                                                                        x(".campaign-send-password-again").addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                                    }),
                                                                    n({}, a),
                                                                    n(s, x(".campaign-change-password-form")),
                                                                    x(".campaign-change-password-form").slideDown(400, "easeInOutCubic");
                                                            })
                                                            : (e.addClass("button-dark clicked").removeClass("button-default is-loading"),
                                                                r(e, 60, "ارسال مجدد در %timer%", function () {
                                                                    e.addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                                }),
                                                                n(s, a))
                                                        : n(s, a, function () {
                                                            e.removeClass("is-loading");
                                                        });
                                                },
                                                error: function () {
                                                    e.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                                },
                                            });
                                        }),
                                        !1
                                    );
                            }),
                            x(".campaign-change-password-form").on("submit", function () {
                                const a = x(this),
                                    s = a.find('button[type="submit"]'),
                                    o = x('.campaign-form input[name="mobile"]').val(),
                                    i = a.find('input[name="password"]').val(),
                                    r = a.find('input[name="verification_code"]').val();
                                if (!s.hasClass("is-loading"))
                                    return (
                                        s.addClass("is-loading"),
                                        d(0, function (l) {
                                            x.ajax({
                                                url: ktAjax.ajaxUrl,
                                                type: "post",
                                                data: { action: "kt_ajax_campaign_change_password", mobile: o, password: i, verificationCode: r, token: l },
                                                success: function (o) {
                                                    t(o.errors)
                                                        ? o.name &&
                                                        a.slideUp(400, "easeInOutCubic", function () {
                                                            s.removeClass("is-loading"), n({}, a), e(o.name), x(".campaign-form").slideDown(400, "easeInOutCubic");
                                                        })
                                                        : n(o, a, function () {
                                                            s.removeClass("is-loading");
                                                        });
                                                },
                                                error: function () {
                                                    a.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                                },
                                            });
                                        }),
                                        !1
                                    );
                            }),
                            x(".change-mobile-btn").on("click", function () {
                                return (
                                    x(this)
                                        .closest(".campaign-login-form, .campaign-change-password-form")
                                        .slideUp(400, "easeInOutCubic", function () {
                                            n({}, x(".campaign-change-password-form, .campaign-login-form")), x(".campaign-form").slideDown(400, "easeInOutCubic");
                                        }),
                                    !1
                                );
                            });
                    })(),
                        A(),
                        (function () {
                            if (T(".carousel-table-holder").length) {
                                const e = {
                                    autoplay: !1,
                                    dots: !1,
                                    infinite: !0,
                                    slidesToShow: 1,
                                    slidesToScroll: 1,
                                    speed: 500,
                                    rtl: !0,
                                    touchMove: !1,
                                    swipe: !1,
                                    draggable: !1,
                                    mobileFirst: !0,
                                    responsive: [
                                        { breakpoint: 1200, settings: { slidesToShow: 6 } },
                                        { breakpoint: 1060, settings: { slidesToShow: 5 } },
                                        { breakpoint: 890, settings: { slidesToShow: 4 } },
                                        { breakpoint: 730, settings: { slidesToShow: 3 } },
                                        { breakpoint: 585, settings: { slidesToShow: 2 } },
                                    ],
                                },
                                    t = e;
                                (t.asNavFor = ".carousel-table-logos"), (t.arrows = !1), T(".carousel-table-items").slick(t);
                                const a = e;
                                (a.asNavFor = ".carousel-table-items"),
                                    (a.arrows = !0),
                                    T(".carousel-table-logos").slick(a),
                                    T(".carousel-table-rating, .blog-compare-box-rating").each(function () {
                                        const e = T(this).attr("data-size") || 70,
                                            t = T(this).attr("data-border") || 5;
                                        T(this).easyPieChart({ barColor: "#ffc02e", trackColor: "#eef0f3", animate: { enabled: !1 }, size: e, lineWidth: t, scaleLength: 0 });
                                    }),
                                    T(".carousel-table-prev").on("click", function () {
                                        T(".carousel-table-logos").slick("slickPrev");
                                    }),
                                    T(".carousel-table-next").on("click", function () {
                                        T(".carousel-table-logos").slick("slickNext");
                                    });
                            }
                        })(),
                        void (
                            x("body").hasClass("woocommerce-cart") ||
                            x(document).on("click", ".minicart-remove-item", function () {
                                const e = x(this),
                                    t = x(".minicart-content-holder");
                                if (!t.hasClass("is-loading"))
                                    return (
                                        t.addClass("is-loading"),
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_remove_from_cart", post_id: e.attr("data-cart-item") },
                                            success: function (e) {
                                                t.removeClass("is-loading"), y(e, !1);
                                            },
                                            error: function () {
                                                t.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                            },
                                        }),
                                        !1
                                    );
                            })
                        ),
                        U(),
                        X(document).on("click", ".kt-minicart-modal .button-light", function () {
                            return X(".kt-minicart-modal .kt-modal-close").trigger("click"), !1;
                        }),
                        void (
                            X(".testimonials-holder").length &&
                            X(".testimonials-holder").each(function () {
                                X(this)
                                    .find("> .testimonials")
                                    .slick({
                                        arrows: !1,
                                        dots: !1,
                                        draggable: !0,
                                        slidesToShow: 1,
                                        autoplay: !0,
                                        autoplaySpeed: 5e3,
                                        speed: 1e3,
                                        infinite: !0,
                                        touchMove: !0,
                                        rtl: !0,
                                        touchThreshold: 3,
                                        mobileFirst: !0,
                                        responsive: [
                                            { breakpoint: 767, settings: { slidesToShow: 2, touchThreshold: 5 } },
                                            { breakpoint: 1049, settings: { slidesToShow: 3, touchThreshold: 7 } },
                                        ],
                                    });
                            })
                        ),
                        void (
                            x(".courses-carousel-holder").length &&
                            x(".courses-carousel-holder").each(function () {
                                x(this).find("> .courses-carousel").slick({ arrows: !1, dots: !0, fade: !0, slidesToShow: 1, autoplay: !0, autoplaySpeed: 5e3, speed: 700, infinite: !0, touchMove: !0, rtl: !0 });
                            })
                        ),
                        void (
                            X(".clients-carousel-holder").length &&
                            X(".clients-carousel-holder").each(function () {
                                X(this)
                                    .find("> .clients-carousel")
                                    .slick({
                                        arrows: !1,
                                        dots: !1,
                                        draggable: !0,
                                        infinite: !0,
                                        slidesToShow: 2,
                                        autoplay: !0,
                                        autoplaySpeed: 3e3,
                                        speed: 700,
                                        touchMove: !0,
                                        rtl: !0,
                                        touchThreshold: 5,
                                        mobileFirst: !0,
                                        responsive: [
                                            { breakpoint: 577, settings: { slidesToShow: 3, touchThreshold: 7 } },
                                            { breakpoint: 767, settings: { slidesToShow: 4, touchThreshold: 9 } },
                                            { breakpoint: 991, settings: { slidesToShow: 5, touchThreshold: 11 } },
                                            { breakpoint: 1049, settings: { slidesToShow: 6, touchThreshold: 14 } },
                                        ],
                                    });
                            })
                        ),
                        p(),
                        _(),
                        h(),
                        f(),
                        m(),
                        k(),
                        C(),
                        w(),
                        void u('a[href*="#"]').on("click", function () {
                            const e = document.createElement("a"),
                                t = "#" + u(this).attr("href").split("#")[1],
                                a = u(this).attr("id") ? u(this).attr("id") : "";
                            if (
                                ((e.href = u(this).attr("href")),
                                    u(t).length &&
                                    -1 === a.indexOf("cancel-comment-reply-link") &&
                                    -1 === a.indexOf("acomment-comment-") &&
                                    !u(this).hasClass("comment-reply-link") &&
                                    (window.location.pathname === e.pathname || "" === e.pathname))
                            ) {
                                const e = u(t).offset().top;
                                return u("html, body").animate({ scrollTop: e - (u("#wpadminbar").length ? u("#wpadminbar").outerHeight() : 0) }, 2e3, "easeInOutQuint"), !1;
                            }
                        }),
                        u(".responsive-menu-holder .menu-item > .menu-item-inner a .menu-item-toggle-icon").on("click", function () {
                            const e = u(this).closest(".menu-item");
                            return (
                                e.hasClass("active")
                                    ? (e.find(".sub-menu").stop(!0, !0).slideUp(350, "easeOutCubic"), e.removeClass("active"), e.find(".menu-item").removeClass("active"))
                                    : (e.find(".sub-menu").first().stop(!0, !0).slideDown(400, "easeOutCubic"), e.addClass("active")),
                                !1
                            );
                        }),
                        u(".responsive-menu-holder .menu-item.active").each(function () {
                            u(this).find(".sub-menu").first().css("display", "block");
                        }),
                        u(".responsive-menu-button").on("click", function () {
                            u(".responsive-menu-overlay").css("visibility", "visible"), u("html").addClass("responsive-menu-opened"), u(this).addClass("active");
                            const e = u(".responsive-menu-overlay").data("timeout") || 0;
                            clearTimeout(e);
                        }),
                        void u(".responsive-menu-button.active, .responsive-menu-overlay").on("click", function () {
                            u("html").removeClass("responsive-menu-opened"), u(".responsive-menu-button").removeClass("active");
                            let e = u(".responsive-menu-overlay").data("timeout") || 0;
                            clearTimeout(e),
                                u("html").hasClass("user-menu-opened")
                                    ? (u("html").removeClass("user-menu-opened"),
                                        (e = setTimeout(function () {
                                            u(".responsive-menu-overlay").css("visibility", "hidden");
                                        }, Math.round(u(".user-mobile-menu-holder").outerWidth()) + 300)))
                                    : (e = setTimeout(function () {
                                        u(".responsive-menu-overlay").css("visibility", "hidden");
                                    }, Math.round(u(".responsive-menu-outer-holder").outerWidth()) + 300)),
                                u(".responsive-menu-overlay").data("timeout", e);
                        }),
                        R(),
                        x('label[for="withdraw-amount"] + span').on("click", function () {
                            x("#withdraw-amount").val(1e3 * Math.floor(parseInt(x("#withdraw-amount").attr("max")) / 1e3));
                        }),
                        void x(".withdraw-request-form").on("submit", function () {
                            const e = x(this),
                                a = e.find('input[name="name"]').val(),
                                s = e.find('input[name="amount"]').val(),
                                o = e.find('input[name="card_number"]').val(),
                                i = e.find('input[name="iban_number"]').val();
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    x.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_ajax_withdraw_request", name: a, amount: s, card_number: o, iban_number: i },
                                        success: function (a) {
                                            n(a, e, function () {
                                                e.removeClass("is-loading");
                                            }),
                                                t(a.errors) && location.reload();
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"), alert("مشکلی پیش آمد. لطفاً مجدداً تلاش کنید.");
                                        },
                                    }),
                                    !1
                                );
                        }),
                        void (X("a[data-gallery^='prettyPhoto']").length && X("a[data-gallery^='prettyPhoto']").prettyPhoto({ hook: "data-gallery", social_tools: "", deeplinking: !1, opacity: 1 })),
                        J(),
                        G(),
                        (function () {
                            const e = X(".ticket-single-form").attr("data-post-id");
                            X(".ticket-single-form").on("submit", function () {
                                const t = X(this),
                                    a = t.find(".ticket-single-form-text").val(),
                                    n = t.find(".ticket-single-form-errors"),
                                    s = n.is(":empty") ? 0 : 400,
                                    o = new FormData(this);
                                if ((o.append("file", X("#ticket-single-form-file").prop("files")[0]), o.append("post_id", e), o.append("action", "kt_ajax_ticket_reply"), o.append("text", a), !t.hasClass("is-loading")))
                                    return (
                                        t.addClass("is-loading"),
                                        t.find(".ticket-single-form-loading").fadeIn(200),
                                        X.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            contentType: !1,
                                            cache: !1,
                                            processData: !1,
                                            data: o,
                                            success: function (e) {
                                                (e = X(e)).length && "" !== e.html()
                                                    ? n.slideUp(s, "easeInOutCubic", function () {
                                                        X(this).empty().append(e).slideDown(500, "easeInOutCubic");
                                                    })
                                                    : n.slideUp(s, "easeInOutCubic", function () {
                                                        X(this).empty();
                                                    }),
                                                    t.removeClass("is-loading"),
                                                    t.find(".ticket-single-form-loading").fadeOut(200);
                                            },
                                            error: function () {
                                                t.removeClass("is-loading"), t.find(".ticket-single-form-loading").fadeOut(200);
                                            },
                                        }),
                                        !1
                                    );
                            });
                        })(),
                        void X(".employment-form").on("submit", function () {
                            const e = X(this),
                                t = e.find(".employment-form-errors"),
                                a = t.is(":empty") ? 0 : 400,
                                n = new FormData(this);
                            if (
                                (n.append("action", "kt_ajax_employment"),
                                    n.append("file", X(".employment-form-file").prop("files")[0]),
                                    n.append("name", e.find(".employment-form-name").val()),
                                    n.append("phone", e.find(".employment-form-phone").val()),
                                    n.append("email", e.find(".employment-form-email").val()),
                                    n.append("type", e.find(".employment-form-type").val()),
                                    n.append("skills", e.find(".employment-form-skills").val()),
                                    n.append("experience", e.find(".employment-form-experience").val()),
                                    n.append("personality", e.find(".employment-form-personality").val()),
                                    !e.hasClass("is-loading"))
                            )
                                return (
                                    e.addClass("is-loading"),
                                    e.find(".employment-form-loading").fadeIn(200),
                                    X.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        contentType: !1,
                                        cache: !1,
                                        processData: !1,
                                        data: n,
                                        success: function (n) {
                                            (n = X(n)).length && "" !== n.html()
                                                ? t.slideUp(a, "easeInOutCubic", function () {
                                                    X(this).empty().append(n).slideDown(500, "easeInOutCubic");
                                                })
                                                : t.slideUp(a, "easeInOutCubic", function () {
                                                    X(this).empty();
                                                }),
                                                e.removeClass("is-loading"),
                                                e.find(".employment-form-loading").fadeOut(200);
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"), e.find(".employment-form-loading").fadeOut(200);
                                        },
                                    }),
                                    !1
                                );
                        }),
                        c(".kt-verification-form").on("submit", function () {
                            const e = c(this),
                                a = e.find('input[name="verification_code"]').val(),
                                s = e.find('input[name="password"]').val(),
                                o = e.find('button[type="submit"]');
                            if (!o.hasClass("is-loading"))
                                return (
                                    o.addClass("is-loading"),
                                    d(0, function (i) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_check_verify_code", password: s, verificationCode: a, token: i },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? (window.location = a.url)
                                                    : n(a, e, function () {
                                                        o.removeClass("is-loading");
                                                    });
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        c("#send-verification-code, #send-verification-code-again").on("click", function () {
                            const e = c(this),
                                a = e.closest(".kt-verification-inner, .kt-verification-form");
                            if (!e.hasClass("is-loading") && !e.hasClass("clicked"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (s) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_send_verification_code", token: s },
                                            success: function (s) {
                                                t(s.errors)
                                                    ? e.is("#send-verification-code")
                                                        ? a.slideUp(400, "easeInOutCubic", function () {
                                                            e.removeClass("is-loading"),
                                                                c("#send-verification-code-again").addClass("button-dark clicked").removeClass("button-default"),
                                                                r(c("#send-verification-code-again"), 60, "ارسال مجدد در %timer%", function () {
                                                                    c("#send-verification-code-again").addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                                }),
                                                                n({}, a),
                                                                n(s, c(".kt-verification-form")),
                                                                c(".kt-verification-form").slideDown(400, "easeInOutCubic");
                                                        })
                                                        : (e.addClass("button-dark clicked").removeClass("button-default is-loading"),
                                                            r(e, 60, "ارسال مجدد در %timer%", function () {
                                                                e.addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                            }),
                                                            n(s, a))
                                                    : s.errors.mobile
                                                        ? a.slideUp(400, "easeInOutCubic", function () {
                                                            e.removeClass("is-loading"), n({}, a), n(s, c(".kt-change-mobile-form")), c(".kt-change-mobile-form").slideDown(400, "easeInOutCubic");
                                                        })
                                                        : n(s, a, function () {
                                                            e.removeClass("is-loading");
                                                        });
                                            },
                                            error: function () {
                                                e.removeClass("is-loading");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        c(".change-mobile-btn").on("click", function () {
                            return (
                                c(this)
                                    .closest(".kt-verification-inner, .kt-verification-form")
                                    .slideUp(400, "easeInOutCubic", function () {
                                        c(".kt-change-mobile-form .kt-form-errors").empty(),
                                            c(".kt-change-mobile-form")
                                                .attr("data-target", c(this).closest(".kt-verification-inner").length ? ".kt-verification-inner" : ".kt-verification-form")
                                                .slideDown(400, "easeInOutCubic");
                                    }),
                                !1
                            );
                        }),
                        c("#change-mobile-cancel").on("click", function () {
                            const e = c(c(".kt-change-mobile-form").attr("data-target") || ".kt-verification-inner");
                            return (
                                c(".kt-change-mobile-form").slideUp(400, "easeInOutCubic", function () {
                                    e.find(".kt-form-errors").length && e.find(".kt-form-errors").empty(), e.slideDown(400, "easeInOutCubic");
                                }),
                                !1
                            );
                        }),
                        void c(".kt-change-mobile-form").on("submit", function () {
                            const e = c(this),
                                a = e.find('input[name="mobile"]').val(),
                                s = e.find('button[type="submit"]');
                            if (!s.hasClass("is-loading"))
                                return (
                                    s.addClass("is-loading"),
                                    d(0, function (o) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_change_number", mobile: a, token: o },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? e.slideUp(400, "easeInOutCubic", function () {
                                                        n({}, e),
                                                            n(a, c(".kt-verification-form")),
                                                            r(c("#send-verification-code-again"), 60, "ارسال مجدد در %timer%", function () {
                                                                c("#send-verification-code-again").addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                            }),
                                                            c(".kt-verification-form").slideDown(400, "easeInOutCubic");
                                                    })
                                                    : n(a, e, function () {
                                                        s.removeClass("is-loading");
                                                    });
                                            },
                                            error: function () {
                                                s.removeClass("is-loading");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        void x(".service-renew-form").each(function () {
                            const e = x(this),
                                t = parseFloat(e.attr("data-service"));
                            e.on("submit", function () {
                                if (!e.hasClass("is-loading"))
                                    return (
                                        e.addClass("is-loading"),
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_add_renewal_product_to_cart", service_id: t, product_id: e.find(".service-renew-form-select").val() },
                                            success: function (e) {
                                                window.location = e;
                                            },
                                            error: function () {
                                                e.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                            },
                                        }),
                                        !1
                                    );
                            });
                        }),
                        (function () {
                            const e = x(".course-review-form").attr("data-id");
                            x(".course-review-form").on("submit", function () {
                                const a = x(this),
                                    s = a.find(".review-form-stars button.active").length ? a.find(".review-form-stars button.active").attr("data-star") : 0,
                                    o = a.find('[name="comment"]').val();
                                if (!a.hasClass("is-loading"))
                                    return (
                                        a.addClass("is-loading"),
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_course_review", product_id: e, text: o, rating: s },
                                            success: function (e) {
                                                !t(e.errors) && e.errors.duplicate
                                                    ? n(
                                                        e.errors.duplicate,
                                                        a,
                                                        function () {
                                                            a.removeClass("is-loading"), a.find('[name="comment"]').val(""), a.find(".review-form-stars").removeClass("selected").find("button").removeClass("active");
                                                        },
                                                        "warning"
                                                    )
                                                    : n(e, a, function () {
                                                        a.removeClass("is-loading"), e.success && (a.find('[name="comment"]').val(""), a.find(".review-form-stars").removeClass("selected").find("button").removeClass("active"));
                                                    });
                                            },
                                            error: function () {
                                                a.removeClass("is-loading");
                                            },
                                        }),
                                        !1
                                    );
                            });
                        })(),
                        (function () {
                            const e = x(".kt-interview-request").attr("data-product-id");
                            x(".kt-interview-request").on("click", function () {
                                const t = x(this);
                                if (!t.hasClass("is-loading") && !t.hasClass("submitted"))
                                    return (
                                        t.addClass("is-loading"),
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_interview_request", product_id: e },
                                            success: function (e) {
                                                e.length ? alert(e) : t.text("درخواست شما ثبت شد").addClass("submitted"), t.removeClass("is-loading");
                                            },
                                            error: function () {
                                                t.text("با عرض پوزش، مشکلی پیش آمد. لطفا مجددا امتحان کنید."), t.removeClass("is-loading");
                                            },
                                        }),
                                        !1
                                    );
                            });
                        })(),
                        (function () {
                            const e = x(".kt-let-me-know").attr("data-product-id");
                            x(".kt-let-me-know").on("click", function () {
                                const t = x(this);
                                if (!t.hasClass("is-loading") && !t.hasClass("submitted"))
                                    return (
                                        t.addClass("is-loading"),
                                        x.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_let_me_know", product_id: e },
                                            success: function (e) {
                                                e.length ? alert(e) : t.text("درخواست شما ثبت شد").addClass("submitted"), t.removeClass("is-loading");
                                            },
                                            error: function () {
                                                t.text("با عرض پوزش، مشکلی پیش آمد. لطفا مجددا امتحان کنید."), t.removeClass("is-loading");
                                            },
                                        }),
                                        !1
                                    );
                            });
                        })(),
                        void (
                            X(".carousel-holder").length &&
                            X(".carousel-holder").each(function () {
                                const e = X(this),
                                    t = e.find("> .carousel"),
                                    a = e.find("> .slick-prev, > .blog-note-arrows .slick-prev"),
                                    n = e.find("> .slick-next, > .blog-note-arrows .slick-next"),
                                    s = t.find("> *").length;
                                let o;
                                !t.hasClass("slick-initialized") &&
                                    t.length &&
                                    (t.on("init", function (e, t) {
                                        s > 1 && n.addClass("active");
                                    }),
                                        t.slick({ autoplay: !1, arrows: !0, dots: !1, draggable: !0, fade: !0, infinite: !1, responsive: o, slidesToShow: 1, slidesToScroll: 1, speed: 300, swipe: !0, swipeToSlide: !0, touchMove: !0, rtl: !0 }),
                                        a.on("click", function () {
                                            X(".blog-note-slide.slick-current .blog-note-expend.expended").length && X(".blog-note-slide.slick-current .blog-note-expend.expended").trigger("click"), t.slick("slickPrev");
                                        }),
                                        n.on("click", function () {
                                            X(".blog-note-slide.slick-current .blog-note-expend.expended").length && X(".blog-note-slide.slick-current .blog-note-expend.expended").trigger("click"), t.slick("slickNext");
                                        }),
                                        t.on("afterChange", function (e, s) {
                                            t.find(".slick-prev").first().hasClass("slick-disabled") ? a.removeClass("active") : a.addClass("active"),
                                                t.find(".slick-next").first().hasClass("slick-disabled") ? n.removeClass("active") : n.addClass("active");
                                        }));
                            })
                        ),
                        void (
                            X(".tabs").length &&
                            X(".tabs").each(function () {
                                const e = X(this),
                                    t = e.find("> .tabs-title-holder > .tab-title"),
                                    a = e.find("> .tabs-content-holder > .tabs-content-inner"),
                                    n = e.find("> .tabs-content-holder > .tabs-content-inner > .tab-content"),
                                    s = e.find("." + t.first().attr("data-tab-id"));
                                n.find("> .tabs-content-holder > .tabs-content-inner").css("opacity", 0),
                                    t.first().addClass("active"),
                                    s.addClass("active"),
                                    s.find(".tab-content-inner").css("opacity", 1),
                                    t.on("click", function () {
                                        const n = X(this),
                                            s = e.find("> .tabs-content-holder > .tabs-content-inner > .tab-content.active"),
                                            o = e.find("." + n.attr("data-tab-id"));
                                        if (!n.hasClass("active")) {
                                            a.css("height", s.outerHeight()),
                                                s
                                                    .find("> .tab-content-inner")
                                                    .stop(!0, !0)
                                                    .animate({ opacity: 0 }, 150, function () {
                                                        s.removeClass("active"), o.addClass("active"), o.find("> .tab-content-inner").stop(!0, !0).animate({ opacity: 1 }, 300);
                                                    }),
                                                t.removeClass("active"),
                                                n.addClass("active"),
                                                a.css("height", o.outerHeight());
                                            let e = a.data("timeout") || 0;
                                            clearTimeout(e),
                                                (e = setTimeout(function () {
                                                    a.css("height", "auto");
                                                }, 600));
                                        }
                                    });
                            })
                        ),
                        void (
                            X(".accordions").length &&
                            X(".accordions").each(function () {
                                const e = X(this),
                                    t = e.find(".accordion-title"),
                                    a = e.find(".accordion-content");
                                a.css("height", "0"),
                                    e.hasClass("accordion-items-closed") || (t.first().addClass("active"), a.first().css("height", a.first().find(".accordion-content-inner").outerHeight(!0))),
                                    t.on("click", function () {
                                        const e = X(this).closest(".accordion").find(".accordion-content");
                                        if (X(this).hasClass("active")) X(this).removeClass("active"), e.css("height", "0");
                                        else {
                                            const n = e.find(".accordion-content-inner").outerHeight(!0);
                                            a.css("height", "0"), t.removeClass("active"), X(this).addClass("active"), e.css("height", n);
                                        }
                                    });
                            })
                        ),
                        void (
                            x(".course-chapter").length &&
                            x(".course-chapter").each(function () {
                                const e = x(this);
                                e.find(".course-chapter-title").on("click", function () {
                                    const t = e.find(".course-chapter-content");
                                    if (e.hasClass("active")) e.removeClass("active"), t.css("height", "0");
                                    else {
                                        const a = t.find(".course-chapter-content-inner").outerHeight(!0);
                                        e.addClass("active"), t.css("height", a);
                                    }
                                });
                            })
                        ),
                        B(),
                        void T(".social-share-button").on("click", function () {
                            const e = T(this);
                            e.hasClass("is-loading") ||
                                (e.addClass("is-loading"),
                                    T.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_social_share", post_id: e.data("id"), type: e.data("type") },
                                        success: function (t) {
                                            e.find("span").html(t), e.removeClass("is-loading");
                                        },
                                    }));
                        }),
                        void T(document).on("click", ".kt-like-button, .kt-dislike-button", function () {
                            const e = T(this).closest(".kt-like-holder");
                            if (e.hasClass("is-loading")) return;
                            e.addClass("is-loading");
                            const t = e.data("id"),
                                a = T(this);
                            let n, s;
                            a.hasClass("kt-like-button") && ((n = e.hasClass("liked") ? "unliked" : "liked"), e.hasClass("disliked") && (s = "undisliked")),
                                a.hasClass("kt-dislike-button") && ((s = e.hasClass("disliked") ? "undisliked" : "disliked"), e.hasClass("liked") && (n = "unliked"));
                            const o = '{"like_status":"' + n + '","dislike_status":"' + s + '"}';
                            return (
                                T.ajax({
                                    url: ktAjax.ajaxUrl,
                                    type: "post",
                                    data: { action: e.hasClass("kt-comment-like-holder") ? "kt_comments_add_like" : "kt_posts_add_like", id: t, status: o },
                                    success: function (t) {
                                        (t = JSON.parse(t)),
                                            e.find(".kt-like-count").html(t.likes),
                                            e.find(".kt-dislike-count").html(t.dislikes),
                                            e.attr("data-likes", t.likes),
                                            e.attr("data-dislikes", t.dislikes),
                                            a.hasClass("kt-like-button") && (e.hasClass("liked") ? e.removeClass("liked") : e.addClass("liked"), e.hasClass("disliked") && e.removeClass("disliked")),
                                            a.hasClass("kt-dislike-button") && (e.hasClass("disliked") ? e.removeClass("disliked") : e.addClass("disliked"), e.hasClass("liked") && e.removeClass("liked")),
                                            e.removeClass("is-loading");
                                    },
                                }),
                                !1
                            );
                        }),
                        (function () {
                            X(".dashboard-discount-box-timer").length &&
                                X(".dashboard-discount-box-timer").each(function () {
                                    const e = X(this),
                                        t = e.attr("data-final-date"),
                                        a = e.attr("data-content");
                                    e.countdown(t, function (t) {
                                        let n = t.offset.totalDays,
                                            s = t.offset.hours,
                                            o = t.offset.minutes,
                                            i = t.offset.seconds;
                                        1 === n.toString().length && (n = "0" + n),
                                            1 === s.toString().length && (s = "0" + s),
                                            1 === o.toString().length && (o = "0" + o),
                                            1 === i.toString().length && (i = "0" + i),
                                            e.html(t.strftime(a.replace("/*روز*/", n).replace("/*ساعت*/", s).replace("/*دقیقه*/", o).replace("/*ثانیه*/", i)));
                                    });
                                });
                            X(".campaign-timer").length &&
                                X(".campaign-timer").each(function () {
                                    const e = X(this),
                                        t = new Date(e.attr("data-date"));
                                    e.countdown(t, function (e) {
                                        X(this).html(e.strftime("%I:%M:%S"));
                                    }).on("finish.countdown", function () {
                                        location.reload();
                                    });
                                });
                        })(),
                        void c(".kt-register-form").on("submit", function () {
                            const e = c(this),
                                a = e.find('input[name="name"]').val(),
                                s = e.find('input[name="password"]').val(),
                                o = e.find('input[name="mobile"]').val();
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (r) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_registration", name: a, password: s, mobile: o, token: r, options: i(e) },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? a.url
                                                        ? (window.location = a.url)
                                                        : location.reload()
                                                    : n(a, e, function () {
                                                        e.removeClass("is-loading");
                                                    });
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        c(".kt-login-form").on("submit", function () {
                            const e = c(this),
                                a = e.find('input[name="username"]').val(),
                                s = e.find('input[name="password"]').val(),
                                o = e.find(".kt-login-remember").is(":checked");
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (r) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_login", username: a, password: s, remember: o, token: r, options: i(e) },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? a.url
                                                        ? (window.location = a.url)
                                                        : location.reload()
                                                    : n(a, e, function () {
                                                        e.removeClass("is-loading");
                                                    });
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        c("#reset-password-btn, #reset-password-back, #change-password-back").on("click", function () {
                            if (c(this).hasClass("is-loading")) return;
                            const e = c(this);
                            let t, a;
                            return (
                                c(this).is("#reset-password-btn")
                                    ? ((t = ".kt-login-form"), (a = ".kt-reset-password-form"))
                                    : c(this).is("#reset-password-back")
                                        ? ((t = ".kt-reset-password-form"), (a = ".kt-login-form"))
                                        : ((t = ".kt-change-password-form"), (a = ".kt-reset-password-form")),
                                (t = e.closest(t)),
                                (a = t.parent().find(a)),
                                e.addClass("is-loading"),
                                t.slideUp(400, "easeInOutCubic", function () {
                                    n({}, t), a.slideDown(400, "easeInOutCubic"), e.removeClass("is-loading");
                                }),
                                !1
                            );
                        }),
                        c(".kt-reset-password-form").on("submit", function () {
                            const e = c(this),
                                a = e.find('input[name="mobile"]').val();
                            if (!c(this).hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (s) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_reset_password", mobile: a, token: s },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? e.slideUp(400, "easeInOutCubic", function () {
                                                        const t = e.parent().find(".kt-change-password-form"),
                                                            s = t.find("#reset-password-again");
                                                        n({}, e),
                                                            n(a, t),
                                                            e.removeClass("is-loading"),
                                                            e.parent().find(".kt-change-password-form").slideDown(400, "easeInOutCubic"),
                                                            s.addClass("button-dark clicked").removeClass("button-default"),
                                                            r(s, 60, "ارسال مجدد در %timer%", function () {
                                                                s.addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                            });
                                                    })
                                                    : n(a, e, function () {
                                                        e.removeClass("is-loading");
                                                    });
                                            },
                                            error: function () {
                                                e.removeClass("is-loading");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        c("#reset-password-again").on("click", function () {
                            const e = c(this),
                                a = e.closest(".kt-change-password-form"),
                                s = a.parent().find('input[name="mobile"]').val();
                            if (!e.hasClass("is-loading") && !e.hasClass("clicked"))
                                return (
                                    e.addClass("is-loading"),
                                    d(0, function (o) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_reset_password", mobile: s, token: o },
                                            success: function (s) {
                                                n(s, a, function () {
                                                    e.removeClass("is-loading");
                                                }),
                                                    t(s.errors) &&
                                                    (e.addClass("button-dark clicked").removeClass("button-default"),
                                                        r(e, 60, "ارسال مجدد در %timer%", function () {
                                                            e.addClass("button-default").removeClass("button-dark clicked").text("کد تایید را دریافت نکردید؟ ارسال مجدد");
                                                        }));
                                            },
                                            error: function () {
                                                e.removeClass("is-loading");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        void c(".kt-change-password-form").on("submit", function () {
                            const e = c(this),
                                a = e.parent().find(".kt-reset-password-form").find('input[name="mobile"]').val(),
                                s = e.find('input[name="verification_code"]').val(),
                                o = e.find('input[name="password"]').val(),
                                r = e.find('button[type="submit"]');
                            if (!r.hasClass("is-loading"))
                                return (
                                    r.addClass("is-loading"),
                                    d(0, function (l) {
                                        c.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            data: { action: "kt_ajax_change_password", mobile: a, verificationCode: s, password: o, token: l, options: i(e) },
                                            success: function (a) {
                                                t(a.errors)
                                                    ? a.url
                                                        ? (window.location = a.url)
                                                        : location.reload()
                                                    : n(a, e, function () {
                                                        r.removeClass("is-loading");
                                                    });
                                            },
                                            error: function () {
                                                r.removeClass("is-loading");
                                            },
                                        });
                                    }),
                                    !1
                                );
                        }),
                        void X(".consultation-form").on("submit", function () {
                            const e = X(this),
                                a = X(".course-single-advice").length ? "academy" : "normal",
                                s = e.find('input[name="name"]').val(),
                                o = e.find('input[name="phone"]').val(),
                                i = e.find('input[name="website"]').val(),
                                r = e.find('input[name="method"]:checked').val(),
                                l = e.find('select[name="course"]').val();
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    X.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_ajax_consultation", name: s, phone: o, website: i, contact_method: r, course: l, type: a },
                                        success: function (a) {
                                            !t(a.errors) && a.errors.duplicate
                                                ? n(
                                                    a.errors.duplicate,
                                                    e,
                                                    function () {
                                                        e.removeClass("is-loading");
                                                    },
                                                    "warning"
                                                )
                                                : n(a, e, function () {
                                                    e.removeClass("is-loading"), a.success && e.find('[name="name"], [name="phone"]').val("");
                                                });
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"), alert("مشکلی پیش آمد. لطفاً مجدداً تلاش کنید.");
                                        },
                                    }),
                                    !1
                                );
                        }),
                        void X(".contact-form").on("submit", function () {
                            const e = X(this),
                                t = e.find(".contact-form-errors"),
                                a = t.is(":empty") ? 0 : 400,
                                n = new FormData(this);
                            if (
                                (n.append("file", X(".contact-form-file").prop("files")[0]),
                                    n.append("name", e.find(".contact-form-name").val()),
                                    n.append("phone", e.find(".contact-form-phone").val()),
                                    n.append("action", "kt_ajax_contact"),
                                    n.append("email", e.find(".contact-form-email").val()),
                                    n.append("website", e.find(".contact-form-website").val()),
                                    n.append("text", e.find(".contact-form-text").val()),
                                    n.append("subject", e.find(".contact-form-subject").val()),
                                    !e.hasClass("is-loading"))
                            )
                                return (
                                    e.addClass("is-loading"),
                                    e.find(".contact-form-loading").fadeIn(200),
                                    X.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        contentType: !1,
                                        cache: !1,
                                        processData: !1,
                                        data: n,
                                        success: function (n) {
                                            (n = X(n)).length && "" !== n.html()
                                                ? t.slideUp(a, "easeInOutCubic", function () {
                                                    X(this).empty().append(n).slideDown(500, "easeInOutCubic");
                                                })
                                                : t.slideUp(a, "easeInOutCubic", function () {
                                                    X(this).empty();
                                                }),
                                                e.removeClass("is-loading"),
                                                e.find(".contact-form-loading").fadeOut(200);
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"), e.find(".contact-form-loading").fadeOut(200);
                                        },
                                    }),
                                    !1
                                );
                        }),
                        (function () {
                            X("#new-ticket-form-file").on("change", function () {
                                X("#new-ticket-form-file + label").text(X("#new-ticket-form-file").prop("files")[0].name);
                            });
                            const e = X(".product.type-product").length ? X(".product.type-product").attr("id").replace("product-", "") : "";
                            X(".new-ticket-form").on("submit", function () {
                                const t = X(this),
                                    a = t.find(".new-ticket-form-text").val(),
                                    n = t.find(".new-ticket-form-title").val(),
                                    s = t.find(".new-ticket-form-errors"),
                                    o = X("#new-ticket-noti").is(":checked"),
                                    i = s.is(":empty") ? 0 : 400,
                                    r = new FormData(this);
                                if (
                                    (r.append("file", X("#new-ticket-form-file").prop("files")[0]),
                                        r.append("action", "kt_ajax_new_ticket"),
                                        r.append("title", n),
                                        r.append("text", a),
                                        r.append("sms", o),
                                        r.append("post_id", e),
                                        !t.hasClass("is-loading"))
                                )
                                    return (
                                        t.addClass("is-loading"),
                                        t.find(".new-ticket-form-loading").fadeIn(200),
                                        X.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            contentType: !1,
                                            cache: !1,
                                            processData: !1,
                                            data: r,
                                            success: function (e) {
                                                (e = X(e)).is(".new-ticket-form-errors-inner")
                                                    ? s.slideUp(i, "easeInOutCubic", function () {
                                                        X(this).empty().append(e).slideDown(500, "easeInOutCubic");
                                                    })
                                                    : s.slideUp(i, "easeInOutCubic", function () {
                                                        window.location.href = e.text();
                                                    }),
                                                    t.removeClass("is-loading"),
                                                    t.find(".new-ticket-form-loading").fadeOut(200);
                                            },
                                            error: function () {
                                                t.removeClass("is-loading"), t.find(".new-ticket-form-loading").fadeOut(200);
                                            },
                                        }),
                                        !1
                                    );
                            });
                        })(),
                        g(),
                        O(),
                        H(),
                        (function () {
                            if (
                                (M(".google-ad-preview-limit input, .google-ad-preview-limit textarea").on("input", function () {
                                    const e = M(this).val().length,
                                        t = M(this).closest(".google-ad-preview-item"),
                                        a = parseInt(t.attr("data-limit")),
                                        n = t.find(".google-ad-preview-alert"),
                                        s = a - e,
                                        o = M(".gadp-" + M(this).attr("data-field"));
                                    n.text(s),
                                        s >= 0 ? n.removeClass("google-ad-preview-alert-red").addClass("google-ad-preview-alert-green") : n.removeClass("google-ad-preview-alert-green").addClass("google-ad-preview-alert-red"),
                                        o.length && o.text(M(this).val());
                                }),
                                    M(".google-ad-preview-callout input").on("input", function () {
                                        let e = [];
                                        M(".google-ad-preview-callout input").each(function () {
                                            M(this).val().length && e.push(M(this).val());
                                        }),
                                            e.length ? ((e = e.join(" · ")), M(".gadp-callouts").text(e)) : M(".gadp-callouts").text("");
                                    }),
                                    M(".google-ad-preview-snippets input").on("input", function () {
                                        $();
                                    }),
                                    M(".google-ad-preview-snippets select").on("change", function () {
                                        $();
                                    }),
                                    M(".google-ad-preview-sitelinks input").on("input", function () {
                                        let e = [];
                                        M(".google-ad-preview-sitelinks .google-ad-preview-limit input").each(function () {
                                            if (M(this).val().length) {
                                                const t = M('.google-ad-preview-sitelinks input[data-field="sitelink-url' + M(this).attr("data-number") + '"]').val();
                                                e.push('<a href="' + t + '">' + M(this).val() + "</a>");
                                            }
                                        }),
                                            e.length ? ((e = e.join(" · ")), M(".gadp-sitelinks").html(M(e))) : M(".gadp-sitelinks").text("");
                                    }),
                                    M('.google-ad-preview-item input[data-field="headline1"], .google-ad-preview-item input[data-field="headline2"], .google-ad-preview-item input[data-field="headline3"]').on("input", function () {
                                        const e = M('.google-ad-preview-item input[data-field="headline1"]').val(),
                                            t = M('.google-ad-preview-item input[data-field="headline2"]').val(),
                                            a = M('.google-ad-preview-item input[data-field="headline3"]').val(),
                                            n = e.length && t.length,
                                            s = a.length && (e.length || t.length),
                                            o = M(".gadp-title-line1"),
                                            i = M(".gadp-title-line2");
                                        n && o.hasClass("gadp-hide") ? o.removeClass("gadp-hide") : n || o.hasClass("gadp-hide") || o.addClass("gadp-hide"),
                                            s && i.hasClass("gadp-hide") ? i.removeClass("gadp-hide") : s || i.hasClass("gadp-hide") || i.addClass("gadp-hide");
                                    }),
                                    M(".google-ad-preview-final-url").on("input", function () {
                                        let e = M(this).val();
                                        M(".gadp-title").attr("href", e), e.indexOf("://") > -1 && (e = e.split("://")[1]), e.indexOf("/") > -1 && (e = e.split("/")[0]), M(".google-ad-preview-url-field").text(e + "/");
                                    }),
                                    M(".google-ad-preview-checkbox").on("change", function () {
                                        const e = M("." + M(this).attr("id")),
                                            t = M("." + M(this).attr("data-ui"));
                                        M(this).is(":checked") ? (e.stop(!0, !0).slideDown(450, "easeOutCubic"), t.removeClass("gadp-hide")) : (e.stop(!0, !0).slideUp(400, "easeOutCubic"), t.addClass("gadp-hide"));
                                    }),
                                    M(".google-ad-preview-url input, .google-ad-preview-final-url").on("input", function () {
                                        let e = [M(".google-ad-preview-url-field").text().replace("/", "")];
                                        M(".google-ad-preview-url input").each(function () {
                                            M(this).val().length && e.push(M(this).val());
                                        }),
                                            e.length && ((e = e.join("/")), M(".gadp-url").text(e));
                                    }),
                                    M(".gadp-share").on("click", function () {
                                        const e = M(this);
                                        if (!e.hasClass("is-loading"))
                                            return (
                                                e.addClass("is-loading"),
                                                M.ajax({
                                                    url: ktAjax.ajaxUrl,
                                                    type: "post",
                                                    data: { action: "kt_gadp_share", content: D() },
                                                    success: function (t) {
                                                        e.removeClass("is-loading"), M(".gadp-success-box, .gadp-error-box").remove(), M(".gadp-buttons").append(M(t));
                                                    },
                                                    error: function () {
                                                        e.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                                    },
                                                }),
                                                !1
                                            );
                                    }),
                                    M(".gadp-save").length)
                            ) {
                                const e = M(".gadp-save").attr("data-service");
                                M(".gadp-save").on("click", function () {
                                    const t = M(this);
                                    if (!t.hasClass("is-loading"))
                                        return (
                                            t.addClass("is-loading"),
                                            M.ajax({
                                                url: ktAjax.ajaxUrl,
                                                type: "post",
                                                data: { action: "kt_gadp_save", content: D(), service: e },
                                                success: function (e) {
                                                    t.removeClass("is-loading"), M(".gadp-success-box, .gadp-error-box").remove(), M(".gadp-buttons").append(M(e));
                                                },
                                                error: function () {
                                                    t.removeClass("is-loading"), alert("با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.");
                                                },
                                            }),
                                            !1
                                        );
                                });
                            }
                        })(),
                        M(".google-snippet-title").on("input change", function () {
                            let e = M(".google-snippet-title").val();
                            const t = M(".google-snippet-title-output");
                            let a = !1;
                            t.empty(),
                                (e = e.split(" ")),
                                M.each(e, function (e, n) {
                                    if (n.length > 0) {
                                        const e = document.createElement("span");
                                        (e.innerHTML = n), a && (e.className = "hidden"), t.append(e);
                                        let s = 5 * (t.outerHeight() / 18 - 1),
                                            o = Math.round(L(t) - s);
                                        o > 480 &&
                                            !a &&
                                            (t.find(":last-child").addClass("hidden"),
                                                t.append(M('<span class="dots">...</span>')),
                                                (s = 5 * (t.outerHeight() / 18 - 1)),
                                                (o = Math.round(E(t) - s)),
                                                o > 480 && t.find(":nth-last-child(3)").addClass("hidden"),
                                                (a = !0));
                                    }
                                });
                            const n = 5 * (t.outerHeight() / 18 - 1);
                            let s = L(t) - n;
                            (s = Math.round(s - (t.find(".dots").length ? 20 : ""))),
                                M(".google-snippet-limit-title span").text(s),
                                s > 480 ? M(".google-snippet-limit-title").addClass("google-snippet-limit-error") : M(".google-snippet-limit-title").removeClass("google-snippet-limit-error"),
                                t.find(".hidden").remove();
                        }),
                        M(".google-snippet-desc, .google-snippet-search-query").on("input change", function () {
                            let e = M(".google-snippet-desc").val();
                            const t = M(".google-snippet-desc-output"),
                                a = M(".google-snippet-search-query").val().split(" ");
                            let n = !1;
                            t.empty(),
                                (e = e.split(" ")),
                                M.each(e, function (e, s) {
                                    if (s.length > 0) {
                                        let e;
                                        (e = -1 !== M.inArray(s, a) ? document.createElement("b") : document.createElement("span")), n && (e.className = "hidden"), (e.innerHTML = s), t.append(e);
                                        let o = 3.5 * (t.outerHeight() / 18 - 1),
                                            i = Math.round(L(t) - o);
                                        i > 750 &&
                                            !n &&
                                            (t.find(":last-child").addClass("hidden"),
                                                t.append(M('<span class="dots">...</span>')),
                                                (o = 3.5 * (t.outerHeight() / 18 - 1)),
                                                (i = Math.round(E(t) - o)),
                                                i > 750 && t.find(":nth-last-child(3)").addClass("hidden"),
                                                (n = !0));
                                    }
                                });
                            const s = 3.5 * (t.outerHeight() / 18 - 1);
                            let o = L(t) - s;
                            (o = Math.round(o - (t.find(".dots").length ? 14.5 : 0))),
                                M(".google-snippet-limit-desc span").text(o),
                                o > 750 ? M(".google-snippet-limit-desc").addClass("google-snippet-limit-error") : M(".google-snippet-limit-desc").removeClass("google-snippet-limit-error"),
                                t.find(".hidden").remove();
                        }),
                        M(".google-snippet-url").on("input", function () {
                            let e = M(this).val();
                            "" !== e && (M(".google-snippet-title-output, .google-snippet-url-output").attr("href", e), e.indexOf("://") > -1 && (e = e.split("://")[1]), M(".google-snippet-url-output").text(e));
                        }),
                        void M(".google-snippet-url-submit").on("click", function () {
                            if (M(this).hasClass("is-loading")) return;
                            const e = M(this),
                                t = M(".google-snippet-url").val();
                            "" !== t &&
                                (e.addClass("is-loading"),
                                    M.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_get_snippet", url: t },
                                        success: function (t) {
                                            (t = JSON.parse(t)), M(".google-snippet-title").val(t.title), M(".google-snippet-desc").val(t.desc), M(".google-snippet-title, .google-snippet-desc").change(), e.removeClass("is-loading");
                                        },
                                        error: function () {
                                            e.removeClass("is-loading");
                                        },
                                    }));
                        }),
                        (function () {
                            if (x(".course-free-download").length) {
                                const e = x(".course-free-download"),
                                    t = e.attr("data-product-id");
                                e.on("click", function () {
                                    if (!e.hasClass("is-loading"))
                                        return (
                                            e.addClass("is-loading"),
                                            x.ajax({
                                                url: ktAjax.ajaxUrl,
                                                type: "post",
                                                data: { action: "kt_course_free_download", product_id: t },
                                                success: function (t) {
                                                    (window.location = t), e.removeClass("is-loading");
                                                },
                                                error: function () {
                                                    e.removeClass("is-loading"), alert("مشکلی در دریافت فایل پیش آمده است. لطفاً مجدداً تلاش کنید.");
                                                },
                                            }),
                                            !1
                                        );
                                });
                            }
                        })(),
                        (function () {
                            const e = x("#banner-type").val();
                            x(".affiliate-banner-holder").removeClass("active"),
                                x('.affiliate-banner-holder[data-id="' + e + '"]').addClass("active"),
                                x(".affiliate-banner-holder select").each(function () {
                                    const e = x(this).val(),
                                        t = x(this).closest(".affiliate-banner-holder");
                                    t.find(".affiliate-banner").removeClass("active"), t.find('.affiliate-banner[data-id="' + e + '"]').addClass("active");
                                }),
                                x("#banner-type").on("change", function () {
                                    const e = x(this).val();
                                    x(".affiliate-banner-holder").removeClass("active"), x('.affiliate-banner-holder[data-id="' + e + '"]').addClass("active");
                                }),
                                x(".affiliate-banner-holder select").on("change", function () {
                                    const e = x(this).val(),
                                        t = x(this).closest(".affiliate-banner-holder");
                                    t.find(".affiliate-banner").removeClass("active"), t.find('.affiliate-banner[data-id="' + e + '"]').addClass("active");
                                });
                        })(),
                        (function () {
                            F(".profile-rules-button-holder .button").on("click", function () {
                                return (
                                    !!F("#profile-rules").is(":checked") &&
                                    (F(".profile-settings-rules").remove(), F(".modify-profile-form").removeClass("d-none"), F("html, body").scrollTop(F(".panel-content-holder").offset().top - 40), !1)
                                );
                            }),
                                F("#profile-rules").on("change", function () {
                                    const e = F(".profile-rules-button-holder .button");
                                    F(this).is(":checked") ? e.prop("disabled", !1) : e.prop("disabled", !0);
                                }),
                                F(".profile-renew-item").on("click", function () {
                                    if (F(this).hasClass("active")) return;
                                    F(".profile-renew-item").removeClass("active"), F(this).addClass("active");
                                    const e = F(".profile-renew-button");
                                    return e.attr("href", `${e.attr("data-url")}?add-to-cart=${F(this).attr("data-id")}`), F(".profile-renew-total").text(parseInt(F(this).attr("data-price")).toLocaleString()), !1;
                                }),
                                F(".modify-profile-form").length &&
                                    window.history.state ?.success &&
                                    !F(".modify-profile-form .kt-form-errors-inner").length &&
                                    (F(".modify-profile-form .kt-form-errors").append(F(`<div class="kt-form-errors-inner success">${window.history.state.success}</div>`)), window.history.pushState(null, "")),
                                F(".expert-profile-gallery-showmore").on("click", function () {
                                    F(this).closest(".expert-profile-gallery").addClass("active"), F(this).parent().remove();
                                }),
                                F(".profile-settings-list button").on("click", function () {
                                    F(this).hasClass("selected") ? F(this).removeClass("selected") : F(this).addClass("selected");
                                }),
                                (window.ktFiles = []),
                                F(".modify-profile-form #expert-avatar").on("change", async function () {
                                    const e = F(this).prop("files")[0];
                                    let t = F("#avatar").attr("data-default");
                                    e &&
                                        (t = await new Promise((t) => {
                                            const a = new FileReader();
                                            a.readAsDataURL(e),
                                                (a.onload = ({ target: e }) => {
                                                    t(e.result);
                                                });
                                        })),
                                        F("#avatar img").attr("src", t);
                                }),
                                F('.modify-profile-form input[name="portfolio"]').on("change", async function () {
                                    (window.ktFiles = [...Array.from(F(this).prop("files")), ...window.ktFiles]), F(this).val("");
                                    const e = [];
                                    for (const t of window.ktFiles) {
                                        const a = await new Promise((e) => {
                                            const a = new FileReader();
                                            a.readAsDataURL(t),
                                                (a.onload = ({ target: t }) => {
                                                    e(t.result);
                                                });
                                        });
                                        let n = "";
                                        (n = ["image/gif", "image/jpeg", "image/png"].includes(t.type.toLowerCase()) ? `<img src="${a}"/>` : `<video><source src="${a}" type="${t.type}"></video>`),
                                            e.push(F(`<div class="column new"><div class="profile-settings-portfolio-item">${n}<button type="button" class="fa fa-trash-o"></button></div></div>`));
                                    }
                                    F(".profile-settings-portfolio .new").remove(), F(".profile-settings-portfolio .row").prepend(e).prepend(F("#portfolio").parent());
                                }),
                                F("body").on("click", ".profile-settings-portfolio-item button", function () {
                                    const e = F(this).closest(".column");
                                    if (e.hasClass("new")) {
                                        const t = F(".profile-settings-portfolio .row .new").index(e);
                                        window.ktFiles.splice(t, 1);
                                    }
                                    F(this).closest(".column").remove();
                                }),
                                F(".modify-profile-form").on("submit", function () {
                                    const e = F(this);
                                    if (e.hasClass("is-loading")) return !1;
                                    const a = new FormData(this);
                                    a.delete("portfolio"),
                                        a.append("action", "kt_ajax_modify_profile"),
                                        a.append("name", e.find('input[name="name"]').val()),
                                        a.append("job_title", e.find('input[name="job_title"]').val()),
                                        a.append("avatar", e.find('input[name="avatar_file"]').prop("files")[0]);
                                    for (let e = 0; e < window.ktFiles.length; e++) a.append("portfolio_" + e, window.ktFiles[e]);
                                    return (
                                        a.append("about", e.find('textarea[name="about"]').val()),
                                        a.append(
                                            "portfolio",
                                            e
                                                .find(".profile-settings-portfolio .column:not(.new) .profile-settings-portfolio-item")
                                                .find("video source,img")
                                                .map(function () {
                                                    return F(this).attr("src");
                                                })
                                                .get()
                                                .join(",")
                                        ),
                                        a.append("mobile", e.find('input[name="mobile"]').val()),
                                        a.append("whatsapp", e.find('input[name="whatsapp"]').val()),
                                        a.append("telegram", e.find('input[name="telegram"]').val()),
                                        a.append("instagram", e.find('input[name="instagram"]').val()),
                                        a.append(
                                            "skills",
                                            e
                                                .find("#skills-list button.selected")
                                                .map(function () {
                                                    return parseInt(F(this).attr("data-id"));
                                                })
                                                .get()
                                                .join(",")
                                        ),
                                        a.append(
                                            "contracts",
                                            e
                                                .find("#contracts-list button.selected")
                                                .map(function () {
                                                    return parseInt(F(this).attr("data-id"));
                                                })
                                                .get()
                                                .join(",")
                                        ),
                                        a.append("location", e.find('select[name="location"]').val()),
                                        a.append("salary", e.find('input[name="salary"]').val()),
                                        a.append("is_active", e.find('input[name="is_active"]').is(":checked")),
                                        a.append("is_available", e.find('input[name="is_available"]').is(":checked")),
                                        a.append(
                                            "projects",
                                            JSON.stringify(
                                                e
                                                    .find(".profile-settings-projects-item")
                                                    .map(function () {
                                                        return {
                                                            title: F(this).find('[id*="project_job_title_"]').val() || "",
                                                            employer: F(this).find('[id*="project_employer_"]').val() || "",
                                                            text: F(this).find('[id*="project_text_"]').val() || "",
                                                            url: F(this).find('[id*="project_url_"]').val() || "",
                                                        };
                                                    })
                                                    .get()
                                            )
                                        ),
                                        e.addClass("is-loading"),
                                        F.ajax({
                                            url: ktAjax.ajaxUrl,
                                            type: "post",
                                            contentType: !1,
                                            cache: !1,
                                            processData: !1,
                                            data: a,
                                            success: function (a) {
                                                if (t(a.errors)) return window.history.replaceState({ success: a.success }, "", window.location.href), void window.location.reload();
                                                F(".profile-settings-projects-item").removeClass("is-invalid");
                                                for (const e in a.errors) /^project_.+?_\d+$/.test(e) && F(`#${e}`).closest(".profile-settings-projects-item").addClass("active is-invalid");
                                                n(a, e, function () {
                                                    e.removeClass("is-loading");
                                                    const t = e.find(".kt-form-errors-inner, .field-error").first().closest(".kt-form-errors, .column").offset().top,
                                                        a = t > window.innerHeight - F(".menu-holder").outerHeight() ? F(".menu-holder").outerHeight() : 0;
                                                    F("html, body").scrollTop(t - a - 15);
                                                });
                                            },
                                            error: function () {
                                                e.removeClass("is-loading"), alert("مشکلی پیش آمد. لطفاً مجدداً تلاش کنید.");
                                            },
                                        }),
                                        !1
                                    );
                                }),
                                F("body").on("click", ".profile-settings-projects-item .icon_pencil-edit", function () {
                                    const e = F(this).closest(".profile-settings-projects-item");
                                    e.hasClass("active") ? e.removeClass("active") : e.addClass("active");
                                });
                            const e = () => {
                                F(".profile-settings-projects-item").each(function (e) {
                                    F(this)
                                        .find('[id*="project_"]')
                                        .each(function () {
                                            F(this).attr("id", F(this).attr("id").replace(/_\d$/, `_${e}`));
                                        }),
                                        F(this)
                                            .find('[for*="project_"]')
                                            .each(function () {
                                                F(this).attr("for", F(this).attr("for").replace(/_\d$/, `_${e}`));
                                            });
                                });
                            };
                            F("body").on("click", ".profile-settings-projects-item .arrow_carrot-up, .profile-settings-projects-item .arrow_up", function () {
                                const t = F(this).closest(".profile-settings-projects-item"),
                                    a = t.prev(".profile-settings-projects-item");
                                a.length && (t.insertBefore(a), e());
                            }),
                                F("body").on("click", ".profile-settings-projects-item .arrow_carrot-down, .profile-settings-projects-item .arrow_down", function () {
                                    const t = F(this).closest(".profile-settings-projects-item"),
                                        a = t.next(".profile-settings-projects-item");
                                    a.length && (t.insertAfter(a), e());
                                }),
                                F("body").on("click", ".profile-settings-projects-item .fa-trash-o", function () {
                                    const t = F(this).closest(".profile-settings-projects-item");
                                    window.confirm("آیا مطمئنید؟ این عمل قابل بازگشت نمیباشد.") && (t.remove(), e());
                                }),
                                F(".profile-settings-projects").on("input keydown paste change", '.profile-settings-projects-item [id*="project_job_title_"]', function () {
                                    F(this)
                                        .closest(".profile-settings-projects-item")
                                        .find(".profile-settings-projects-item-title")
                                        .text(F(this).val() || "وارد نشده");
                                }),
                                F(".profile-settings-projects").on("input keydown paste change", '.profile-settings-projects-item [id*="project_employer_"]', function () {
                                    F(this)
                                        .closest(".profile-settings-projects-item")
                                        .find(".profile-settings-projects-item-employer")
                                        .text(F(this).val() || "وارد نشده");
                                }),
                                F(".profile-settings-new-project").on("click", function () {
                                    const e = F(".profile-settings-projects-item").length || 0;
                                    F(".profile-settings-projects").append(
                                        F(
                                            `<div class="profile-settings-projects-item active"><div class="profile-settings-projects-item-header"><div class="profile-settings-projects-item-handle"><button type="button" class="elegant-icon arrow_carrot-up"></button><button type="button" class="elegant-icon arrow_carrot-down"></button></div><div class="profile-settings-projects-item-header-inner"><span class="profile-settings-projects-item-title">وارد نشده</span><span class="profile-settings-projects-item-employer">وارد نشده</span></div><div class="profile-settings-projects-item-actions"><button type="button" class="elegant-icon arrow_up"></button><button type="button" class="elegant-icon arrow_down"></button><button type="button" class="elegant-icon icon_pencil-edit"></button><button type="button" class="fa fa-trash-o"></button></div></div><div class="profile-settings-projects-item-content"><div class="row"><div class="column kt-col-xs-12 kt-col-sm-6"><label for="project_job_title_${e}">عنوان شغلی <span class="required">*</span></label><input type="text" id="project_job_title_${e}"></div><div class="column kt-col-xs-12 kt-col-sm-6"><label for="project_employer_${e}">نام کارفرما <span class="required">*</span></label><input type="text" id="project_employer_${e}"></div><div class="column kt-col-xs-12"><label for="project_text_${e}">توضیحات <span class="required">*</span></label><textarea id="project_text_${e}" rows="3"></textarea></div><div class="column kt-col-xs-12"><label for="project_url_${e}">لینک مشاهده آنلاین (اختیاری)</label><input type="text" id="project_url_${e}" class="dir-ltr text-right"></div></div></div></div>`
                                        )
                                    );
                                });
                        })(),
                        (function () {
                            F(".expert-review-services button").on("click", function () {
                                F(this).hasClass("selected") ? F(this).removeClass("selected") : F(this).addClass("selected");
                            });
                            const e = F(".kt-expert-review-form").attr("data-id");
                            F(".kt-expert-review-form").on("submit", function () {
                                const a = F(this);
                                if (a.hasClass("is-loading")) return;
                                const s = a.find(".review-form-stars button.active").length ? a.find(".review-form-stars button.active").attr("data-star") : 0,
                                    o = a.find('[name="comment"]').val(),
                                    i = a
                                        .find(".expert-review-services button.selected")
                                        .map(function () {
                                            return parseInt(F(this).attr("data-id"));
                                        })
                                        .get()
                                        .join(",");
                                return (
                                    a.addClass("is-loading"),
                                    F.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_ajax_expert_review", expert_id: e, text: o, rating: s, services: i },
                                        success: function (e) {
                                            !t(e.errors) && e.errors.duplicate
                                                ? n(
                                                    e.errors.duplicate,
                                                    a,
                                                    function () {
                                                        a.removeClass("is-loading"),
                                                            a.find('[name="comment"]').val(""),
                                                            a.find(".expert-review-services button").removeClass("selected"),
                                                            a.find(".review-form-stars").removeClass("selected").find("button").removeClass("active");
                                                    },
                                                    "warning"
                                                )
                                                : n(e, a, function () {
                                                    a.removeClass("is-loading"),
                                                        e.success &&
                                                        (a.find('[name="comment"]').val(""),
                                                            a.find(".expert-review-services button").removeClass("selected"),
                                                            a.find(".review-form-stars").removeClass("selected").find("button").removeClass("active"));
                                                });
                                        },
                                        error: function () {
                                            a.removeClass("is-loading");
                                        },
                                    }),
                                    !1
                                );
                            });
                        })(),
                        N(),
                        X(".price-format-field").each(function () {
                            v(X(this));
                        }),
                        X(".price-format-field").on("change input keydown paste", function () {
                            v(X(this));
                        }),
                        X(".comment-form-rating .review-form-stars").length &&
                        X(".comment-form-rating .review-form-stars button").on("click", function () {
                            return (
                                X(".comment-form-rating .review-form-stars").hasClass("selected") || X(".comment-form-rating .review-form-stars").addClass("selected"),
                                X(".comment-form-rating .review-form-stars button").removeClass("active"),
                                X(this).addClass("active"),
                                !1
                            );
                        });
                    X(".affiliate-banner-code button").on("click", function () {
                        const e = X(this);
                        return (
                            s(e.parent().find("pre code").text()),
                            X(".affiliate-banner-code button").removeClass("active"),
                            e.addClass("active"),
                            clearTimeout(e.data("timeout") || null),
                            e.data(
                                "timeout",
                                setTimeout(function () {
                                    e.removeClass("active");
                                }, 3e3)
                            ),
                            !1
                        );
                    }),
                        X(".campaign-item").on("click", function () {
                            const e = X(this);
                            e.hasClass("active") ||
                                (X(".campaign-item, .campaign-content-holder .campaign-content").removeClass("active"),
                                    e.addClass("active"),
                                    X('.campaign-content-holder .campaign-content[data-id="' + e.attr("data-id") + '"]').addClass("active"));
                        }),
                        X(".show-more-btn").on("click", function () {
                            const e = X(this),
                                t = X(e.attr("data-target")),
                                a = e.attr("data-text") || "مشاهده همه",
                                n = e.attr("data-open-text") || "بستن",
                                s = "1" === e.attr("data-remove");
                            e.hasClass("is-active") ? (e.removeClass("is-active").text(a), t.removeClass("active")) : (s ? e.remove() : e.addClass("is-active").text(n), t.addClass("active"));
                        }),
                        X(".blog-cat-box-holder").length && new PerfectScrollbar(".blog-cat-box-holder", { wheelPropagation: !0, suppressScrollX: !0, wheelSpeed: 0.7 });
                    X(".blog-academy-box-close").on("click", function () {
                        const e = X(this).closest(".blog-academy-box");
                        return (
                            o("remove_" + e.attr("data-id") + "_box", "yes"),
                            e.stop(!0, !0).fadeOut(300, "easeOutCubic", function () {
                                X(this).remove();
                            }),
                            !1
                        );
                    }),
                        X(".kt-spoiler-button").on("click", function () {
                            const e = X(this).parent().find(".kt-spoiler-inner");
                            return (
                                X(this).fadeOut(300, "easeInOutCubic", function () {
                                    X(this).remove();
                                }),
                                e.slideDown(700, "easeInOutCubic"),
                                !1
                            );
                        }),
                        X(".dashboard-welcome-close").on("click", function () {
                            o("removeDashboardWelcome", "yes"),
                                X(".dashboard-welcome-box")
                                    .stop(!0, !0)
                                    .slideUp(700, "easeInOutCubic", function () {
                                        X(this).remove();
                                    });
                        }),
                        X(".kt-notice-close").on("click", function () {
                            const e = X(".kt-notice-outer");
                            o("remove_" + e.attr("data-id"), "yes"),
                                e.stop(!0, !0).slideUp(400, "easeInOutCubic", function () {
                                    X(this).remove();
                                });
                        }),
                        X(".typing-text-holder").length &&
                        X(".typing-text-holder").each(function () {
                            const e = X(this).data("strings") ? X(this).data("strings") : "";
                            X(this).typed({ strings: e.split("|"), typeSpeed: 40, backSpeed: 2, shuffle: !1, backDelay: 1500, loop: !0, loopCount: !0 });
                        });
                    X(".panel-menu-button").on("click", function () {
                        X(this).hasClass("active")
                            ? (X(".panel-responsive-menu").stop(!0, !0).slideUp(400, "easeOutCubic"), X(this).removeClass("active"))
                            : (X(".panel-responsive-menu").stop(!0, !0).slideDown(450, "easeOutCubic"), X(this).addClass("active"));
                    }),
                        X(".blog-note-expend").on("click", function () {
                            const e = X(this).parent().find(".blog-note-text");
                            return (
                                X(this).hasClass("expended")
                                    ? (X(this).removeClass("expended").text("مشاهده ادامه یادداشت"), e.stop(!0, !0).animate({ height: 180 }, 350, "easeOutCubic"))
                                    : (X(this).addClass("expended").text("بستن"), e.stop(!0, !0).animate({ height: e.find(".blog-note-text-inner").outerHeight() }, 400, "easeOutCubic")),
                                !1
                            );
                        }),
                        X(".column .blog-note-text").length &&
                        X(".column .blog-note-text").each(function () {
                            X(window).outerWidth() > 767 && new PerfectScrollbar(this, { wheelPropagation: !0, suppressScrollX: !0, wheelSpeed: 0.36 });
                        });
                    X(".wpmlr_input_container").length && (X(".wpmlr_input_name").attr("placeholder", "نام و نام خانوادگی"), X(".wpmlr_input_email").attr("placeholder", "پست الکترونیکی"));
                    X(".menu-holder .menu .menu-item.menu-item-style-normal, .menu-holder .menu .menu-item.menu-item-style-normal .menu-item").hover(
                        function () {
                            X(this).find(".sub-menu").first().stop(!0, !0).delay(100).fadeIn(200);
                        },
                        function () {
                            X(this).find(".sub-menu").first().stop(!0, !0).delay(100).fadeOut(150);
                        }
                    ),
                        X(".header-user-area-list").length &&
                        (X(".header-user-area").hover(
                            function () {
                                window.innerWidth < 992 || (b(), X(".header-user-area-list").stop(!0, !0).delay(100).fadeIn(200));
                            },
                            function () {
                                X(".header-user-area-list").stop(!0, !0).delay(100).fadeOut(150);
                            }
                        ),
                            X(".header-user-area").on("click", function () {
                                if (window.innerWidth >= 992) return !0;
                                X(".responsive-menu-overlay").css("visibility", "visible"), X("html").addClass("responsive-menu-opened user-menu-opened"), X(this).addClass("active");
                                const e = X(".responsive-menu-overlay").data("timeout") || 0;
                                return clearTimeout(e), !1;
                            }));
                    X(".menu-holder .menu .menu-item.menu-item-style-mega-menu").hover(
                        function () {
                            X(this).find(".kt-mega-menu-holder").stop(!0, !0).delay(100).fadeIn(200);
                        },
                        function () {
                            X(this).find(".kt-mega-menu-holder").stop(!0, !0).delay(100).fadeOut(150);
                        }
                    ),
                        X(".comment-open-button").on("click", function () {
                            return X(".comment-form-outer").stop(!0, !0).slideDown(500, "easeOutCubic"), X(this).stop(!0, !0).fadeOut(300, "easeOutCubic"), !1;
                        }),
                        X(".ticket-single-reply-button").on("click", function () {
                            return X(".ticket-single-form-holder").stop(!0, !0).slideDown(500, "easeOutCubic"), X(this).stop(!0, !0).fadeOut(300, "easeOutCubic"), !1;
                        }),
                        X(document).on("click", "a.load-more-posts", function () {
                            const e = X(this);
                            let t;
                            if ((e.hasClass("portfolio-load-more-posts") ? (t = "portfolio") : e.hasClass("courses-load-more-posts") && (t = "courses"), e.hasClass("is-loading"))) return;
                            e.addClass("is-loading ajax-pagination-fade-out"), X("." + t + "-items-outer .ajax-pagination-loading").addClass("ajax-pagination-fade-in");
                            const a = new XMLHttpRequest();
                            return (
                                a.open("GET", X(this).attr("data-url")),
                                a.addEventListener("loadend", function () {
                                    const a = document.createElement("html");
                                    a.innerHTML = this.responseText;
                                    const n = X("." + t + "-items-holder", a);
                                    n.waitForImages(function () {
                                        X("." + t + "-items-outer ." + t + "-items-holder")
                                            .isotope("insert", X(n.html()))
                                            .isotope("layout")
                                            .ktLazyLoad(),
                                            g(),
                                            setTimeout(function () {
                                                X("." + t + "-items-outer ." + t + "-items-holder").isotope("layout");
                                            }, 100),
                                            X("a.portfolio-load-more-posts", a).length
                                                ? (e.attr("data-url", X("a.load-more-posts", a).attr("data-url")), X(".ajax-pagination-loading").removeClass("ajax-pagination-fade-in"), e.removeClass("is-loading ajax-pagination-fade-out"))
                                                : (X(".pagination-holder").css("height", X(".ajax-pagination-inner").outerHeight()),
                                                    X(".ajax-pagination-inner").fadeOut(200, function () {
                                                        X(this).remove(), X(".pagination-holder").slideUp(200);
                                                    }));
                                    });
                                }),
                                a.send(),
                                !1
                            );
                        }),
                        X(document).on("click", "a.load-more-notes", function () {
                            const e = X(this);
                            if (e.hasClass("is-loading")) return;
                            e.addClass("is-loading ajax-pagination-fade-out"), X(".blog-page-notes .ajax-pagination-loading").addClass("ajax-pagination-fade-in");
                            const t = new XMLHttpRequest();
                            return (
                                t.open("GET", X(this).attr("data-url")),
                                X(".blog-page-notes").css("height", X(".blog-page-notes").outerHeight()),
                                t.addEventListener("loadend", function () {
                                    const t = document.createElement("html");
                                    t.innerHTML = this.responseText;
                                    const a = X(".blog-page-notes-inner", t);
                                    let n = 0;
                                    a.find(".blog-page-note").each(function () {
                                        if (X(this).hasClass("active")) X(this).remove();
                                        else {
                                            X(this).addClass("post-hide");
                                            const e = n / 10;
                                            e > 0 && X(this).css("animation-delay", e + "s"), n++;
                                        }
                                    }),
                                        X(".blog-page-notes .blog-page-notes-inner").append(X(a.html())),
                                        X(".blog-page-notes").css("height", X(".blog-page-notes-inner").outerHeight() + X(".blog-page-notes .pagination-holder").outerHeight()),
                                        setTimeout(function () {
                                            X(".blog-page-notes").css("height", "auto");
                                        }, 500),
                                        X(".blog-page-notes a.load-more-notes", t).length
                                            ? (e.attr("data-url", X(".blog-page-notes a.load-more-notes", t).attr("data-url")),
                                                X(".blog-page-notes .ajax-pagination-loading").removeClass("ajax-pagination-fade-in"),
                                                e.removeClass("is-loading ajax-pagination-fade-out"))
                                            : (X(".blog-page-notes .pagination-holder").css("height", X(".blog-page-notes .ajax-pagination-inner").outerHeight()),
                                                X(".blog-page-notes .ajax-pagination-inner").fadeOut(200, function () {
                                                    X(this).remove(), X(".blog-page-notes .pagination-holder").slideUp(200);
                                                }));
                                }),
                                t.send(),
                                !1
                            );
                        }),
                        X(document).on("click", function () {
                            X(".courses-filter-options").fadeOut(100), X(".courses-filter-label").removeClass("active");
                        }),
                        X(".courses-type").each(function () {
                            const e = X(this),
                                t = e.find("a"),
                                a = e.find("input");
                            t.on("click", function () {
                                return (
                                    X(this).hasClass("active")
                                        ? (t.removeClass("active"), X(this).addClass("active"), a.val(X(this).attr("data-filter-type")))
                                        : (X(this).addClass("active"), a.val(X(this).attr("data-filter-type")), e.find("a.active").length > 1 && a.val("")),
                                    I(),
                                    !1
                                );
                            });
                        }),
                        X(".courses-filter").each(function () {
                            const e = X(this),
                                t = e.find(".courses-filter-label"),
                                a = e.find(".courses-filter-options a");
                            t.on("click", function (t) {
                                t.stopPropagation(),
                                    X(this).hasClass("active")
                                        ? (e.find(".courses-filter-options").fadeOut(100), X(this).removeClass("active"))
                                        : (X(".courses-filter-options").fadeOut(100), X(".courses-filter-label").removeClass("active"), e.find(".courses-filter-options").fadeIn(150), X(this).addClass("active"));
                            }),
                                a.on("click", function () {
                                    const n = X(this).find("input"),
                                        s = [];
                                    return (
                                        n.is(":checked") ? n.prop("checked", !1) : n.prop("checked", !0),
                                        a.find("input:checked").each(function () {
                                            s.push(X(this).val());
                                        }),
                                        e.attr("data-value", s.join(",")),
                                        I(),
                                        t.removeClass("active"),
                                        e.find(".courses-filter-options").fadeOut(100),
                                        !1
                                    );
                                });
                        }),
                        X(".header-search-content .search-field").keyup(function () {
                            const e = X(this);
                            e.parents(".header-search-content").addClass("is-loading");
                            let t = e.data("timeout") || 0;
                            clearTimeout(t),
                                (t = setTimeout(function () {
                                    S(e.val());
                                }, 800)),
                                e.data("timeout", t);
                        }),
                        X(".search-form").each(function () {
                            const e = X(this),
                                t = e.find(".search-field"),
                                a = e.find(".search-remove-value");
                            t.keyup(function () {
                                X(this).val().length > 1 ? a.addClass("active") : a.removeClass("active");
                            }),
                                a.on("click", function () {
                                    t.val(""), X(this).removeClass("active"), S("");
                                });
                        }),
                        X(document).on("click", function () {
                            X(".header-search-content, .header-search-button").removeClass("active"),
                                setTimeout(function () {
                                    X(".header-search-content").css("display", "none");
                                }, 300),
                                X(".blog-header-filters-holder").fadeOut(150),
                                X(".blog-header-filters .button, .blog-header-filters").removeClass("active"),
                                b();
                        }),
                        X(".blog-header-filters > .button").on("click", function (e) {
                            return (
                                e.stopPropagation(),
                                X(".header-search-content, .header-search-button").removeClass("active"),
                                setTimeout(function () {
                                    X(".header-search-content").css("display", "none");
                                }, 300),
                                X(this).hasClass("active")
                                    ? (X(".blog-header-filters-holder").fadeOut(200), X(".blog-header-filters > .button, .blog-header-filters").removeClass("active"))
                                    : (X(".blog-header-filters-holder").fadeIn(250), X(".blog-header-filters > .button, .blog-header-filters").addClass("active")),
                                !1
                            );
                        }),
                        X(".blog-header-filters form").on("submit", function () {
                            return (
                                X(this)
                                    .find("select")
                                    .filter(function () {
                                        return !this.value;
                                    })
                                    .attr("disabled", "disabled"),
                                !0
                            );
                        }),
                        X(".header-search-button").on("click", function (e) {
                            return (
                                e.stopPropagation(),
                                X(".blog-header-filters-holder").fadeOut(200),
                                X(".blog-header-filters .button, .blog-header-filters").removeClass("active"),
                                X(this).hasClass("active")
                                    ? (X(this).removeClass("active"),
                                        X(".header-search-content").removeClass("active"),
                                        setTimeout(function () {
                                            X(".header-search-content").css("display", "none");
                                        }, 300))
                                    : (X(this).addClass("active"),
                                        X(".header-search-content").css("display", "block"),
                                        setTimeout(function () {
                                            X(".header-search-content").addClass("active");
                                        }, 10),
                                        X(".header-search-content .search-field").focus()),
                                !1
                            );
                        }),
                        X(".header-search-content,.blog-header-filters-holder").on("click", function (e) {
                            e.stopPropagation();
                        }),
                        X(".blog-note-share").on("click", function () {
                            X(this)
                                .stop(!0, !0)
                                .fadeOut(150, "easeOutCubic", function () {
                                    X(this).parent().find(".blog-note-share-icons").fadeIn(150, "easeOutCubic");
                                });
                        }),
                        X(document).on("click", ".kt-modal-button", function () {
                            const e = X(".kt-" + X(this).attr("data-modal") + "-modal");
                            return (
                                e.length &&
                                (X(this).hasClass("kt-login-button") &&
                                    (X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(2), .kt-modal-tabs .tabs-title-holder .tab-title:nth-child(2)").removeClass("active"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(2) .tab-content-inner").css("opacity", "0"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(1), .kt-modal-tabs .tabs-title-holder .tab-title:nth-child(1)").addClass("active"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(1) .tab-content-inner").css("opacity", "1")),
                                    X(this).hasClass("kt-register-button") &&
                                    (X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(1), .kt-modal-tabs .tabs-title-holder .tab-title:nth-child(1)").removeClass("active"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(1) .tab-content-inner").css("opacity", "0"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(2), .kt-modal-tabs .tabs-title-holder .tab-title:nth-child(2)").addClass("active"),
                                        X(".kt-modal-tabs .tabs-content-holder .tabs-content-inner .tab-content:nth-child(2) .tab-content-inner").css("opacity", "1")),
                                    X(this).attr("data-options") && e.attr("data-options", X(this).attr("data-options")),
                                    X(".kt-modal-outer-holder").addClass(X(this).attr("data-modal-outer")),
                                    X("html").addClass("kt-modal-opened"),
                                    X(".kt-modal-outer-holder").css("visibility", "visible").addClass("active"),
                                    e.css({ position: "relative", left: "0" }).addClass("active")),
                                !1
                            );
                        }),
                        X(document).on("click", ".kt-modal-close, .kt-modal-inner .close, .kt-modal-overlay, .kt-modal-transparent-overlay", function () {
                            X(".kt-modal-outer-holder, .kt-modal-inner").removeClass("active"),
                                X("html").removeClass("kt-modal-opened"),
                                setTimeout(function () {
                                    X(".kt-modal-outer-holder").css("visibility", "hidden"),
                                        X(".kt-modal-inner").css({ position: "absolute", left: "-10000px" }).attr("data-options", null),
                                        (X(".kt-modal-outer-holder")[0].className = "kt-modal-outer-holder");
                                }, 450);
                        }),
                        setInterval(function () {
                            G();
                        }, 10),
                        X(".header-minicart-holder").hover(
                            function () {
                                b(), X(".header-minicart-content").stop(!0, !0).delay(100).fadeIn(200);
                            },
                            function () {
                                X(".header-minicart-content").stop(!0, !0).delay(100).fadeOut(150);
                            }
                        ),
                        X(".header-search").on("click", function (e) {
                            e.stopPropagation();
                        }),
                        X(".header-search-btn").on("click", function () {
                            X(this).hasClass("active")
                                ? b()
                                : (X(this).addClass("active"),
                                    X(".header-search-form-holder")
                                        .stop(!0, !0)
                                        .delay(100)
                                        .fadeIn(200, function () {
                                            const e = document.querySelector(".header-search-form input"),
                                                t = e.value;
                                            (e.value = ""), e.focus(), (e.value = t);
                                        }));
                        }),
                        X(".header-search-form").on("submit", function () {
                            const e = X(this).find("input").val();
                            return e && (window.location = ktAjax.siteUrl + "s/" + e), !1;
                        }),
                        X("body").on("input", ".qty", function () {
                            let e = X(this).data("timeout") || 0;
                            clearTimeout(e),
                                (e = setTimeout(function () {
                                    X(".woocommerce-cart-form").trigger("submit");
                                }, 1e3)),
                                X(this).data("timeout", e);
                        }),
                        M(".utm-generate-button").on("click", function () {
                            const e = [];
                            if (
                                (M(".utm-generator-item .required").each(function () {
                                    M(this).val().length || e.push("لطفا " + M(this).attr("data-title") + " را وارد نمایید.");
                                }),
                                    e.length > 0)
                            )
                                alert(e.join("\n"));
                            else {
                                let e = M('.utm-generator-item input[data-field="website_url"').val();
                                const t = [];
                                e.indexOf("http://") < 0 && e.indexOf("https://") < 0 && (e = "http://" + e),
                                    (e += ("/" === e.substr(e.length - 1) ? "" : "/") + "?"),
                                    M(".utm-generator-item input:not(.website)").each(function () {
                                        M(this).val().length && t.push(M(this).attr("data-field") + "=" + M(this).val());
                                    }),
                                    (e += t.join("&")),
                                    M(".utm-link").val(e);
                            }
                            return !1;
                        }),
                        void M(".utm-copy-button").on("click", function () {
                            return M(".utm-link").val().length && (M(".utm-link").select(), document.execCommand("copy")), !1;
                        }),
                        X(".woocommerce-variation-add-to-cart .single_add_to_cart_button").length &&
                        X(".woocommerce-variation-add-to-cart .single_add_to_cart_button").on("click", function () {
                            return j(X(this), { add_to_cart: X('[name="add-to-cart"]').val(), variation_id: X('[name="variation_id"]').val() }), !1;
                        });
                    X('[href*="add-to-cart="]').length &&
                        !X("body").hasClass("page-template-cart-page") &&
                        (X('[href*="add-to-cart="]').addClass("kt-ajax-button"),
                            X(document).on("click", '[href*="add-to-cart="]', function () {
                                const e = X(this);
                                X(this).hasClass("kt-ajax-button") || X(this).addClass("kt-ajax-button");
                                const t = (function (e) {
                                    const t = {};
                                    e = decodeURIComponent(e).replace(/-/g, "_").split("?")[1].split("&");
                                    for (const a of e) {
                                        const e = a.split("=");
                                        t[e[0]] = e[1];
                                    }
                                    return t;
                                })(e.attr("href"));
                                return j(e, t), !1;
                            }));
                    X(".kt-newsletter").on("submit", function () {
                        const e = X(this),
                            t = e.parent();
                        if (!e.hasClass("is-loading"))
                            return (
                                e.addClass("is-loading"),
                                X.ajax({
                                    url: ktAjax.ajaxUrl,
                                    type: "post",
                                    data: {
                                        action: "kt_ajax_sender_subscribe",
                                        email: e.find(".kt-newsletter-email").val(),
                                        list_id: e.attr("data-id"),
                                        product_id: e.closest(".kt-ebook-modal").length ? e.closest(".kt-ebook-modal").attr("data-id") : "",
                                    },
                                    success: function (a) {
                                        (a = JSON.parse(a)),
                                            e.removeClass("is-loading"),
                                            t.find(".kt-newsletter-message").remove(),
                                            a.success && t.append(X('<span class="kt-newsletter-message success">' + a.success + "</span>")),
                                            a.error && t.append(X('<span class="kt-newsletter-message error">' + a.error + "</span>"));
                                    },
                                    error: function () {
                                        e.removeClass("is-loading"), t.find(".kt-newsletter-message").remove(), t.append(X('<span class="kt-newsletter-message error">با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.</span>'));
                                    },
                                }),
                                !1
                            );
                    }),
                        X(".kt-course-newsletter").on("submit", function () {
                            const e = X(this),
                                t = e.parent();
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    X.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: {
                                            action: "kt_ajax_course_newsletter",
                                            email: e.find(".kt-newsletter-email").val(),
                                            name: e.find(".kt-newsletter-name").val(),
                                            tell: e.find(".kt-newsletter-tell").val(),
                                            product_id: e.attr("data-id"),
                                        },
                                        success: function (a) {
                                            (a = JSON.parse(a)),
                                                e.removeClass("is-loading"),
                                                t.find(".kt-newsletter-message").remove(),
                                                a.success && (a.file && window.location.assign(a.file), t.append(X('<span class="kt-newsletter-message success">' + a.success + "</span>"))),
                                                a.error && t.append(X('<span class="kt-newsletter-message error">' + a.error.replace("\n", "<br/>") + "</span>"));
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"), t.find(".kt-newsletter-message").remove(), t.append(X('<span class="kt-newsletter-message error">با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.</span>'));
                                        },
                                    }),
                                    !1
                                );
                        }),
                        X(".button-demo.kt-ajax-button").on("click", function () {
                            const e = X(this);
                            if (!e.hasClass("is-loading"))
                                return (
                                    e.addClass("is-loading"),
                                    X.ajax({
                                        url: ktAjax.ajaxUrl,
                                        type: "post",
                                        data: { action: "kt_ajax_course_newsletter", product_id: e.attr("data-id") },
                                        success: function (e) {
                                            window.location = e;
                                        },
                                        error: function () {
                                            e.removeClass("is-loading"),
                                                X(".course-details-inner .kt-newsletter-message").remove(),
                                                X('<span class="kt-newsletter-message error">با عرض پوزش، خطایی رخ داد. لطفا مجددا تلاش کنید.</span>').insertAfter(e);
                                        },
                                    }),
                                    !1
                                );
                        }),
                        X(".kt-mobile-modal-btn").on("click", function () {
                            if (!X("body").hasClass("kt-mobile") || !X(".kt-mobile-modal").length) return;
                            const e = X(this),
                                t = e.attr("data-modal"),
                                a = X(".kt-mobile-modal-" + t);
                            if (a.length) {
                                const n = e.attr("data-title") || "توضیحات";
                                X("html").addClass("kt-modal-opened"),
                                    X(".kt-mobile-modal-title span").text(n),
                                    X(".kt-mobile-modal").addClass("active"),
                                    a.addClass("active"),
                                    (window.history && window.history.state && "object" == typeof window.history.state && "ktModal" === window.history.state.type) || history.pushState({ type: "ktModal", id: t }, null);
                            }
                        }),
                        X("#cancel-comment-reply-link").on("click", function () {
                            return !1;
                        }),
                        X('[data-modal="comment"]').on("click", function () {
                            X(".comments-list #cancel-comment-reply-link").length && document.getElementById("cancel-comment-reply-link").trigger("click");
                        }),
                        X('[data-modal="comments"]').on("click", function () {
                            X(".kt-mobile-modal-comments .comments-holder").append(X(".comments-section .comments-list"));
                        }),
                        X(".kt-mobile-modal-title").on("click", function () {
                            X(this).hasClass("clicked") || (X(this).addClass("clicked"), history.back());
                        }),
                        X(".aparat-list-item .button").on("click", function () {
                            const e = parseInt(X(this).attr("data-per-page")) || 6;
                            X(".aparat-list-item .column:not(.active)").slice(0, e).addClass("active"), X(".aparat-list-item .column:not(.active)").length || X(this).parent().remove();
                        }),
                        X(".button-copy").on("click", function () {
                            const e = X(this);
                            return (
                                s(e.attr("data-content")),
                                X(".button-copy").removeClass("active"),
                                e.addClass("active"),
                                clearTimeout(e.data("timeout") || null),
                                e.data(
                                    "timeout",
                                    setTimeout(function () {
                                        e.removeClass("active");
                                    }, 3e3)
                                ),
                                !1
                            );
                        }),
                        X(".expert-profile-gallery").length && X(".expert-profile-gallery").lightGallery({ videojs: 1, thumbnail: !1, share: !1, selector: "a" });
                })();
            }),
            Array.isArray ||
            (Array.isArray = function (e) {
                return "[object Array]" === Object.prototype.toString.call(e);
            }),
            window.addEventListener("popstate", function (e) {
                X(".kt-mobile-modal").hasClass("active")
                    ? (X(".kt-mobile-modal-comments").hasClass("active") && (X(".comments-section .comments-holder").append(X(".kt-mobile-modal-comments .comments-list")), X("html, body").scrollTop(X(".comments-section").offset().top)),
                        X("html").removeClass("kt-modal-opened"),
                        X(".kt-mobile-modal, .kt-mobile-modal-content").removeClass("active"),
                        X(".kt-mobile-modal-title").removeClass("clicked"))
                    : window.history && window.history.state && "object" == typeof window.history.state && "ktModal" === window.history.state.type && X('[data-modal="' + window.history.state.id + '"]').trigger("click");
            }),
            X(window).on("resize", function () {
                A(), J(), G(), h(), f(), m(), O(), k(), B(), C(), w(), _(), R(), U(), p();
            }),
            X(window).on("load", function () {
                m(),
                    A(),
                    X(".carousel-table-holder").length && X(".carousel-table-holder").addClass("carousel-table-loaded"),
                    U(),
                    J(),
                    H(),
                    G(),
                    X("body").ktLazyLoad(),
                    h(),
                    f(),
                    O(),
                    R(),
                    _(),
                    w(),
                    B(),
                    X(".blog-academy-box").length && X(".blog-academy-box").fadeIn(200),
                    p();
            }),
            X(window).on("scroll", function () {
                U(), G(), X("body").ktLazyLoad(), h(), O(), _(), b();
            }),
            X(window).off("scroll.ktScroll"),
            X(window).on("scroll.ktScroll", function () {
                k(), R(), (window.ktCanAutoHide = !0);
            }),
            setInterval(function () {
                window.ktCanAutoHide &&
                    (!(function () {
                        const e = u(window).scrollTop();
                        if (u(".menu-holder").hasClass("scrolled")) {
                            const t = 106,
                                a = Math.round(2.5 * t) + 100;
                            e > window.ktLastScrollTop + 20 && u(".menu-holder").hasClass("show")
                                ? u(".menu-holder")
                                    .stop(!0, !0)
                                    .addClass("hide")
                                    .removeClass("show")
                                    .css("top", "0px")
                                    .animate({ top: -t + "px" }, a, "easeOutCubic")
                                : e < window.ktLastScrollTop - 40 &&
                                !u(".menu-holder").hasClass("show") &&
                                u(".menu-holder")
                                    .stop(!0, !0)
                                    .addClass("show")
                                    .removeClass("hide")
                                    .css("top", -t + "px")
                                    .animate({ top: "0px" }, a, "easeOutCubic");
                        }
                        window.ktLastScrollTop = e;
                    })(),
                        (window.ktCanAutoHide = !1));
            }, 150),
            (X.fn.ktLazyLoad = function () {
                X(this)
                    .find(".kt-lazyload:not(.loaded):not(.loading)")
                    .each(function () {
                        if (!X(this).hasClass("loaded") && !X(this).hasClass("loading") && X(window).scrollTop() + X(window).outerHeight() + 100 > X(this).offset().top) {
                            const e = X(this);
                            if ((e.addClass("loading"), e.attr("data-src"))) {
                                const t = new Image(),
                                    a = e.attr("alt");
                                e.attr("alt", ""),
                                    (t.onload = function () {
                                        e.attr("src", t.src).attr("alt", a).addClass("loaded").removeClass("loading").removeAttr("data-src");
                                    }),
                                    (t.src = e.attr("data-src"));
                            }
                        }
                    });
            });
    })();
   
})();


