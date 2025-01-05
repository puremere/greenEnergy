// document.querySelector('.horizontal-section-scroll').addEventListener('wheel', (e) => {
// 	e.preventDefault();
// 	const scrollSpeed = 0.7;

// 	document.querySelector('.horizontal-section-scroll').scrollLeft += e.deltaY * scrollSpeed;

// 	const leftVal = document.querySelector('.horizontal-section-scroll').scrollLeft += e.deltaY / 100;
	
// 	document.querySelector('.service7-area .left img').style.transform = `translate3d(-${leftVal / 10}px, 0, 0) scale(1.4)`;
// 	document.querySelector('.service8-area .left img').style.transform = `translate3d(-${leftVal / 15}px, 0, 0) scale(1.4)`;
// 	document.querySelector('.pricing-table-area .left img').style.transform = `translate3d(-${leftVal / 25}px, 0, 0) scale(1.4)`;
// 	document.querySelector('.contact-and-footer-area .left img').style.transform = `translate3d(-${leftVal / 50}px, 0, 0) scale(1.4)`;


if (window.innerWidth > 1024) {

  const scroller = new LocomotiveScroll({
    el: document.querySelector("[data-scroll-container]"),
    smooth: true,
    direction: "horizontal"
  });
}

