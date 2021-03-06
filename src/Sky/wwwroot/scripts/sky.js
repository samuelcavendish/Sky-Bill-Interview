﻿var toggleClass = function (element, className) {
    if (element.classList) {
        element.classList.toggle(className);
    } else {
        var classes = element.className.split(' ');
        var existingIndex = classes.indexOf(className);

        if (existingIndex >= 0)
            classes.splice(existingIndex, 1);
        else
            classes.push(className);

        element.className = classes.join(' ');
    }
}

var hasClass = function (element, className) {
    if (element.classList)
        return element.classList.contains(className);
    else
        return new RegExp('(^| )' + className + '( |$)', 'gi').test(element.className);
}

//Expand/collapse mobile menu
var toggleMenu = function () {
    toggleClass(document.querySelector('nav[role="navigation"]'), 'open');
    toggleClass(document.querySelector('body'), 'navigation-open');
}

//foreach navigation trigger add the event to toggle the mobile menu
var navigationTriggers = Array.from(document.querySelectorAll('a[data-trigger="navigation"]'));
navigationTriggers.forEach(function (item, i) {
    item.addEventListener('click', function (event) {
        event.stopPropagation();

        toggleMenu();
    });
});

//Close the menu if someone clicks off it
var menuCloseTriggers = Array.from(document.querySelectorAll('main, .header-wrapper'));
menuCloseTriggers.forEach(function (item, i) {
    item.addEventListener('click', function (event) {
        if (hasClass(document.querySelector('nav[role="navigation"]'), 'open')) {
            event.stopPropagation();

            toggleMenu();
        }
    })
});

//Foreach accordian header, bind the click event to open/close the accordian
var accordianSections = Array.from(document.querySelectorAll('section[data-trigger="accordian-expand"] > header'));
accordianSections.forEach(function (item, i) {
    item.addEventListener('click', function (event) {
        var element = event.currentTarget.parentNode;

        toggleClass(element, 'open');
    });
});
