window.activateBootstrapComponents = function () {
    var collapaseElements = document.querySelectorAll('.collapse');
    var accordionButtons = document.querySelectorAll('.accordion-button');

    collapaseElements.forEach(function (element, index) {
        var accordionButton = accordionButtons[index];
        accordionButton.addEventListener('click', function () {
            var target = accordionButton.getAttribute('data-bs-target');
            var targetElement = document.querySelector(target);
            targetElement.classList.toggle('show');
        });
    });
};