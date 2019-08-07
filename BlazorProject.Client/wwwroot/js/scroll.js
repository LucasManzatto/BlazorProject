window.ScrollDown = (element) => {
    element.scrollBy(0, 32);
}
window.ScrollUp = (element) => {
    element.scrollBy(0, -32);
}

window.scrollToElementId = (element) => {
    element.scrollIntoView();
}
